using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao{ get; set;}
        public Cor cor { get; set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }

        public void incrementarQteMovimentos()
        {
            this.qteMovimentos++;
        }

        public abstract bool[,] movimentosPossiveis();
    }
}
