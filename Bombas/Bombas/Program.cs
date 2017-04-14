using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombas
{
    class Program
    {
        static void Main(string[] args)
        {
            int m, n, d, b;

            Console.Write("Filas: ");
            m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Columnas: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Alcance: ");
            d = Convert.ToInt32(Console.ReadLine());
            Console.Write("Bombas: ");
            b = Convert.ToInt32(Console.ReadLine());

            if (b < (m * n))
            {
                string[,] matriz = new string[m, n];
                List<int[]> bombas = new List<int[]>();

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matriz[i, j] = "O";
                    }
                }

                for (int i = 0; i < b; i++)
                {
                    Console.Write("Coordenadas (X Y) bomba {0}: ", i + 1);
                    string linea = Console.ReadLine();
                    var datos = linea.Split(' ').Select(Int32.Parse).ToList();
                    matriz[datos[0], datos[1]] = "X";
                    if (i == 0)
                    {
                        int[] bomb = { datos[0], datos[1] };
                        bombas.Add(bomb);
                    }
                }

                Console.WriteLine();

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write("{0} ", matriz[i, j]);
                    }
                    Console.WriteLine();
                }

                int aux = 0;
                bool bandera = false;
                bool salida = false;

                while (!salida)
                {
                    bandera = false;
                    List<int[]> lista = new List<int[]>();
                    foreach (int[] elemento in bombas)
                    {
                        matriz[elemento[0], elemento[1]] = "S";
                        aux = 0;
                        while (aux <= d && elemento[1] + aux < n)
                        {
                            if (matriz[elemento[0], elemento[1] + aux] == "X")
                            {
                                int[] bomb = { elemento[0], elemento[1] + aux };
                                lista.Add(bomb);
                                bandera = true;
                            }
                            else
                            {
                                matriz[elemento[0], elemento[1] + aux] = "S";
                            }
                            aux++;
                        }
                        aux = 0;
                        while (aux <= d && elemento[1] - aux >= 0)
                        {
                            if (matriz[elemento[0], elemento[1] - aux] == "X")
                            {
                                int[] bomb = { elemento[0], elemento[1] - aux };
                                lista.Add(bomb);
                                bandera = true;
                            }
                            else
                            {
                                matriz[elemento[0], elemento[1] - aux] = "S";
                            }
                            aux++;
                        }
                        aux = 0;
                        while (aux <= d && elemento[0] + aux < m)
                        {
                            if (matriz[elemento[0] + aux, elemento[1]] == "X")
                            {
                                int[] bomb = { elemento[0] + aux, elemento[1] };
                                lista.Add(bomb);
                                bandera = true;
                            }
                            else
                            {
                                matriz[elemento[0] + aux, elemento[1]] = "S";
                            }
                            aux++;
                        }
                        aux = 0;
                        while (aux <= d && elemento[0] - aux >= 0)
                        {
                            if (matriz[elemento[0] - aux, elemento[1]] == "X")
                            {
                                int[] bomb = { elemento[0] - aux, elemento[1] };
                                lista.Add(bomb);
                                bandera = true;
                            }
                            else
                            {
                                matriz[elemento[0] - aux, elemento[1]] = "S";
                            }
                            aux++;
                        }
                    }
                    if (bandera)
                    {
                        bombas.AddRange(lista);
                    }
                    else
                    {
                        salida = true;
                    }
                }

                Console.WriteLine();
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write("{0} ", matriz[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Demasiadas bombas");
            }

            Console.ReadKey();
        }
    }
}
