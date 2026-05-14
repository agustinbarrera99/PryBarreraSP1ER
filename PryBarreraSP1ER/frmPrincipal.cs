using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PryBarreraSP1ER
{
    public partial class frmPrincipal : Form
    {
        // ── Conexión ─────────────────────────────────────────────────────────────
        // LocalDB: no requiere instalar SQL Server completo.
        // Si usás SQL Server Express cambiá el Data Source por el nombre de tu instancia,
        // por ejemplo: Data Source=.\SQLEXPRESS
        private readonly clsConexion _conexion = new clsConexion(
           @"Data Source=.\SQLEXPRESS;Initial Catalog=GestionMedicos;Integrated Security=True;");

        private bool cargandoCombos = false;

        public frmPrincipal()
        {
            InitializeComponent();
        }


        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ActualizarComboBoxEspecialidades();
        }

        private void BtnGuardarEspecialidad_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposEspecialidad(out int idEspecialidad, out string nombre))
                return;

            try
            {
                clsEspecialidad nueva = new clsEspecialidad(idEspecialidad, nombre);

                if (!nueva.Guardar(_conexion))
                {
                    MostrarError($"Ya existe una especialidad con el número {idEspecialidad}.");
                    txtNumeroEspecialidad.Focus();
                    return;
                }

                ActualizarComboBoxEspecialidades();
                LimpiarCamposEspecialidad();
                MostrarExito("Especialidad registrada correctamente.");
            }
            catch (Exception ex)
            {
                MostrarError($"Error al guardar la especialidad: {ex.Message}");
            }
        }

        private bool ValidarCamposEspecialidad(out int idEspecialidad, out string nombre)
        {
            idEspecialidad = 0;
            nombre = string.Empty;

            if (string.IsNullOrWhiteSpace(txtNumeroEspecialidad.Text))
            {
                MostrarAdvertencia("Ingrese el número de especialidad.");
                txtNumeroEspecialidad.Focus();
                return false;
            }

            if (!int.TryParse(txtNumeroEspecialidad.Text.Trim(), out idEspecialidad) || idEspecialidad <= 0)
            {
                MostrarError("El número de especialidad debe ser un entero positivo.");
                txtNumeroEspecialidad.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombreEspecialidad.Text))
            {
                MostrarAdvertencia("Ingrese el nombre de la especialidad.");
                txtNombreEspecialidad.Focus();
                return false;
            }

            nombre = txtNombreEspecialidad.Text.Trim();
            return true;
        }

        private void LimpiarCamposEspecialidad()
        {
            txtNumeroEspecialidad.Clear();
            txtNombreEspecialidad.Clear();
            txtNumeroEspecialidad.Focus();
        }

        private void BtnGuardarMedico_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposMedico(out int matricula, out string nombre, out clsEspecialidad especialidad))
                return;

            try
            {
                clsMedico nuevo = new clsMedico(matricula, nombre, especialidad);

                if (!nuevo.Guardar(_conexion))
                {
                    MostrarError($"Ya existe un médico con la matrícula {matricula}.");
                    txtMatricula.Focus();
                    return;
                }

                LimpiarCamposMedico();
                MostrarExito("Médico registrado correctamente.");
            }
            catch (Exception ex)
            {
                MostrarError($"Error al guardar el médico: {ex.Message}");
            }
        }

        private bool ValidarCamposMedico(out int matricula, out string nombre, out clsEspecialidad especialidad)
        {
            matricula = 0;
            nombre = string.Empty;
            especialidad = null;

            if (string.IsNullOrWhiteSpace(txtMatricula.Text))
            {
                MostrarAdvertencia("Ingrese la matrícula del médico.");
                txtMatricula.Focus();
                return false;
            }

            if (!int.TryParse(txtMatricula.Text.Trim(), out matricula) || matricula <= 0)
            {
                MostrarError("La matrícula debe ser un entero positivo.");
                txtMatricula.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombreMedico.Text))
            {
                MostrarAdvertencia("Ingrese el nombre del médico.");
                txtNombreMedico.Focus();
                return false;
            }

            nombre = txtNombreMedico.Text.Trim();

            especialidad = cmbEspecialidadMedico.SelectedItem as clsEspecialidad;
            if (especialidad == null)
            {
                MostrarAdvertencia("Seleccione una especialidad.");
                cmbEspecialidadMedico.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCamposMedico()
        {
            txtMatricula.Clear();
            txtNombreMedico.Clear();
            cmbEspecialidadMedico.SelectedIndex = -1;
            txtMatricula.Focus();
        }

        private void CmbEspecialidadConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombos) return;

            dgvMedicos.Rows.Clear();

            clsEspecialidad esp = cmbEspecialidadConsulta.SelectedItem as clsEspecialidad;
            if (esp == null) return;

            try
            {
                List<clsMedico> medicos = clsMedico.ObtenerPorEspecialidad(_conexion, esp.IdEspecialidad);

                foreach (clsMedico m in medicos)
                    dgvMedicos.Rows.Add(m.Matricula, m.Nombre);

                if (medicos.Count == 0)
                    MostrarAdvertencia("No hay médicos registrados para la especialidad seleccionada.");
            }
            catch (Exception ex)
            {
                MostrarError($"Error al consultar médicos: {ex.Message}");
            }
        }

        private void ActualizarComboBoxEspecialidades()
        {
            try
            {
                List<clsEspecialidad> lista = clsEspecialidad.ObtenerTodas(_conexion);
                ActualizarCombo(cmbEspecialidadMedico, lista);
                ActualizarCombo(cmbEspecialidadConsulta, lista);
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar especialidades: {ex.Message}");
            }
        }

        private void ActualizarCombo(ComboBox combo, List<clsEspecialidad> lista)
        {
            cargandoCombos = true;
            combo.DataSource = null;
            combo.DataSource = new List<clsEspecialidad>(lista);
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdEspecialidad";
            combo.SelectedIndex = -1;
            cargandoCombos = false;
        }


        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            _conexion?.Dispose();
        }
        private void MostrarError(string mensaje) =>
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void MostrarAdvertencia(string mensaje) =>
            MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void MostrarExito(string mensaje) =>
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}