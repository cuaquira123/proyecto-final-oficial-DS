using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proyecto_suplente
{
    public partial class frmBoletacs : Form
    {
        public frmBoletacs()
        {
            InitializeComponent();
            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
            timer1.Start();
            CargarDatosUltimoRegistro();

        }
        private void CargarDatosUltimoRegistro()
        {
            // Aquí deberías obtener los datos del último registro desde la base de datos
            // Puedes utilizar el mismo objeto de conexión y comando que usas para la inserción

            // Ejemplo con SqlConnection y SqlCommand
            using (SqlConnection connection = new SqlConnection("Data Source=CHRISTIAN\\SQLEXPRESS;Initial Catalog=Proyecto_final_DS;Integrated Security=True"))
            {
                string query = " DECLARE @ID INT\r\nSELECT @ID=MAX(Peaje1.id_Peaje1) FROM Peaje1 SELECT TOP 1 Peaje1.id_Peaje1,Peaje1.Monto,Vehiculo.Placa,Vehiculo.Marca,Vehiculo.Modelo,Peaje1.Destino\r\n\r\nFROM Peaje1,Vehiculo\r\nWHERE Peaje1.id_Peaje1=@ID AND Peaje1.id_vehiculo= Vehiculo.id_Vehiculo\r\nORDER BY id_Peaje1,Monto,Placa,Marca,Modelo DESC";// Ordenar por ID en orden descendente para obtener el último registro
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    //Se ejecuta la consulta y se obtiene un lector de datos 
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Aquí debes asignar los valores a tus etiquetas
                        lblPlaca.Text = reader["Placa"].ToString();
                        lblMarca.Text = reader["Marca"].ToString();
                        lblModelo.Text = reader["Modelo"].ToString();
                        lblIdPeaje.Text = reader["id_Peaje1"].ToString();
                        lblMonto.Text = reader["Monto"].ToString();
                        lblDestino.Text = reader["Destino"].ToString();
                        // ... repite esto para cada campo que desees mostrar en tus etiquetas
                    }

                    connection.Close();
                }
            }
        }

        //BOTON CERRAR
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario de login
                         // Crear una instancia del formulario de registro
            frmRegistro registroForm = new frmRegistro();
            registroForm.FormClosed += (s, args) => this.Close(); // Cierra el formulario de login cuando se cierre el de registro
                                                                  // Mostrar el formulario de registro
            registroForm.Show();
        }



        private void frmBoletacs_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label17.Text = DateTime.Now.ToString();
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            btnSalir.BackColor = Color.AliceBlue;
        }

        private void btnSalir_MouseHover(object sender, EventArgs e)
        {
            btnSalir.BackColor = Color.Transparent;
        }
    }
}
