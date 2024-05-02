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
    public class DL_Terreno
    {
        public List<Terreno> ListarTerrenos(int usuario)
        {
            List<Terreno> listaTerrenos = new List<Terreno>();

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idTerreno");
                    query.AppendLine("FROM tbl_SeleccionTerreno");
                    query.AppendLine("WHERE idUsuario = @parametroIdUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objConnection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@parametroIdUsuario", usuario);

                    objConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaTerrenos.Add(new Terreno()
                            {
                                idTerreno = dr["idTerreno"].ToString()
                            });
                        }
                    }
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    listaTerrenos = new List<Terreno>();
                }
            }
            return listaTerrenos;
        }
    }
}
