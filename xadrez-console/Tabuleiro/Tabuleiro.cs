﻿namespace tabuleiro
{
    class Tabuleiro
    {

        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {

            Linhas = linhas;
            Colunas = colunas;

            Pecas = new Peca[linhas, colunas];

        }

        public Peca GetPeca(int linha, int coluna)
        {

            return Pecas[linha, coluna];

        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {

            peca.Posicao = posicao;
            Pecas[peca.Posicao.Linha, peca.Posicao.Coluna] = peca;

        }

    }
}
