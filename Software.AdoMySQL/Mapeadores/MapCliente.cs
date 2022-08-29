using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using Software;

namespace softwareFactory.AdoMySQL.Mapeadores
{
    public class MapCliente: Mapeador<Cliente>
    {
        public MapCliente(AdoAGBD ado):base(ado)
        {
            Tabla = "Cliente";
        }
        public override Cliente ObjetoDesdeFila(DataRow fila)
            => new Cliente(
                Cuit: Convert.ToInt32(fila["Cuit"]),
                RazonSocial : fila["RazonSocial"].ToString()
            );

        internal void AltaCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void altaCliente(Cliente cliente)
            => EjecutarComandoCon("altaCliente", ConfigurarAltaCliente, PostAltaCliente, cliente);

        private void PostAltaCliente(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void ConfigurarAltaCliente(Cliente cliente)
        {
            SetComandoSP("altaCliente");

            BP.CrearParametro("unCuit")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(cliente.Cuit)
                .AgregarParametro();
            BP.CrearParametro("unRazonSocial")
                .SetTipoVarchar(50)
                .SetValor(cliente.RazonSocial)
                .AgregarParametro();
        }
        public List<Cliente> ObtenerClientes() => ColeccionDesdeTabla();
    }
}