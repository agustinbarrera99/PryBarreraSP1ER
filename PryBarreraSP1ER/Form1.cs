using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PryBarreraSP1ER
{
    public partial class Form1 : Form
    {
        private List<ClaseEspecialidad> especialidades = new List<ClaseEspecialidad>();
        private List<ClaseMedico> medicos = new List<ClaseMedico>();

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnGuardarEspecialidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNumeroEspecialidad.Text) || string.IsNullOrWhiteSpace(txtNombreEspecialidad.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtNumeroEspecialidad.Text, out int numeroEspecialidad))
                {
                    MessageBox.Show("El número de especialidad debe ser un valor numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (especialidades.Any(esp => esp.Numero == numeroEspecialidad))
                {
                    MessageBox.Show("El número de especialidad ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var nueva = new ClaseEspecialidad { Numero = numeroEspecialidad, Nombre = txtNombreEspecialidad.Text.Trim() };
                especialidades.Add(nueva);

                ActualizarComboBoxEspecialidades();
                LimpiarCamposEspecialidad();
                MessageBox.Show("Especialidad registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar especialidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardarMedico_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMatricula.Text) || string.IsNullOrWhiteSpace(txtNombreMedico.Text) || cmbEspecialidadMedico.SelectedIndex < 0)
                {
                    MessageBox.Show("Por favor complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtMatricula.Text, out int matricula))
                {
                    MessageBox.Show("La matrícula debe ser un valor numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (medicos.Any(m => m.Matricula == matricula))
                {
                    MessageBox.Show("La matrícula de médico ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var especialidadSeleccionada = cmbEspecialidadMedico.SelectedItem as ClaseEspecialidad;
                if (especialidadSeleccionada == null)
                {
                    MessageBox.Show("Seleccione una especialidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var nuevo = new ClaseMedico
                {
                    Matricula = matricula,
                    Nombre = txtNombreMedico.Text.Trim(),
                    Especialidad = especialidadSeleccionada
                };

                medicos.Add(nuevo);
                LimpiarCamposMedico();
                MessageBox.Show("Médico registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar médico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbEspecialidadConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgvMedicos.Rows.Clear();

                if (cmbEspecialidadConsulta.SelectedIndex < 0)
                    return;

                var especialidadSeleccionada = cmbEspecialidadConsulta.SelectedItem as ClaseEspecialidad;
                if (especialidadSeleccionada == null)
                    return;

                var medicosPorEspecialidad = medicos
                    .Where(m => m.Especialidad != null && m.Especialidad.Numero == especialidadSeleccionada.Numero)
                    .ToList();

                foreach (var medico in medicosPorEspecialidad)
                {
                    dgvMedicos.Rows.Add(medico.Matricula, medico.Nombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar médicos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarComboBoxEspecialidades()
        {
            // Medico
            cmbEspecialidadMedico.DataSource = null;
            cmbEspecialidadMedico.DataSource = especialidades;
            cmbEspecialidadMedico.DisplayMember = "Nombre";
            cmbEspecialidadMedico.ValueMember = "Numero";
            cmbEspecialidadMedico.SelectedIndex = -1;

            // Consulta
            cmbEspecialidadConsulta.DataSource = null;
            cmbEspecialidadConsulta.DataSource = especialidades;
            cmbEspecialidadConsulta.DisplayMember = "Nombre";
            cmbEspecialidadConsulta.ValueMember = "Numero";
            cmbEspecialidadConsulta.SelectedIndex = -1;
        }

        private void LimpiarCamposEspecialidad()
        {
            txtNumeroEspecialidad.Clear();
            txtNombreEspecialidad.Clear();
            txtNumeroEspecialidad.Focus();
        }

        private void LimpiarCamposMedico()
        {
            txtMatricula.Clear();
            txtNombreMedico.Clear();
            cmbEspecialidadMedico.SelectedIndex = -1;
            txtMatricula.Focus();
        }
    }
}
