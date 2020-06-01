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

        public bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca == null || peca.Cor != this.Cor;
        }

    }
}
