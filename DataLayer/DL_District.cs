using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DL_District
    {
        public List<District> ToList(int cityID)
        {
            List<District> districtList = new List<District>();

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    objConnection.Open();

                    SqlCommand cmd = new SqlCommand("select code, city, districtName from tbl_Districts where city = @cityID", objConnection);
                    cmd.Parameters.AddWithValue("@cityID", cityID);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            districtList.Add(new District()
                            {
                                code = Convert.ToInt32(dr["code"]),
                                city = Convert.ToInt32(dr["city"]),
                                districtName = dr["districtName"].ToString()

                            });
                        }
                    }
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    districtList = new List<District>();
                }
            }
            return districtList;
        }
    }
}
