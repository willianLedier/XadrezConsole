using tabuleiro;

namespace xadrez_console
{
    class Tela
    {
        public static void ImprimirTabuleiro(tabuleiro.Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {


                for (int y = 0; y < tabuleiro.Colunas; y++)
                {

                    Peca peca = tabuleiro.GetPeca(i, y);

                    System.Console.Write(peca != null ? peca.ToString() : " -");

                }

                System.Console.WriteLine();

            }
        }
    }
}
