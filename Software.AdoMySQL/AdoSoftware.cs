using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;
using softwareFactory.AdoMySQL.Mapeadores;

    namespace Software.AdoMySQL
    {
    public class AdoSoftware
    {
        public AdoAGBD Ado {get; set;}
        public MapCliente MapCliente {get; set;}
        public static object ADO { get; set; }

        public AdoSoftware(AdoAGBD ado)
        {
            Ado = ado;
            MapCliente = new MapCliente (Ado);
        }

        public void AltaCliente (Cliente cliente) => MapCliente.AltaCliente (cliente);
        public List<Cliente> ObtenerClientes()    => MapCliente.ObtenerClientes(); 
        var AdoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "root");
    }
}