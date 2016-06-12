using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MMM
{
    public enum ŻarłocznościWilków { Mała=1 , Średnia, Duża }
    public enum ŻarłocznościLisów  { Mała=1, Średnia, Duża }


    public class Populacja
    {
              
        public int ParyPłodne { get; set; }
        public int ParyNiePłodne { get; set; }
        public int Wilki { get; set; }
        public int Lisy { get; set; }
        public ŻarłocznościWilków ŻarłocznośćWilków { get; set; }
        public ŻarłocznościLisów ŻarłocznośćLisów { get; set; }
        public int LiczbaMiesiecy { get; set; }
        public long PlodneKonc { get; set; }
        public long NieplodneKonc { get; set; }
        public long SumaKonc { get; set; }
        public Populacja() { }

        public Populacja(int paryPłodne, int paryNiePłodne, int wilki, ŻarłocznościWilków żarłocznośćWilków, int lisy, ŻarłocznościLisów żarłocznośćLisów, int liczbaMiesiecy,long plodneKonc,long nieplodneKonc,long sumaKonc)
        {
            this.ParyPłodne = paryPłodne;
            this.ParyNiePłodne = paryNiePłodne;
            this.Wilki = wilki;
            this.Lisy = lisy;
            this.ŻarłocznośćWilków = żarłocznośćWilków;
            this.ŻarłocznośćLisów = żarłocznośćLisów;
            this.LiczbaMiesiecy = liczbaMiesiecy;
            this.PlodneKonc = plodneKonc;
            this.NieplodneKonc = nieplodneKonc;
            this.SumaKonc = sumaKonc;

        }
 
    }
}
