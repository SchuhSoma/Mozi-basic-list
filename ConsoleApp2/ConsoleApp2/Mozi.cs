using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Mozi
    {
        public string FilmCim;
        public int KiadasDatuma;
        public int Nezoszam;

        public Mozi (string sor)
        {
            var dbok = sor.Split(';');
            this.FilmCim = dbok[0];
            this.KiadasDatuma = int.Parse(dbok[1]);
            this.Nezoszam = int.Parse(dbok[2]);
        }
    }
}
