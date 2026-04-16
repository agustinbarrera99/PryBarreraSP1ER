using System;

namespace PryBarreraSP1ER
{
    public class ClaseEspecialidad
    {
        public int IdEspecialidad { get; set; }
        public string Nombre { get; set; }

        public ClaseEspecialidad()
        {
        }

        public ClaseEspecialidad(int idEspecialidad, string nombre)
        {
            if (idEspecialidad <= 0) throw new ArgumentException("El número de especialidad debe ser un valor positivo.", nameof(numero));
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre de la especialidad no puede estar vacío.", nameof(nombre));

            IdEspecialidad = idEspecialidad;
            Nombre = nombre.Trim();
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
