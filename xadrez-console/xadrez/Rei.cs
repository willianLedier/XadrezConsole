using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor)
            : base(tabuleiro, cor)
        {
        }
       
        public override bool[,] MovimentosPosiveis()
        {
            bool[,] movimentosPosiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);

            // Acima
            posicao.DefinirPosicao(this.Posicao.Linha -1, this.Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // NE
            posicao.DefinirPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // Leste
            posicao.DefinirPosicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // SE
            posicao.DefinirPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // Sul
            posicao.DefinirPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // SO
            posicao.DefinirPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // Oeste
            posicao.DefinirPosicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // NO
            posicao.DefinirPosicao(this.Posicao.Linha -1, this.Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && this.PodeMover(posicao))
            {
                movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
            }

            return movimentosPosiveis;

        }

        public override string ToString()
        {
            return " R";
        }
    }
}
