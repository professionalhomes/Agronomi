using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BL_Resultados
    {
        private DL_Resultados objDL_Resultados = new DL_Resultados();
        
        private Resultados Constructor(int usuario, string idTerreno)
        {
            Resultados objResultados = new Resultados();
            
            objDL_Resultados.CalcularCostoProduccion(usuario, idTerreno);

            objResultados.Mantenimiento = objDL_Resultados.costoMantenimiento.ToString();
            objResultados.Labranza = objDL_Resultados.costoLabranza.ToString();
            objResultados.Siembra = objDL_Resultados.costoSiembra.ToString();
            objResultados.Tratamiento = objDL_Resultados.costoTratamiento.ToString();
            objResultados.Cosecha = objDL_Resultados.costoCosecha.ToString();
            objResultados.Cultivo = objDL_Resultados.areaCultivo.ToString();

            return objResultados;
        }
    }
}