using DataLayer;
using EntityLayer;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BL_Tratamiento
    {
        private DL_Tratamiento objDL_Tratamiento = new DL_Tratamiento();

        //This method allow to list the seleccion data
        public List<Tratamiento> ToList(int usuario)
        {
            return objDL_Tratamiento.ToList(usuario);
        }

        //This method allow to insert Tratamiento data
        public int InsertarDatosTratamiento(Tratamiento objTratamiento, out string message)
        {
            //Falta validación de datos

            objTratamiento.costoActividad = CalcularCostoTratamiento(objTratamiento).ToString();

            return objDL_Tratamiento.InsertarDatosTratamiento(objTratamiento, out message);
        }

        //A method to calculate the cost of Tratamiento
        private double CalcularCostoTratamiento(Tratamiento objTratamiento)
        {
            int costo = 0;

            costo = int.Parse(objTratamiento.costoHora) * int.Parse(objTratamiento.horasAsignadas);

            return costo;
        }
    }
}
