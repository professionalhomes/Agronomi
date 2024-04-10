using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BL_Labranza
    {
        private DL_Labranza objDL_Labranza = new DL_Labranza();

        //This method allow to list the seleccion data
        public List<Labranza> ToList(int usuario)
        {
            return objDL_Labranza.ToList(usuario);
        }

        //This method allow to insert labranza data
        public int InsertarDatosLabranza(Labranza objLabranza, out string message)
        {
            //Falta validación de datos

            objLabranza.resultadoLabranza = CalcularCostoLabranza(objLabranza).ToString();

            return objDL_Labranza.InsertarDatosLabranza(objLabranza, out message);
        }

        //A method to calculate the cost of labranza
        private double CalcularCostoLabranza(Labranza objLabranza)
        {
            double costoPorArado = Convert.ToDouble(objLabranza.costoPorArado);
            double costoPorEnmindas = Convert.ToDouble(objLabranza.costoPorEnmindas);
            double costoPorTrazado = Convert.ToDouble(objLabranza.costoPorTrazado);
            double costoPorCamas = Convert.ToDouble(objLabranza.costoPorCamas);
            double costoPorMurillo = Convert.ToDouble(objLabranza.costoPorMurillo);
            double costoPorRastra = Convert.ToDouble(objLabranza.costoPorRastra);

            return costoPorArado + costoPorEnmindas + costoPorTrazado + costoPorCamas + costoPorMurillo + costoPorRastra;
        }
    }
}