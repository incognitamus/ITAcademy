using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracijaKorisnika
{
    static class StringEkstenzija
    {
        public static bool Contains(this string s, string diostringa, StringComparison comp)
        {
            int? indeks = s?.IndexOf(diostringa, comp);
            return indeks > -1;
        }
    }
}
