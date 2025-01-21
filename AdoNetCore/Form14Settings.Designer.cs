namespace AdoNetCore
{
    partial class Form14Settings
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
            lblCadenaConexion = new Label();
            btnLeerSettings = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblCadenaConexion
            // 
            lblCadenaConexion.AutoSize = true;
            lblCadenaConexion.Location = new Point(25, 84);
            lblCadenaConexion.Name = "lblCadenaConexion";
            lblCadenaConexion.Size = new Size(111, 15);
            lblCadenaConexion.TabIndex = 0;
            lblCadenaConexion.Text = "lblCadenaConexion";
            // 
            // btnLeerSettings
            // 
            btnLeerSettings.Location = new Point(25, 25);
            btnLeerSettings.Name = "btnLeerSettings";
            btnLeerSettings.Size = new Size(144, 45);
            btnLeerSettings.TabIndex = 1;
            btnLeerSettings.Text = "Leer Settings";
            btnLeerSettings.UseVisualStyleBackColor = true;
            btnLeerSettings.Click += btnLeerSettings_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(25, 116);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(255, 199);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(329, 116);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(237, 199);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // Form14Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(608, 443);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(btnLeerSettings);
            Controls.Add(lblCadenaConexion);
            Name = "Form14Settings";
            Text = "Form14Settings";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCadenaConexion;
        private Button btnLeerSettings;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}