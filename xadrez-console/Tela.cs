using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
        public static void ImprimirTabuleiro(tabuleiro.Tabuleiro tabuleiro)
        {


            for (int i = 0; i < tabuleiro.Linhas; i++)
            {

                System.Console.Write(8 - i + " ");

                for (int y = 0; y < tabuleiro.Colunas; y++)
                {
                    ImprimirPeca(tabuleiro.GetPeca(i, y));
                }

                System.Console.WriteLine();

            }

            System.Console.WriteLine( "   a b c d e f g h");

        }

        public static void ImprimirPeca(Peca peca)
        {

           if (peca == null)
            {
                Console.Write(" -");
                return;
            }

            if (peca.Cor == Cor.Branca)
            {
                System.Console.Write(peca);

            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;

                System.Console.Write(peca);


                Console.ForegroundColor = aux;

            }
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();

            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

           return new PosicaoXadrez(coluna, linha);

        }
    }
}
