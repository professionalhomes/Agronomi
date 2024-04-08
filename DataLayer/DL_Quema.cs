using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataLayer
{
    public class DL_Quema
    {
        public List<Quema> ToList(int usuario)
        {
            List<Quema> QuemaList = new List<Quema>();

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idTerreno,producto,costoProducto,cantidadProducto,cantidadAplicada,costoPorAplicacion,resultadoQuema");
                    query.AppendLine("FROM tbl_Quema");
                    query.AppendLine("WHERE idUsuario = @parametroIdUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objConnection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@parametroIdUsuario", usuario);

                    objConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            QuemaList.Add(new Quema()
                            {
                                idTerreno = dr["idTerreno"].ToString(),
                                producto = dr["producto"].ToString(),
                                costoProducto = dr["costoProducto"].ToString(),
                                cantidadProducto = dr["cantidadProducto"].ToString(),
                                cantidadAplicada = dr["cantidadAplicada"].ToString().ToString(),
                                costoPorAplicacion = dr["costoPorAplicacion"].ToString(),
                                resultadoQuema = dr["resultadoQuema"].ToString()
                            });
                        }
                    }
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    QuemaList = new List<Quema>();
                }
                finally
                {
                    objConnection.Close();
                }
            }
            return QuemaList;
        }
        public int InsertarDatosQuema(Quema objQuema, out string message)
        {
            int result = 0;
            message = string.Empty;

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Insertar_Quema", objConnection);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idTerreno", objQuema.idTerreno);
                    cmd.Parameters.AddWithValue("@producto", objQuema.producto);
                    cmd.Parameters.AddWithValue("@costoProducto", Convert.ToInt32(objQuema.costoProducto));
                    cmd.Parameters.AddWithValue("@cantidadProducto", Convert.ToInt32(objQuema.cantidadProducto));
                    cmd.Parameters.AddWithValue("@cantidadAplicada", Convert.ToInt32(objQuema.cantidadAplicada));
                    cmd.Parameters.AddWithValue("@costoPorAplicacion", Convert.ToInt32(objQuema.costoPorAplicacion));
                    cmd.Parameters.AddWithValue("@idUsuario", Convert.ToInt32(objQuema.idUsuario));

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
