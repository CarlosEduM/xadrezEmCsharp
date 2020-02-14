using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrex partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrex partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p == null || p.cor != cor;
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(posicao.linha, posicao.coluna);

            //n
            pos.linha--;
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //ne
            pos.coluna++;
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //l
            pos.linha++;
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //se
            pos.linha++;
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //s
            pos.coluna--;
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //so
            pos.coluna--;
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //o
            pos.linha--;
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //no
            pos.linha--;
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // #jogada especial roque
            if(qteMovimentos == 0 && !partida.xeque)
            {
                // #roque pequeno
                Posicao posRoqueP = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeTorreParaRoque(posRoqueP))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);

                    if(tab.Peca(p1) == null && tab.Peca(p2) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

                // #roque grande
                Posicao posRoqueG = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeTorreParaRoque(posRoqueG))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);

                    if (tab.Peca(p1) == null && tab.Peca(p2) == null && tab.Peca(p3) == null)
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
