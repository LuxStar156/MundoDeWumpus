using System;
using System.Collections.Generic;

namespace MundoDeWumpus
{
    public class Mapa
    {
        /// <summary>
        /// Se inicializa la matriz de casillas con una lista de entidades 
        /// y el jugador
        /// </summary>
        private List<Entidad>[,] _matriz;
        private Jugador _jugador;

        /// <summary>
        /// Constructor del mapa y de los valores iniciales del jugador
        /// </summary>
        public Mapa(int filas, int columnas)
        {
            Matriz = new List<Entidad>[filas, columnas];
            Jugador = new Jugador(0, 0, 0, 3);
        }

        /// <summary>
        /// Funcion que pinta el tablero en consola
        /// </summary>
        public void PintarPantalla()
        {
            Console.Clear();
            Console.WriteLine("El mundo de Wumpus");

            Console.Write(Jugador.Puntos + " Puntos - " + Jugador.Vidas + " Vidas");
            Console.WriteLine();

            for (int i = 0; i < Matriz.GetLength(0); i++)
            {
                for (int j = 0; j < Matriz.GetLength(1); j++)
                {
                    if (Matriz[i, j] != null && Matriz[i, j].Count > 0 && Matriz[i, j][0] is Jugador)
                    {
                        string celda = Matriz[i, j][0]?.Nombre.Substring(0, 1) ?? " ";
                        Console.Write($"[{celda}] ");
                    }
                    else
                    {
                        Console.Write($"[] ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
        /// <summary>
        /// funcion que pobla el tablero con las entidades
        /// </summary>
        /// <param name="filas"></param>
        /// <param name="columnas"></param>
        public void PoblarTablero(int filas, int columnas)
        {
            for (int i = 0; i < Matriz.GetLength(0); i++)
            {
                for (int j = 0; j < Matriz.GetLength(1); j++)
                {
                    Matriz[i, j] = new List<Entidad>();
                }
            }

            Random rand = new Random();

            int oroFila = rand.Next(filas);
            int oroColumna = rand.Next(columnas);
            Matriz[oroFila, oroColumna].Add(new Oro(oroFila, oroColumna));

            int wumpusFila = rand.Next(filas);
            int wumpusColumna = rand.Next(columnas);
            Matriz[wumpusFila, wumpusColumna].Add(new Wumpus(wumpusFila, wumpusColumna));

            int numGrietas = rand.Next(1, 5);
            for (int i = 0; i < numGrietas; i++)
            {
                int grietaFila = rand.Next(filas);
                int grietaColumna = rand.Next(columnas);
                Matriz[grietaFila, grietaColumna].Add(new Grieta(grietaFila, grietaColumna));
            }

            do
            {
                int jugadorFila = rand.Next(filas);
                int jugadorColumna = rand.Next(columnas);
                if (Matriz[jugadorFila, jugadorColumna].Count == 0)
                {
                    Matriz[jugadorFila, jugadorColumna].Add(Jugador);
                    Jugador.I = jugadorFila;
                    Jugador.J = jugadorColumna;
                    break;
                }
            } while (true);
        }

        /// <summary>
        /// Funcion que mueve al jugador en el tablero
        /// </summary>
        /// <param name="nuevaFila"></param>
        /// <param name="nuevaColumna"></param>
        /// <returns></returns>
        public bool MoverJugador(int nuevaFila, int nuevaColumna)
        {
            bool ganar = false;

            if (nuevaFila >= 0 && nuevaFila < Matriz.GetLength(0) && nuevaColumna >= 0 && nuevaColumna < Matriz.GetLength(1))
            {
                Matriz[Jugador.I, Jugador.J].Remove(Jugador);
                Jugador.I = nuevaFila;
                Jugador.J = nuevaColumna;

                ganar = VerificarEstadoJuego();

                Matriz[Jugador.I, Jugador.J].Add(Jugador);
            }

            return ganar;
        }

        /// <summary>
        /// Funcion que verifica el estado del juego
        /// </summary>
        /// <returns></returns>
        public bool VerificarEstadoJuego()
        {
            if (Matriz[Jugador.I, Jugador.J].Count > 0)
            {
                Entidad entidad = Matriz[Jugador.I, Jugador.J][0];

                if (entidad is Oro)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("¡Has encontrado el oro! ¡Has ganado!");
                    Console.ResetColor();
                    Jugador.Puntos++;
                    return true;
                }
                else if (entidad is Wumpus)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Te has encontrado con el Wumpus! ¡Has perdido!");
                    Console.ResetColor();
                    Jugador.Vidas = Jugador.Vidas - 3;
                    return true;
                }
                else if (entidad is Grieta)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Has caído en una grieta! ¡Has perdido!");
                    Console.ResetColor();
                    Jugador.Vidas--;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Funcion que verifica si hay entidades adyacentes al jugador
        /// </summary>
        public void Interactuar()
        {
            for (int i = Jugador.I - 1; i <= Jugador.I + 1; i++)
            {
                for (int j = Jugador.J - 1; j <= Jugador.J + 1; j++)
                {
                    if (i >= 0 && j >= 0 && i < Matriz.GetLength(0) && j < Matriz.GetLength(1))
                    {
                        foreach (Entidad entidad in Matriz[i, j])
                        {
                            if (entidad is Oro)
                            {
                                Oro.AdyacenteOro();
                                break;
                            }
                            else if (entidad is Wumpus)
                            {
                                Wumpus.AdyacenteWumpus();
                                break;
                            }
                            else if (entidad is Grieta)
                            {
                                Grieta.AdyacenteGrieta();
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Getters y Setters de la matriz y el jugador
        /// </summary>
        public List<Entidad>[,] Matriz { get => _matriz; set => _matriz = value; }
        public Jugador Jugador { get => _jugador; set => _jugador = value; }
    }
}