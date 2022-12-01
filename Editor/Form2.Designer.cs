namespace Editor
{
    partial class fmMargenes
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
            this.laIntroMargen = new System.Windows.Forms.Label();
            this.laIzquierdo = new System.Windows.Forms.Label();
            this.laDerecho = new System.Windows.Forms.Label();
            this.cbMargenIzq = new System.Windows.Forms.ComboBox();
            this.cbMargenDer = new System.Windows.Forms.ComboBox();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // laIntroMargen
            // 
            this.laIntroMargen.AutoSize = true;
            this.laIntroMargen.Location = new System.Drawing.Point(100, 65);
            this.laIntroMargen.Name = "laIntroMargen";
            this.laIntroMargen.Size = new System.Drawing.Size(141, 20);
            this.laIntroMargen.TabIndex = 0;
            this.laIntroMargen.Text = "Introduce Márgenes";
            // 
            // laIzquierdo
            // 
            this.laIzquierdo.AutoSize = true;
            this.laIzquierdo.Location = new System.Drawing.Point(80, 107);
            this.laIzquierdo.Name = "laIzquierdo";
            this.laIzquierdo.Size = new System.Drawing.Size(72, 20);
            this.laIzquierdo.TabIndex = 1;
            this.laIzquierdo.Text = "Izquierdo";
            // 
            // laDerecho
            // 
            this.laDerecho.AutoSize = true;
            this.laDerecho.Location = new System.Drawing.Point(203, 107);
            this.laDerecho.Name = "laDerecho";
            this.laDerecho.Size = new System.Drawing.Size(65, 20);
            this.laDerecho.TabIndex = 2;
            this.laDerecho.Text = "Derecho";
            // 
            // cbMargenIzq
            // 
            this.cbMargenIzq.FormattingEnabled = true;
            this.cbMargenIzq.Items.AddRange(new object[] {
            "15",
            "25",
            "40",
            "60",
            "80",
            "100",
            "150",
            "200"});
            this.cbMargenIzq.Location = new System.Drawing.Point(80, 147);
            this.cbMargenIzq.Name = "cbMargenIzq";
            this.cbMargenIzq.Size = new System.Drawing.Size(79, 28);
            this.cbMargenIzq.TabIndex = 3;
            // 
            // cbMargenDer
            // 
            this.cbMargenDer.FormattingEnabled = true;
            this.cbMargenDer.Items.AddRange(new object[] {
            "15",
            "25",
            "40",
            "60",
            "80",
            "100",
            "150",
            "200"});
            this.cbMargenDer.Location = new System.Drawing.Point(189, 147);
            this.cbMargenDer.Name = "cbMargenDer";
            this.cbMargenDer.Size = new System.Drawing.Size(79, 28);
            this.cbMargenDer.TabIndex = 4;
            // 
            // btAceptar
            // 
            this.btAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAceptar.Location = new System.Drawing.Point(58, 206);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(94, 29);
            this.btAceptar.TabIndex = 5;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Location = new System.Drawing.Point(203, 206);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(94, 29);
            this.btCancelar.TabIndex = 6;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // fmMargenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 299);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.cbMargenDer);
            this.Controls.Add(this.cbMargenIzq);
            this.Controls.Add(this.laDerecho);
            this.Controls.Add(this.laIzquierdo);
            this.Controls.Add(this.laIntroMargen);
            this.Name = "fmMargenes";
            this.Text = "Márgenes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label laIntroMargen;
        private Label laIzquierdo;
        private Label laDerecho;
        public ComboBox cbMargenIzq;
        public ComboBox cbMargenDer;
        private Button btAceptar;
        private Button btCancelar;
    }
}