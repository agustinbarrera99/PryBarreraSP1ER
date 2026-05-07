using System;

namespace PryBarreraSP1ER
{
    public class clsMedico
    {
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public clsEspecialidad Especialidad { get; set; }

        public clsMedico() { }

        public clsMedico(int matricula, string nombre, clsEspecialidad especialidad)
        {
            if (matricula <= 0)
                throw new ArgumentException("La matrícula debe ser un valor positivo.", nameof(matricula));
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del médico no puede estar vacío.", nameof(nombre));
            if (especialidad == null)
                throw new ArgumentNullException(nameof(especialidad), "Debe asignar una especialidad al médico.");

            Matricula = matricula;
            Nombre = nombre.Trim();
            Especialidad = especialidad;
        }
    }
}