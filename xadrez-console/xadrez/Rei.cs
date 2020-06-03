using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {

        private PartidaXadrez partida;

        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaXadrez partida)
            : base(tabuleiro, cor)
        {
            this.partida = partida;
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

            //Jogada especial Roque
            if (QtdMovimentos == 0 && !partida.Xeque)
            {

                //Roque Pequeno
                var torre = new Posicao(Posicao.Linha, Posicao.Coluna + 3);

                if (ValidarTorreRoque(torre))
                {
                    var pos1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    var pos2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);

                    if (Tabuleiro.Peca(pos1) == null && Tabuleiro.Peca(pos2) == null)
                    {
                        movimentosPosiveis[this.Posicao.Linha, this.Posicao.Coluna + 2] = true;

                    }


                }

                //Roque grande
                var torre1 = new Posicao(Posicao.Linha, Posicao.Coluna -4);

                if (ValidarTorreRoque(torre1))
                {
                    var pos1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    var pos2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    var pos3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);


                    if (Tabuleiro.Peca(pos1) == null && Tabuleiro.Peca(pos2) == null && Tabuleiro.Peca(pos3) == null)
                    {
                        movimentosPosiveis[this.Posicao.Linha, this.Posicao.Coluna - 2] = true;

                    }


                }
            }

            return movimentosPosiveis;

        }

        private bool ValidarTorreRoque(Posicao posicao) 
        {
            var peca = Tabuleiro.Peca(posicao);
            return (peca is Torre && peca.Cor == Cor && peca.QtdMovimentos == 0);
        }


        public override string ToString()
        {
            return " R";
        }
    }
}
