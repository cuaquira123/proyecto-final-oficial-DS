using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_suplente.Reporte
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'proyecto_final_DSDataSet1.View_TICKET2' Puede moverla o quitarla según sea necesario.
            this.view_TICKET2TableAdapter.Fill(this.proyecto_final_DSDataSet1.View_TICKET2);
            // TODO: esta línea de código carga datos en la tabla 'proyecto_final_DSDataSet.View_ticket' Puede moverla o quitarla según sea necesario.
            this.view_ticketTableAdapter.Fill(this.proyecto_final_DSDataSet.View_ticket);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario de login
            // Crear una instancia del formulario de registro
            frmRegistro registroForm = new frmRegistro();
            registroForm.FormClosed += (s, args) => this.Close(); // Cierra el formulario de login cuando se cierre el de registro
            // Mostrar el formulario de registro
            registroForm.Show();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.AliceBlue;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }
    }
}
