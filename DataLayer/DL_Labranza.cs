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
    public class DL_Labranza
    {
        public List<Labranza> ToList(int usuario)
        {
            List<Labranza> LabranzaList = new List<Labranza>();

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idTerreno, costoPorArado, costoPorEnmindas, costoPorTrazado,costoPorCamas, costoPorMurillo,costoPorRastra,resultadoLabranza");
                    query.AppendLine("FROM tbl_Labranza");
                    query.AppendLine("WHERE idUsuario = @parametroIdUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objConnection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@parametroIdUsuario", usuario);

                    objConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LabranzaList.Add(new Labranza()
                            {
                                idTerreno = dr["idTerreno"].ToString(),
                                costoPorArado = dr["costoPorArado"].ToString(),
                                costoPorEnmindas = dr["costoPorEnmindas"].ToString(),
                                costoPorTrazado = dr["costoPorTrazado"].ToString().ToString(),
                                costoPorCamas = dr["costoPorCamas"].ToString(),
                                costoPorMurillo = dr["costoPorMurillo"].ToString(),
                                costoPorRastra = dr["costoPorRastra"].ToString(),
                                resultadoLabranza = dr["resultadoLabranza"].ToString()
                            });
                        }
                    }
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    LabranzaList = new List<Labranza>();
                }
                finally
                {
                    objConnection.Close();
                }
            }
            return LabranzaList;
        }

        public int InsertarDatosLabranza(Labranza objLabranza, out string message)
        {
            int result = 0;
            message = string.Empty;

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Insertar_Labranza", objConnection);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idTerreno", objLabranza.idTerreno);
                    cmd.Parameters.AddWithValue("@costoPorArado", Convert.ToInt32(objLabranza.costoPorArado));
                    cmd.Parameters.AddWithValue("@costoPorEnmindas", Convert.ToInt32(objLabranza.costoPorEnmindas));
                    cmd.Parameters.AddWithValue("@costoPorTrazado", Convert.ToInt32(objLabranza.costoPorTrazado));
                    cmd.Parameters.AddWithValue("@costoPorCamas", Convert.ToInt32(objLabranza.costoPorCamas));
                    cmd.Parameters.AddWithValue("@costoPorMurillo", Convert.ToInt32(objLabranza.costoPorMurillo));
                    cmd.Parameters.AddWithValue("@costoPorRastra", Convert.ToInt32(objLabranza.costoPorRastra));
                    cmd.Parameters.AddWithValue("@resultadoLabranza", Convert.ToDouble(objLabranza.resultadoLabranza));
                    cmd.Parameters.AddWithValue("@idUsuario", Convert.ToInt32(objLabranza.IdUsuario));

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