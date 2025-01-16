namespace AdoNetCore
{
    partial class Form10UpdateEmpleadosOficios
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
            lstOficios = new ListBox();
            Empleados = new Label();
            lstEmpleados = new ListBox();
            label3 = new Label();
            txtIncremento = new TextBox();
            btnIncrementarSalario = new Button();
            lblSumaSalarial = new Label();
            lblMediaSalarial = new Label();
            lblMaximoSalario = new Label();
            label2 = new Label();
            txtOficio = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 24);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "Oficios";
            // 
            // lstOficios
            // 
            lstOficios.FormattingEnabled = true;
            lstOficios.Location = new Point(29, 52);
            lstOficios.Name = "lstOficios";
            lstOficios.Size = new Size(167, 139);
            lstOficios.TabIndex = 1;
            lstOficios.SelectedIndexChanged += lstOficios_SelectedIndexChanged;
            // 
            // Empleados
            // 
            Empleados.AutoSize = true;
            Empleados.Location = new Point(249, 24);
            Empleados.Name = "Empleados";
            Empleados.Size = new Size(65, 15);
            Empleados.TabIndex = 2;
            Empleados.Text = "Empleados";
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(249, 52);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(187, 199);
            lstEmpleados.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(495, 118);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 4;
            label3.Text = "Incremento";
            // 
            // txtIncremento
            // 
            txtIncremento.Location = new Point(495, 136);
            txtIncremento.Name = "txtIncremento";
            txtIncremento.Size = new Size(100, 23);
            txtIncremento.TabIndex = 5;
            // 
            // btnIncrementarSalario
            // 
            btnIncrementarSalario.Location = new Point(495, 174);
            btnIncrementarSalario.Name = "btnIncrementarSalario";
            btnIncrementarSalario.Size = new Size(100, 58);
            btnIncrementarSalario.TabIndex = 6;
            btnIncrementarSalario.Text = "Incrementar Salario";
            btnIncrementarSalario.UseVisualStyleBackColor = true;
            btnIncrementarSalario.Click += btnIncrementarSalario_Click;
            // 
            // lblSumaSalarial
            // 
            lblSumaSalarial.AutoSize = true;
            lblSumaSalarial.Location = new Point(29, 236);
            lblSumaSalarial.Name = "lblSumaSalarial";
            lblSumaSalarial.Size = new Size(87, 15);
            lblSumaSalarial.TabIndex = 7;
            lblSumaSalarial.Text = "lblSumaSalarial";
            // 
            // lblMediaSalarial
            // 
            lblMediaSalarial.AutoSize = true;
            lblMediaSalarial.Location = new Point(29, 277);
            lblMediaSalarial.Name = "lblMediaSalarial";
            lblMediaSalarial.Size = new Size(90, 15);
            lblMediaSalarial.TabIndex = 8;
            lblMediaSalarial.Text = "lblMediaSalarial";
            // 
            // lblMaximoSalario
            // 
            lblMaximoSalario.AutoSize = true;
            lblMaximoSalario.Location = new Point(29, 315);
            lblMaximoSalario.Name = "lblMaximoSalario";
            lblMaximoSalario.Size = new Size(99, 15);
            lblMaximoSalario.TabIndex = 9;
            lblMaximoSalario.Text = "lblMaximoSalario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(495, 24);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 10;
            label2.Text = "Oficio";
            // 
            // txtOficio
            // 
            txtOficio.Location = new Point(495, 42);
            txtOficio.Name = "txtOficio";
            txtOficio.Size = new Size(100, 23);
            txtOficio.TabIndex = 11;
            // 
            // Form10UpdateEmpleadosOficios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 355);
            Controls.Add(txtOficio);
            Controls.Add(label2);
            Controls.Add(lblMaximoSalario);
            Controls.Add(lblMediaSalarial);
            Controls.Add(lblSumaSalarial);
            Controls.Add(btnIncrementarSalario);
            Controls.Add(txtIncremento);
            Controls.Add(label3);
            Controls.Add(lstEmpleados);
            Controls.Add(Empleados);
            Controls.Add(lstOficios);
            Controls.Add(label1);
            Name = "Form10UpdateEmpleadosOficios";
            Text = "Form10UpdateEmpleadosOficios";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox lstOficios;
        private Label Empleados;
        private ListBox lstEmpleados;
        private Label label3;
        private TextBox txtIncremento;
        private Button btnIncrementarSalario;
        private Label lblSumaSalarial;
        private Label lblMediaSalarial;
        private Label lblMaximoSalario;
        private Label label2;
        private TextBox txtOficio;
    }
}