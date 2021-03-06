﻿using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    ImprimirPeca(tab.Peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        internal static void imprimirPartida(PartidaDeXadrex partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine($"Turno: {partida.turno}");

            if (!partida.terminada)
            {
                Console.WriteLine($"Aguardado jogador: {partida.jogadorAtual}");
                Console.WriteLine($"{((partida.xeque) ? "Xeque!" : null )}");
            }
            else
            {
                Console.WriteLine("Xequemate!");
                Console.WriteLine($"Vencedor: {partida.jogadorAtual}");
            }
        }

        private static void imprimirPecasCapturadas(PartidaDeXadrex partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));

            Console.Write("Pretas: ");
            ConsoleColor cor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));

            Console.ForegroundColor = cor;
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca x in conjunto)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine("]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor corOriginal = Console.BackgroundColor;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if(posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = corOriginal;
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        internal static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse($"{s[1]}");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca + " ");
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca + " ");
                    Console.ForegroundColor = aux;
                }
            }
        }
    }
}
