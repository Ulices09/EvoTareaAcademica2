using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace EvolucionTA2
{
    public class TestClass
    {
        //1.- Valores Iguales
        public int Multiplicar(int num1, int num2)
        {
            return num1 * num2;
        }

        public string ParOImpar(int num)
        {
            if (num % 2 == 0)
                return "par";
            else
                return "impar";
        }

        //2.- Valores Diferentes
        public int Restar(int num1, int num2)
        {
            return num1 - num2;
        }

        public string GetLetra(string palabra, int pos)
        {
            return palabra.Substring(pos, pos);
        }

        //3.- Valores Nulos
        public string GetDato(string dato)
        {
            List<string> lista = new List<string>();
            lista.Add("Hola"); lista.Add("Mundo");

            foreach (string item in lista)
            {
                if (item == dato)
                    return item;
            }
            return null;
        }

        //4.- Valores boolean
        public bool NumeroEncontrado(int num)
        {
            List<int> lista = new List<int>();
            lista.Add(3);
            lista.Add(5);
            lista.Add(9);

            foreach (int item in lista)
            {
                if (item == num)
                    return true;
            }
            return false;
        }

        //5.- Arreglos
        public List<int> GetLista()
        {
            List<int> listaInt = new List<int>();
            listaInt.Add(1);
            listaInt.Add(2);
            listaInt.Add(3);

            return listaInt;
        }

        public List<string> GetPalabras()
        {
            List<string> lista = new List<string>();
            lista.Add("uno");
            lista.Add("dos");
            lista.Add("tres");
            return lista;
        }

        //6.- Objetos
        public Persona GetPersonaByCodigo(int codigo)
        {
            List<Persona> lista = new List<Persona>();
            Persona p = new Persona();
            p.Codigo = 1; p.Nombre = "Ulices"; p.Apellido = "Melendez";
            Persona p1 = new Persona();
            p1.Codigo = 2; p1.Nombre = "Luis"; p1.Apellido = "Lopez";
            lista.Add(p); lista.Add(p1);

            foreach (Persona item in lista)
            {
                if (item.Codigo == codigo)
                    return item;
            }
            return null;
        }

        public Persona GetPersonaByNombre(string nombre)
        {
            List<Persona> lista = new List<Persona>();
            Persona p = new Persona();
            p.Codigo = 1; p.Nombre = "Ulices"; p.Apellido = "Melendez";
            Persona p1 = new Persona();
            p1.Codigo = 2; p1.Nombre = "Luis"; p1.Apellido = "Lopez";
            lista.Add(p); lista.Add(p1);

            foreach (Persona item in lista)
            {
                if (item.Nombre == nombre)
                    return item;
            }
            return null;
        }

        //7.- Excepciones
        public void IngresoDatos(Persona persona)
        {
            if (persona.Codigo < 0) throw new Exception("Código debe ser mayor a cero");
            else if (String.IsNullOrEmpty(persona.Nombre)) throw new ArgumentException("Nombre no existe");
            else if (String.IsNullOrEmpty(persona.Apellido)) throw new ArgumentException("Apellido no existe");
        }

        public decimal Division(decimal num1, decimal num2)
        {
            if (num2 == 0) throw new ArgumentException("No se puede dividir entre cero");

            return num1 / num2;
        }

        //Archivos
        private SqlConnection AccesoDatos()
        {
            try
            {
                SqlConnection cn = new SqlConnection("Server=.;Database=EvolucionTA2;Trusted_Connection=true;");
                return cn;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede establecer conexión con la base de datos ", ex);
            }
        }

        public Persona GetPersonaPorCodigo(int codigo){

            SqlConnection conexion = AccesoDatos();
            List<Persona> lista = new List<Persona>();
            conexion.Open();
            string query = "SELECT * FROM Persona WHERE Codigo = {0}";
            string comando = String.Format(query, codigo);
            SqlCommand cmd = new SqlCommand(comando, conexion);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Persona p = new Persona();
                p.Codigo = r.GetInt32(0);
                p.Nombre = r.GetString(1);
                p.Apellido = r.GetString(2);
                lista.Add(p);
            }
            conexion.Close();
            return lista[0];
        }

        public List<Persona> GetPersonasPorNombre(string nombre)
        {

            SqlConnection conexion = AccesoDatos();
            List<Persona> lista = new List<Persona>();
            conexion.Open();
            string query = "SELECT * FROM Persona WHERE Nombre = '{0}'";
            string comando = String.Format(query, nombre);
            SqlCommand cmd = new SqlCommand(comando, conexion);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Persona p = new Persona();
                p.Codigo = r.GetInt32(0);
                p.Nombre = r.GetString(1);
                p.Apellido = r.GetString(2);
                lista.Add(p);
            }
            conexion.Close();
            return lista;
        }

        public int GetCantidadPersonas()
        {
            SqlConnection conexion = AccesoDatos();
            List<Persona> lista = new List<Persona>();
            conexion.Open();
            string query = "SELECT * FROM Persona";
            string comando = String.Format(query);
            SqlCommand cmd = new SqlCommand(comando, conexion);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Persona p = new Persona();
                p.Codigo = r.GetInt32(0);
                p.Nombre = r.GetString(1);
                p.Apellido = r.GetString(2);
                lista.Add(p);
            }
            conexion.Close();
            return lista.Count;
        }

        public void ModificarPersona(int codigo, string nombre, string apellido)
        {
            if (String.IsNullOrEmpty(nombre)) throw new ArgumentException("Ingrese un nombre");
            else if (String.IsNullOrEmpty(apellido)) throw new ArgumentException("Ingrese un apellido");

            SqlConnection conexion = AccesoDatos();
            conexion.Open();
            string query = "UPDATE Persona SET Nombre = '{0}', Apellido = '{1}' WHERE Codigo = {2}";
            string comando = String.Format(query, nombre, apellido, codigo);
            SqlCommand cmd = new SqlCommand(comando, conexion);
            cmd.ExecuteNonQuery();
            throw new Exception("Persona modificada");
        }

    }
}