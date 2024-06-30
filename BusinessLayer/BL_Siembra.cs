using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BL_Siembra
    {
        private DL_Siembra objDL_Siembra = new DL_Siembra();

        //This method allow to list the seleccion data
        public List<Siembra> ToList(int usuario)
        {
            return objDL_Siembra.ToList(usuario);
        }

        //This method allow to insert Siembra data
        public int InsertarDatosSiembra(Siembra objSiembra, out string message)
        {
            //Falta validación de datos

            objSiembra.resultadoSiembra = CalcularCostoSiembra(objSiembra).ToString();

            return objDL_Siembra.InsertarDatosSiembra(objSiembra, out message);
        }

        //A method to calculate the cost of Siembra
        private double CalcularCostoSiembra(Siembra objSiembra)
        {
            double costoPorSucroAnimal = Convert.ToDouble(objSiembra.costoPorSucroAnimal);
            double costoPorRegadoPapa = Convert.ToDouble(objSiembra.costoPorRegadoPapa);
            double costoPorFertilizacion = Convert.ToDouble(objSiembra.costoPorFertilizacion);
            double costoSemilla = Convert.ToDouble(objSiembra.costoSemilla);

            return costoPorFertilizacion + costoPorRegadoPapa + costoPorSucroAnimal + costoSemilla;
        }
    }
}
