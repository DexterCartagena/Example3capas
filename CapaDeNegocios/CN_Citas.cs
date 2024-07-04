using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDeDatos;
using System.Globalization;

namespace CapaDeNegocios
{
    public class CN_Citas
    {
        private CD_Citas objetoCD = new CD_Citas();

        public DataTable MostrarCit()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarCit(string nombre, string fecha, string hora, string duracion) 
        {
            objetoCD.Insertar(nombre, fecha, hora, duracion);
         }
        public void ModificarCitas(string nombre, string fechastring, string hora, string duracion,string id)
        {
            DateTime fecha = DateTime.ParseExact(fechastring, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            objetoCD.Modificar( nombre, fecha,  hora, duracion, Convert.ToInt32(id));
        }

        public void EliminarCitas(string id ) {

            objetoCD.Eliminar(Convert.ToInt32(id));
        
        }
            
    }
}
