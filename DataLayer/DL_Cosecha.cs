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
    public class DL_Cosecha
    {
        public List<Cosecha> ToList(int usuario)
        {
            List<Cosecha> CosechaList = new List<Cosecha>();

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idTerreno,costoPorCosecha,costoPorLavado,costoPorSaco,costoPorTransporteCarga,costoPorLavadoQuintal,resultadoCosecha");
                    query.AppendLine("FROM tbl_Cosecha");
                    query.AppendLine("WHERE idUsuario = @parametroIdUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objConnection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@parametroIdUsuario", usuario);

                    objConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CosechaList.Add(new Cosecha()
                            {
                                idTerreno = dr["idTerreno"].ToString(),
                                costoPorCosecha = dr["costoPorCosecha"].ToString(),
                                costoPorLavado = dr["costoPorLavado"].ToString(),
                                costoPorSaco = dr["costoPorSaco"].ToString(),
                                costoPorTransporteCarga = dr["costoPorTransporteCarga"].ToString().ToString(),
                                costoPorLavadoQuintal = dr["costoPorLavadoQuintal"].ToString(),
                                resultadoCosecha = dr["resultadoCosecha"].ToString()
                            });
                        }
                    }
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    CosechaList = new List<Cosecha>();
                }
                finally
                {
                    objConnection.Close();
                }
            }
            return CosechaList;
        }

        public int InsertarDatosCosecha(Cosecha objCosecha, out string message)
        {
            int result = 0;
            message = string.Empty;

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Insertar_Cosecha", objConnection);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idTerreno", objCosecha.idTerreno);
                    cmd.Parameters.AddWithValue("@costoPorCosecha", Convert.ToInt32(objCosecha.costoPorCosecha));
                    cmd.Parameters.AddWithValue("@costoPorLavado", Convert.ToInt32(objCosecha.costoPorLavado));
                    cmd.Parameters.AddWithValue("@costoPorSaco", Convert.ToInt32(objCosecha.costoPorSaco));
                    cmd.Parameters.AddWithValue("@costoPorTransporteCarga", Convert.ToInt32(objCosecha.costoPorTransporteCarga));
                    cmd.Parameters.AddWithValue("@costoPorLavadoQuintal", Convert.ToInt32(objCosecha.costoPorLavadoQuintal));
                    cmd.Parameters.AddWithValue("@idUsuario", Convert.ToInt32(objCosecha.idUsuario));

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