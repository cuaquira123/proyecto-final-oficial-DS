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
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
           
            InitializeComponent();
            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //NOS REDIRECCIONA AL FORMULARIO PARA REGISTRARNO COMO NUEVOS USUARIOS
        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide(); // Oculta el formulario de login
            // Crear una instancia del formulario de registro
            frmInicioSesion registroForm = new frmInicioSesion();
            registroForm.FormClosed += (s, args) => this.Close(); // Cierra el formulario de login cuando se cierre el de registro
            // Mostrar el formulario de registro
            registroForm.Show();
        }

        private void btnInicioSesion_Click(object sender, EventArgs e)
        {

            string nombreUsuario = txtNombreUsuario.Text;
            string contraseña = txtContrasena.Text;

            if (ValidarCredenciales(nombreUsuario, contraseña))
            {
                MessageBox.Show("Inicio de sesión exitoso");
                
                this.Hide(); // Oculta el formulario de login
                             // Crear una instancia del formulario de registro
                frmRegistro registroForm = new frmRegistro();
                registroForm.FormClosed += (s, args) => this.Close(); // Cierra el formulario de login cuando se cierre el de registro
                                                                      // Mostrar el formulario de registro
                registroForm.Show();


                // Aquí puedes realizar cualquier acción adicional que desees después del inicio de sesión exitoso
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos");
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
        private bool ValidarCredenciales(string nombreUsuario, string contraseña)
        {
            string connectionString = "Data Source=CHRISTIAN\\SQLEXPRESS;Initial Catalog=Proyecto_final_DS;Integrated Security=True;";
            string query = "SELECT COUNT(*) FROM Usuarios1 WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña";
            string contraseñaEncriptada = EncriptarContraseña(contraseña);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                command.Parameters.AddWithValue("@Contraseña", contraseñaEncriptada);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                return count > 0;
            }
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {

        }

        private void btnInicioSesion_MouseLeave(object sender, EventArgs e)
        {
            btnInicioSesion.BackColor = Color.AliceBlue;
        }

        private void btnInicioSesion_MouseHover(object sender, EventArgs e)
        {
            btnInicioSesion.BackColor = Color.Transparent;
        }

        private void btnRegistro_MouseLeave(object sender, EventArgs e)
        {
            btnRegistro.BackColor = Color.AliceBlue;
        }

        private void btnRegistro_MouseHover(object sender, EventArgs e)
        {
            btnInicioSesion.BackColor = Color.Transparent;
        }
    }
}
