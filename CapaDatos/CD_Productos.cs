using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Se agregan las librerias para trabajar con Sql
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    //Ponemos la clase en Public
    public class CD_Productos
    {
        //Encapsulamiento de la variable conexion de tipo CD_Conexion
        private CD_Conexion conexion = new CD_Conexion();
   

        SqlDataReader leer;//SqlDataReader nos permite ller datos de la tabla Productos que esta en la base de datos
        DataTable tabla = new DataTable();//Agregamos tabla de tipo DataTable para almacenar las filas de la consulta que realizara SqlDataReader
        SqlCommand comando = new SqlCommand();//SqlCommand nos permite ejecutar instrucciones TransactSql o procedimientos almacenados

        

        //Este metodo de tipo DataTable no permitira visualizar los registros de la tabla Productos
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();//Abrimos la conexion
            comando.CommandText = "MostrarProducto";//Seleccionamos los registros de la tabla
            comando.CommandType = CommandType.StoredProcedure;//Especificamos al comando que sera de tipo Procedimiento
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }


        //Metodo de Insertar Registros
        public void Insertar(string nombre, string laboratorio, string descripcion, double precio, int stock)
        {
            comando.Connection = conexion.AbrirConexion();//Abrimos la conexion
            comando.CommandText = "AgregarProducto";//Seleccionamos al procedimiento de la base de datos
            comando.CommandType = CommandType.StoredProcedure;//Especificamos al comando que sera de tipo Procedimiento

            //Agregamos valores a los parametros del procedimiento con los parametros que recibe del metodo
            comando.Parameters.AddWithValue("@nombre", nombre);//el nombre debe ir igual que en la base de datos @nombre...
            comando.Parameters.AddWithValue("@laboratorio", laboratorio);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);

            comando.ExecuteNonQuery();//Es para ejecutar instrucciones

            comando.Parameters.Clear();//Limpiamos los parametros cada vez que termina de hacer una consulta, asi podemos reutilizar comando
            conexion.CerrarConexion();

        }


        //Con este metodo Editaremos los registros, recibe los mismo parametros que insertar
        public void Editar(string nombre, string laboratorio, string descripcion, double precio, int stock, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@laboratorio", laboratorio);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }


        //Con este metodo Eliminaremos los registros por medio del Id
        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idprod", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }




    }
}
