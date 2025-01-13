namespace AdoNetCore
{
    partial class Form04EliminarPlantilla
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
            lstPlantilla = new ListBox();
            Plantilla = new Label();
            btnEliminar = new Button();
            txtId = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lstPlantilla
            // 
            lstPlantilla.FormattingEnabled = true;
            lstPlantilla.Location = new Point(330, 120);
            lstPlantilla.Name = "lstPlantilla";
            lstPlantilla.Size = new Size(290, 244);
            lstPlantilla.TabIndex = 9;
            // 
            // Plantilla
            // 
            Plantilla.AutoSize = true;
            Plantilla.Location = new Point(330, 87);
            Plantilla.Name = "Plantilla";
            Plantilla.Size = new Size(57, 15);
            Plantilla.TabIndex = 8;
            Plantilla.Text = "Enfermos";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(180, 168);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(125, 30);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(180, 120);
            txtId.Name = "txtId";
            txtId.Size = new Size(125, 23);
            txtId.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(180, 87);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 5;
            label1.Text = "Id";
            // 
            // Form04EliminarPlantilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 471);
            Controls.Add(lstPlantilla);
            Controls.Add(Plantilla);
            Controls.Add(btnEliminar);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "Form04EliminarPlantilla";
            Text = "Form04EliminarPlantilla";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstPlantilla;
        private Label Plantilla;
        private Button btnEliminar;
        private TextBox txtId;
        private Label label1;
    }
}