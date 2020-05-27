namespace tabuleiro
{
    class Tabuleiro
    {

        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {

            Linhas = linhas;
            Colunas = colunas;

            Pecas = new Peca[linhas, colunas];

        }



        public Peca GetPeca(int linha, int coluna)
        {

            return Pecas[linha, coluna];

        }

        public Peca Peca(Posicao posicao)
        {

            return Pecas[posicao.Linha, posicao.Coluna];
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {

            if (ExistePeca(posicao)) throw new TabuleiroException("Já existe uma peça nesta posição.");

            peca.Posicao = posicao;
            Pecas[peca.Posicao.Linha, peca.Posicao.Coluna] = peca;



        }
        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);

            return Peca(posicao) != null;

        }

        public void ValidarPosicao(Posicao posicao)
        {

            if (posicao.Linha < 0|| posicao.Linha > Linhas || posicao.Coluna < 0 || posicao.Coluna > Colunas)
            {
                throw new TabuleiroException("Posição inválida.");
            }

        }

    }
}
