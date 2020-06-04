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
        public bool Xeque { get; set; }
        public Peca VulneravelEnPassant { get; private set; }

        public PartidaXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            VulneravelEnPassant = null;
            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {

            var peca = Tabuleiro.RetirarPeca(origem);
            peca.QtdMovimentos += 1;
            var pecaCapturada = Tabuleiro.RetirarPeca(destino);

            Tabuleiro.ColocarPeca(peca, destino);

            if (pecaCapturada != null)
            {
                PecasCapturadas.Add(pecaCapturada);
            }

            //Jogada especial roque pequeno
            if (peca is Rei && destino.Coluna == origem.Coluna + 2)
            {

                var torreOrigem = new Posicao(origem.Linha, origem.Coluna + 3);
                var torreDestino = new Posicao(origem.Linha, origem.Coluna + 1);

                var torre = Tabuleiro.RetirarPeca(torreOrigem);
                torre.QtdMovimentos++;
                Tabuleiro.ColocarPeca(torre, torreDestino);

            }

            //Jogada especial roque g
            if (peca is Rei && destino.Coluna == origem.Coluna - 2)
            {
                var torreOrigem = new Posicao(origem.Linha, origem.Coluna - 4);
                var torreDestino = new Posicao(origem.Linha, origem.Coluna - 1);

                var torre = Tabuleiro.RetirarPeca(torreOrigem);
                torre.QtdMovimentos++;
                Tabuleiro.ColocarPeca(torre, torreDestino);

            }

            if (peca is Peao)
            {

                if (origem.Coluna != destino.Coluna && pecaCapturada == null)
                {
                    Posicao pos;

                    if (peca.Cor == Cor.Branca)
                    {
                        pos = new Posicao(destino.Linha - 1, destino.Coluna);
                    }
                    else
                    {
                        pos = new Posicao(destino.Linha + 1, destino.Coluna);
                    }

                    pecaCapturada = Tabuleiro.RetirarPeca(pos);

                    PecasCapturadas.Add(pecaCapturada);
                }

            }

            return pecaCapturada;

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

            foreach (var item in Pecas)
            {
                if (item.Cor == cor)
                {
                    emJogo.Add(item);
                }
            }

            emJogo.ExceptWith(Capturadas(cor));

            return emJogo;

        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {

            Xeque = false;

            var peca = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, peca);
                throw new TabuleiroException("Não pode se colocar em check, movimento inválido.");
            }

            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }

            if (ValidarXequeMate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudarJogador();
            }

             
            //Jogada Especial En Passant
            VulneravelEnPassant = null;

            var pecaMovida = Tabuleiro.Peca(destino);

            if (pecaMovida is Peao && (destino.Linha == origem.Linha - 2 || destino.Linha == origem.Linha + 2))
            {
                VulneravelEnPassant = pecaMovida;
            }
            
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca capturada)
        {

            Peca peca = Tabuleiro.RetirarPeca(destino);
            peca.QtdMovimentos--;

            if (capturada != null)
            {
                Tabuleiro.ColocarPeca(capturada, destino);
                PecasCapturadas.Remove(capturada);
            }

            Tabuleiro.ColocarPeca(peca, origem);

            //Jogada especial roque pequeno
            if (peca is Rei && destino.Coluna == origem.Coluna + 2)
            {

                var torreOrigem = new Posicao(origem.Linha, origem.Coluna + 3);
                var torreDestino = new Posicao(origem.Linha, origem.Coluna + 1);

                var torre = Tabuleiro.RetirarPeca(torreDestino);
                torre.QtdMovimentos--;
                Tabuleiro.ColocarPeca(torre, torreOrigem);

            }

            //Jogada especial roque grande
            if (peca is Rei && destino.Coluna == origem.Coluna - 2)
            {
;                var torreOrigem = new Posicao(origem.Linha, origem.Coluna - 4);
                var torreDestino = new Posicao(origem.Linha, origem.Coluna - 1);

                var torre = Tabuleiro.RetirarPeca(torreDestino);
                torre.QtdMovimentos--;
                Tabuleiro.ColocarPeca(torre, torreOrigem);

            }

            // Jogada especial en passant
            if (peca is Peao)
            {

                if (origem.Coluna != destino.Coluna)
                {
                    var peao = Tabuleiro.RetirarPeca(destino);
                    Posicao pos;

                    if (peca.Cor == Cor.Branca)
                    {
                        pos = new Posicao(3, destino.Coluna);
                    }
                    else
                    {
                        pos = new Posicao(4, destino.Coluna);
                    }

                    Tabuleiro.ColocarPeca(peao, pos);

                }

            }

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
            if (!Tabuleiro.Peca(origem).MovimentoPossivel(destino))
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
            ColocarNovaPeca('b', 1, new Cavalo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('c', 1, new Bispo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 1, new Rainha(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 1, new Rei(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('f', 1, new Bispo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('g', 1, new Cavalo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('a', 2, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('b', 2, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('c', 2, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('d', 2, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('e', 2, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('f', 2, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('g', 2, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('h', 2, new Peao(Tabuleiro, Cor.Preta, this));

            ColocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('b', 8, new Cavalo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 8, new Bispo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 8, new Rainha(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 8, new Rei(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('f', 8, new Bispo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('g', 8, new Cavalo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('h', 8, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('a', 7, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('b', 7, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('c', 7, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('d', 7, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('e', 7, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('f', 7, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('g', 7, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('h', 7, new Peao(Tabuleiro, Cor.Branca, this));

        }

        public Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            return Cor.Branca;

        }

        public bool EstaEmXeque(Cor cor)
        {

            var rei = ObterRei(cor);

            if (rei == null) throw new TabuleiroException($"Não existe um rei no tabuleiro da cor {cor}.");

            foreach (var peca in PecasEmJogo(Adversaria(cor)))
            {

                bool[,] movimentosPossiveis = peca.MovimentosPosiveis();

                if (movimentosPossiveis[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }

            }

            return false;

        }

        public bool ValidarXequeMate(Cor cor)
        {

            if (!EstaEmXeque(cor))
            {
                return false;
            }

            foreach (var item in PecasEmJogo(cor))
            {
                var movimentosPossiveis = item.MovimentosPosiveis();

                for (int i = 0; i < Tabuleiro.Linhas; i++)
                {
                    for (int y = 0; y < Tabuleiro.Colunas; y++)
                    {
                        if (movimentosPossiveis[i, y])
                        {
                            var origem = item.Posicao;
                            var destino = new Posicao(i, y);
                            var pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }

            }

            return true;

        }

        private Peca ObterRei(Cor cor)
        {
            foreach (Peca peca in PecasEmJogo(cor))
            {
                if (peca is Rei)
                {
                    return peca;
                }
            }
            return null;
        }

    }
}
