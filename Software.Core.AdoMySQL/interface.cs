using System.Collections.Generic;
using Software.Core;

namespace Software.Core.Ado
{
    public interface IAdo
    {
        //Acciones para la entidad Cliente
        void AltaCliente(Cliente cliente );
        List<Cliente> ObtenerProductos();

        void AltaC(cliente cliente);
        List<cliente> ObtenerProductos();
    }
}