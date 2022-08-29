using System;

namespace Software
{
    public class Proyecto
    {
        public int Id { get; set; }

        public Cliente Cliente { get; set; }

        public string Descripcion { get; set; }

        public decimal Presopuesto { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime Fin { get; set; }
    }
}