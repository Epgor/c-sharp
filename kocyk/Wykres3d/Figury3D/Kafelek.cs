using punkt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kocyk
{
    class Kafelek : IComparable<Kafelek>
    {
        public static Punkt Obserwator;

        private Punkt[] wierzcholki = new Punkt[4];
        public Punkt[] Wierzcholki => wierzcholki;

        public Kafelek(Punkt[] NoweWierzcholki)
        {
            wierzcholki = NoweWierzcholki;
        }

        public int CompareTo(Kafelek inny)//porównanie kafelków w celu ułożenia-sortowania
        {
            double BliskieKafelki = Wierzcholki[0].odleglosc(Obserwator);
            double InneKafelki = inny.Wierzcholki[0].odleglosc(Obserwator);

            return InneKafelki.CompareTo(BliskieKafelki);
        }
    }
}
