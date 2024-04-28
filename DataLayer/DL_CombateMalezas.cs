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
    public class DL_CombateMalezas
    {
        public List<CombateMalezas> ToList(int usuario)
        {
            List<CombateMalezas> CombateMalezasList = new List<CombateMalezas>();

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idTerreno,producto,costoProducto,cantidadProducto,cantidadAplicada,costoPorAplicacion");
                    query.AppendLine("FROM tbl_CombateMalezas");
                    query.AppendLine("WHERE idUsuario = @parametroIdUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objConnection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@parametroIdUsuario", usuario);

                    objConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CombateMalezasList.Add(new CombateMalezas()
                            {
                                idTerreno = dr["idTerreno"].ToString(),
                                producto = dr["producto"].ToString(),
                                costoProducto = dr["costoProducto"].ToString(),
                                cantidadProducto = dr["cantidadProducto"].ToString(),
                                cantidadAplicada = dr["cantidadAplicada"].ToString().ToString(),
                                costoPorAplicacion = dr["costoPorAplicacion"].ToString()
                            });
                        }
                    }
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    CombateMalezasList = new List<CombateMalezas>();
                }
                finally
                {
                    objConnection.Close();
                }
            }
            return CombateMalezasList;
        }

        public int InsertarDatosCombateMalezas(CombateMalezas objCombateMalezas, out string message)
        {
            int result = 0;
            message = string.Empty;

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Insertar_CombateMalezas", objConnection);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idTerreno", objCombateMalezas.idTerreno);
                    cmd.Parameters.AddWithValue("@producto", objCombateMalezas.producto);
                    cmd.Parameters.AddWithValue("@costoProducto", Convert.ToInt32(objCombateMalezas.costoProducto));
                    cmd.Parameters.AddWithValue("@cantidadProducto", Convert.ToInt32(objCombateMalezas.cantidadProducto));
                    cmd.Parameters.AddWithValue("@cantidadAplicada", Convert.ToInt32(objCombateMalezas.cantidadAplicada));
                    cmd.Parameters.AddWithValue("@costoPorAplicacion", Convert.ToInt32(objCombateMalezas.costoPorAplicacion));
                    cmd.Parameters.AddWithValue("@idUsuario", Convert.ToInt32(objCombateMalezas.idUsuario));

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
