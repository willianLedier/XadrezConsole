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
                Partida();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static void Partida()
        {

            PartidaXadrez partida = new PartidaXadrez();

            while (!partida.Terminada)
            {

                try
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro);
                    Console.WriteLine();
                    Console.WriteLine("Turno: " + partida.Turno);
                    Console.WriteLine("Aguardando jogador peça: " + partida.JogadorAtual);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarPosicaoOrigem(origem);

                    bool[,] movimentosPossiveis = partida.Tabuleiro.Peca(origem).MovimentosPosiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro, movimentosPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ValidarPosicaoDestino(origem, destino);

                    partida.RealizaJogada(origem, destino);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }



            }

        }

    }

}
