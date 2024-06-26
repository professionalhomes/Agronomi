using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Nematicidas
    {
        public int idUsuario { get; set; }
        public string idTerreno { get; set; }
        public string producto { get; set; }
        public string costoProducto { get; set; }
        public string cantidadProducto { get; set; }
        public string cantidadAplicada { get; set; }
        public string costoPorAplicacion { get; set; }
    }
}