using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BL_CombateMalezas
    {
        private DL_CombateMalezas objDL_CombateMalezas = new DL_CombateMalezas();

        //This method allow to list the seleccion data
        public List<CombateMalezas> ToList(int usuario)
        {
            return objDL_CombateMalezas.ToList(usuario);
        }
    }
}
