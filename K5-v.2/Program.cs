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

            //KomplektoDetaliuSarasas kds = new KomplektoDetaliuSarasas("Bendras", komplDet_AnaloguSar);

            Console.WriteLine();
            Console.WriteLine("Bendras komplektu detaliu-analogu sarasas suformuotas.");
            Console.WriteLine();

            //suformuotas komplektu detaliu-analogu sarasas
        }
    }
}
