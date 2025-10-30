using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estabilizador
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            OpcionSeleccionada = null;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public string OpcionSeleccionada { get; private set; }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                OpcionSeleccionada = "Automatico";
                this.Close();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                OpcionSeleccionada = "Manual";
                this.Close();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                OpcionSeleccionada = "Repetir";
                this.Close();
            }
        }
    }
}
