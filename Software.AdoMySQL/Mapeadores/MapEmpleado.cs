using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using Software;
using System;
using System.Collections.Generic;
using System.Data;
{
    
}

namespace softwareFactory.AdoMySQL.Mapeadores
{
    public class MapEmpleado: Mapeador<Empleado>
    { 
        public MapEmpleado(AdoAGBD ado) : base(ado)
        {
            Tabla = "Empleado";
        }
        public override Empleado ObjetoDesdeFila(DataRow fila)
            => new Empleado
            (
                Cuil: Convert.ToInt32(fila["Cuil"]),
                Nombre: fila["Nombre"].ToString(),
                
                Apellido: fila["Apellido"].ToString(),
                Contratacion: Convert.ToDateTime(fila["Contratacion"])
            );
        public void AltaEmpleado(Empleado empleado)
            => EjecutarComandoCon("AltaEmpleado", ConfigurarAltaEmpleado, PostAltaEmpleado, empleado);
                public void ConfigurarAltaEmpleado(Empleado empleado)
        {
            SetComandoSP("altaEmpleado");

            BP.CrearParametro("unCuiL")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(empleado.Cuil)
                .AgregarParametro();

            BP.CrearParametro("Nombre")
                .SetTipoVarchar(50)
                .SetValor(empleado.Nombre)
                .AgregarParametro();

            BP.CrearParametro("Apellido")
                .SetTipoVarchar(50)
                .SetValor(empleado.Apellido)
                .AgregarParametro();

            BP.CrearParametro("Contratacion")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
                .SetValor(empleado.Contratacion)
                .AgregarParametro();
        }
            public void PostAltaEmpleado(Empleado Empleado)
            {
                var parmIdEmpleado = GetParametro("unIdEmpleado");

            }

        private object SetValor(DateTime contratacion)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> ObtenerEmpleados() => ColeccionDesdeTabla();

        }
    }
