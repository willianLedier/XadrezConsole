using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {

        private PartidaXadrez PartidaXadrez { get; set; }

        public Peao(Tabuleiro tabuleiro, Cor cor, PartidaXadrez partidaXadrez)
            : base(tabuleiro, cor)
        {
            PartidaXadrez = partidaXadrez;
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

                posicao.DefinirPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.DefinirPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    movimentosPosiveis[posicao.Linha, posicao.Coluna] = true;
                }

                //en passant
                if (this.Posicao.Linha == 3)
                {

                    var posicaoEsquerda = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(posicaoEsquerda) && Tabuleiro.Peca(posicaoEsquerda) is Peao && Tabuleiro.Peca(posicaoEsquerda) == PartidaXadrez.VulneravelEnPassant)
                    {
                        movimentosPosiveis[posicaoEsquerda.Linha - 1, posicaoEsquerda.Coluna] = true;
                    }

                    var posicaoDireita = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(posicaoDireita) && Tabuleiro.Peca(posicaoDireita) is Peao && Tabuleiro.Peca(posicaoDireita) == PartidaXadrez.VulneravelEnPassant)
                    {
                        movimentosPosiveis[posicaoDireita.Linha - 1, posicaoDireita.Coluna] = true;
                    }

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

                //en passant
                if (this.Posicao.Linha == 4)
                {

                    var posicaoEsquerda = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(posicaoEsquerda) && Tabuleiro.Peca(posicaoEsquerda) is Peao && Tabuleiro.Peca(posicaoEsquerda) == PartidaXadrez.VulneravelEnPassant)
                    {
                        movimentosPosiveis[posicaoEsquerda.Linha + 1, posicaoEsquerda.Coluna] = true;
                    }
                    
                    var posicaoDireita = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(posicaoDireita) && Tabuleiro.Peca(posicaoDireita) is Peao && Tabuleiro.Peca(posicaoDireita) == PartidaXadrez.VulneravelEnPassant)
                    {
                        movimentosPosiveis[posicaoDireita.Linha + 1, posicaoDireita.Coluna] = true;
                    }

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
