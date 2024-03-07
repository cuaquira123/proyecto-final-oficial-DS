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
using System.Security.Cryptography;


namespace proyecto_suplente
{
    public partial class frmInicioSesion : Form
    {
        public frmInicioSesion()
        {
            InitializeComponent();
            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {

            string nuevoUsername = txtNuevoUsuario.Text;
            string nuevaContraseña = txtNuevaContrasena.Text;
            string nuevoEmail = txtEmail.Text;

            // Validar si el correo electrónico contiene el símbolo '@'
            if (!nuevoEmail.Contains("@"))
            {
                MessageBox.Show("Por favor, introduce una dirección de correo electrónico válida.");
                return; // Salir del método si la dirección de correo electrónico no es válida
            }

            //llama al metodo encriptar
            string contraseñaEncriptada = EncriptarContraseña(nuevaContraseña);

            string connectionString = "Data Source=CHRISTIAN\\SQLEXPRESS;Initial Catalog=Proyecto_final_DS;Integrated Security=True"; // Reemplaza "TU_SERVIDOR" con la dirección de tu servidor SQL Server

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                // Verificar si el usuario ya existe
                string queryBuscarUsuario = "SELECT COUNT(*) FROM Usuarios1 WHERE NombreUsuario = @NombreUsuario";
                SqlCommand commandBuscarUsuario = new SqlCommand(queryBuscarUsuario, connection);
                commandBuscarUsuario.Parameters.AddWithValue("@NombreUsuario", nuevoUsername);

                connection.Open();
                int count = (int)commandBuscarUsuario.ExecuteScalar();
                connection.Close();
                if (count > 0)
                {
                    MessageBox.Show("El usuario ya existe.");
                    this.Close();
                    return; // Salir del método si el usuario ya existe
                }

                string query = "INSERT INTO Usuarios1 (NombreUsuario, Contraseña, Email) VALUES (@NombreUsuario, @Contraseña, @Email)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NombreUsuario", nuevoUsername);
                command.Parameters.AddWithValue("@Contraseña", contraseñaEncriptada);
                command.Parameters.AddWithValue("@Email", nuevoEmail);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Usuario registrado exitosamente.");
                        //this.Close();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar usuario: " + ex.Message);
                }
                this.Hide(); // Oculta el formulario de inicio de sesion
                frmlogin registroForm = new frmlogin();

                // Mostrar el formulario de registro
                registroForm.Show();
                // this.Close();  Cierra el formulario de registro
                registroForm.FormClosed += (s, args) => this.Close();
            }

        }
        private string EncriptarContraseña(string contraseña)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            this.Hide(); // Oculta el formulario de inicio de sesion
            frmlogin registroForm = new frmlogin();

            // Mostrar el formulario de registro
            registroForm.Show();
            // this.Close();  Cierra el formulario de registro
            registroForm.FormClosed += (s, args) => this.Close(); // Cierra el formulario de RegLogin cuando se cierre el de
                                                                  // Login
        }

        private void btnCrearCuenta_MouseLeave(object sender, EventArgs e)
        {
            btnCrearCuenta.BackColor = Color.AliceBlue;
        }

        private void btnCrearCuenta_MouseHover(object sender, EventArgs e)
        {
            btnCrearCuenta.BackColor = Color.Transparent;
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
