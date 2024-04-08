using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BL_City
    {
        private DL_City objDL_City = new DL_City();

        //This method list projects in the city data layer to make interactions with the client 
        //using presentationLayer
        public List<City> ToList(int provinceID)
        {
            return objDL_City.ToList(provinceID);
        }
    }
}
