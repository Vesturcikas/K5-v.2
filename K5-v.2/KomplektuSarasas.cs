using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K5_v._2
{
    class KomplektuSarasas
    {
        public string KomlektuSarasoPav { get; }
        public List<Komplektas> KomplektuSar { get; }

        public KomplektuSarasas(string kmplSarPav, List<Komplektas> kmplSar)
        {
            KomlektuSarasoPav = kmplSarPav;
            KomplektuSar = kmplSar;
        }

        public KomplektuSarasas()
        {

        }

        public void Isvedimas()
        {
            Console.WriteLine("Komplektu saraso {0} visi komplektai.", KomlektuSarasoPav);
            Console.WriteLine();

            foreach (var item in KomplektuSar)
            {
                item.Isvedimas();
            }

        }
    }
}
