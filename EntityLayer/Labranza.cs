using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Labranza
    {
        public string idTerreno { get; set; }
        public string costoPorArado { get; set; }
        public string costoPorEnmindas { get; set; }
        public string costoPorTrazado { get; set; }
        public string costoPorCamas { get; set; }
        public string costoPorMurillo { get; set; }
        public string costoPorRastra { get; set; }
        public string resultadoLabranza { get; set; }
        public int IdUsuario { get; set; }
    }
}