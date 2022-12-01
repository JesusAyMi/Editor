namespace Editor
{
    partial class fmAcercaDe
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
            this.laAcercaDe = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // laAcercaDe
            // 
            this.laAcercaDe.AutoSize = true;
            this.laAcercaDe.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.laAcercaDe.Location = new System.Drawing.Point(51, 45);
            this.laAcercaDe.Name = "laAcercaDe";
            this.laAcercaDe.Size = new System.Drawing.Size(558, 268);
            this.laAcercaDe.TabIndex = 0;
            this.laAcercaDe.Text = "Práctica: Editor\r\nAutor: Jesús Ayala Milán\r\nCurso: 2 DAM Q\r\nFecha: 28/11/2022";
            // 
            // fmAcercaDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 382);
            this.Controls.Add(this.laAcercaDe);
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "fmAcercaDe";
            this.Text = "Acerca De";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label laAcercaDe;
    }
}