using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banca
{
    class Cliente
    {
        private List<Conto> _conti = new List<Conto>();

        // la copia di una lista è una shallow copy non una deep copy
        public List<Conto> Conti { get { return new List<Conto>(_conti); } }

        public decimal Patrimonio
        {
            get
            {
                decimal saldo = 0;
                foreach (Conto c in _conti)
                    saldo += c.Saldo;

                return saldo;
            }
        }

        public string Prospetto
        {
            get
            {
                return $"{Nome} {Cognome}";
            }
        }

        public string ProspettoConti
        {
            get
            {
                string s = "";
                foreach (Conto c in _conti)
                    s += c.Prospetto + '\n';

                return s;
            }
        }

        public string Nome { get; }
        public string Cognome { get; }

        public void IntestaConto(Conto c)
        {
            _conti.Add(c);
        }

        public Cliente(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }
    }
}