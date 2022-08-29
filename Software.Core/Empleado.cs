using System;

namespace Software
{
    public class Empleado
    {
        public Empleado(string nombre)
        {
            Nombre = nombre;
        }

        public Empleado(object nombre, int Cuil, string Nombre)
        {
            Nombre1 = nombre;
        }

        public Empleado(int Cuil, string Nombre, string Apellido, DateTime Contratacion)
        {
            this.Cuil = Cuil;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Contratacion = Contratacion;
        }

        public int Cuil { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }
        
        public DateTime Contratacion { get; set; }
        public object Nombre1 { get; }
    }
}