using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataLayer
{
    public class DL_Seleccion
    {
        public List<Seleccion> ToList(int usuario)
        {
            List<Seleccion> seleccionList = new List<Seleccion>();

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idTerreno, tamanioTerreno, areaCultivo, analisisTerreno, costoOportunidad, analisisPatologico, ubicacionTerrno, resultadoSeleccionTerreno");
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
                            seleccionList.Add(new Seleccion()
                            {
                                idTerreno = dr["idTerreno"].ToString(),
                                tamanioTerreno = Convert.ToDecimal(dr["tamanioTerreno"]),
                                areaCultivo = Convert.ToDecimal(dr["areaCultivo"]),
                                analisisTerreno = dr["analisisTerreno"].ToString(),
                                costoOportunidad = Convert.ToInt32(dr["costoOportunidad"]),
                                analisisPatologico = dr["analisisPatologico"].ToString(),
                                ubicacionTerrno = dr["ubicacionTerrno"].ToString(),
                                resultadoSeleccionTerreno = Convert.ToDecimal(dr["resultadoSeleccionTerreno"])

                            });
                        }
                    }
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    seleccionList = new List<Seleccion>();
                }
                finally
                {
                    objConnection.Close();
                }
            }
            return seleccionList;
        }

        public int InsertSeleccionData(Seleccion objSeleccion, out string message)
        {
            int result = 0;
            message = string.Empty;

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Insertar_SeleccionInfo", objConnection);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idTerreno", objSeleccion.idTerreno);
                    cmd.Parameters.AddWithValue("@tamanioTerreno", objSeleccion.tamanioTerreno);
                    cmd.Parameters.AddWithValue("@areaCultivo", objSeleccion.areaCultivo);
                    cmd.Parameters.AddWithValue("@analisisTerreno", objSeleccion.analisisTerreno);
                    cmd.Parameters.AddWithValue("@costoOportunidad", objSeleccion.costoOportunidad);
                    cmd.Parameters.AddWithValue("@analisisPatologico", objSeleccion.analisisPatologico);
                    cmd.Parameters.AddWithValue("@ubicacionTerrno", objSeleccion.ubicacionTerrno);
                    cmd.Parameters.AddWithValue("@idUsuario", objSeleccion.idUsuario);

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