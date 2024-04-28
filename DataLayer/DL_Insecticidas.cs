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
    public class DL_Insecticidas
    {
        public List<Insecticidas> ToList(int usuario)
        {
            List<Insecticidas> InsecticidasList = new List<Insecticidas>();

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idTerreno,producto,costoProducto,cantidadProducto,cantidadAplicada,costoPorAplicacion,ciclos,duracionCiclo,duracionTotal");
                    query.AppendLine("FROM tbl_Insecticidas");
                    query.AppendLine("WHERE idUsuario = @parametroIdUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objConnection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@parametroIdUsuario", usuario);

                    objConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            InsecticidasList.Add(new Insecticidas()
                            {
                                idTerreno = dr["idTerreno"].ToString(),
                                producto = dr["producto"].ToString(),
                                costoProducto = dr["costoProducto"].ToString(),
                                cantidadProducto = dr["cantidadProducto"].ToString(),
                                cantidadAplicada = dr["cantidadAplicada"].ToString().ToString(),
                                costoPorAplicacion = dr["costoPorAplicacion"].ToString(),
                                ciclos = dr["ciclos"].ToString(),
                                duracionCiclo = dr["duracionCiclo"].ToString(),
                                duracionTotal = dr["duracionTotal"].ToString()
                            });
                        }
                    }
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    InsecticidasList = new List<Insecticidas>();
                }
                finally
                {
                    objConnection.Close();
                }
            }
            return InsecticidasList;
        }

        public int InsertarDatosInsecticidas(Insecticidas objInsecticidas, out string message)
        {
            int result = 0;
            message = string.Empty;

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Insertar_Insecticidas", objConnection);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idTerreno", objInsecticidas.idTerreno);
                    cmd.Parameters.AddWithValue("@producto", objInsecticidas.producto);
                    cmd.Parameters.AddWithValue("@costoProducto", Convert.ToInt32(objInsecticidas.costoProducto));
                    cmd.Parameters.AddWithValue("@cantidadProducto", Convert.ToInt32(objInsecticidas.cantidadProducto));
                    cmd.Parameters.AddWithValue("@cantidadAplicada", Convert.ToInt32(objInsecticidas.cantidadAplicada));
                    cmd.Parameters.AddWithValue("@costoPorAplicacion", Convert.ToInt32(objInsecticidas.costoPorAplicacion));
                    cmd.Parameters.AddWithValue("@ciclos", Convert.ToInt32(objInsecticidas.ciclos));
                    cmd.Parameters.AddWithValue("@duracionCiclo", Convert.ToInt32(objInsecticidas.duracionCiclo));
                    cmd.Parameters.AddWithValue("@duracionTotal", Convert.ToInt32(objInsecticidas.duracionTotal));
                    cmd.Parameters.AddWithValue("@idUsuario", Convert.ToInt32(objInsecticidas.idUsuario));

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