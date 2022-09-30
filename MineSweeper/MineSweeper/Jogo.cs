using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class Jogo
    {
        public static void ComecarJogo()
        {
            Console.ResetColor();
            var primeiraCriacao = CriarTabuleiro();
            char[] tabuleiro = primeiraCriacao.Item1;
            int[] bombas = primeiraCriacao.Item2;

            ImprimirTabuleiro(tabuleiro, -1, false, bombas);

            string teclaPressionada = Console.ReadLine();
            teclaPressionada = teclaPressionada.ToUpper();

            int indice = VerificarPressionado(teclaPressionada, tabuleiro, bombas);

            tabuleiro = VerificarBombas(indice, tabuleiro, bombas);

            ContinuarJogo(tabuleiro, bombas);
        }

        public static void ContinuarJogo(char[] tabuleiro, int[] bombas)
        {

            string teclaPressionada = Console.ReadLine();
            teclaPressionada = teclaPressionada.ToUpper();

            int indice = VerificarPressionado(teclaPressionada, tabuleiro, bombas);

            tabuleiro = VerificarBombas(indice, tabuleiro, bombas);

            ContinuarJogo(tabuleiro, bombas);
        }
        public static Tuple<char[], int[]> CriarTabuleiro()
        {
            char[] tabuleiro = new char[100];

            Random rand = new Random();

            // Colocar os valores no tabuleiro

            for (int i = 0; i < tabuleiro.Length; i++)
            {
                tabuleiro[i] = 'X';
            }

            // Colocar as bombas randomicamente no tabuleiro

            int[] posicaoBombas = new int[10];

            for (int i = 0; i < 10; i++)
            {

                posicaoBombas[i] = rand.Next(0, 100);
                //tabuleiro[posicaoBombas[i]] = 'B';
            }

            // Imprimir o tabuleiro

            return Tuple.Create(tabuleiro, posicaoBombas);

        }
        public static char[] ImprimirTabuleiro(char[] tabuleiro, int indice, bool terminarJogo, int[] bombas)
        {
            if (terminarJogo)
            {
                foreach(int bomba in bombas)
                {
                    tabuleiro[bomba] = 'B';
                }
            }
            Console.Clear();

            char posicao = 'A';

            for (int i = 1; i <= 10; i++)
            {
                string numero = i.ToString() + new string(' ', 1);
                
                if (i == 1)
                {
                    Console.Write($"  {numero}");
                }
                else
                {
                    Console.Write($"{numero}");
                }
            }

            for (int i = 0; i < 10; i++)
            {

                Console.WriteLine();
                int indiceHelper = 0;

                switch (i)
                {
                    case 0: posicao = 'A'; indiceHelper = 0; break;
                    case 1: posicao = 'B'; indiceHelper = 10; break;
                    case 2: posicao = 'C'; indiceHelper = 20; break;
                    case 3: posicao = 'D'; indiceHelper = 30; break;
                    case 4: posicao = 'E'; indiceHelper = 40; break;
                    case 5: posicao = 'F'; indiceHelper = 50; break;
                    case 6: posicao = 'G'; indiceHelper = 60; break;
                    case 7: posicao = 'H'; indiceHelper = 70; break;
                    case 8: posicao = 'I'; indiceHelper = 80; break;
                    case 9: posicao = 'J'; indiceHelper = 90; break;


                }
                for (int j = 0; j < 10; j++)
                {
                    if (j == 0)
                    {
                        if(tabuleiro[j + indiceHelper] != 'X')
                        {
                            Console.Write($"{posicao}");
                            Console.ForegroundColor = ConsoleColor.Green;
                            if (tabuleiro[j + indiceHelper] == 'B')
                                Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($" {tabuleiro[j + indiceHelper]} ");
                            Console.ResetColor();
                            
                        } else
                        {
                            Console.Write($"{posicao} {tabuleiro[j + indiceHelper]} ");
                        }
                    } else
                    {
                        if (tabuleiro[j + indiceHelper] != 'X')
                        {  
                            Console.ForegroundColor = ConsoleColor.Green;
                            if (tabuleiro[j + indiceHelper] == 'B')
                                Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{tabuleiro[j + indiceHelper]} ");
                            Console.ResetColor();         
                        }
                        else
                        {
                            Console.Write($"{tabuleiro[j + indiceHelper]} ");
                        }
                        
                    }

                }

            }

            Console.WriteLine();

            return tabuleiro;
        }
        public static int VerificarPressionado(string inputUtilizador, char[] tabuleiro, int[] bombas)
        {

            string numeroInputUtilizador = string.Empty;
            string letraInputUtilizador = string.Empty;
            
            for(int i = 0; i < inputUtilizador.Length; i++)
            {
                Console.WriteLine(Char.IsDigit(inputUtilizador[i]));
                Console.WriteLine(Char.IsLetter(inputUtilizador[i]));
                
                if (Char.IsDigit(inputUtilizador[i]))
                {
                    numeroInputUtilizador += inputUtilizador[i];
                }

                if (Char.IsLetter(inputUtilizador[i]))
                {
                    letraInputUtilizador += inputUtilizador[i];
                }
            }

            if (numeroInputUtilizador.Length == 0 || letraInputUtilizador.Length == 0)
            {

                ImprimirTabuleiro(tabuleiro, -1, false, bombas);
                ContinuarJogo(tabuleiro, bombas);
                return 0;
            }

            int clicado = 0;

            switch (letraInputUtilizador)
            {
                case "A": clicado = 0; break;
                case "B": clicado = 10; break;
                case "C": clicado = 20; break;
                case "D": clicado = 30; break;
                case "E": clicado = 40; break;
                case "F": clicado = 50; break;
                case "G": clicado = 60; break;
                case "H": clicado = 70; break;
                case "I": clicado = 80; break;
                case "J": clicado = 90; break;
            }

            int indiceClicado = clicado + int.Parse(numeroInputUtilizador) - 1;

            return indiceClicado;

        }
        public static char[] VerificarBombas(int indice, char[] tabuleiro, int[] bombas)
        {

            for(int i = 0; i < bombas.Length; i++)
            {
                if (bombas[i] == indice)
                {
                    TerminarJogo(tabuleiro, bombas);
                }
            }
            int[] indicesParaVerificar = new int[4];

            for(int i = 0; i < indicesParaVerificar.Length; i++)
            {
                indicesParaVerificar[i] = -1;
            }

            if (indice == 0)
            {
                indicesParaVerificar[0] = indice + 1;
                indicesParaVerificar[1] = indice + 10;
            } else if(indice > 0 && indice < 9)
            {
                indicesParaVerificar[0] = indice - 1;
                indicesParaVerificar[1] = indice + 1;              
                indicesParaVerificar[1] = indice + 10;
            } else if (indice > 9 && indice < 89)
            {
                indicesParaVerificar[0] = indice - 10;
                indicesParaVerificar[1] = indice - 1;
                indicesParaVerificar[2] = indice + 1;
                indicesParaVerificar[3] = indice + 10;
            } else if (indice == 99)
            {
                indicesParaVerificar[0] = indice - 10;
                indicesParaVerificar[1] = indice - 1;
            } else if (indice > 90 && indice < 99)
            {
                indicesParaVerificar[0] = indice + 1;
                indicesParaVerificar[1] = indice - 1;
                indicesParaVerificar[2] = indice - 10;
            }

            int bombasEncontradas = 0;

            for (int i = 0; i < indicesParaVerificar.Length; i++)
            {
                if (indicesParaVerificar[i] == -1)
                    continue;

                for(int j = 0; j < bombas.Length; j++) { 
                    if(indicesParaVerificar[i] == bombas[j])
                    {
                        bombasEncontradas += 1;
                    }
                }
            }

            tabuleiro[indice] = char.Parse(bombasEncontradas.ToString());

            ImprimirTabuleiro(tabuleiro, indice, false, bombas);

            return tabuleiro;
        }
        public static void TerminarJogo(char[] tabuleiro, int[] bombas)
        {
            ImprimirTabuleiro(tabuleiro, -1, true, bombas);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A bomba explodiu e o jogo acabou!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Queres jogar outra vez? (Y/N)");
            string resposta = Console.ReadLine().ToUpper();

            if(resposta == "Y")
            {
                ComecarJogo();
            } else if(resposta == "N")
            {
                Environment.Exit(0);
            } else
            {
                TerminarJogo(tabuleiro, bombas);
            }
        }
    }
}