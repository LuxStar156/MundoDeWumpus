using System;


namespace MundoDeWumpus
{
    public abstract class Entidad
    {
        private string _nombre;
        private int _i;
        private int _j;

        public Entidad(string nombre, int i, int j)
        {
            this.Nombre = nombre;
            this.I = i;
            this.J = j;
        }

        public void MostrarCoordenadas()
        {
            Console.WriteLine("Coordenadas de " + Nombre + ": " + I + ", " + J);
        }

        public string Nombre { get => _nombre; set => _nombre = value; }
        public int I { get => _i; set => _i = value; }
        public int J { get => _j; set => _j = value; }

    }

}
