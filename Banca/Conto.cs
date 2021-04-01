using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banca
{
    class Conto
    {
        const int MAX_INTESTATARI = 3;

        //private Cliente _intestatario;  // nel caso in cui un conto abbia un solo
        //                                // intestatario

        public string Prospetto { get
            {
                return $"Conto: {Numero} Saldo: {Saldo}";
            } }

        public string ProspettoIntestatari
        {
            get
            {
                string s = "";
                foreach (Cliente c in _intestatari)
                    s += c.Prospetto + '\n';

                return s;
            }
        }
        public string ElencoOperazioni
        {
            get
            {
                string s = "";
                foreach (Operazione o in _operazioni)
                    s += o.DettaglioOperazione + '\n';

                return s;
            }
        }

        private List<Cliente> _intestatari = new List<Cliente>();

        private List<Operazione> _operazioni = new List<Operazione>();

        // ogni nuovo conto si autogenera il numero e viene associato
        // ai suoi intestatari (minimo 1 - massimo 3)

        private static int _numero = 0;
        public int Numero { get; }

        //public Conto(Cliente intestatario1, Cliente intestatario2 = null, Cliente intestatario3 = null)
        //{
        //    if (intestatario1 == null)
        //        throw new ArgumentNullException(nameof(intestatario1), "non può essere nullo");

        //    Numero = ++_numero;

        //    _intestatari.Add(intestatario1);
        //    intestatario1.IntestaConto(this);

        //    if (intestatario2 != null)
        //    {
        //        _intestatari.Add(intestatario2);
        //        intestatario2.IntestaConto(this);
        //    }
        //    if (intestatario3 != null)
        //    {
        //        _intestatari.Add(intestatario3);
        //        intestatario3.IntestaConto(this);
        //    }
        //}

        public Conto(params Cliente[] intestatari)
        {
            if (intestatari.Length < 1 || intestatari.Length > MAX_INTESTATARI)
                throw new ArgumentOutOfRangeException(nameof(intestatari), 
                    $"compresi tra 1 e {MAX_INTESTATARI}");

            Numero = ++_numero;

            foreach (Cliente intestatario in intestatari)
            {
                _intestatari.Add(intestatario);
                intestatario.IntestaConto(this);
            }
        }

        public void Versa(decimal importo, string causale)
        {
            // creare una nuova operazione con dati opportuni
            // e accodarla alla lista di operazioni

            _operazioni.Add(new Operazione(importo, causale, DateTime.Today));
//            Saldo += importo;
        }

        // aggiungere Preleva
        public void Preleva(decimal importo, string causale)
        {
            // creare una nuova operazione con dati opportuni
            // e accodarla alla lista di operazioni

            _operazioni.Add(new Operazione(-importo, causale, DateTime.Today));
//            Saldo -= importo;
        }

        // implementare saldo
//        public decimal Saldo { get; private set; }

        public decimal Saldo
        {
            get
            {
                decimal s = 0;
                foreach (Operazione op in _operazioni)
                    s += op.Importo;
                return s;
            }
        }
    }
}