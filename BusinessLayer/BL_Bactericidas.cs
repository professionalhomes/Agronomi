using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class BL_Bactericidas
    {
        private DL_Bactericidas objDL_Bactericidas = new DL_Bactericidas();

        //This method allow to list the seleccion data
        public List<Bactericidas> ToList(int usuario)
        {
            return objDL_Bactericidas.ToList(usuario);
        }

        //This method allow to insert Bactericidas data
        public int InsertarDatosBactericidas(Bactericidas objBactericidas, out string message)
        {
            //Falta validación de datos

            return objDL_Bactericidas.InsertarDatosBactericidas(objBactericidas, out message);
        }
    }
}
