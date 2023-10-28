using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Ensamblamos la capa Negocios
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    //Cambiamos la clase a Public
    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new CN_Productos();//Instanciamos un objeto de la clase CN_Producto
        
        
        double resultado;
        private string idProducto = null;
        private bool Editar = false;
        

        public Form1()
        {
            InitializeComponent();
            
        }

        

        //Evento Load
        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProdctos();//Llamamos al metodos MostrarProdtos
            
        }

        //Creamos un metodo de tipo void MostrarP...
        private void MostrarProdctos()
        { 
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarProd();   
        }
        
        //Boton Insertar
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            
            //INSERTAR, al cumplirse la condicion pasara a crear un registro
            if (Editar == false)
            {
                //Usamos try catch para evitar errores y poner excepciones
                try
                {
                    //Llamamos al objeto de la CapaNegocios y a su metodo InsertPRod y como parametros enviamos los textBox
                    objetoCN.InsertarPRod(txtNombre.Text, txtLaboratorio.Text, txtDescripcion.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("se inserto correctamente");
                    MostrarProdctos();//Llamamos al metodo MostrarProd.. para actualizar la vista del datagridview
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo insertar los datos por: " + ex);
                }
            }
            //EDITAR, luego de usar el boton editar, guardamos los cambios con el boton guardar
            if (Editar == true)
            {
                try
                {
                    objetoCN.EditarProd(txtNombre.Text, txtLaboratorio.Text, txtDescripcion.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("se edito correctamente");
                    MostrarProdctos();
                    limpiarForm();
                    Editar = false;//reiniciamos el estado del boton para que pueda seguir editando registros
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo editar los datos por: " + ex);
                }
            }
        }

        //Boton Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Preguntamos si las celdas seleccionadas es > 0
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;

                //Decimos que el valor del txt... sea igual al valor de la fila-celda seleccionada
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtLaboratorio.Text = dataGridView1.CurrentRow.Cells["Laboratorio"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtValorProd.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
                MessageBox.Show("seleccione una fila por favor");//Si no se cumple la condicion se muestra un mensaje
        }

        //Boton Eliminar
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarPRod(idProducto);
                MessageBox.Show("Eliminado correctamente");
                MostrarProdctos();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }


        //Este metodo lo usamos para limpiar los campos de texto cada vez que los usamos
        private void limpiarForm()
        {
            txtDescripcion.Clear();
            txtLaboratorio.Text = "";
            txtPrecio.Clear();
            txtStock.Clear();
            txtNombre.Clear();
        }



        private void rdbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rdbEfectivo.Checked)
            {
                cmbEfectivo.Enabled=true;
                cmbObraSocial.Enabled = false;
            }else if(rdbObraSocial.Checked)
            {
                cmbObraSocial.Enabled = true;
                cmbEfectivo.Enabled = false;
            }
        }


        private void btnCalcular_Click(object sender, EventArgs e)
        { 
            double valor = Convert.ToDouble(txtValorProd.Text);
            int efectivo = cmbEfectivo.SelectedIndex;
            int oSocial = cmbObraSocial.SelectedIndex;

            if (rdbEfectivo.Checked)
            {
                switch (efectivo)
                {
                    case 1:
                        resultado = valor - ((valor * 10) / 100);
                        break;

                    case 2:
                        resultado = valor + ((valor * 10) / 100);
                        break;

                    case 3:
                        resultado = valor + ((valor * 18) / 100);
                        break;

                    case 4:
                        resultado = valor + ((valor * 25) / 100);
                        break;
                }
                
                txtTotal.Clear(); 
                txtTotal.Text = resultado.ToString();
            }

            if (rdbObraSocial.Checked)
            {
                switch (oSocial)
                {
                    case 1:
                        resultado = valor - ((valor * 60) / 100);

                        break;

                    case 2:
                        resultado = valor - ((valor * 40) / 100);
                        break;

                    case 3:
                        resultado = valor - ((valor * 35) / 100);
                        break;

                    case 4:
                        resultado = valor - ((valor * 30) / 100);
                        break;
                }

                txtTotal.Clear();
                txtTotal.Text = resultado.ToString();
            }
            
            
        }

        private void btnObtener_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                txtValorProd.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStockDisponibles.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();

            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnIntegrantes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Miembros ventanaMiembros = new Miembros();
            ventanaMiembros.Show();
        }


    }
}
