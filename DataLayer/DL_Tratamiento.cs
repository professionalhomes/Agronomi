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
    public class DL_Tratamiento
    {
        public List<Tratamiento> ToList(int usuario)
        {
            List<Tratamiento> tratamientoList = new List<Tratamiento>();

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idTerreno, actividad, costoHora, horasAsignadas, costoActividad");
                    query.AppendLine("FROM tbl_TratamientoHierbas");
                    query.AppendLine("WHERE idUsuario = @parametroIdUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objConnection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@parametroIdUsuario", usuario);

                    objConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tratamientoList.Add(new Tratamiento()
                            {
                                idTerreno = dr["idTerreno"].ToString(),
                                actividad = dr["actividad"].ToString(),
                                costoHora = dr["costoHora"].ToString(),
                                horasAsignadas = dr["horasAsignadas"].ToString().ToString(),
                                costoActividad = dr["costoActividad"].ToString()
                            });
                        }
                    }
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    tratamientoList = new List<Tratamiento>();
                }
                finally
                {
                    objConnection.Close();
                }
            }
            return tratamientoList;
        }

        public int InsertarDatosTratamiento(Tratamiento objTratamiento, out string message)
        {
            int result = 0;
            message = string.Empty;

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_Insertar_TratamientoHierbas", objConnection);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idTerreno", objTratamiento.idTerreno);
                    cmd.Parameters.AddWithValue("@costoHora", Convert.ToDecimal(objTratamiento.costoHora));
                    cmd.Parameters.AddWithValue("@horasAsignadas", Convert.ToInt32(objTratamiento.horasAsignadas));
                    cmd.Parameters.AddWithValue("@costoActividad", Convert.ToInt32(objTratamiento.costoActividad));
                    cmd.Parameters.AddWithValue("@actividad", objTratamiento.actividad);
                    cmd.Parameters.AddWithValue("@idUsuario", Convert.ToInt32(objTratamiento.idUsuario));

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