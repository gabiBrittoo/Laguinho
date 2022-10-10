using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaguinhoPeixes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("------------Bem vindo ao jogo da pesca------------");
            Console.ReadLine();
            Console.Write("\n\nTemos de 1 a 50 posições no nosso laguinho. Cada jogador " +
                  "\ndeve escolher uma posição para descobrir se pegou ou não um dos peixes");
            Console.ReadLine();
            Console.WriteLine("\n\nClique ENTER para iniciar o jogo!");
            Console.ReadLine();
            Console.WriteLine("********************************************************");
            Console.ReadLine();



            //declaração das variáveis 
            int jogadores;
            int tentativasjogadores;
            bool empate = false;
            int nPeixes;
            String[,] lago = new String[5, 10];




            Console.Write("Informe a quantidade de jogadores:  "); //pega a quantidade de jogadores
            jogadores = int.Parse(Console.ReadLine());




            Console.Write("Informe quantas tentativas cada jogador vai ter: "); //pega a quantidade de tentativas que cada jogador vai ter direito 
            tentativasjogadores = int.Parse(Console.ReadLine());




            Console.Write("Informe o número de peixes de 1 a 50 (quanto menos peixe tiver mais difícil fica) "); //Pega o número de peixes
            nPeixes = int.Parse(Console.ReadLine());

            while(nPeixes > 50)// caso o usuário coloque um número maior que 50, para n travar o programa ele manda essa msg
            {
                Console.Write("Nosso laguinho só comporta 50 peixinhos, digite um número menor ou igual: ");
                nPeixes = int.Parse(Console.ReadLine());

            }


            String[] nomes = new string[jogadores];
            int[] pescados = new int[jogadores];




            //pega o nome da quantidade de jogadores informados 
            for (int i = 0; i < jogadores; i++)
            {
                Console.Write("Nome " + (i + 1) + "º jogador: ");
                nomes[i] = Console.ReadLine();
            }




            //começando a fazer o laguinho
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                    lago[i, j] = " ";
            }





            for (int i = 0; i < nPeixes; i++)
            {
                Random aleatorio = new Random();
                int x, y;
                do
                {
                    x = aleatorio.Next(0, 5);
                    y = aleatorio.Next(0, 10);
                } while (lago[x, y] != " ");





                lago[x, y] = "p";
            }





            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                   
                    Console.Write("[" + (i + 1) + "," + (j + 1) + "] ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();




            //faznedo o laguinho funcionar de acordo com a quantidade de tentativas informadas pelo usuário
            for (int t = 0; t < tentativasjogadores; t++)
            {
                for (int jog = 0; jog < jogadores; jog++)
                {
                    int jogadaX;
                    int jogadaY;
                    Console.WriteLine("-------------------------");
                    Console.WriteLine((t + 1) + "ª tentativa " + nomes[jog] + ": ");
                    Console.WriteLine("*************************");





                    Console.Write("X: "); // x é a linha
                    jogadaX = int.Parse(Console.ReadLine());





                    Console.Write("Y: "); //y é a coluna
                    jogadaY = int.Parse(Console.ReadLine());




                    //lógica para ver se acertou ou errou
                    if (lago[jogadaX - 1, jogadaY - 1] == "p")
                    {
                        // Acertou
                        Console.WriteLine("Conseguiu pescar :)");
                        lago[jogadaX - 1, jogadaY - 1] = "*";
                        pescados[jog]++;
                    }
                    else
                    {
                        // Errou
                        Console.WriteLine("Poxa! Não foi dessa vez :(");
                        lago[jogadaX - 1, jogadaY - 1] = "X";
                    }
                }
                Console.WriteLine();
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (lago[i, j] != " " && lago[i, j] != "p")
                        {
                            if (lago[i, j] == "*")
                                Console.Write("  *   "); //  * eh quando alguem acertou o peixe
                            else
                                Console.Write("  X   "); // X eh quando alguem errou o peixe
                        }
                        else
                            Console.Write("[" + (i + 1) + "," + (j + 1) + "] ");
                    }
                    Console.WriteLine();
                }

               

                Console.WriteLine();





                Console.WriteLine();
            }



            for (int i = 0; i < jogadores; i++)
            {
                if (pescados[i] == pescados[i+1])
                {
                    Console.WriteLine("DEU EMPATE");
                    empate = true;
                    
                    break;

                }
                else
                {
                    
                    Console.WriteLine("O vencedor foi " + jogadores + " com " + pescados.Max() + " peixes!!!");
                   
                }

                if (empate = true)
                {
                    break;
                }
            }
           


            Console.Read();


        }
    }
}
