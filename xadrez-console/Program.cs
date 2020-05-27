using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            var tab = new tabuleiro.Tabuleiro(8, 8);

            var rei = new Rei(tab, new Cor());

            tab.ColocarPeca(rei, new Posicao(1, 1));
            

            Tela.ImprimirTabuleiro(tab);

            Console.ReadKey();
        }
    }
}
