namespace proyecto_suplente.Reporte
{
    partial class frmReporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.viewTICKET2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proyectofinalDSDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proyecto_final_DSDataSet1 = new proyecto_suplente.Proyecto_final_DSDataSet1();
            this.viewticketBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proyecto_final_DSDataSet = new proyecto_suplente.Proyecto_final_DSDataSet();
            this.view_ticketTableAdapter = new proyecto_suplente.Proyecto_final_DSDataSetTableAdapters.View_ticketTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.view_TICKET2TableAdapter = new proyecto_suplente.Proyecto_final_DSDataSet1TableAdapters.View_TICKET2TableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.viewTICKET2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectofinalDSDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyecto_final_DSDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewticketBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyecto_final_DSDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // viewTICKET2BindingSource
            // 
            this.viewTICKET2BindingSource.DataMember = "View_TICKET2";
            this.viewTICKET2BindingSource.DataSource = this.proyectofinalDSDataSet1BindingSource;
            // 
            // proyectofinalDSDataSet1BindingSource
            // 
            this.proyectofinalDSDataSet1BindingSource.DataSource = this.proyecto_final_DSDataSet1;
            this.proyectofinalDSDataSet1BindingSource.Position = 0;
            // 
            // proyecto_final_DSDataSet1
            // 
            this.proyecto_final_DSDataSet1.DataSetName = "Proyecto_final_DSDataSet1";
            this.proyecto_final_DSDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewticketBindingSource
            // 
            this.viewticketBindingSource.DataMember = "View_ticket";
            this.viewticketBindingSource.DataSource = this.proyecto_final_DSDataSet;
            // 
            // proyecto_final_DSDataSet
            // 
            this.proyecto_final_DSDataSet.DataSetName = "Proyecto_final_DSDataSet";
            this.proyecto_final_DSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // view_ticketTableAdapter
            // 
            this.view_ticketTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.viewTICKET2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "proyecto_suplente.Reporte.Reporte.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1902, 1033);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load_1);
            // 
            // view_TICKET2TableAdapter
            // 
            this.view_TICKET2TableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1460, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 90);
            this.button1.TabIndex = 1;
            this.button1.Text = "SALIR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // frmReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporte";
            this.Text = "frmReporte";
            this.Load += new System.EventHandler(this.frmReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewTICKET2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectofinalDSDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyecto_final_DSDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewticketBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyecto_final_DSDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Proyecto_final_DSDataSet proyecto_final_DSDataSet;
        private System.Windows.Forms.BindingSource viewticketBindingSource;
        private Proyecto_final_DSDataSetTableAdapters.View_ticketTableAdapter view_ticketTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource proyectofinalDSDataSet1BindingSource;
        private Proyecto_final_DSDataSet1 proyecto_final_DSDataSet1;
        private System.Windows.Forms.BindingSource viewTICKET2BindingSource;
        private Proyecto_final_DSDataSet1TableAdapters.View_TICKET2TableAdapter view_TICKET2TableAdapter;
        private System.Windows.Forms.Button button1;
    }
}