using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MundoDeWumpus
{
    public class Mapa
    {
        private Entidad[,] _matriz;
        private Jugador _jugador;

        public Mapa(int filas, int columnas)
        {
            Matriz = new Entidad[filas, columnas];
            PoblarTablero(filas, columnas);
        }

        public void PintarPantalla()
        {
            Console.Clear();
            Console.WriteLine("El mundo de Wumpus");

            for (int i = 0; i < Matriz.GetLength(0); i++)
            {
                for (int j = 0; j < Matriz.GetLength(1); j++)
                {
                    string celda = Matriz[i, j]?.Nombre.Substring(0,1) ?? " ";
                    Console.Write($"[{celda}] ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private void PoblarTablero(int filas, int columnas)
        {
            Random rand = new Random();

            int oroFila = rand.Next(filas);
            int oroColumna = rand.Next(columnas);
            Matriz[oroFila, oroColumna] = new Oro(oroFila, oroColumna);

            int wumpusFila = rand.Next(filas);
            int wumpusColumna = rand.Next(columnas);
            Matriz[wumpusFila, wumpusColumna] = new Wumpus(wumpusFila, wumpusColumna);

            int numGrietas = rand.Next(1, 5);
            for (int i = 0; i < numGrietas; i++)
            {
                int grietaFila = rand.Next(filas);
                int grietaColumna = rand.Next(columnas);
                Matriz[grietaFila, grietaColumna] = new Grieta(grietaFila, grietaColumna);
            }

            do
            {
                int jugadorFila = rand.Next(filas);
                int jugadorColumna = rand.Next(columnas);
                if (Matriz[jugadorFila, jugadorColumna] == null)
                {
                    Jugador = new Jugador(jugadorFila, jugadorColumna, 0, 3);
                    Matriz[jugadorFila, jugadorColumna] = Jugador;
                    break;
                }
            } while (true);
        }

        public bool MoverJugador(int nuevaFila, int nuevaColumna)
        {
            bool ganar = false;

            if (nuevaFila >= 0 && nuevaFila < Matriz.GetLength(0) && nuevaColumna >= 0 && nuevaColumna < Matriz.GetLength(1))
            {
                Matriz[Jugador.I, Jugador.J] = null;
                Jugador.I = nuevaFila;
                Jugador.J = nuevaColumna;

                ganar = VerificarEstadoJuego();

                Matriz[Jugador.I, Jugador.J] = Jugador;

            }

            return ganar;
        }

        public bool VerificarEstadoJuego()
        {

            if (Matriz[Jugador.I, Jugador.J] is Oro)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("¡Has encontrado el oro! ¡Has ganado!");
                Console.ResetColor();
                return true;
            }
      
            else if (Matriz[Jugador.I, Jugador.J] is Wumpus)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡Te has encontrado con el Wumpus! ¡Has perdido!");
                Console.ResetColor();
                return true;
            }
            else if (Matriz[Jugador.I, Jugador.J] is Grieta)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡Has caído en una grieta! ¡Has perdido!");
                Console.ResetColor();
                return true;
            }
            
            return false;
        }

        public void Interactuar()
        {
            for (int i = Jugador.I - 1; i <= Jugador.I + 1; i++)
            {
                for (int j = Jugador.J - 1; j <= Jugador.J + 1; j++)
                {
                    if (i >= 0 && j >= 0 && i < Matriz.GetLength(0) && j < Matriz.GetLength(1))
                    {
                        if (Matriz[i, j] is Oro)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Se puede ver un resplandor cerca.");
                            Console.ResetColor();
                            break;

                        }else if (Matriz[i, j] is Wumpus)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Se siente mal olor.");
                            Console.ResetColor();
                            break;

                        }else if (Matriz[i, j] is Grieta)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Se siente la brisa.");
                            Console.ResetColor();
                            break;
                        }

                    }
                }
            }
        }

            public Entidad ObtenerEntidad(int fila, int columna)
        {
            return Matriz[fila, columna];
        }

        public Entidad[,] Matriz { get => _matriz; set => _matriz = value; }
        public Jugador Jugador { get => _jugador; set => _jugador = value; }
    }
}
