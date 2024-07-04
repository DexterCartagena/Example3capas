using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data; 

namespace CapaDeDatos
{
    public class CD_Citas
    {
        private ConexionBD conexionBD = new ConexionBD();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        public DataTable Mostrar()
        {
            comando.Connection= conexionBD.abrirBd();
            comando.CommandText="select id, nombre, CONVERT(varchar(10), fecha, 103) as fecha, Hora, Duracion from Citas";
            leer=comando.ExecuteReader();
            tabla.Load(leer);
            conexionBD.cerrarBD();
            return tabla;

        }

        public void Insertar(string nombre, string fecha, string hora, string duracion) 
        {
        
            comando.Connection = conexionBD.abrirBd();
            comando.CommandText = "InsertarCitas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@fecha", fecha);
            comando.Parameters.AddWithValue("@hora", hora);
            comando.Parameters.AddWithValue("@duracion", duracion);
            comando.ExecuteNonQuery();
          


        }
        public void Modificar(string nombre,DateTime fecha, string hora, string duracion, int ID_citas) 
        {
            comando.Connection = conexionBD.abrirBd();
            comando.CommandText = "EditarCitas"; 
            comando.CommandType = CommandType.StoredProcedure; 
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@fecha", fecha);
            comando.Parameters.AddWithValue("@hora", hora);
            comando.Parameters.AddWithValue("@duracion",duracion);
            comando.Parameters.AddWithValue("@id_citas",ID_citas);
            
            comando.ExecuteNonQuery();
        }

        public void Eliminar(int ID_citas)
        {
            comando.Connection = conexionBD.abrirBd();
            comando.CommandText = "EliminarCitas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_citas", ID_citas);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
    }
}
