using System;

namespace PryBarreraSP1ER
{
    public class clsEspecialidad
    {
        public int IdEspecialidad { get; set; }
        public string Nombre { get; set; }

        public clsEspecialidad() { }

        public clsEspecialidad(int idEspecialidad, string nombre)
        {
            if (idEspecialidad <= 0)
                throw new ArgumentException("El número de especialidad debe ser un valor positivo.", nameof(idEspecialidad));
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la especialidad no puede estar vacío.", nameof(nombre));

            IdEspecialidad = idEspecialidad;
            Nombre = nombre.Trim();
        }

        public override string ToString() => Nombre;
    }
}