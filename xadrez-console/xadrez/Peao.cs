using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tabuleiro, Cor cor)
            : base(tabuleiro, cor)
        {
        }

        private bool ExisteInimigo(Posicao posicao)
        {
            var p = Tabuleiro.Peca(posicao);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao posicao)
        {
            return Tabuleiro.Peca(posicao) == null;
        }
       
        public override bool[,] MovimentosPosiveis()
        {
            bool[,] movimentosPosiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);

            if (Cor == Cor.Preta)
            {

                posicao.DefinirPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && Livre(posicao))
                {
                    movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirPosicao(this.Posicao.Linha - 2, this.Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && Livre(posicao) && QtdMovimentos == 0)
                {
                    movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna -1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
                }


            }
            else
            {

                posicao.DefinirPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && Livre(posicao))
                {
                    movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirPosicao(this.Posicao.Linha + 2, this.Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && Livre(posicao) && QtdMovimentos == 0)
                {
                    movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
                }

            }

            return movimentosPosiveis;

        }

        public override string ToString()
        {
            return " P";
        }
    }
}
