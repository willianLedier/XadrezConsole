namespace tabuleiro
{
    abstract class Peca
    {

        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; set; }
        
        public Tabuleiro Tabuleiro { get; private set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {

            Posicao = null;
            Tabuleiro = tabuleiro;
            Cor = cor;
            QtdMovimentos = 0;

        }

        public override string ToString()
        {
            return " -";
        }

        public abstract bool[,] MovimentosPosiveis();

        public bool ExisteMovimentoPossivel()
        {

            var movimentosPossiveis = MovimentosPosiveis();

            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int y = 0; y < Tabuleiro.Colunas; y++)
                {
                    if(movimentosPossiveis[i, y])
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        public bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca == null || peca.Cor != this.Cor;
        }

        public bool PodeMoverPara(Posicao destino)
        {
            return MovimentosPosiveis()[destino.Linha, destino.Coluna];
        }

    }
}
