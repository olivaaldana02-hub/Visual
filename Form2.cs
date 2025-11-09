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
        public string OpcionSeleccionada { get; private set; }

        public Form2()
        {
            InitializeComponent();
            OpcionSeleccionada = null;

            // Asegurar que los RadioButtons estén desmarcados al inicio
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

     

        // Métodos vacíos por si el diseñador los necesita
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton3_CheckedChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                OpcionSeleccionada = "Automatico";
            else if (radioButton2.Checked)
                OpcionSeleccionada = "Manual";
            else if (radioButton3.Checked)
                OpcionSeleccionada = "Repetir";

            if (OpcionSeleccionada != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccioná una opción antes de continuar.",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
    }
}
