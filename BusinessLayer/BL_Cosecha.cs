using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BL_Cosecha
    {
        private DL_Cosecha objDL_Cosecha = new DL_Cosecha();

        //This method allow to list the seleccion data
        public List<Cosecha> ToList(int usuario)
        {
            return objDL_Cosecha.ToList(usuario);
        }

        //This method allow to insert Cosecha data
        public int InsertarDatosCosecha(Cosecha objCosecha, out string message)
        {
            //Falta validación de datos

            objCosecha.resultadoCosecha = CalcularCostoCosecha(objCosecha).ToString();

            return objDL_Cosecha.InsertarDatosCosecha(objCosecha, out message);
        }

        //A method to calculate the cost of Cosecha
        private double CalcularCostoCosecha(Cosecha objCosecha)
        {
            double costoPorCosecha = Convert.ToDouble(objCosecha.costoPorCosecha);
            double costoPorLavado = Convert.ToDouble(objCosecha.costoPorLavado);
            double costoPorSaco = Convert.ToDouble(objCosecha.costoPorSaco);
            double costoPorTransporteCarga = Convert.ToDouble(objCosecha.costoPorTransporteCarga);
            double costoPorLavadoQuintal = Convert.ToDouble(objCosecha.costoPorLavadoQuintal);

            return (costoPorCosecha + costoPorLavado + costoPorSaco + costoPorTransporteCarga + costoPorLavadoQuintal);
        }
    }
}
