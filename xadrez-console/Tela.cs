using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {

        public static void ImprimirPartida(PartidaXadrez partida)
        {
            
            Tela.ImprimirTabuleiro(partida.Tabuleiro);
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Aguardando jogador peça: " + partida.JogadorAtual);

            if (partida.Xeque)
            {
                Console.WriteLine("XEQUE!");
            }

        }

        public static void ImprimirPecasCapturadas(PartidaXadrez partidaXadrez)
        {

            Console.WriteLine("Peças capturadas: ");
            Console.WriteLine("Brancas :");
            ImprimirConjunto(partidaXadrez.Capturadas(Cor.Branca));

            Console.WriteLine();
            Console.WriteLine("Pretas :");
            ImprimirConjunto(partidaXadrez.Capturadas(Cor.Preta));

        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {

            Console.Write("[");

            foreach (var peca in conjunto)
            {
                Console.Write(peca + " ");
            }

            Console.Write("]");

        }

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

            System.Console.WriteLine("   a b c d e f g h");
            Console.WriteLine();

        }

        public static void ImprimirTabuleiro(tabuleiro.Tabuleiro tabuleiro, bool[,] possicoesPossiveis)
        {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoPossicoesPossiveis = ConsoleColor.DarkGray;


            for (int i = 0; i < tabuleiro.Linhas; i++)
            {

                System.Console.Write(8 - i + " ");

                for (int y = 0; y < tabuleiro.Colunas; y++)
                {

                    if (possicoesPossiveis[i, y]) Console.BackgroundColor = fundoPossicoesPossiveis;

                    ImprimirPeca(tabuleiro.GetPeca(i, y));

                    Console.BackgroundColor = fundoOriginal;
                }

                System.Console.WriteLine();

            }

            Console.BackgroundColor = fundoOriginal;
            System.Console.WriteLine("   a b c d e f g h");

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
