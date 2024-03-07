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
using System.Data.SqlClient;
using proyecto_suplente.Reporte;

namespace proyecto_suplente
{
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
            timer1.Start();

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            // Obtener los datos del formulario
            string placa = txtPlaca.Text;
            string marca = combo_Marca.Text;
            string modelo = txtModelo.Text;
            //cambio 
            string destino=combo_Destino.Text;
            decimal montoSeleccionado = 0;

            /*if (comboBoxMontos.SelectedItem != null)
            {
                montoSeleccionado = (decimal)comboBoxMontos.SelectedItem;
            }*/
            if (comboBoxMontos.SelectedItem != null)
            {
                if (decimal.TryParse(comboBoxMontos.SelectedItem.ToString(), out montoSeleccionado))
                {
                    // La conversión fue exitosa
                }
                else
                {
                    // Manejar el caso en el que la conversión falla
                    MessageBox.Show("El valor seleccionado no es un número válido.");
                }
            }



            // Validar que los campos obligatorios estén llenos
            if (string.IsNullOrEmpty(placa) || string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(modelo) || string.IsNullOrEmpty(destino))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método sin realizar el registro
            }

            // Cadena de conexión a la base de datos
            string connectionString = "Data Source=CHRISTIAN\\SQLEXPRESS;Initial Catalog=Proyecto_final_DS;Integrated Security=True";

            // Query SQL para insertar los datos del vehículo en la tabla Vehiculo
            string queryVehiculo = "INSERT INTO Vehiculo (Placa, Marca, Modelo) VALUES (@Placa, @Marca, @Modelo) SELECT SCOPE_IDENTITY();";

            // Query SQL para insertar los datos del peaje en la tabla Peaje

            int idvehiculo = 0;
            bool vehiculoguardado = false;
            // Crear una conexión a la base de datos y un comando SQL para el registro de vehículo
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryVehiculo, connection))
            {
                // Asignar los parámetros
                command.Parameters.AddWithValue("@Placa", placa);
                command.Parameters.AddWithValue("@Marca", marca);
                command.Parameters.AddWithValue("@Modelo", modelo);

                try
                {
                    // Abrir la conexión y ejecutar el comando
                    connection.Open();
                    idvehiculo = Convert.ToInt32(command.ExecuteScalar());

                    if (idvehiculo > 0)
                    {
                        vehiculoguardado = true;

                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar vehículo: " + ex.Message);
                }
            }
            string queryPeaje = "INSERT INTO Peaje1 (id_Vehiculo,Destino, FechaHora, Monto) VALUES (@id_Vehiculo,@Destino, @FechaHora, @Monto)";

            // Crear una conexión a la base de datos y un comando SQL para el registro de peaje
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryPeaje, connection))
            {
                command.Parameters.AddWithValue("@id_Vehiculo", idvehiculo);
                command.Parameters.AddWithValue("@Destino", destino);//combo_Destino.Text
                command.Parameters.AddWithValue("@FechaHora", DateTime.Now); // Obtener la fecha y hora actuales
                command.Parameters.AddWithValue("@Monto", montoSeleccionado);

                try
                {
                    // Abrir la conexión y ejecutar el comando
                    connection.Open();
                    int rowsAffectedPeaje1 = command.ExecuteNonQuery();

                    if (rowsAffectedPeaje1 > 0 && vehiculoguardado)
                    {
                        // Se guardó el vehículo y el peaje
                        MessageBox.Show("Registro de peaje exitoso. Monto: Bs" + montoSeleccionado.ToString("0.00"));
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar peaje: " + ex.Message);
                }
            }
        }
        private void LimpiarCampos()
        {
            // Limpiar los campos del formulario
            txtPlaca.Text = "";
            combo_Marca.Text = "";
            txtModelo.Text = "";
            combo_Destino.Text  = "";
            comboBoxMontos.Text = "";
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Mostrar el cuadro de diálogo con botones de "Aceptar" y "Cancelar"
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // Verificar la respuesta del usuario
            if (result == DialogResult.OK)
            {
                // Si el usuario hace clic en "Aceptar", ocultar el formulario actual y mostrar el formulario de login
                this.Hide();
                frmlogin registroForm = new frmlogin();
                registroForm.FormClosed += (s, args) => this.Close(); // Cierra el formulario de login cuando se cierre el de registro
                registroForm.Show();
            }
            // Si el usuario hace clic en "Cancelar", no hacemos nada
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario de RegLogin
            frmBoletacs registroForm = new frmBoletacs();

            // Mostrar el formulario de registro
            registroForm.Show();
            // this.Close();  Cierra el formulario de registro
            registroForm.FormClosed += (s, args) => this.Close();
        }

        
       

        private void btnReporte_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario de registro
            // Crear una instancia del formulario de reporte
            frmReporte registroForm = new frmReporte();
            registroForm.FormClosed += (s, args) => this.Close(); // Cierra el formulario de login cuando se cierre el de registro
            // Mostrar el formulario de registro
            registroForm.Show();
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            btnSalir.BackColor = Color.AliceBlue;
        }

        private void btnSalir_MouseHover(object sender, EventArgs e)
        {
            btnSalir.BackColor = Color.Transparent;
        }

        private void btnImprimir_MouseLeave(object sender, EventArgs e)
        {
            btnImprimir.BackColor = Color.AliceBlue;
        }

        private void btnImprimir_MouseHover(object sender, EventArgs e)
        {
            btnImprimir.BackColor = Color.Transparent;
        }

        private void btnRegistrar_MouseLeave(object sender, EventArgs e)
        {
            btnRegistrar.BackColor = Color.AliceBlue;
        }

        private void btnRegistrar_MouseHover(object sender, EventArgs e)
        {
            btnRegistrar.BackColor = Color.Transparent;
        }

        private void btnReporte_MouseLeave(object sender, EventArgs e)
        {
            btnReporte.BackColor = Color.AliceBlue;
        }

        private void btnReporte_MouseHover(object sender, EventArgs e)
        {
            btnReporte.BackColor = Color.Transparent;
        }
    }
}
