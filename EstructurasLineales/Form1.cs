using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstructurasLineales
{
    public partial class Form1 : Form
    {
        private Pila pila1;
        public Form1()
        {
            InitializeComponent();

            Stack<int> pila2 = new Stack<int>();

            pila2.Push(2);
            pila2.Pop();
        }

        private void bt_crear_pila_Click(object sender, EventArgs e)
        {
            pila1 = new Pila();

            bt_insertar.Enabled = true;
            bt_extraer.Enabled = true;

            reset_pila_grafica();
        }

        private void reset_pila_grafica()
        {
            tx_insertar.Clear();
            this.raiz_null.Visible = true;

            pila_1.Visible = false;
            pila_2.Visible = false;
            pila_3.Visible = false;
            pila_4.Visible = false;
        }

        private void bt_insertar_Click(object sender, EventArgs e)
        {
            pila1.Insertar(Convert.ToInt32(this.tx_insertar.IntegerValue));

            if (this.pila_1.Visible==true)
            {
                if (this.pila_2.Visible == true)
                {
                    if (this.pila_3.Visible == true)
                    {
                        if (this.pila_4.Visible == true)
                        {
                            MessageBox.Show("Se ha llegado al limite de nodos en esta pila", "Pilas");
                        }
                        else
                        {
                            ShowPila(this.pila_4, lb_pila_4, Convert.ToInt32(this.tx_insertar.IntegerValue));
                        }
                    }
                    else
                    {
                        ShowPila(this.pila_3, lb_pila_3, Convert.ToInt32(this.tx_insertar.IntegerValue));
                    }
                }
                else
                {
                    ShowPila(this.pila_2, lb_pila_2, Convert.ToInt32(this.tx_insertar.IntegerValue));
                }
            }
            else
            {
                ShowPila(this.pila_1, lb_pila_1, Convert.ToInt32(this.tx_insertar.IntegerValue));
            }

            this.tx_insertar.Clear();
        }

        private void ShowPila(GunaElipsePanel panel, Label label, int valor_nodo)
        {
            panel.Visible = true;
            label.Visible = true;
            label.Text = valor_nodo.ToString();
        }

        private void HidePila(GunaElipsePanel panel, string valor_nodo, string valor_sig)
        {
            panel.Visible = false;

            pila_extraida.Visible = true;
            lb_pila_extraida.Text = valor_nodo;
            lb_raiz.Text = valor_sig;
        }

        private void bt_extraer_Click(object sender, EventArgs e)
        {
            int pila_estraida = pila1.Extraer();

            if (pila_estraida > 100000)
            {
                MessageBox.Show("La pila se encuentra vacía", "Pilas");
                pila_extraida.Visible = false;
            }
            else
            {
                lb_pila_extraida.Text = pila_estraida.ToString();

                if (this.pila_1.Visible == true)
                {
                    if (this.pila_2.Visible == true)
                    {
                        if (this.pila_3.Visible == true)
                        {
                            if (this.pila_4.Visible == true)
                            {
                                HidePila(this.pila_4, lb_pila_4.Text, lb_pila_3.Text);
                            }
                            else
                            {
                                HidePila(this.pila_3, lb_pila_3.Text, lb_pila_2.Text);
                            }
                        }
                        else
                        {
                            HidePila(this.pila_2, lb_pila_2.Text, lb_pila_1.Text);
                        }
                    }
                    else
                    {
                        HidePila(this.pila_1, lb_pila_1.Text, "NULL");
                    }
                }
                else
                {
                    MessageBox.Show("La pila ya se encuentra vacía", "Pilas");
                    pila_extraida.Visible = false;
                }

                this.tx_insertar.Clear();
            }
        }

        private void bt_imprimir_Click(object sender, EventArgs e)
        {
            pila1.Imprimir();

            //this.ejercicio();
        }

        private void ejercicio()
        {
            Pila pila1 = new Pila();
            pila1.Insertar(10);
            pila1.Insertar(40);
            pila1.Insertar(3);
            pila1.Imprimir();
            Console.WriteLine("Extraemos de la pila:" + pila1.Extraer());
            pila1.Imprimir();
            //Console.ReadKey();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
