using System;
using System.Collections.Generic;
namespace MuseSort
{
    interface IBazaDanych
    {
        void delete(WierszTabeli where);
        string[] getNazwyKolumn(string nazwaTabeli);
        void insert(WierszTabeli nowyWiersz); 
        void insert(IList<WierszTabeli> noweWiersze);
        void update(WierszTabeli where, WierszTabeli noweDane);
        IList<WierszTabeli> select(WierszTabeli where);
    }
}
