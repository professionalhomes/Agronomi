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
    public class DL_Estimulador
    {
        public List<Estimulador> ToList(int usuario)
        {
            List<Estimulador> EstimuladorList = new List<Estimulador>();

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idTerreno,producto,costoProducto,cantidadProducto,cantidadAplicada,costoPorAplicacion,resultadoEstimuladorCrecimiento");
                    query.AppendLine("FROM tbl_EstimuladorCrecimiento");
                    query.AppendLine("WHERE idUsuario = @parametroIdUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objConnection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@parametroIdUsuario", usuario);

                    objConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EstimuladorList.Add(new Estimulador()
                            {
                                idTerreno = dr["idTerreno"].ToString(),
                                producto = dr["producto"].ToString(),
                                costoProducto = dr["costoProducto"].ToString(),
                                cantidadProducto = dr["cantidadProducto"].ToString(),
                                cantidadAplicada = dr["cantidadAplicada"].ToString().ToString(),
                                costoPorAplicacion = dr["costoPorAplicacion"].ToString(),
                                resultadoEstimuladorCrecimiento = dr["resultadoEstimuladorCrecimiento"].ToString()
                            });
                        }
                    }
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    EstimuladorList = new List<Estimulador>();
                }
                finally
                {
                    objConnection.Close();
                }
            }
            return EstimuladorList;
        } 
    }
}
