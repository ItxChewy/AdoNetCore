namespace AdoNetCore
{
    partial class Form11UpdatePlantillaProcedure
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
            label2 = new Label();
            txtIncremento = new TextBox();
            btnModificarSalarios = new Button();
            cmbHospital = new ComboBox();
            label3 = new Label();
            lstPlantilla = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 28);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Hospitales";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(268, 28);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 1;
            label2.Text = "Incremento";
            // 
            // txtIncremento
            // 
            txtIncremento.Location = new Point(268, 46);
            txtIncremento.Name = "txtIncremento";
            txtIncremento.Size = new Size(128, 23);
            txtIncremento.TabIndex = 2;
            // 
            // btnModificarSalarios
            // 
            btnModificarSalarios.Location = new Point(161, 121);
            btnModificarSalarios.Name = "btnModificarSalarios";
            btnModificarSalarios.Size = new Size(114, 28);
            btnModificarSalarios.TabIndex = 3;
            btnModificarSalarios.Text = "Modificar Salarios";
            btnModificarSalarios.UseVisualStyleBackColor = true;
            btnModificarSalarios.Click += btnModificarSalarios_Click;
            // 
            // cmbHospital
            // 
            cmbHospital.FormattingEnabled = true;
            cmbHospital.Location = new Point(34, 46);
            cmbHospital.Name = "cmbHospital";
            cmbHospital.Size = new Size(141, 23);
            cmbHospital.TabIndex = 4;
            cmbHospital.SelectedIndexChanged += cmbHospital_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 182);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 5;
            label3.Text = "Plantilla";
            // 
            // lstPlantilla
            // 
            lstPlantilla.FormattingEnabled = true;
            lstPlantilla.Location = new Point(34, 214);
            lstPlantilla.Name = "lstPlantilla";
            lstPlantilla.Size = new Size(405, 184);
            lstPlantilla.TabIndex = 6;
            // 
            // Form11UpdatePlantillaProcedure
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 419);
            Controls.Add(lstPlantilla);
            Controls.Add(label3);
            Controls.Add(cmbHospital);
            Controls.Add(btnModificarSalarios);
            Controls.Add(txtIncremento);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form11UpdatePlantillaProcedure";
            Text = "Form11UpdatePlantillaProcedure";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtIncremento;
        private Button btnModificarSalarios;
        private ComboBox cmbHospital;
        private Label label3;
        private ListBox lstPlantilla;
    }
}