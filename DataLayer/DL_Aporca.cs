using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DL_Aporca
    {
        public List<Aporca> ToList(int usuario)
        {
            List<Aporca> AporcaList = new List<Aporca>();

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idTerreno, costoTotalAnimal, costoPorAporcamiento, costoPorFertilizacion,resultadoAporca");
                    query.AppendLine("FROM tbl_Aporca");
                    query.AppendLine("WHERE idUsuario = @parametroIdUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objConnection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@parametroIdUsuario", usuario);

                    objConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            AporcaList.Add(new Aporca()
                            {
                                idTerreno = dr["idTerreno"].ToString(),
                                costoTotalAnimal = dr["costoTotalAnimal"].ToString(),
                                costoPorAporcamiento = dr["costoPorAporcamiento"].ToString(),
                                costoPorFertilizacion = dr["costoPorFertilizacion"].ToString().ToString(),
                                resultadoAporca = dr["resultadoAporca"].ToString()
                            });
                        }
                    }
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    AporcaList = new List<Aporca>();
                }
                finally
                {
                    objConnection.Close();
                }
            }
            return AporcaList;
        }

        public int InsertarDatosAporca(Aporca objAporca, out string message)
        {
            int result = 0;
            message = string.Empty;

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Insertar_Aporca", objConnection);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idTerreno", objAporca.idTerreno);
                    cmd.Parameters.AddWithValue("@costoTotalAnimal", Convert.ToInt32(objAporca.costoTotalAnimal));
                    cmd.Parameters.AddWithValue("@costoPorAporcamiento", Convert.ToInt32(objAporca.costoPorAporcamiento));
                    cmd.Parameters.AddWithValue("@costoPorFertilizacion", Convert.ToInt32(objAporca.costoPorFertilizacion));
                    cmd.Parameters.AddWithValue("@idUsuario", Convert.ToInt32(objAporca.IdUsuario));

                    cmd.Parameters.Add("result", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    objConnection.Open();

                    cmd.ExecuteNonQuery();

                    result = Convert.ToInt32(cmd.Parameters["result"].Value);
                    message = cmd.Parameters["message"].Value.ToString();

                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    result = 0;
                }
                finally
                {
                    objConnection.Close();
                }
            }
            return result;
        }
    }
}
