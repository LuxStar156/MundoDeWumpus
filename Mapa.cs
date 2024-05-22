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
        private int _jugadorFila;
        private int _jugadorColumna;

        public Mapa(int filas, int columnas)
        {
            this.Matriz = new Entidad[filas, columnas];
        }

        private static void PintarPantalla(ref String[,] matriz)
        {
            Console.Clear();
            Console.WriteLine("El mundo de Wumpus");

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write("[{0}] ", matriz[i, j]);
                }
                Console.WriteLine();
            }


            Console.WriteLine();
        }

        private static void PoblarTablero(ref String[,] matriz, int elementosA, int elementosB,int )
        {
            Random rand = new Random();

            int oroFila = rand.Next(0, elementosA);
            int oroColumna = rand.Next(0, elementosB);
            matriz[oroFila, oroColumna] = "O";

            int wumpusFila = rand.Next(0, elementosA);
            int wumpusColumna = rand.Next(0, elementosB);
            matriz[wumpusFila, wumpusColumna] = "W";

            int numPozos = rand.Next(1, 5);
            for (int i = 0; i < numPozos; i++)
            {
                int pozoFila = rand.Next(0, elementosA);
                int pozoColumna = rand.Next(0, elementosB);
                matriz[pozoFila, pozoColumna] = "P";
            }

            JugadorGia = rand.Next(0, elementosA);
            JugadorColumna = rand.Next(0, elementosB);

            if (oroFila == jugadorFila && oroColumna == jugadorColumna)
            {
                jugadorFila = 0;
                jugadorColumna = 0;
            }


        }


        private static void AgregarEntidad(ref String[,] matriz, Entidad entidad)
        {
            matriz[entidad.I, entidad.J] = entidad.Nombre;
        }

        private static void EliminarEntidad(ref String[,] matriz, Entidad entidad)
        {
            matriz[entidad.I, entidad.J] = " ";
        }

        public Entidad[,] Matriz { get => _matriz; set => _matriz = value; }
        public int JugadorFila { get => _jugadorFila; set => _jugadorFila = value; }
        public int JugadorColumna { get => _jugadorColumna; set => _jugadorColumna = value; }
    }

}
