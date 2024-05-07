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
        private Resultados objResultados;

        private Resultados Constructor(int usuario, string idTerreno)
        {
            objDL_Resultados.GetCostos(usuario, idTerreno);

            objResultados = new Resultados();

            objResultados.Mantenimiento = objDL_Resultados.costoMantenimiento.ToString();
            objResultados.Labranza = objDL_Resultados.costoLabranza.ToString();
            objResultados.Siembra = objDL_Resultados.costoSiembra.ToString();
            objResultados.Tratamiento = objDL_Resultados.costoTratamiento.ToString();
            objResultados.Cosecha = objDL_Resultados.costoCosecha.ToString();
            objResultados.Cultivo = objDL_Resultados.areaCultivo.ToString();

            return objResultados;
        }

        private decimal CalcularCostoProduccion(int usuario, string idTerreno)
        {
            return (Convert.ToInt32(objResultados.Tratamiento) + Convert.ToInt32(objResultados.Labranza) +
                Convert.ToInt32(objResultados.Siembra) + Convert.ToInt32(objResultados.Mantenimiento)
                + Convert.ToInt32(objResultados.Cosecha)) / Convert.ToInt32(objResultados.Cultivo);
        }

        public Resultados ListarResultados(int usuario, string idTerreno)
        {
            objResultados = Constructor(usuario, idTerreno);

            objResultados.Produccion = CalcularCostoProduccion(usuario, idTerreno).ToString();
            objResultados.idTerreno = idTerreno;

            return objResultados;
        }
    }
}