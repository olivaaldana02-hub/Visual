using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace Estabilizador
{
    public partial class Form1 : Form
    {
        SerialPort serialPort1 = new SerialPort();

        public Form1()
        {
            InitializeComponent();

            textBox2.Enabled = false;
            textBox3.Enabled = false;   
            label2.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false; 
            label6.Enabled = false;
            label7.Enabled = false;
            label8.Enabled = false;
            label9.Enabled = false;
            label10.Enabled = false;
            label11.Enabled = false;
            label12.Enabled = false;
            label13.Enabled = false;
            label14.Enabled = false;
            label15.Enabled = false;
            label17.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //título
        {

        }

        private void label1_Click(object sender, EventArgs e) //elegir modo:
        {

        }

        private void button1_Click(object sender, EventArgs e) //Automático
        {
            button1.BackColor = Color.LightBlue;
            button2.BackColor = SystemColors.Control;

            textBox2.Enabled = true;
            textBox3.Enabled = true;
            label2.Enabled = true;
            label3.Enabled = true;
            label4.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            label7.Enabled = true;
            label8.Enabled = true;
            label9.Enabled = true;
            label10.Enabled = true;
            label11.Enabled = true;
            label12.Enabled = false;
            label13.Enabled = false;
            label14.Enabled = false;
            label15.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            label17.Text = " ";
        }

        private void button2_Click(object sender, EventArgs e) //Manual
        {
            button2.BackColor = Color.LightBlue;
            button1.BackColor = SystemColors.Control;

            label12.Enabled = true;
            label13.Enabled = true;
            label14.Enabled = true;
            label15.Enabled = true;
            label17.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            button3.Enabled = true;
            label17.Text = " ";
        }

        private void textBox2_TextChanged(object sender, EventArgs e) //Inclinación
        {

        }

        private void label2_Click(object sender, EventArgs e) //X
        {

        }

        private void label3_Click(object sender, EventArgs e) //Y
        {

        }

        private void label4_Click(object sender, EventArgs e) //Dato X
        {

        }

        private void label5_Click(object sender, EventArgs e) //Dato Y
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) //Motores
        {

        }

        private void label6_Click(object sender, EventArgs e) //Horizontal
        {

        }

        private void label8_Click(object sender, EventArgs e) //ON h
        {

        }

        private void label9_Click(object sender, EventArgs e) //OFF h
        {

        }

        private void label7_Click(object sender, EventArgs e) //Vertical
        {

        }

        private void label11_Click(object sender, EventArgs e) //ON v
        {

        }

        private void label10_Click(object sender, EventArgs e) //OFF v
        {

        }

        private void label12_Click(object sender, EventArgs e) //Conf Manual
        {

        }

        private void label13_Click(object sender, EventArgs e) //Movimiento
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //horiz - vertical
        {
            comboBox2.Items.Clear(); 

            if (comboBox1.SelectedItem.ToString() == "Horizontal")
            {
                comboBox2.Items.Add("Derecha a Izquierda");
                comboBox2.Items.Add("Izquierda a Derecha");
            }
            else
            {
                comboBox2.Items.Add("Arriba a Abajo");
                comboBox2.Items.Add("Abajo a Arriba");
            }

            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //sentido
        {
            
        }

        private void label14_Click(object sender, EventArgs e) //Apertura
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) //grados
        {

        }

        private void label15_Click(object sender, EventArgs e) //Velocidad
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) //elegir velocidad
        {

        }

        private void button3_Click(object sender, EventArgs e) //Botón Chequear
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || comboBox4.SelectedIndex == -1)
            {
                label17.Text = "Por favor, complete todos los datos";
                label17.ForeColor = Color.Red; 
            }
            else
            {
                label17.Text = "Todo en orden! Presione el botón PREPARAR para continuar, \nacomodaremos el estabilizador para que realice el moviiento que desea.";
                label17.ForeColor = Color.Black;
                button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e) //Botón Acomodar
        {

        }

        private void button5_Click(object sender, EventArgs e) //Botón Comenzar
        {

        }


        private void label19_Click(object sender, EventArgs e) //Texto de continuar
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //Automático
        {
            if (radioButton1.Checked)
            {
                button1.PerformClick();
                button1.BackColor = Color.LightBlue;
                button2.BackColor = SystemColors.Control;
            }                
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) //Manual
        {
            if (radioButton2.Checked)
            {
                button2.PerformClick();
                button2.BackColor = Color.LightBlue;
                button1.BackColor = SystemColors.Control;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) //Repetir
        {
            if (radioButton3.Checked)
            {
                button2.PerformClick();
                button2.BackColor = Color.LightBlue;
                button1.BackColor = SystemColors.Control;
            }
        }

        private void label17_Click(object sender, EventArgs e) //texto de botones finales de manual
        {
            
        }
    }
}
