using System;
using Tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Posicao p = new Posicao(3, 4);

            var tab = new Tabuleiro.Tabuleiro(8, 8);
            
        }
    }
}
