using DataLayer;
using EntityLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BL_Quema
    {
        private DL_Quema objDL_Quema = new DL_Quema();

        //This method allow to list the seleccion data
        public List<Quema> ToList(int usuario)
        {
            return objDL_Quema.ToList(usuario);
        }

        //This method allow to insert data
        public int InsertarDatosQuema(Quema objQuema, out string message)
        {
            //Falta validación de datos

            objQuema.costoPorAplicacion = CalcularCostoQuema(objQuema).ToString();

            return objDL_Quema.InsertarDatosQuema(objQuema, out message);
        }

        //This method to calculate cost of Quema
        private double CalcularCostoQuema(Quema objQuema)
        {
            double costoProducto = Convert.ToDouble(objQuema.costoProducto);
            double cantidadProducto = Convert.ToDouble(objQuema.cantidadProducto);
            double cantidadAplicada = Convert.ToDouble(objQuema.cantidadAplicada);

            return (costoProducto / cantidadProducto) * cantidadAplicada;
        }
    }
}
