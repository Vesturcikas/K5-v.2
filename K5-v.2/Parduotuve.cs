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
        public double PardavejoKomplektuSuma { get; private set; }

        public Parduotuve(string pardavPav, List<ParduotaDetale> pardavDetSar, List<ParduotaDetale> pardavKomplSar)
        {
            PardavejoPavad = pardavPav;
            PardavejoDetaliuSarasas = pardavDetSar;
            PardavejoKomplSarasas = pardavKomplSar;
        }

        public Parduotuve(string pardavPav, List<ParduotaDetale> pardavDetSar)
        {
            PardavejoPavad = pardavPav;
            PardavejoDetaliuSarasas = pardavDetSar;
        }

        public void ParduotuvesDetIsvedimas()
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
                item.IsvedimasSF();
            }
        }

        public void KmplektuSFformavimas()
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
            }

            PardavejoKomplektuSFSarasas = kmplSfSar;
        }

        public void KomplektuSuma()
        {
            double ksuma = 0;

            foreach (var item in PardavejoKomplSarasas)
            {
                ksuma += item.DetalesKiekis;
            }

            PardavejoKomplektuSuma = ksuma;
        }

        public void Komplektiskumas(List<Komplektas> orgkomplsar, List<KomplektoDetale> analogsar)
        {
            Komplektas orgkompl = new Komplektas();
            List<KomplektoDetale> analogai = new List<KomplektoDetale>();

            foreach (var item in PardavejoKomplektuSFSarasas)
            {
                for (int i = 0; i < orgkomplsar.Count; i++)
                {
                    if (item.SFKomplektoKodas==orgkomplsar[i].KomplKodas)
                    {
                        orgkompl = orgkomplsar[i];

                        foreach (var kint in orgkompl.KomplDetKodai)
                        {
                            for (int j = 0; j < analogsar.Count; j++)
                            {
                                if (kint==analogsar[i].KomplektoDetalesKodas)
                                {
                                    analogai.Add(analogsar[i]);
                                    break;
                                }
                            }
                        }

                        item.SFKomplektiskumoSkaiciavimas(orgkompl, analogai);



                        break;
                    }
                }

            }

        }






    }
}
