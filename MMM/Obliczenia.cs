using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMM
{

    public class Obliczenia
    {
        private long plodneKonc = 0;
        private long nieplodneKonc = 0;

        public long zwrocPlodneKonc()
        {

            return plodneKonc;
        }
        public long zwrocNieplodneKonc()
        {

            return nieplodneKonc;
        }
        public long zwrocSume()
        {

            return plodneKonc + nieplodneKonc;
        }


        public void licz(long plodne, long nieplodne, int wilk, int lis, int ilosc_miesiecy, int zarW, int zarL)
        {

            plodneKonc = 0;
            nieplodneKonc = 0;

            long buffer = 0;
            for (int i = 0; i < ilosc_miesiecy; i++)
            {
                buffer = plodne;
                plodne = plodne + nieplodne - zarW * wilk - zarL * lis;
                if (buffer < 0) buffer = 0;
                if (plodne < 0) plodne = 0;
                nieplodne = buffer - zarW * wilk - zarL * lis;
                if (nieplodne < 0) nieplodne = 0;
            }

            plodneKonc = plodne;
            nieplodneKonc = nieplodne;
        }
    }
}
