using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K5_v._2
{
    class KomplektoDetale
    {
        public string KomplektoDetalesKodas { get; }
        public List<string> AnaloguSarasas { get; }

        public KomplektoDetale(string kmpldetkodas, List<string> analogai)
        {
            KomplektoDetalesKodas = kmpldetkodas;
            AnaloguSarasas = analogai;
        }

        public void Isvedimas()
        {
            Console.Write("Komplekto detales " + KomplektoDetalesKodas + " analogai: ");
            foreach (var item in AnaloguSarasas)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
    }
}
