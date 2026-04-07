using System;

namespace PryBarreraSP1ER
{
    public class ClaseEspecialidad
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }

        public ClaseEspecialidad()
        {
        }

        public ClaseEspecialidad(int numero, string nombre)
        {
            if (numero <= 0) throw new ArgumentException("El número de especialidad debe ser un valor positivo.", nameof(numero));
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre de la especialidad no puede estar vacío.", nameof(nombre));

            Numero = numero;
            Nombre = nombre.Trim();
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
