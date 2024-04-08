using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DL_City
    {
        public List<City> ToList(int provinceID)
        {
            List<City> cityList = new List<City>();

            using (SqlConnection objConnection = new SqlConnection(Connection.stringConnection))
            {
                try
                {
                    objConnection.Open();

                    SqlCommand cmd = new SqlCommand("select code, province, cityName from tbl_City where province = @provinceID", objConnection);
                    cmd.Parameters.AddWithValue("@provinceID", provinceID);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cityList.Add(new City()
                            {
                                code = Convert.ToInt32(dr["code"]),
                                province = Convert.ToInt32(dr["province"]),
                                cityName = dr["cityName"].ToString()

                            });
                        }
                    }
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    cityList = new List<City>();
                }
            }
            return cityList;
        }
    }
}
