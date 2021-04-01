using System;

namespace Banca
{
    class Program
    {
        static void Main(string[] args)
        {
            // per il momento non creiamo una classe che coordini conti e clienti
            // mi accontento di testare il modello direttamente dal main

            Cliente pino = new Cliente("Pino", "Pini");
            Cliente gino = new Cliente("Gino", "Gini");
            Cliente tino = new Cliente("Tino", "Tini");
            Cliente dino = new Cliente("Dino", "Dini");

            Conto conto1 = new Conto(pino);
            Conto conto2 = new Conto(gino, tino);
            Conto conto3 = new Conto(pino, dino);

            conto2.Versa(1000, "Stipendio");
            conto2.Preleva(300, "Assegno");

            Console.WriteLine($"Il saldo di conto {conto2.Numero} è {conto2.Saldo}");

            //foreach (Conto c in pino.Conti)
            //    Console.WriteLine($"Conto: {c.Numero} Saldo: {c.Saldo}");

            // Prospetto Conti di un cliente
            Console.WriteLine($"Prospetto conti di {gino.Prospetto}:");
            Console.WriteLine(pino.ProspettoConti);

            // ProspettoIntestatari di un conto
            Console.WriteLine($"Intestatari del conto {conto2.Numero}:");
            Console.WriteLine(conto2.ProspettoIntestatari);

            // ElencoOperazioni di un conto
            Console.WriteLine($"Operazioni del conto {conto2.Numero}:");
            Console.WriteLine(conto2.ElencoOperazioni);

            // patrimonio di ogni cliente
            Console.WriteLine($"Patrimonio totale del cliente {gino.Prospetto}: {gino.Patrimonio}");
        }
    }
}
