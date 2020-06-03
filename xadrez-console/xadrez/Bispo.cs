using tabuleiro;

namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tabuleiro, Cor cor)
            : base(tabuleiro, cor)
        {
        }

        public override bool[,] MovimentosPosiveis()
        {

            bool[,] movimentosPosiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);

            // Acima
            posicao.DefinirPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna -1);
            while (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {

                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }

                posicao.Linha--;
                posicao.Coluna--;



            }

            // Abaixo
            posicao.DefinirPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {

                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }

                posicao.Linha--;
                posicao.Coluna++;


            }

            // Direita
            posicao.DefinirPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {

                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }

                posicao.Linha++;
                posicao.Coluna++;


            }

            // Esquerda
            posicao.DefinirPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna -1);
            while (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {

                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }

                posicao.Linha++;
                posicao.Coluna--;

            }

            return movimentosPosiveis;

        }

        public override string ToString()
        {
            return " B";
        }
    }
}
