using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Cosecha
    {
        public string idTerreno { get; set; }
        public int idUsuario { get; set; }
        public string costoPorCosecha { get; set; }
        public string costoPorLavado { get; set; }
        public string costoPorSaco { get; set; }
        public string costoPorTransporteCarga { get; set; }
        public string costoDelQuintal { get; set; }
    }
}
