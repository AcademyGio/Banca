using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banca
{
    class Operazione
    {
        public string Causale { get; }
        public decimal Importo { get; }
        public DateTime Data { get; }

        public string DettaglioOperazione => 
            $"{Data.ToShortDateString()}\t{Importo}\t{Causale}";

        // costruttore
        public Operazione(decimal importo, string causale, DateTime data)
        {
            Importo = importo;
            Causale = causale;
            Data = data;
        }
    }
}