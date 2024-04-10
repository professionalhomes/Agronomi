using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BL_Insecticidas
    {
        private DL_Insecticidas objDL_Insecticidas = new DL_Insecticidas();

        //This method allow to list the seleccion data
        public List<Insecticidas> ToList(int usuario)
        {
            return objDL_Insecticidas.ToList(usuario);
        }

        //This method allow to insert Insecticidas data
        public int InsertarDatosInsecticidas(Insecticidas objInsecticidas, out string message)
        {
            //Falta validación de datos

            objInsecticidas.resultadoInsecticidas = CalcularCostoInsecticidas(objInsecticidas).ToString();

            return objDL_Insecticidas.InsertarDatosInsecticidas(objInsecticidas, out message);
        }

        //A method to calculate the cost of Insecticidas
        private double CalcularCostoInsecticidas(Insecticidas objInsecticidas)
        {
            double costoProducto = Convert.ToDouble(objInsecticidas.costoProducto);
            double cantidadProducto = Convert.ToDouble(objInsecticidas.cantidadProducto);
            double cantidadAplicada = Convert.ToDouble(objInsecticidas.cantidadAplicada);
            double costoPorAplicacion = Convert.ToDouble(objInsecticidas.costoPorAplicacion);

            return (costoProducto * cantidadProducto) + (cantidadAplicada * costoPorAplicacion);
        }
    }
}