using Software;

using System.Collections.Generic;
namespace software.Core
{
    public interface IAdo
    {
        void AltaCliente(Cliente cliente);

        List<Cliente> ObtenerClientes();       
        
        void AltaEmpleado(Empleado empleado);

        List<Empleado> ObtenerEmpleados();      
    }
}