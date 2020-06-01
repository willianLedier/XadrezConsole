using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {

        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> PecasCapturadas;

        public PartidaXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {

            var pecaCapturada = Tabuleiro.RetirarPeca(destino);
            var peca = Tabuleiro.RetirarPeca(origem);

            Tabuleiro.ColocarPeca(peca, destino);
            peca.QtdMovimentos += 1;

            if(pecaCapturada != null)
            {
                PecasCapturadas.Add(pecaCapturada);
            }

        }

        public HashSet<Peca> Capturadas(Cor cor)
        {

            var capturadas = new HashSet<Peca>();

            foreach (var capturada in PecasCapturadas)
            {
                if (capturada.Cor == cor)
                {
                    capturadas.Add(capturada);
                }
            }

            return capturadas;

        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {

            var emJogo = new HashSet<Peca>();

            foreach (var capturada in PecasCapturadas)
            {
                if (capturada.Cor == cor)
                {
                    emJogo.Add(capturada);
                }
            }

            emJogo.ExceptWith(Capturadas(cor));

            return emJogo;

        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }

        public void MudarJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }


        public void ValidarPosicaoOrigem(Posicao posicao)
        {

            if (Tabuleiro.Peca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça nesta posição.");
            }

            if (JogadorAtual != Tabuleiro.Peca(posicao).Cor)
            {
                throw new TabuleiroException("Peça escolhida inválida para a rodada.");
            }

            if (!Tabuleiro.Peca(posicao).ExisteMovimentoPossivel())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça escolhida.");
            }

        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida.");
            }
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }
        private void ColocarPecas()
        {

            ColocarNovaPeca('a', 1, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('b', 1, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 1, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 1, new Torre(Tabuleiro, Cor.Preta));


            ColocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('b', 8, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 8, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 8, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 8, new Torre(Tabuleiro, Cor.Branca));


        }

    }
}
