using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PryBarreraSP1ER
{
    public partial class frmPrincipal : Form
    {
        private List<clsEspecialidad> especialidades = new List<clsEspecialidad>();
        private List<clsMedico> medicos = new List<clsMedico>();
        private bool cargandoCombos = false;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void BtnGuardarEspecialidad_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposEspecialidad(out int idEspecialidad, out string nombre))
                return;

            if (especialidades.Any(esp => esp.IdEspecialidad == idEspecialidad))
            {
                MostrarError($"Ya existe una especialidad con el número {idEspecialidad}.");
                txtNumeroEspecialidad.Focus();
                return;
            }

            try
            {
                clsEspecialidad nuevaEspecialidad = new clsEspecialidad(idEspecialidad, nombre);
                especialidades.Add(nuevaEspecialidad);
                ActualizarComboBoxEspecialidades();
                LimpiarCamposEspecialidad();
                MostrarExito("Especialidad registrada correctamente.");
            }
            catch (ArgumentException ex)
            {
                MostrarError(ex.Message);
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

            if (medicos.Any(m => m.Matricula == matricula))
            {
                MostrarError($"Ya existe un médico con la matrícula {matricula}.");
                txtMatricula.Focus();
                return;
            }

            try
            {
                clsMedico nuevoMedico = new clsMedico(matricula, nombre, especialidad);
                medicos.Add(nuevoMedico);
                LimpiarCamposMedico();
                MostrarExito("Médico registrado correctamente.");
            }
            catch (ArgumentException ex)
            {
                MostrarError(ex.Message);
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

            clsEspecialidad especialidadSeleccionada = cmbEspecialidadConsulta.SelectedItem as clsEspecialidad;
            if (especialidadSeleccionada == null)
                return;

            List<clsMedico> medicosFiltrados = medicos
                .Where(m => m.Especialidad != null && m.Especialidad.IdEspecialidad == especialidadSeleccionada.IdEspecialidad)
                .OrderBy(m => m.Nombre)
                .ToList();

            foreach (clsMedico medico in medicosFiltrados)
                dgvMedicos.Rows.Add(medico.Matricula, medico.Nombre);

            if (medicosFiltrados.Count == 0)
                MostrarAdvertencia("No hay médicos registrados para la especialidad seleccionada.");
        }

        private void ActualizarComboBoxEspecialidades()
        {
            ActualizarCombo(cmbEspecialidadMedico);
            ActualizarCombo(cmbEspecialidadConsulta);
        }

        private void ActualizarCombo(ComboBox combo)
        {
            cargandoCombos = true;
            combo.DataSource = null;
            combo.DataSource = new List<clsEspecialidad>(especialidades);
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdEspecialidad";
            combo.SelectedIndex = -1;
            cargandoCombos = false;
        }

        private void MostrarError(string mensaje) =>
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void MostrarAdvertencia(string mensaje) =>
            MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void MostrarExito(string mensaje) =>
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}