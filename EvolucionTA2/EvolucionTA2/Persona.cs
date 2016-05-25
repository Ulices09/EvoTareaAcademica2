using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolucionTA2
{
    public class Persona
    {
        private int codigo;
        private string nombre;
        private string apellido;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }        

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }        

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
    }
}
