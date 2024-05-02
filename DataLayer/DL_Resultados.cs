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
    public class DL_Resultados
    {
        
        //public List<Resultados> ToList(int usuario)
        //{
        //    List<Resultados> ResultadosList = new List<Resultados>();

        //    using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
        //    {
        //        try
        //        {
        //            StringBuilder query = new StringBuilder();
        //            query.AppendLine("SELECT idTerreno,NombreProducto,costoProducto,cantidadProducto,cantidadAplicada,costoPorAplicacion,ciclos,duracionCiclo,duracionTotal");
        //            query.AppendLine("FROM tbl_Bactericidas");
        //            query.AppendLine("WHERE idUsuario = @parametroIdUsuario");

        //            SqlCommand cmd = new SqlCommand(query.ToString(), objConnection);
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.AddWithValue("@parametroIdUsuario", usuario);

        //            objConnection.Open();

        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    ResultadosList.Add(new Resultados()
        //                    {
        //                        idTerreno = dr["idTerreno"].ToString(),
        //                        NombreProducto = dr["NombreProducto"].ToString(),
        //                        costoProducto = dr["costoProducto"].ToString(),
        //                        cantidadProducto = dr["cantidadProducto"].ToString(),
        //                        cantidadAplicada = dr["cantidadAplicada"].ToString().ToString(),
        //                        costoPorAplicacion = dr["costoPorAplicacion"].ToString(),
        //                        ciclos = dr["ciclos"].ToString(),
        //                        duracionCiclo = dr["duracionCiclo"].ToString(),
        //                        duracionTotal = dr["duracionTotal"].ToString()
        //                    });
        //                }
        //            }
        //            objConnection.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            ResultadosList = new List<Resultados>();
        //        }
        //        finally
        //        {
        //            objConnection.Close();
        //        }
        //    }
        //    return ResultadosList;
        //}
    }
}
