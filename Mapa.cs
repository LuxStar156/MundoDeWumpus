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

        private static void AgregarEntidad(ref String[,] matriz, Entidad entidad)
        {
            matriz[entidad.I, entidad.J] = entidad.Nombre;
        }

        private static void EliminarEntidad(ref String[,] matriz, Entidad entidad)
        {
            matriz[entidad.I, entidad.J] = " ";
        }

        public Entidad[,] Matriz { get => _matriz; set => _matriz = value; }
    }

}
