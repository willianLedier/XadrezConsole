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
            var torrea = new Torre(Tabuleiro, Cor.Amarela);
            var torre = new Torre(Tabuleiro, Cor.Branca);
            var torre1 = new Torre(Tabuleiro, Cor.Branca);
            var torre2 = new Torre(Tabuleiro, Cor.Branca);
            var torre3 = new Torre(Tabuleiro, Cor.Branca);



            Tabuleiro.ColocarPeca(rei, new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.ColocarPeca(torre, new PosicaoXadrez('a', 4).ToPosicao());
            Tabuleiro.ColocarPeca(torre1, new PosicaoXadrez('a', 5).ToPosicao());
            Tabuleiro.ColocarPeca(torre2, new PosicaoXadrez('a', 6).ToPosicao());
            Tabuleiro.ColocarPeca(torre3, new PosicaoXadrez('a', 7).ToPosicao());

            Tabuleiro.ColocarPeca(torrea, new PosicaoXadrez('e', 7).ToPosicao());





        }

    }
}
