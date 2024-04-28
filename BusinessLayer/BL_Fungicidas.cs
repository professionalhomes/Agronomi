using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BL_Fungicidas
    {
        private DL_Fungicidas objDL_Fungicidas = new DL_Fungicidas();

        //This method allow to list the seleccion data
        public List<Fungicidas> ToList(int usuario)
        {
            return objDL_Fungicidas.ToList(usuario);
        }

        //This method allow to insert Fungicidas data
        public int InsertarDatosFungicidas(Fungicidas objFungicidas, out string message)
        {
            //Falta validación de datos

            objFungicidas.costoPorAplicacion = CalcularCostoFungicidas(objFungicidas).ToString();

            return objDL_Fungicidas.InsertarDatosFungicidas(objFungicidas, out message);
        }

        //A method to calculate the cost of fungicidas
        private double CalcularCostoFungicidas(Fungicidas objFungicidas)
        {
            double costoProducto = Convert.ToDouble(objFungicidas.costoProducto);
            double cantidadProducto = Convert.ToDouble(objFungicidas.cantidadProducto);
            double cantidadAplicada = Convert.ToDouble(objFungicidas.cantidadAplicada);

            return (costoProducto / cantidadProducto) * cantidadAplicada;
        }
    }
}
