using DataLayer;
using EntityLayer;
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

            objTratamiento.resultadoTratamientoHierbas = CalcularCostoTratamiento(objTratamiento).ToString();

            return objDL_Tratamiento.InsertarDatosTratamiento(objTratamiento, out message);
        }

        //A method to calculate the cost of Tratamiento
        private double CalcularCostoTratamiento(Tratamiento objTratamiento)
        {
            double costoPorCortaMalezas = Convert.ToDouble(objTratamiento.costoPorCortaMalezas);
            double costoPorHoraCorteMalezas = Convert.ToDouble(objTratamiento.costoPorHoraCorteMalezas);
            double horasAsignadasCorteMalezas = Convert.ToDouble(objTratamiento.horasAsignadasCorteMalezas);

            double costoAplicacionHierbicidas = Convert.ToDouble(objTratamiento.costoAplicacionHierbicidas);
            double horasAsignadasAplicacionHierbicidas = Convert.ToDouble(objTratamiento.horasAsignadasAplicacionHierbicidas);
            double costoPorHoraAplicacionHierbicidas = Convert.ToDouble(objTratamiento.costoPorHoraAplicacionHierbicidas);

            double horasCortaMalezas = costoPorHoraCorteMalezas * horasAsignadasCorteMalezas;
            double horasAplicacionHierbicidas = costoPorHoraAplicacionHierbicidas * horasAsignadasAplicacionHierbicidas;

            return (costoPorCortaMalezas * horasCortaMalezas) + (costoAplicacionHierbicidas * horasAplicacionHierbicidas);
        }
    }
}
