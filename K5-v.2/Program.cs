using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K5_v._2
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Pardaveju sarasas
            List<string> pardavejai = new List<string> { "Autokurtas", "KN-Serv", "KN-Real", "KL-Serv", "KL-Real", "SL-Serv", "SL-Real", "VL-Serv", "VL-Real" };

            //suformuojamas komplekto detaliu-analogu sarasas

            List<KomplektoDetale> komplDet_AnaloguSar = new List<KomplektoDetale>();

            string path1 = null;
            Console.WriteLine("Nurodykite kuriame .csv faile saugoma komplektuojancios detales:");
            Console.WriteLine();

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path1 = ofd.FileName;
                }
            }

            System.IO.StreamReader reader1 = new System.IO.StreamReader(path1);
            string line1 = null;

            while ((line1 = reader1.ReadLine()) != null)
            {
                var data2 = line1.Split(';');
                List<string> analog = new List<string>();

                for (int i = 1; i < data2.Length; i++)
                {
                    analog.Add(data2[i]);
                }

                KomplektoDetale komplDet_Analog = new KomplektoDetale(data2[0], analog);
                komplDet_AnaloguSar.Add(komplDet_Analog);
                komplDet_Analog.Isvedimas();
            }

            
            Console.WriteLine();
            Console.WriteLine("Bendras komplektu detaliu-analogu sarasas suformuotas.");
            Console.WriteLine();

            //suformuotas komplektu detaliu-analogu sarasas

            //sukuriamas komplektu sarasas is parengto komplektu failo
            //atidaromas komplektu failas .csv

            string path = null;
            Console.WriteLine("Nurodykite is kurio .csv failo nuskaityti komplektus:");
            Console.WriteLine();

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                }
            }

            System.IO.StreamReader reader = new System.IO.StreamReader(path);

            string line = null;
            List<Komplektas> komplektuSarasasA = new List<Komplektas>();
            List<string> komplektuKoduSarasas = new List<string>();

            while ((line = reader.ReadLine()) != null)
            {
                var data = line.Split(';');
                List<string> detkodai = new List<string>();
                List<int> detkiek = new List<int>();

                for (int i = 3; i < data.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        detkiek.Add(Convert.ToInt32(data[i]));
                    }
                    else
                    {
                        detkodai.Add(data[i]);
                    }
                }
                Komplektas kompl_i = new Komplektas(data[0], data[1], data[2], detkodai, detkiek);
                komplektuSarasasA.Add(kompl_i);
                komplektuKoduSarasas.Add(data[1]);
            }

            KomplektuSarasas komplektaiA = new KomplektuSarasas(pardavejai[0], komplektuSarasasA);
            komplektaiA.Isvedimas();

            Console.WriteLine();
            Console.WriteLine("Komplektu sarasas suformuotas.");
            Console.WriteLine();

            //suformuotas komplektu sarasas

            //Nuskaitomi parduotu detaliu duomenys is csv failo
            //ieskomi parduoti komplektai

            string path2 = null;
            Console.WriteLine("Nurodykite is kurio failo nuskaityti perduotas detales:");
            Console.WriteLine();

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path2 = ofd.FileName;
                }
            }

            List<ParduotaDetale> pardDetSarasasA = new List<ParduotaDetale>();
            List<ParduotaDetale> pardKomplSarasasA = new List<ParduotaDetale>();

            System.IO.StreamReader reader2 = new System.IO.StreamReader(path2);
            string line3 = null;
            Console.WriteLine();

            while ((line3 = reader2.ReadLine()) != null) //Suformuojamas visu parduotu detaliu ir parduotu komplektu sarasai
            {
                ParduotaDetale pardDet = new ParduotaDetale(line3);
                pardDetSarasasA.Add(pardDet);
                if (pardDet.ArDetaleIsKomplektuSaraso(komplektuKoduSarasas, pardDet.DetlesKodas))
                {
                    pardKomplSarasasA.Add(pardDet);
                }
                pardDet.Isvedimas();
            }






        }
    }
}
