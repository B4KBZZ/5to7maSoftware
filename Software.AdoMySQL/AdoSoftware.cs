using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;

namespace Software.AdoMySQL
{
    public class AdoSoftware
    {
        public AdoAGBD Ado {get; set};
        public MapCliente MapCliente {get; set};
        public AdoSoftware(AdoAGBD ado)
        {
            Ado = ado;
            MapCliente = new MapCliente (Ado);
        }

        public void AltaCliente (cliente cliente) => MapCliente.AltaCliente (cliente);
        public List<Cliente> ObtenerClientes()    => MapCliente.ObtenerClientes(); 
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "root");
    }
}