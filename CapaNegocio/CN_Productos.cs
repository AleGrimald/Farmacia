using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregamos las librerias y ensamblamos la capa de datos
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    //Cambiamos la clase a Public
    public class CN_Productos
    {
        //Instanciamos a la clase Productos de la CapaDatos
        private CD_Productos objetoCD = new CD_Productos();


        //Creamos un metodo de tipo DataTable Mostr....
        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();//Creamos un objeto DataTable para guardar los registros de la tabla que devuelve en la CapaDatos
            tabla = objetoCD.Mostrar();
            return tabla;//retornamos la tabla
        }

        //Creamos un metodo, cuyos parametros recibiran los datos que le enviaremos del formulario
        public void InsertarPRod(string nombre, string desc, string laboratorio, string precio, string stock)
        {
            objetoCD.Insertar(nombre, desc, laboratorio, Convert.ToDouble(precio), Convert.ToInt32(stock));
        }

        public void EditarProd(string nombre, string desc, string laboratorio, string precio, string stock, string id)
        {
            objetoCD.Editar(nombre, desc, laboratorio, Convert.ToDouble(precio), Convert.ToInt32(stock), Convert.ToInt32(id));
        }

        public void EliminarPRod(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }



    }
}
