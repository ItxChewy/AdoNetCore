namespace AdoNetCore
{
    partial class Form09CrudHospitales
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
            btnEliminar = new Button();
            btnModificar = new Button();
            btnInsertar = new Button();
            txtTelefono = new TextBox();
            label4 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            txtId = new TextBox();
            label2 = new Label();
            lstHospitales = new ListBox();
            label1 = new Label();
            label5 = new Label();
            txtDireccion = new TextBox();
            labelewrq = new Label();
            txtCamas = new TextBox();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.ForeColor = Color.Red;
            btnEliminar.Location = new Point(374, 360);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(127, 40);
            btnEliminar.TabIndex = 21;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(212, 360);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(125, 40);
            btnModificar.TabIndex = 20;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(45, 360);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(125, 40);
            btnInsertar.TabIndex = 19;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(524, 216);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(169, 23);
            txtTelefono.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(523, 189);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 17;
            label4.Text = "Telefono";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(521, 102);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(169, 23);
            txtNombre.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(521, 84);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 15;
            label3.Text = "Nombre";
            // 
            // txtId
            // 
            txtId.Location = new Point(521, 52);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(521, 30);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 13;
            label2.Text = "Id";
            // 
            // lstHospitales
            // 
            lstHospitales.FormattingEnabled = true;
            lstHospitales.Location = new Point(108, 84);
            lstHospitales.Name = "lstHospitales";
            lstHospitales.Size = new Size(318, 244);
            lstHospitales.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(108, 55);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 11;
            label1.Text = "Hospitales";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(523, 130);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 22;
            label5.Text = "Direccion";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(523, 152);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(167, 23);
            txtDireccion.TabIndex = 23;
            // 
            // labelewrq
            // 
            labelewrq.AutoSize = true;
            labelewrq.Location = new Point(524, 259);
            labelewrq.Name = "labelewrq";
            labelewrq.Size = new Size(43, 15);
            labelewrq.TabIndex = 24;
            labelewrq.Text = "Camas";
            // 
            // txtCamas
            // 
            txtCamas.Location = new Point(524, 289);
            txtCamas.Name = "txtCamas";
            txtCamas.Size = new Size(149, 23);
            txtCamas.TabIndex = 25;
            // 
            // Form09CrudHospitales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(729, 441);
            Controls.Add(txtCamas);
            Controls.Add(labelewrq);
            Controls.Add(txtDireccion);
            Controls.Add(label5);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnInsertar);
            Controls.Add(txtTelefono);
            Controls.Add(label4);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(txtId);
            Controls.Add(label2);
            Controls.Add(lstHospitales);
            Controls.Add(label1);
            Name = "Form09CrudHospitales";
            Text = "Form09CrudHospitales";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button btnModificar;
        private Button btnInsertar;
        private TextBox txtTelefono;
        private Label label4;
        private TextBox txtNombre;
        private Label label3;
        private TextBox txtId;
        private Label label2;
        private ListBox lstHospitales;
        private Label label1;
        private Label label5;
        private TextBox txtDireccion;
        private Label labelewrq;
        private TextBox txtCamas;
    }
}