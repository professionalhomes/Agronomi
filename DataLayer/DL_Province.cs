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
    public class DL_Province
    {
        public List<Province> ToList()
        {
            List<Province> provinceList = new List<Province>();

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select idProvince, provinceName from tbl_Province");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objConnection);
                    cmd.CommandType = CommandType.Text;

                    objConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            provinceList.Add(new Province()
                            {
                                idProvince = Convert.ToInt32(dr["idProvince"]),
                                provinceName = dr["provinceName"].ToString()

                            });
                        }
                    }
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    provinceList = new List<Province>();
                }
            }
            return provinceList;
        }
    }
}
