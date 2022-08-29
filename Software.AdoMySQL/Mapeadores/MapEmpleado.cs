using et12.edu.ar.AGBD.Ado;
using Software;
using System;
using System.Collections.Generic;
using System.Data;
namespace softwareFactory.AdoMySQL.Mapeadores
{
    public class MapEmpleado
{
    public string Tabla { get; private set; }
    public object PostAltaEmpleado { get; private set; }
        public object BP { get; private set; }

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

        private void EjecutarComandoCon(string v, Action<Empleado> configurarAltaEmpleado, object postAltaEmpleado, Empleado empleado)
        {
            throw new NotImplementedException();
        }

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

        private object SetValor(DateTime contratacion)
        {
            throw new NotImplementedException();
        }

        private void SetComandoSP(string v)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> ObtenerEmpleados() => ColeccionDesdeTabla();

        private List<Empleado> ColeccionDesdeTabla()
        {
            throw new NotImplementedException();
        }
    }
}