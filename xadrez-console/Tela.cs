namespace xadrez_console
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro.Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {


                for (int y = 0; y < tabuleiro.Colunas; y++)
                {



                    System.Console.Write(tabuleiro.GetPeca(i, y) + " -");

                }

                System.Console.WriteLine();

            }
        }
    }
}
