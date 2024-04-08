using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Seleccion
    {
        public string idTerreno { get; set; }

        public decimal tamanioTerreno { get; set; }

        public decimal areaCultivo { get; set; }

        public string analisisTerreno { get; set; }

        public int costoOportunidad { get; set; }

        public string analisisPatologico { get; set; }

        public string ubicacionTerrno { get; set; }

        public decimal resultadoSeleccionTerreno { get; set; }

        public int idUsuario { get; set; }
    }
}
