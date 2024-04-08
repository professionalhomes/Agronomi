using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Tratamiento
    {
        public string idTerreno { get; set; }
        public string costoPorCortaMalezas { get; set; }
        public string costoPorHoraCorteMalezas { get; set; }
        public string horasAsignadasCorteMalezas { get; set; }
        public string costoAplicacionHierbicidas { get; set; }
        public string horasAsignadasAplicacionHierbicidas { get; set; }
        public string costoPorHoraAplicacionHierbicidas { get; set; }
        public string resultadoTratamientoHierbas { get; set; }
        public string actividad { get; set; }
        public int idUsuario { get; set; }
    }
}