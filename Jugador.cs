using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundoDeWumpus
{
    public class Jugador : Entidad
    {
        private int _puntos;
        private int _vidas;

        public Jugador(int i, int j, int puntos, int vidas) : base("Jugador", i, j)
        {
            this.Puntos = puntos;
            this.Vidas = vidas;
        }

        public int Puntos { get => _puntos; set => _puntos = value; }
        public int Vidas { get => _vidas; set => _vidas = value; }


    }

}
