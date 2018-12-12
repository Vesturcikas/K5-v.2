using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K5_v._2
{
    class KomplektoSF
    {
        public int SFKomplektoNr { get; }
        public string SFKomplektoKodas { get; }
        public double SFKomplektoKiekis { get; private set; }
        public string SFNumeris { get; }
        public List<ParduotaDetale> SFDetales { get; }
        public double SFKomplektiskumas { get; private set; }

        public KomplektoSF(int sfkomplektonr, string sfkomplektokodas, double sfkomplektokiekis, string sfnumeris, List<ParduotaDetale> sfdetales)
        {
            SFKomplektoNr = sfkomplektonr;
            SFKomplektoKodas = sfkomplektokodas;
            SFKomplektoKiekis = sfkomplektokiekis;
            SFNumeris = sfnumeris;
            SFDetales = sfdetales;
        }

        public void IsvedimasSF()
        {
            Console.WriteLine("Sakatoje {0} rastas komplektas: {1}, kiekis {2} vnt. Saskaitos komplektiskumas: {3}.", SFNumeris, SFKomplektoKodas, SFKomplektoKiekis, SFKomplektiskumas);
            Console.WriteLine("Kitos saskaitoje esancios detales:");
            foreach (var item in SFDetales)
            {
                Console.WriteLine("{0}; {1}; {2}; {3}; {4}", item.DetalesNr, item.DetlesKodas, item.DetalesKiekis, item.DetalesMatas, item.DetalesZyma);
            }
            Console.WriteLine();
        }
       
        public void SFKomplektiskumoSkaiciavimas(Komplektas orgkompl, List<KomplektoDetale> analogai)
        {
            double kmpl = 0;
            double kmplsk = 0;
            List<double> komplsar = new List<double>();
            List<double> komplsvorsar = new List<double>();
            double detkiekiusuma = 0;

            for (int j = 0; j < SFDetales.Count; j++)
            {
                double komplj = 0;
                double kompljsvoris = 0;
                bool lygus_kodai = false;
                string zyma = null;

                for (int i = 0; i < orgkompl.KomplDetKodai.Count; i++)
                {
                    if (SFDetales[j].DetlesKodas == orgkompl.KomplDetKodai[i])
                    {
                        lygus_kodai = true;
                        zyma = "Komplekto detale.";
                    }
                    else
                    {
                        string detkod = orgkompl.KomplDetKodai[i];
                        foreach (var item in analogai)
                        {
                            if (detkod == item.KomplektoDetalesKodas)
                            {
                                for (int z = 0; z < item.AnaloguSarasas.Count; z++)
                                {
                                    if (SFDetales[j].DetlesKodas == item.AnaloguSarasas[z])
                                    {
                                        lygus_kodai = true;
                                        zyma = "Analogas detalei " + detkod;
                                    }
                                }
                            }
                        }
                    }

                    if (lygus_kodai)
                    {
                        komplj = SFDetales[j].DetalesKiekis / (SFKomplektoKiekis * orgkompl.KomplDetKiekiai[i]);
                        kompljsvoris = SFDetales[j].DetalesKiekis;
                        komplsar.Add(komplj);
                        komplsvorsar.Add(kompljsvoris);
                        SFDetales[j].PazymetiDetale(zyma);
                        break;
                    }

                }
            }

            for (int l = 0; l < komplsar.Count; l++)
            {
                kmplsk += komplsar[l] * komplsvorsar[l];
                detkiekiusuma += komplsvorsar[l];
            }

            if (detkiekiusuma == 0)
            {
                kmpl = 0;
            }
            else
            {
                kmpl = kmplsk / detkiekiusuma;
            }

            SFKomplektiskumas = kmpl;

        }
    }
}
