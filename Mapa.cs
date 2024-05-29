using System;
using System.Collections.Generic;
using System.Linq;
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
                    string celda = Matriz[i, j]?.Nombre ?? " ";
                    Console.Write($"[{celda}] ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private void PoblarTablero(int filas, int columnas)
        {
            Random rand = new Random();

            // Colocar el oro
            int oroFila = rand.Next(filas);
            int oroColumna = rand.Next(columnas);
            Matriz[oroFila, oroColumna] = new Oro(oroFila, oroColumna);

            // Colocar el Wumpus
            int wumpusFila = rand.Next(filas);
            int wumpusColumna = rand.Next(columnas);
            Matriz[wumpusFila, wumpusColumna] = new Wumpus(wumpusFila, wumpusColumna);

            // Colocar las grietas
            int numGrietas = rand.Next(1, 5);
            for (int i = 0; i < numGrietas; i++)
            {
                int grietaFila = rand.Next(filas);
                int grietaColumna = rand.Next(columnas);
                Matriz[grietaFila, grietaColumna] = new Grieta(grietaFila, grietaColumna);
            }

            // Colocar el jugador
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

        public void MoverJugador(int nuevaFila, int nuevaColumna)
        {
            if (nuevaFila >= 0 && nuevaFila < Matriz.GetLength(0) && nuevaColumna >= 0 && nuevaColumna < Matriz.GetLength(1))
            {
                Matriz[Jugador.I, Jugador.J] = null; // Limpia la posición anterior del jugador
                Jugador.I = nuevaFila;
                Jugador.J = nuevaColumna;
                Matriz[Jugador.I, Jugador.J] =Jugador;
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