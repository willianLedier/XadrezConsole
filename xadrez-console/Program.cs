using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                var tab = new tabuleiro.Tabuleiro(8, 8);

                var rei = new Rei(tab, Cor.Branca);

                tab.ColocarPeca(rei, new Posicao(1, 9));
                tab.ColocarPeca(rei, new Posicao(1, 1));



                Tela.ImprimirTabuleiro(tab);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();


        }
    }
}
