using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K5_v._2
{
    class ParduotaDetale
    {
        public int DetalesNr { get; }
        public string DetalesSaskaitosNr { get; }
        public string DetlesKodas { get; }
        public string DetalesPav { get; }
        public double DetalesKiekis { get; }
        public string DetalesMatas { get; }
        public string DetelesKiekisSuMatu { get; }
        public string DetalesPardavejas { get; }
        public double DetalesSuma { get; }
        public string DetalesZyma { get; private set; }

        public ParduotaDetale()
        {

        }

        public ParduotaDetale(string line3)
        {
            var data = line3.Split(';');
            DetalesNr = Convert.ToInt32(data[0]);
            DetalesSaskaitosNr = data[1];
            DetlesKodas = data[2];
            DetalesPav = data[3];
            DetalesKiekis = Convert.ToDouble(data[4]);
            DetalesMatas = data[5];
            DetelesKiekisSuMatu = data[6];
            DetalesPardavejas = data[7];
            DetalesSuma = Convert.ToDouble(data[8]);
        }

        public void Isvedimas()
        {
            Console.WriteLine("Parduota detale: Nr: {0}; SF Nr: {1}; kodas: {2}; pardavejas {3}; kiekis {4}; suma {5}; ",
                DetalesNr, DetalesSaskaitosNr, DetlesKodas, DetalesPardavejas, DetalesKiekis, DetalesSuma);
        }

        public bool ArDetaleIsKomplektuSaraso(List<string> komplsar, string detPard)
        {
            bool zyma = false;

            for (int i = 0; i < komplsar.Count; i++)
            {
                if (detPard == komplsar[i])
                {
                    zyma = true;
                    break;
                }
            }
            return zyma;
        }
        
        public void PazymetiDetale(string zyma)
        {
            DetalesZyma = zyma;
        }
    }
}
