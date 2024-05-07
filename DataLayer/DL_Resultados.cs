using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Misc;

namespace DataLayer
{
    public class DL_Resultados
    {
        public int costoMantenimiento { get; private set; }
        public int costoLabranza { get; private set; }
        public int costoSiembra { get; private set; }
        public int costoTratamiento { get; private set; }
        public int costoCosecha { get; private set; }
        public int areaCultivo { get; private set; }

        private void ConsultarCostoMantenimiento(int idUsuario, string idTerreno)
        {
            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                SqlCommand command = new SqlCommand("SumarCostosPorIdTerreno", objConnection);
                command.CommandType = CommandType.StoredProcedure;

                // Agrega parámetros al comando
                command.Parameters.AddWithValue("@idTerreno", idTerreno);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                try
                {
                    objConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Asegúrate de que el nombre de la columna devuelta coincida con el nombre correcto
                            // y de que el tipo de datos sea el adecuado
                            // Aquí asumo que el nombre de la columna devuelta es "totalCosto" y es un entero
                            costoMantenimiento = reader.GetInt32(reader.GetOrdinal("totalCosto"));
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de errores: Puedes registrar la excepción o asignar un valor predeterminado
                    costoMantenimiento = 0;
                }
            }
        }


        public void ConsultarCostosLTS(int idUsuario, string idTerreno)
        {

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                SqlCommand command = new SqlCommand("ObtenerCostosTratamientoSiembraLabranza", objConnection);
                command.CommandType = CommandType.StoredProcedure;

                // Agrega parámetros al comando
                command.Parameters.AddWithValue("@idTerreno", idTerreno);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                try
                {
                    objConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            costoTratamiento = reader.GetInt32(reader.GetOrdinal("costoActividad"));
                            costoLabranza = reader.GetInt32(reader.GetOrdinal("resultadoLabranza"));
                            costoSiembra = reader.GetInt32(reader.GetOrdinal("resultadoSiembra"));
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    costoTratamiento = 0;
                    costoLabranza = 0;
                    costoSiembra = 0;
                }
            }
        }

        private void ConsultarCostoCosecha(int idUsuario, string idTerreno)
        {
            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                SqlCommand command = new SqlCommand("ConsultarCostoCosecha", objConnection);
                command.CommandType = CommandType.StoredProcedure;

                // Agrega parámetros al comando
                command.Parameters.AddWithValue("@idTerreno", idTerreno);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                try
                {
                    objConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            decimal costoDecimal = reader.GetDecimal(reader.GetOrdinal("costoCosecha"));
                            // Convierte el valor decimal a int
                            costoCosecha = Convert.ToInt32(costoDecimal);
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    costoCosecha = 0;
                    // Manejo de errores: Puedes registrar la excepción o asignar un valor predeterminado
                }
            }
        }


        private void ConsultarAreaCultivo(int idUsuario, string idTerreno)
        {
            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                SqlCommand command = new SqlCommand("ConsultarAreaCultivo", objConnection);
                command.CommandType = CommandType.StoredProcedure;

                // Agrega parámetros al comando
                command.Parameters.AddWithValue("@idTerreno", idTerreno);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                try
                {
                    objConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            areaCultivo = reader.GetInt32(reader.GetOrdinal("areaCultivo"));
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    areaCultivo = 0;
                }
            }
        }

        public void GetCostos(int usuario, string idTerreno)
        {
            ConsultarCostoMantenimiento(usuario, idTerreno);
            ConsultarCostosLTS(usuario, idTerreno);
            ConsultarCostoCosecha(usuario, idTerreno);
            ConsultarAreaCultivo(usuario, idTerreno);
        }
    }
}