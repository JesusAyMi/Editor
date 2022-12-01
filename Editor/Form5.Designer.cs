namespace Editor
{
    partial class fmDatos
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
            this.laIntroNumLi = new System.Windows.Forms.Label();
            this.tbDato = new System.Windows.Forms.TextBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // laIntroNumLi
            // 
            this.laIntroNumLi.AutoSize = true;
            this.laIntroNumLi.Location = new System.Drawing.Point(25, 21);
            this.laIntroNumLi.Name = "laIntroNumLi";
            this.laIntroNumLi.Size = new System.Drawing.Size(190, 20);
            this.laIntroNumLi.TabIndex = 0;
            this.laIntroNumLi.Text = "Introduce Número de Línea";
            // 
            // tbDato
            // 
            this.tbDato.Location = new System.Drawing.Point(25, 57);
            this.tbDato.Name = "tbDato";
            this.tbDato.Size = new System.Drawing.Size(242, 27);
            this.tbDato.TabIndex = 1;
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(173, 102);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(94, 29);
            this.btCancelar.TabIndex = 2;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // btAceptar
            // 
            this.btAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAceptar.Location = new System.Drawing.Point(25, 102);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(94, 29);
            this.btAceptar.TabIndex = 3;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            // 
            // fmDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 187);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.tbDato);
            this.Controls.Add(this.laIntroNumLi);
            this.Name = "fmDatos";
            this.Text = "Para Ir a una Línea Concreta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label laIntroNumLi;
        public TextBox tbDato;
        private Button btCancelar;
        private Button btAceptar;
    }
}