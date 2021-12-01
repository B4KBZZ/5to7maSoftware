using MenuesConsola;
using Software;
using System;

namespace Admin.Consola.menu
{
    public class MenuAltaEmpleado: MenuComponente
    {
        public Empleado Categoria { get; set; }
        public override void mostrar()
        {
            base.mostrar();
            Console.WriteLine();
            var nombre = prompt("Ingrese nombre Empleado: ");
            Categoria = new Empleado(nombre);
            try
            {
                AdoSoftware.ADO.AgregarRubro(Categoria);
                Console.WriteLine("Empleado agregada con exito");
            }
            catch (Exception e)
            {
                Console.WriteLine($"No se pudo cargar el empleado por: {e.Message}");
            }
            Console.ReadKey();
        }
    }
}