using et12.edu.ar.MenuesConsola;
using Software;
using System;
using et12.edu.ar.AGBD.Ado;
using System.Collections.Generic;
using Software.AdoMySQL;

    namespace Admin.Consola.menu
{ 
    public class MenuAltaCliente: MenuComponente

    {
        private Cajero Cajero;
        private object AdoGerente;
        private object AdoAGBD; 
        public Cliente Cliente { get; set; }
        private object ReadPassword(string v)
        {
            throw new NotImplementedException();
        }
        public override void mostrar()
        
        {
            base.mostrar();

            var dni = Convert.ToInt32(prompt("Ingrese DNI"));
            var nombre = prompt("Ingrese nombre cliente");
            var apellido = prompt("Ingrese apellido");
            //Uso la libreria System.ReadLine para leer una contraseña
            var pass = ReadPassword("Ingrese contraseña: ");

            Cajero = new Cajero()
            {
                Apellido = apellido,
                Nombre = nombre,
                Dni = dni,
                Password = pass
            };
            
            try
            {
                AdoGerente.Ado.AltaCliente(Cliente);
                Console.WriteLine("Cliente dada de alta con exito");
            }
            catch (Exception e)
            {
                Console.WriteLine($"No se pudo dar de alta: {e.Message}");
            }
            Console.ReadKey();
        }     
    }

    internal class Cajero
    {
        public Cajero()
        {
        }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public object Password { get; set; }
    }
}