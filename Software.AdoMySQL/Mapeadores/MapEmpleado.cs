using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Collections.Generic;
using softwareFactory.Core;
using System.Data;
namespace softwareFactory.AdoMySQL.Mapeadores
{
    public class MapEmpleado
{
        public MapEmpleado(AdoAGBD ado):base(ado)
        {
            Tabla = "Empleado";
        }
        public override Empleado ObjetoDesdeFila(DataRow fila)
            => new Empleado(
                Cuil: Convert.ToInt32(fila["Cuil"]),
                Nombre : fila["Nombre"].ToString()

                Apellido : fila["Apellido"].ToString(),
                Contratacion : Convert.ToDateTime(fila["Contratacion"])
            );
        public void altaEmpleado(Empleado empleado)
            => EjecutarComandoCon("altaEmpleado", ConfigurarAltaEmpleado, PostAltaEmpleado, empleado);
        public void ConfigurarAltaEmpleado(Empleado empleado)
        {
            SetComandoSP("altaEmpleado");

            BP.CrearParametro("unCuiL")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(Empleado.Cuil)
                .AgregarParametro();

            BP.CrearParametro("Nombre")
                .SetTipoVarchar(50)
                .SetValor(Empleado.Nombre)
                .AgregarParametro();

            BP.CrearParametro("Apellido")
                .SetTipoVarchar(50)
                .SetValor(Empleado.Apellido)
                .AgregarParametro();

            BP.CrearParametro("Contratacion")
                .SetTipoDatetime
                SetValor(Empleado.Contratacion)
                .AgregarParametro();
        }
        public List<empleado> ObtenerEmpleados() => ColeccionDesdeTabla();
    }
}