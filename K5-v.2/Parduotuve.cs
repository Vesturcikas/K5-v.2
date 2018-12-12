using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K5_v._2
{
    class Parduotuve
    {
        public string PardavejoPavad { get; }
        public List<ParduotaDetale> PardavejoDetaliuSarasas { get; }
        public List<ParduotaDetale> PardavejoKomplSarasas { get; }
        public List<KomplektoSF> PardavejoKomplektuSFSarasas { get; private set; }

        public Parduotuve(string pardavPav, List<ParduotaDetale> pardavDetSar, List<ParduotaDetale> pardavKomplSar)
        {
            PardavejoPavad = pardavPav;
            PardavejoDetaliuSarasas = pardavDetSar;
            PardavejoKomplSarasas = pardavKomplSar;
            
        }

        public void Isvedimas()
        {
            Console.WriteLine("{0} parduotos detales:", PardavejoPavad);

            foreach (var item in PardavejoDetaliuSarasas)
            {
                item.Isvedimas();
            }
        }

        public void SFisvedimas()
        {
            Console.WriteLine();
            Console.WriteLine("Pardavejo: " + PardavejoPavad + " saskaitos fakturos, kuriose rasti komplektu kodai: ");
            Console.WriteLine();

            foreach (var item in PardavejoKomplektuSFSarasas)
            {
                Console.WriteLine("Sakatoje {0} rastas komplektas: {1}, kiekis {2} vnt. Saskaitos komplektiskumas: {3}.", item.SFNumeris, item.SFKomplektoKodas, item.SFKomplektoKiekis, item.SFKomplektiskumas);
                Console.WriteLine("Saskatoje esancios detales:");
                foreach (var itemp in item.SFDetales)
                {
                    Console.WriteLine(itemp.DetalesNr + " " + itemp.DetlesKodas + " " + itemp.DetalesKiekis + " " + itemp.DetalesMatas + " " + itemp.DetalesZyma);
                }
                Console.WriteLine();
            }
        }

        public void KmplektoSFformavimas()
        {
            List<KomplektoSF> kmplSfSar = new List<KomplektoSF>();

            foreach (var item in PardavejoKomplSarasas)
            {
                List<ParduotaDetale> sfdet = new List<ParduotaDetale>();

                foreach (var kint in PardavejoDetaliuSarasas)
                {
                    if (kint.DetalesSaskaitosNr == item.DetalesSaskaitosNr)
                    {
                        sfdet.Add(kint);
                    }
                }
                
                KomplektoSF kmplsf = new KomplektoSF(item.DetalesNr, item.DetlesKodas, item.DetalesKiekis, item.DetalesSaskaitosNr, sfdet);
                kmplSfSar.Add(kmplsf);
                //kmplsf.SFKomplektoKiekioperskaiciavimas();
                //kmplsf.SFKomplektiskumoSkaiciavimas(orgkompl);
            }

            PardavejoKomplektuSFSarasas = kmplSfSar;
        }
    }
}
