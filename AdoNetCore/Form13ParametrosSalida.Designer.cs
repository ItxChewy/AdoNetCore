namespace AdoNetCore
{
    partial class Form13ParametrosSalida
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
            label1 = new Label();
            cmbDepartamento = new ComboBox();
            btnMostarDatos = new Button();
            label2 = new Label();
            txtSuma = new TextBox();
            label3 = new Label();
            txtMedia = new TextBox();
            label4 = new Label();
            txtPersonas = new TextBox();
            label5 = new Label();
            lstEmpleados = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 14);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "Departamentos";
            // 
            // cmbDepartamento
            // 
            cmbDepartamento.FormattingEnabled = true;
            cmbDepartamento.Location = new Point(28, 42);
            cmbDepartamento.Name = "cmbDepartamento";
            cmbDepartamento.Size = new Size(153, 23);
            cmbDepartamento.TabIndex = 1;
            // 
            // btnMostarDatos
            // 
            btnMostarDatos.Location = new Point(28, 98);
            btnMostarDatos.Name = "btnMostarDatos";
            btnMostarDatos.Size = new Size(153, 36);
            btnMostarDatos.TabIndex = 2;
            btnMostarDatos.Text = "Mostar Datos";
            btnMostarDatos.UseVisualStyleBackColor = true;
            btnMostarDatos.Click += btnMostarDatos_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 166);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 3;
            label2.Text = "Suma salarial";
            // 
            // txtSuma
            // 
            txtSuma.Location = new Point(28, 184);
            txtSuma.Name = "txtSuma";
            txtSuma.Size = new Size(153, 23);
            txtSuma.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 223);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 5;
            label3.Text = "Media Salarial";
            // 
            // txtMedia
            // 
            txtMedia.Location = new Point(28, 241);
            txtMedia.Name = "txtMedia";
            txtMedia.Size = new Size(153, 23);
            txtMedia.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 287);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 7;
            label4.Text = "Personas";
            // 
            // txtPersonas
            // 
            txtPersonas.Location = new Point(28, 305);
            txtPersonas.Name = "txtPersonas";
            txtPersonas.Size = new Size(153, 23);
            txtPersonas.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(267, 14);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 9;
            label5.Text = "Empleados";
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(267, 42);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(187, 304);
            lstEmpleados.TabIndex = 10;
            // 
            // Form13ParametrosSalida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 357);
            Controls.Add(lstEmpleados);
            Controls.Add(label5);
            Controls.Add(txtPersonas);
            Controls.Add(label4);
            Controls.Add(txtMedia);
            Controls.Add(label3);
            Controls.Add(txtSuma);
            Controls.Add(label2);
            Controls.Add(btnMostarDatos);
            Controls.Add(cmbDepartamento);
            Controls.Add(label1);
            Name = "Form13ParametrosSalida";
            Text = "Form13ParametrosSalida";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbDepartamento;
        private Button btnMostarDatos;
        private Label label2;
        private TextBox txtSuma;
        private Label label3;
        private TextBox txtMedia;
        private Label label4;
        private TextBox txtPersonas;
        private Label label5;
        private ListBox lstEmpleados;
    }
}