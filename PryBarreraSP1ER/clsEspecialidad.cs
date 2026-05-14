using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

        public bool Guardar(clsConexion conexion)
        {
            SqlConnection cn = conexion.ObtenerConexion();

            using (SqlCommand cmdCheck = new SqlCommand(
                "SELECT COUNT(*) FROM Especialidades WHERE IdEspecialidad = @id", cn))
            {
                cmdCheck.Parameters.AddWithValue("@id", IdEspecialidad);
                if ((int)cmdCheck.ExecuteScalar() > 0) return false;
            }

            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Especialidades (IdEspecialidad, Nombre) VALUES (@id, @nombre)", cn))
            {
                cmd.Parameters.AddWithValue("@id", IdEspecialidad);
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.ExecuteNonQuery();
            }

            return true;
        }

        public static List<clsEspecialidad> ObtenerTodas(clsConexion conexion)
        {
            var lista = new List<clsEspecialidad>();
            SqlConnection cn = conexion.ObtenerConexion();

            using (SqlCommand cmd = new SqlCommand(
                "SELECT IdEspecialidad, Nombre FROM Especialidades ORDER BY Nombre", cn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new clsEspecialidad
                    {
                        IdEspecialidad = reader.GetInt32(0),
                        Nombre = reader.GetString(1)
                    });
                }
            }

            return lista;
        }
    }
}