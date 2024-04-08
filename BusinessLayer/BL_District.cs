using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BL_District
    {
        private DL_District objDL_District = new DL_District();

        //This method list projects in the city data layer to make interactions with the client 
        //using presentationLayer
        public List<District> ToList(int cityID)
        {
            return objDL_District.ToList(cityID);
        }
    }
}
