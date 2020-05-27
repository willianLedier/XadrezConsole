using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {

        public Tabuleiro Tabuleiro { get; private set; }
        private int Turno { get; set; }
        private Cor JogadorAtual { get; set; }
        public bool Terminada { get; set; }

        public PartidaXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;

            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {

            var pecaCapturada = Tabuleiro.RetirarPeca(destino);
            var peca = Tabuleiro.RetirarPeca(origem);

            Tabuleiro.ColocarPeca(peca, destino);
            peca.QtdMovimentos += 1;

        }

        private void ColocarPecas()
        {

            var rei = new Rei(Tabuleiro, Cor.Branca);
            var reib = new Rei(Tabuleiro, Cor.Amarela);

            Tabuleiro.ColocarPeca(rei, new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.ColocarPeca(reib, new PosicaoXadrez('a', 4).ToPosicao());

        }

    }
}
