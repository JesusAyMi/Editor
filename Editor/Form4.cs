using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Editor
{
    public partial class fmPresentacion : Form
    {
        public fmPresentacion()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void fmPresentacion_Load(object sender, EventArgs e)
        {
            Timer mitimer = new Timer(); // Creamos objeto temporizador
            mitimer.Tick += Mitimer_Tick; // creamos evento por código
            mitimer.Interval = 2000; //Asignamos intervalo en milésimas de segundo
            mitimer.Enabled = true; //Habilitamos temporizador
            mitimer.Start(); // Iniciamos el temporizador
        }

        private void Mitimer_Tick(object sender, EventArgs e)
        {
            Close(); //Trancurridos 2 segundos cerramos el formulario
        }
    }
}
