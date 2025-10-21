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

            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = 115200;
            serialPort1.DataReceived += SerialPort1_DataReceived;
            try
            {
                serialPort1.Open();
                MessageBox.Show("Puerto abierto");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el puerto: {ex.Message}");
            }

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

            groupBox1.Visible = false;
            label19.Visible = false;
        }


        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort1.ReadExisting();
                this.BeginInvoke(new Action(() => ProcesarTramas(data)));
            }
            catch { }
        }

        private string buffer = "";

        private void ProcesarTramas(string data)
        {
            buffer += data;

            while (buffer.Contains("<") && buffer.Contains(">"))
            {
                int inicio = buffer.IndexOf('<');
                int fin = buffer.IndexOf('>', inicio);

                if (fin > inicio)
                {
                    string trama = buffer.Substring(inicio + 1, fin - inicio - 1);
                    buffer = buffer.Substring(fin + 1);

                    InterpretarTrama(trama);
                }
                else
                {
                    break;
                }
            }
        }

        private void InterpretarTrama(string trama)
        {
            string[] partes = trama.Split('=');
            if (partes.Length != 2) return;

            string clave = partes[0].Trim();
            string valor = partes[1].Trim();

            switch (clave)
            {
                case "PITCH":
                    label4.Text = $"{valor}°";
                    break;

                case "ROLL":
                    label5.Text = $"{valor}°";
                    break;

                case "MH":
                    ActualizarLabelsMotores(valor == "1", label11.Visible);
                    break;

                case "MV":
                    ActualizarLabelsMotores(label8.Visible, valor == "1");
                    break;

                case "LISTO":
                    if (valor == "1")
                    {
                        label17.Text = "Estabilizador preparado! Presione COMENZAR para ejecutar el movimiento.";
                        label17.ForeColor = Color.Green;
                        button5.Enabled = true;
                    }
                    break;

                case "FINALIZADO":
                    if (valor == "1")
                    {
                        // muestro los radioButtons
                        groupBox1.Visible = true;
                        label19.Visible = true;

                        //button4.Enabled = false;
                        //button5.Enabled = false;
                        //textBox1.Visible = false;
                        //textBox2.Visible = false;
                        //textBox3.Visible = false;
                        //label1.Visible = false;
                        //label2.Visible = false;
                        //label3.Visible = false;
                        //label4.Visible = false;
                        //label5.Visible = false;
                        //label6.Visible = false;
                        //label7.Visible = false;
                        //label8.Visible = false;
                        //label9.Visible = false;
                        //label10.Visible = false;
                        //label11.Visible = false;
                        //label12.Visible = false;
                        //label13.Visible = false;
                        //label14.Visible = false;
                        //label15.Visible = false;
                        //label17.Visible = false;
                        //button1.Visible = false;
                        //button2.Visible = false;
                        //button3.Visible = false;
                        //button4.Visible = false;
                        //button5.Visible = false;
                        //comboBox1.Visible = false;
                        //comboBox2.Visible = false;
                        //comboBox3.Visible = false;
                        //comboBox4.Visible = false;
                    }
                    break;
            }
        }

        private void EnviarTrama(string clave, string valor)
        {
            if (serialPort1.IsOpen)
            {
                string trama = $"<{clave}={valor}>\n";
                serialPort1.Write(trama);
            }
        }

        private int ObtenerVelocidadMs()
        {
            if (comboBox4.SelectedItem == null) return 20;

            string velocidad = comboBox4.SelectedItem.ToString();
            switch (velocidad)
            {
                case "Muy Lento": return 50;
                case "Lento": return 30;
                case "Medio": return 15;
                case "Rápido": return 7;
                case "Muy Rápido": return 3;
                default: return 20;
            }
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

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label17.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;

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

            EnviarTrama("MODO", "A");

            label19.Visible = false; 
            groupBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e) //Manual
        {
            button2.BackColor = Color.LightBlue;
            button1.BackColor = SystemColors.Control;

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label17.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;

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

            EnviarTrama("MODO", "M");

            label19.Visible = false;
            groupBox1.Visible = false;
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

        private void ActualizarLabelsMotores(bool motorH, bool motorV)
        {
            label8.Visible = motorH;
            label9.Visible = !motorH;

            label11.Visible = motorV;
            label10.Visible = !motorV;
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
                label17.Text = "Todo en orden! Presione el botón PREPARAR para continuar, \nacomodaremos el estabilizador para que realice el movimiento que desea.";
                label17.ForeColor = Color.Black;
                button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e) //Botón Preparar
        {
            string tipo = comboBox1.SelectedItem.ToString() == "Horizontal" ? "H" : "V";
            EnviarTrama("MOVTIPO", tipo);

            string sentido = "";
            string sentidoTexto = comboBox2.SelectedItem.ToString();
            switch (sentidoTexto)
            {
                case "Derecha a Izquierda": sentido = "DI"; break;
                case "Izquierda a Derecha": sentido = "ID"; break;
                case "Arriba a Abajo": sentido = "ArA"; break;
                case "Abajo a Arriba": sentido = "AbA"; break;
            }
            EnviarTrama("MOVSENTIDO", sentido);

            string apertura = comboBox3.SelectedItem.ToString();
            EnviarTrama("APERTURA", apertura);

            int velocidadMs = ObtenerVelocidadMs();
            EnviarTrama("VELOCIDAD", velocidadMs.ToString());

            EnviarTrama("PREPARAR", "1");
            label17.Text = "Preparando estabilizador, espere...";
            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e) //Botón Comenzar
        {
            EnviarTrama("COMENZAR", "1");
            label17.Text = "Ejecutando movimiento...";
            button5.Enabled = false;
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
                EnviarTrama("REPETIR", "1");
                label17.Text = "Preparando repetición del movimiento...";
                groupBox1.Visible = false;
                label19.Visible = false;
            }
        }

        private void label17_Click(object sender, EventArgs e) //texto de botones finales de manual
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();

            base.OnFormClosing(e);
        }
    }
}