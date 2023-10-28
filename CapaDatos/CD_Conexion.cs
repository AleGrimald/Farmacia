using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Conexion
    {
        //cadena de conexion a la base de datos, lleva el nombre del servidor y de la base de datos
        private SqlConnection Conexion = new SqlConnection("Server=DESKTOP-6R4I6DF;DataBase= Farmacia2021;Integrated Security=true");
        

        //Metodo de Abrir Conexion
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }


        //Metodo de Cerrar Conexion
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
