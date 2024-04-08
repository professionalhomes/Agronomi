using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Siembra
    {
        public string idTerreno { get; set; }
        public string costoPorSucroAnimal { get; set; }
        public string costoPorRegadoPapa { get; set; }
        public string costoPorTapadoPap { get; set; }
        public string costoPorFertilizacion { get; set; }
        public string resultadoSiembra { get; set; }
        public int idUsuario { get; set; }

    }
}