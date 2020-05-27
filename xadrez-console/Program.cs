using System;
using Tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            var tab = new Tabuleiro.Tabuleiro(8, 8);

            

            Tela.ImprimirTabuleiro(tab);

            Console.ReadKey();
        }
    }
}
