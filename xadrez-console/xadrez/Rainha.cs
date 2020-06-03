using tabuleiro;

namespace xadrez
{
    class Rainha : Peca
    {
        public Rainha(Tabuleiro tabuleiro, Cor cor)
            : base(tabuleiro, cor)
        {
        }

        public override bool[,] MovimentosPosiveis()
        {

            bool[,] movimentosPosiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);

            // Acima
            posicao.DefinirPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
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
            posicao.DefinirPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
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

            // Acima
            posicao.DefinirPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {

                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }

                posicao.Linha -= 1;

            }

            // Abaixo
            posicao.DefinirPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {

                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }

                posicao.Linha += 1;

            }

            // Direita
            posicao.DefinirPosicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {

                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }

                posicao.Coluna += 1;

            }

            // Esquerda
            posicao.DefinirPosicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {

                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;

                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != this.Cor)
                {
                    break;
                }

                posicao.Coluna -= 1;

            }

            return movimentosPosiveis;

        }

        public override string ToString()
        {
            return " Q";
        }
    }
}
