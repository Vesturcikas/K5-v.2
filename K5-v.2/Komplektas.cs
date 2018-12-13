using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K5_v._2
{
    class Komplektas
    {
        public string KomplID { get; }
        public string KomplKodas { get; }
        public string KomplPavad { get; }
        public List<string> KomplDetKodai { get; }
        public List<int> KomplDetKiekiai { get; }

        public Komplektas(string komplid, string komplkodas, string komplpavad, List<string> kompldetkodai, List<int> kompldetkiekiai)
        {
            KomplID = komplid;
            KomplKodas = komplkodas;
            KomplPavad = komplpavad;
            KomplDetKodai = kompldetkodai;
            KomplDetKiekiai = kompldetkiekiai;
        }

        public Komplektas()
        {

        }

        public void Isvedimas()
        {
            Console.WriteLine("Komplektas: {0, 10} | {1, 20} | {2, 30} |", KomplID, KomplKodas, KomplPavad);
            Console.Write("Komplekto detales: ");
            foreach (var item in KomplDetKodai)
            {
                Console.Write(item + "; ");
            }
            Console.WriteLine();
            Console.Write("Komplekto detaliu kiekiai: ");
            foreach (var item in KomplDetKiekiai)
            {
                Console.Write(item + "; ");
            }
            Console.WriteLine();
        }
    }
}
