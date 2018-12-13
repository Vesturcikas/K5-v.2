using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace K5_v._2
{
    class Parduotuve
    {
        public string PardavejoPavad { get; }
        public List<ParduotaDetale> PardavejoDetaliuSarasas { get; }
        public List<ParduotaDetale> PardavejoKomplSarasas { get; }
        public List<KomplektoSF> PardavejoKomplektuSFSarasas { get; private set; }
        public double PardavejoKomplektuSuma { get; private set; }
        public double PardavejoKomplektuKomplektiskumas { get; private set; }

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
            double pardkompl = 0;

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
                                if (kint==analogsar[j].KomplektoDetalesKodas)
                                {
                                    analogai.Add(analogsar[j]);
                                    break;
                                }
                            }
                        }

                        item.SFKomplektiskumoSkaiciavimas(orgkompl, analogai);

                        break;
                    }
                }

                pardkompl += item.SFKomplektoKiekis * item.SFKomplektiskumas;

            }

            PardavejoKomplektuKomplektiskumas = pardkompl / PardavejoKomplektuSuma;

        }

        public void Spausdinimas()
        {
            Console.WriteLine("Nurodykite .csv faila i kuri surasyti {0} duomenys:", PardavejoPavad);

            string path1 = null;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path1 = ofd.FileName;
                }
            }

            System.IO.StreamWriter file2 = new System.IO.StreamWriter(path1, false);

            string lineirasymas = "*";

            file2.WriteLine(lineirasymas);
            file2.Close();

            Console.WriteLine("Duomenys surasyti :)");


        }




    }
}
