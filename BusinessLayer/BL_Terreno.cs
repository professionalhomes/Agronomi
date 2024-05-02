using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BL_Terreno
    {
        private DL_Terreno objDL_Terreno = new DL_Terreno();
        public List<Terreno> ListarTerrenos(int usuario)
        {
            return objDL_Terreno.ListarTerrenos(usuario);
        }
    }
}
