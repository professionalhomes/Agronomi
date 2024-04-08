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
                    query.AppendLine("SELECT idTerreno,producto,costoProducto,cantidadProducto,cantidadAplicada,costoPorAplicacion,resultadoCombateMalezas");
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
                                costoPorAplicacion = dr["costoPorAplicacion"].ToString(),
                                resultadoCombateMalezas = dr["resultadoCombateMalezas"].ToString()
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
    }
}
