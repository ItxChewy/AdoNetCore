namespace AdoNetCore
{
    partial class Fomr12MensajeServidor
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
            txtNumero = new TextBox();
            label2 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            txtLocalidad = new TextBox();
            btnInsertar = new Button();
            label4 = new Label();
            lblMensaje = new Label();
            lstDepartamentos = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 47);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Numero";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(34, 76);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(100, 23);
            txtNumero.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 130);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(34, 161);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(141, 23);
            txtNombre.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 210);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 4;
            label3.Text = "Localidad";
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(34, 252);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(141, 23);
            txtLocalidad.TabIndex = 5;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(34, 304);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(141, 32);
            btnInsertar.TabIndex = 6;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(263, 47);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 7;
            label4.Text = "Departamentos";
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Location = new Point(34, 384);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(64, 15);
            lblMensaje.TabIndex = 8;
            lblMensaje.Text = "lblMensaje";
            // 
            // lstDepartamentos
            // 
            lstDepartamentos.FormattingEnabled = true;
            lstDepartamentos.Location = new Point(263, 80);
            lstDepartamentos.Name = "lstDepartamentos";
            lstDepartamentos.Size = new Size(313, 289);
            lstDepartamentos.TabIndex = 9;
            // 
            // Fomr12MensajeServidor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 460);
            Controls.Add(lstDepartamentos);
            Controls.Add(lblMensaje);
            Controls.Add(label4);
            Controls.Add(btnInsertar);
            Controls.Add(txtLocalidad);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(txtNumero);
            Controls.Add(label1);
            Name = "Fomr12MensajeServidor";
            Text = "Fomr12MensajeServidor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNumero;
        private Label label2;
        private TextBox txtNombre;
        private Label label3;
        private TextBox txtLocalidad;
        private Button btnInsertar;
        private Label label4;
        private Label lblMensaje;
        private ListBox lstDepartamentos;
    }
}