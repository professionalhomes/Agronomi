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
    public class DL_Siembra
    {
        public List<Siembra> ToList(int usuario)
        {
            List<Siembra> SiembraList = new List<Siembra>();

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idTerreno, costoPorSucroAnimal, costoPorRegadoPapa, costoPorTapadoPap,costoPorFertilizacion,resultadoSiembra");
                    query.AppendLine("FROM tbl_Siembra");
                    query.AppendLine("WHERE idUsuario = @parametroIdUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objConnection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@parametroIdUsuario", usuario);

                    objConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            SiembraList.Add(new Siembra()
                            {
                                idTerreno = dr["idTerreno"].ToString(),
                                costoPorSucroAnimal = dr["costoPorSucroAnimal"].ToString(),
                                costoPorRegadoPapa = dr["costoPorRegadoPapa"].ToString(),
                                costoPorTapadoPap = dr["costoPorTapadoPap"].ToString().ToString(),
                                costoPorFertilizacion = dr["costoPorFertilizacion"].ToString().ToString(),
                                resultadoSiembra = dr["resultadoSiembra"].ToString()
                            });
                        }
                    }
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    SiembraList = new List<Siembra>();
                }
                finally
                {
                    objConnection.Close();
                }
            }
            return SiembraList;
        }

        public int InsertarDatosSiembra(Siembra objSiembra, out string message)
        {
            int result = 0;
            message = string.Empty;

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Insertar_Siembra", objConnection);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idTerreno", objSiembra.idTerreno);
                    cmd.Parameters.AddWithValue("@costoPorSucroAnimal", Convert.ToInt32(objSiembra.costoPorSucroAnimal));
                    cmd.Parameters.AddWithValue("@costoPorRegadoPapa", Convert.ToInt32(objSiembra.costoPorRegadoPapa));
                    cmd.Parameters.AddWithValue("@costoPorTapadoPap", Convert.ToInt32(objSiembra.costoPorTapadoPap));
                    cmd.Parameters.AddWithValue("@costoPorFertilizacion", Convert.ToInt32(objSiembra.costoPorFertilizacion));
                    cmd.Parameters.AddWithValue("@idUsuario", Convert.ToInt32(objSiembra.idUsuario));

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