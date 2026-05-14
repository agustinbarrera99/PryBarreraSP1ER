using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

        public bool Guardar(clsConexion conexion)
        {
            SqlConnection cn = conexion.ObtenerConexion();

            using (SqlCommand cmdCheck = new SqlCommand(
                "SELECT COUNT(*) FROM Medicos WHERE Matricula = @matricula", cn))
            {
                cmdCheck.Parameters.AddWithValue("@matricula", Matricula);
                if ((int)cmdCheck.ExecuteScalar() > 0) return false;
            }

            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Medicos (Matricula, Nombre, IdEspecialidad) VALUES (@matricula, @nombre, @idEsp)", cn))
            {
                cmd.Parameters.AddWithValue("@matricula", Matricula);
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.Parameters.AddWithValue("@idEsp", Especialidad.IdEspecialidad);
                cmd.ExecuteNonQuery();
            }

            return true;
        }

        public static List<clsMedico> ObtenerPorEspecialidad(clsConexion conexion, int idEspecialidad)
        {
            var lista = new List<clsMedico>();
            SqlConnection cn = conexion.ObtenerConexion();

            using (SqlCommand cmd = new SqlCommand(
                @"SELECT m.Matricula, m.Nombre, e.IdEspecialidad, e.Nombre
                  FROM   Medicos m
                  INNER JOIN Especialidades e ON m.IdEspecialidad = e.IdEspecialidad
                  WHERE  m.IdEspecialidad = @idEsp
                  ORDER  BY m.Nombre", cn))
            {
                cmd.Parameters.AddWithValue("@idEsp", idEspecialidad);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new clsMedico
                        {
                            Matricula = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Especialidad = new clsEspecialidad
                            {
                                IdEspecialidad = reader.GetInt32(2),
                                Nombre = reader.GetString(3)
                            }
                        });
                    }
                }
            }

            return lista;
        }
    }
}