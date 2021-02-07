using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rompecabezas
{
    public partial class Puzzle : Form
    {
        private Double tiempo = 0;
        private Double TiempoMaximo = 100;
        private bool Arrastrandose = false;
        private int ActualX, ActualY, ImagenActualX, ImagenActualY;
        // Posicion de cada imagen para desordenarlas
        List<Point> listaCoordenadas = new List<Point>(); 
        public Puzzle()
        {
            InitializeComponent();
            Iniciar();
            this.comboBox1.SelectedIndex =  0;
            this.comboBox2.SelectedIndex =  0;
        }
        public void Iniciar()
        {
            pictureBox1.BringToFront();
            pictureBox2.BringToFront();
            pictureBox3.BringToFront();
            pictureBox4.BringToFront();
            pictureBox5.BringToFront();
            pictureBox6.BringToFront();
            pictureBox7.BringToFront();
            pictureBox8.BringToFront();
            pictureBox9.BringToFront();
            pictureBox10.BringToFront();
            pictureBox11.BringToFront();
            pictureBox12.BringToFront();
            pictureBox13.BringToFront();
            pictureBox14.BringToFront();
            pictureBox15.BringToFront();
            pictureBox16.BringToFront();
            
            llenarListaCoordenadas();
            //this.pictureBox9.Image = global::Rompecabezas.Properties.Resources._9;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            Controles(false);
            Desordenar_Rompecabezas();
        }
        public void llenarListaCoordenadas() {
            listaCoordenadas.Add(new Point(74, 70)  ); // 16
            listaCoordenadas.Add(new Point(146, 70) ); // 15
            listaCoordenadas.Add(new Point(218, 70) ); // 14
            listaCoordenadas.Add(new Point(290, 70) ); // 13
            listaCoordenadas.Add(new Point(74, 148) ); // 12
            listaCoordenadas.Add(new Point(146, 148)); // 11
            listaCoordenadas.Add(new Point(218, 148)); // 10
            listaCoordenadas.Add(new Point(290, 148)); // 9
            listaCoordenadas.Add(new Point(74, 226) ); // 8
            listaCoordenadas.Add(new Point(146, 226)); // 7
            listaCoordenadas.Add(new Point(218, 226)); // 6
            listaCoordenadas.Add(new Point(290, 226)); // 5
            listaCoordenadas.Add(new Point(74, 304) ); // 4
            listaCoordenadas.Add(new Point(146, 304)); // 3
            listaCoordenadas.Add(new Point(218, 304)); // 2
            listaCoordenadas.Add(new Point(290, 304)); // 1
        }
        public void reacomodarRompecabezas()
        {
            this.pictureBox16.Location = new Point(74, 70);
            this.pictureBox15.Location = new Point(146, 70);
            this.pictureBox14.Location = new Point(218, 70);
            this.pictureBox13.Location = new Point(290, 70);
            this.pictureBox12.Location = new Point(74, 148);
            this.pictureBox11.Location = new Point(146, 148);
            this.pictureBox10.Location = new Point(218, 148);
            this.pictureBox9.Location = new Point(290, 148);
            this.pictureBox8.Location = new Point(74, 226);
            this.pictureBox7.Location = new Point(146, 226);
            this.pictureBox6.Location = new Point(218, 226);
            this.pictureBox5.Location = new Point(290, 226);
            this.pictureBox4.Location = new Point(74, 304);
            this.pictureBox3.Location = new Point(146, 304);
            this.pictureBox2.Location = new Point(218, 304);
            this.pictureBox1.Location = new Point(290, 304);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempo += 1;
            this.label1.Text =  ( tiempo / 10).ToString().Replace(',','.');
            
            if ((tiempo / 10) > TiempoMaximo)
            {
              // pierde
              timer1.Stop();
              tiempo = 0;
              this.label1.Text = "0.0";
              Controles(true);  
              MessageBox.Show("You lost, time out :(");
              reacomodarRompecabezas();
            }
            /*Console.WriteLine("Coordenadas de Imagen1: {0}", this.pictureBox1.Location.ToString());
            Console.WriteLine("Coordenadas de Panel1: {0}", this.panel1.Location.ToString());*/
            if (Ganador())
            {
                timer1.Stop();
                tiempo = 0;
                this.label1.Text = "0.0";
                Controles(true);
                reacomodarRompecabezas();
                MessageBox.Show("Congratulations, you win!");
            }
        }
        public void Controles(bool valor)
        {
            this.comboBox1.Enabled = valor;
            this.comboBox2.Enabled = valor;
            this.button1.Enabled = valor;
        }
        public bool Ganador()
        {
            if (
                (this.pictureBox1.Top == panel1.Top && this.pictureBox1.Left == panel1.Left) && (this.pictureBox2.Top == panel2.Top && this.pictureBox2.Left == panel2.Left) &&
                (this.pictureBox1.Top == panel3.Top && this.pictureBox3.Left == panel3.Left) && (this.pictureBox4.Top == panel4.Top && this.pictureBox4.Left == panel4.Left) &&
                (this.pictureBox5.Top == panel5.Top && this.pictureBox5.Left == panel5.Left) && (this.pictureBox6.Top == panel6.Top && this.pictureBox6.Left == panel6.Left) &&
                (this.pictureBox7.Top == panel7.Top && this.pictureBox7.Left == panel7.Left) && (this.pictureBox8.Top == panel8.Top && this.pictureBox8.Left == panel8.Left) &&
                (this.pictureBox9.Top == panel9.Top && this.pictureBox9.Left == panel9.Left) && (this.pictureBox10.Top == panel10.Top && this.pictureBox10.Left == panel10.Left) &&
                (this.pictureBox11.Top == panel11.Top && this.pictureBox11.Left == panel11.Left) && (this.pictureBox12.Top == panel12.Top && this.pictureBox12.Left == panel12.Left) &&
                (this.pictureBox13.Top == panel13.Top && this.pictureBox13.Left == panel13.Left) && (this.pictureBox14.Top == panel14.Top && this.pictureBox14.Left == panel14.Left) &&
                (this.pictureBox15.Top == panel15.Top && this.pictureBox15.Left == panel15.Left) && (this.pictureBox16.Top == panel16.Top && this.pictureBox16.Left == panel16.Left) 
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)  // Modo Facil
                TiempoMaximo = 80;
            if (this.comboBox1.SelectedIndex == 1)  // Modo Medio
                TiempoMaximo = 60;
            if (this.comboBox1.SelectedIndex == 2)  // Modo Dificil
                TiempoMaximo = 40;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox2.SelectedIndex == 0) // Rompecabezas de carita feliz
                Cambiar_Rompecabezas(0);
            if (this.comboBox2.SelectedIndex == 1) // Rompecabezas de yaoman
                Cambiar_Rompecabezas(1);
        }
        public void movimientoInicia(PictureBox Imagen, MouseEventArgs e)
        {
            Arrastrandose = true;
            ActualX = e.X;
            ActualY = e.Y;
            ImagenActualY = Imagen.Top;
            ImagenActualX = Imagen.Left;
            //this.label1.Text = "(" + e.X + "," +e.Y+ ")";
        }
        public void movimientoTermina(PictureBox Imagen, MouseEventArgs e)
        {
            if (Arrastrandose)
            {
                Imagen.Top = Imagen.Top + (e.Y - ActualY);
                Imagen.Left = Imagen.Left + (e.X - ActualX);
            }
        }
        public void Cambiar_Rompecabezas(int tipoRompecabezas)
        {
            if (tipoRompecabezas == 0)
            {
                this.pictureBox1.Image = global::Rompecabezas.Properties.Resources.happy1;
                this.pictureBox2.Image = global::Rompecabezas.Properties.Resources.happy2;
                this.pictureBox3.Image = global::Rompecabezas.Properties.Resources.happy3;
                this.pictureBox4.Image = global::Rompecabezas.Properties.Resources.happy4;
                this.pictureBox5.Image = global::Rompecabezas.Properties.Resources.happy5;
                this.pictureBox6.Image = global::Rompecabezas.Properties.Resources.happy6;
                this.pictureBox7.Image = global::Rompecabezas.Properties.Resources.happy7;
                this.pictureBox8.Image = global::Rompecabezas.Properties.Resources.happy8;
                this.pictureBox9.Image = global::Rompecabezas.Properties.Resources.happy9;
                this.pictureBox10.Image = global::Rompecabezas.Properties.Resources.happy10;
                this.pictureBox11.Image = global::Rompecabezas.Properties.Resources.happy11;
                this.pictureBox12.Image = global::Rompecabezas.Properties.Resources.happy12;
                this.pictureBox13.Image = global::Rompecabezas.Properties.Resources.happy13;
                this.pictureBox14.Image = global::Rompecabezas.Properties.Resources.happy14;
                this.pictureBox15.Image = global::Rompecabezas.Properties.Resources.happy15;
                this.pictureBox16.Image = global::Rompecabezas.Properties.Resources.happy16;
            }
            if (tipoRompecabezas == 1)
            {
                this.pictureBox1.Image = global::Rompecabezas.Properties.Resources.image_4_4;
                this.pictureBox2.Image = global::Rompecabezas.Properties.Resources.image_4_3;
                this.pictureBox3.Image = global::Rompecabezas.Properties.Resources.image_4_2;
                this.pictureBox4.Image = global::Rompecabezas.Properties.Resources.image_4_1;
                this.pictureBox5.Image = global::Rompecabezas.Properties.Resources.image_3_4;
                this.pictureBox6.Image = global::Rompecabezas.Properties.Resources.image_3_3;
                this.pictureBox7.Image = global::Rompecabezas.Properties.Resources.image_3_2;
                this.pictureBox8.Image = global::Rompecabezas.Properties.Resources.image_3_1;
                this.pictureBox9.Image = global::Rompecabezas.Properties.Resources.image_2_4;
                this.pictureBox10.Image = global::Rompecabezas.Properties.Resources.image_2_3;
                this.pictureBox11.Image = global::Rompecabezas.Properties.Resources.image_2_2;
                this.pictureBox12.Image = global::Rompecabezas.Properties.Resources.image_2_1;
                this.pictureBox13.Image = global::Rompecabezas.Properties.Resources.image_1_4;
                this.pictureBox14.Image = global::Rompecabezas.Properties.Resources.image_1_3;
                this.pictureBox15.Image = global::Rompecabezas.Properties.Resources.image_1_2;
                this.pictureBox16.Image = global::Rompecabezas.Properties.Resources.image_1_1;
            }
           
        }
        public void Desordenar_Rompecabezas()
        {
            if (listaCoordenadas.Count == 0)
                llenarListaCoordenadas();
            List<Point> ListaNueva = DesordenarLista(listaCoordenadas);
            this.pictureBox1.Location = ListaNueva[0];
            this.pictureBox2.Location = ListaNueva[1];
            this.pictureBox3.Location = ListaNueva[2];
            this.pictureBox4.Location = ListaNueva[3];
            this.pictureBox5.Location = ListaNueva[4];
            this.pictureBox6.Location = ListaNueva[5];
            this.pictureBox7.Location = ListaNueva[6];
            this.pictureBox8.Location = ListaNueva[7];
            this.pictureBox9.Location = ListaNueva[8];
            this.pictureBox10.Location = ListaNueva[9];
            this.pictureBox11.Location = ListaNueva[10];
            this.pictureBox12.Location = ListaNueva[11];
            this.pictureBox13.Location = ListaNueva[12];
            this.pictureBox14.Location = ListaNueva[13];
            this.pictureBox15.Location = ListaNueva[14];
            this.pictureBox16.Location = ListaNueva[15];
        }
        public static List<T> DesordenarLista<T>(List<T> input)
        {
            List<T> arr = input;
            List<T> arrDes = new List<T>();
            Random randNum = new Random();
            while (arr.Count > 0)
            {
                int val = randNum.Next(0, arr.Count - 1);
                arrDes.Add(arr[val]);
                arr.RemoveAt(val);
            }
            return arrDes;
        }
        public void DeterminarMovimiento(PictureBox Imagen, Panel panel)
        {
            Arrastrandose = false;
            /*
            Panel1 :  Point(655, 304);
            Panel2 :  Point(583, 304); 
            Panel3 :  Point(511, 304);
            Panel4 :  Point(439, 304);
            */
            // Panel 1
            if ((Imagen.Left >= 645 && Imagen.Left <= 665) && (Imagen.Top >= 294 && Imagen.Top <= 314))
            {
                Imagen.Location = new Point(655, 304);
            }
            // Panel 2
            if ((Imagen.Left >= 573 && Imagen.Left <= 593) && (Imagen.Top >= 294 && Imagen.Top <= 314))
            {
                Imagen.Location = new Point(583, 304);
            }
            // Panel 3
            if ((Imagen.Left >= 501 && Imagen.Left <= 521) && (Imagen.Top >= 294 && Imagen.Top <= 314))
            {
                Imagen.Location = new Point(511, 304);
            }
            // Panel 4
            if ((Imagen.Left >= 429 && Imagen.Left <= 449) && (Imagen.Top >= 294 && Imagen.Top <= 314))
            {
                Imagen.Location = new Point(439, 304);
            }
            /////////////////////////////////////////////////////////////////////////////////////////////
            /*
                Panel5 :  Point(655, 226);
                Panel6 :  Point(583, 226);
                Panel7 :  Point(511, 226);
                Panel8 :  Point(439, 226);
             */
            // Panel 5
            if ((Imagen.Left >= 645 && Imagen.Left <= 665) && (Imagen.Top >= 216 && Imagen.Top <= 236))
            {
                Imagen.Location = new Point(655, 226);
            }
            // Panel 6
            if ((Imagen.Left >= 573 && Imagen.Left <= 593) && (Imagen.Top >= 216 && Imagen.Top <= 236))
            {
                Imagen.Location = new Point(583, 226);
            }
            // Panel 7
            if ((Imagen.Left >= 501 && Imagen.Left <= 521) && (Imagen.Top >= 216 && Imagen.Top <= 236))
            {
                Imagen.Location = new Point(511, 226);
            }
            // Panel 8
            if ((Imagen.Left >= 429 && Imagen.Left <= 449) && (Imagen.Top >= 216 && Imagen.Top <= 236))
            {
                Imagen.Location = new Point(439, 226);
            }

            //////////////////////////////////////////////////////////////////////////////////////////////
            /*
                panel9 :  Point(655, 148);
                panel10 : Point(583, 148);
                panel11 : Point(511, 148);
                panel12 : Point(439, 148);
             */
            // Panel 9
            if ((Imagen.Left >= 645 && Imagen.Left <= 665) && (Imagen.Top >= 138 && Imagen.Top <= 158))
            {
                Imagen.Location = new Point(655, 148);
            }
            // Panel 10
            if ((Imagen.Left >= 573 && Imagen.Left <= 593) && (Imagen.Top >= 138 && Imagen.Top <= 158))
            {
                Imagen.Location = new Point(583, 148);
            }
            // Panel 11
            if ((Imagen.Left >= 501 && Imagen.Left <= 521) && (Imagen.Top >= 138 && Imagen.Top <= 158))
            {
                Imagen.Location = new Point(511, 148);
            }
            // Panel 12
            if ((Imagen.Left >= 429 && Imagen.Left <= 449) && (Imagen.Top >= 138 && Imagen.Top <= 158))
            {
                Imagen.Location = new Point(439, 148);
            }

            //////////////////////////////////////////////////////////////////////////////////////////////
            /*
                panel13 : Point(655, 70);
                panel14 : Point(583, 70);
                panel15 : Point(511, 70);
                panel16 : Point(439, 70);
             */
            // Panel 13
            if ((Imagen.Left >= 645 && Imagen.Left <= 665) && (Imagen.Top >= 60 && Imagen.Top <= 90))
            {
                Imagen.Location = new Point(655, 70);
            }
            // Panel 14
            if ((Imagen.Left >= 573 && Imagen.Left <= 593) && (Imagen.Top >= 60 && Imagen.Top <= 90))
            {
                Imagen.Location = new Point(583, 70);
            }
            // Panel 15
            if ((Imagen.Left >= 501 && Imagen.Left <= 521) && (Imagen.Top >= 60 && Imagen.Top <= 90))
            {
                Imagen.Location = new Point(511, 70);
            }
            // Panel 16
            if ((Imagen.Left >= 429 && Imagen.Left <= 449) && (Imagen.Top >= 60 && Imagen.Top <= 90))
            {
                Imagen.Location = new Point(439, 70);
            }


            if (
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel1.Left, panel1.Top))) &&
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel2.Left, panel2.Top))) &&
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel3.Left, panel3.Top))) &&
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel4.Left, panel4.Top))) &&
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel5.Left, panel5.Top))) &&
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel6.Left, panel6.Top))) &&
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel7.Left, panel7.Top))) &&
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel8.Left, panel8.Top))) &&
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel9.Left, panel9.Top))) &&
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel10.Left, panel10.Top))) &&
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel11.Left, panel11.Top))) &&
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel12.Left, panel12.Top))) &&
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel13.Left, panel13.Top))) &&
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel14.Left, panel14.Top))) &&
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel15.Left, panel15.Top))) &&
                !(new Point(Imagen.Left, Imagen.Top).Equals(new Point(panel16.Left, panel16.Top))) 
            )
            {
                Imagen.Top = ImagenActualY;
                Imagen.Left = ImagenActualX;
            }
            
            
        }
        // Eventos de imagenes
        /// ////////////////////////////////////////////////////
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox1, this.panel1);

        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox1, e);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox1, e);   
        }
        /// ////////////////////////////////////////////////////
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox2, this.panel2);
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox2 , e);
        }
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox2, e);
        }
        /// ////////////////////////////////////////////////////
        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox3, this.panel3);
        }
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox3, e);
        }
        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox3, e);
        }
        /// ////////////////////////////////////////////////////
        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox4, this.panel4);
        }
        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox4, e);
        }
        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox4, e);
        }
        /// ////////////////////////////////////////////////////
        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox5, this.panel5);
        }
        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox5, e);
        }
        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox5, e);
        }
        /// ////////////////////////////////////////////////////
        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox6, this.panel6);
        }
        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox6, e);
        }
        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox6, e);
        }
        /// ////////////////////////////////////////////////////
        private void pictureBox7_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox7, this.panel7);
        }
        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox7, e);
        }
        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox7, e);
        }
        /// ////////////////////////////////////////////////////
        private void pictureBox8_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox8, this.panel8);
        }
        private void pictureBox8_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox8, e);
        }
        private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox8, e);
        }
        /// ////////////////////////////////////////////////////
        private void pictureBox9_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox9, this.panel9);
        }
        private void pictureBox9_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox9, e);
        }
        private void pictureBox9_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox9, e);
        }
        /// ////////////////////////////////////////////////////
        private void pictureBox10_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox10, this.panel10);
        }
        private void pictureBox10_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox10, e);
        }
        private void pictureBox10_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox10, e);
        }
        /// ////////////////////////////////////////////////////
        private void pictureBox11_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox11, this.panel11);
        }
        private void pictureBox11_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox11, e);
        }
        private void pictureBox11_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox11, e);
        }
        /// ////////////////////////////////////////////////////
        private void pictureBox12_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox12, this.panel12);
        }
        private void pictureBox12_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox12, e);
        }
        private void pictureBox12_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox12, e);
        }
        /// ////////////////////////////////////////////////////
        private void pictureBox13_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox13, this.panel13);
        }
        private void pictureBox13_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox13, e);
        }
        private void pictureBox13_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox13, e);
        }
        /// ////////////////////////////////////////////////////
        private void pictureBox14_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox14, this.panel14);
        }
        private void pictureBox14_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox14, e);
        }
        private void pictureBox14_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox14, e);
        }
        /// ////////////////////////////////////////////////////
        private void pictureBox15_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox15, this.panel15);
        }
        private void pictureBox15_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox15, e);
        }
        private void pictureBox15_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox15, e);
        }
        /// ////////////////////////////////////////////////////
        private void pictureBox16_MouseUp(object sender, MouseEventArgs e)
        {
            DeterminarMovimiento(this.pictureBox16, this.panel16);
        }
        private void pictureBox16_MouseDown(object sender, MouseEventArgs e)
        {
            movimientoInicia(this.pictureBox16, e);
        }
        private void pictureBox16_MouseMove(object sender, MouseEventArgs e)
        {
            movimientoTermina(this.pictureBox16, e);
        }
    }
}
