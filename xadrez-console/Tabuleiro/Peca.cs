namespace tabuleiro
{
    class Peca
    {

        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }

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

    }
}
