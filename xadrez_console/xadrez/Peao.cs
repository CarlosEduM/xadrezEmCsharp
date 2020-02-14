using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(posicao.linha, posicao.coluna);

            if(cor == Cor.Branca)
            {
                pos.linha--;
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    if(tab.Peca(pos) == null)
                    {
                        mat[pos.linha, pos.coluna] = true;

                        if (qteMovimentos == 0)
                        {
                            pos.linha--;
                            if (tab.posicaoValida(pos) && podeMover(pos))
                            {
                                if(tab.Peca(pos) == null)
                                {
                                    mat[pos.linha, pos.coluna] = true;
                                }
                            }
                            pos.linha++;
                        }
                    }
                }

                pos.coluna++;
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    if(tab.Peca(pos) != null)
                    {
                        mat[pos.linha, pos.coluna] = true;
                    }
                } 

                pos.coluna -= 2;
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    if (tab.Peca(pos) != null)
                    {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }
            }
            else
            {
                pos.linha++;
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    if (tab.Peca(pos) == null)
                    {
                        mat[pos.linha, pos.coluna] = true;

                        if (qteMovimentos == 0)
                        {
                            pos.linha++;
                            if (tab.posicaoValida(pos) && podeMover(pos))
                            {
                                if (tab.Peca(pos) == null)
                                {
                                    mat[pos.linha, pos.coluna] = true;
                                }
                            }
                            pos.linha--;
                        }
                    }
                }

                pos.coluna++;
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    if (tab.Peca(pos) != null)
                    {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }

                pos.coluna -= 2;
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    if (tab.Peca(pos) != null)
                    {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
