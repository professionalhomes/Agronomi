using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BL_Aporca
    {
        private DL_Aporca objDL_Aporca = new DL_Aporca();

        //This method allow to list the seleccion data
        public List<Aporca> ToList(int usuario)
        {
            return objDL_Aporca.ToList(usuario);
        }

        //This method allow to insert Aporca data
        public int InsertarDatosAporca(Aporca objAporca, out string message)
        {
            //Falta validación de datos

            return objDL_Aporca.InsertarDatosAporca(objAporca, out message);
        }
    }
}
