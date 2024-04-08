using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BL_Province
    {
        private DL_Province objDL_Province = new DL_Province();

        //This method list projects in the province data layer to make interactions with the client 
        //using presentationLayer
        public List<Province> ToList()
        {
            return objDL_Province.ToList();
        }
    }
}
