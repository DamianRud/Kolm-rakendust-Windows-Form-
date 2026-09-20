using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MahtQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();


        int a, b, c, d, k, f, g, h;
        int oige = 0;
        int vale = 0;


        TextBox vastus1;
        TextBox vastus2;
        TextBox vastus3;
        TextBox vastus4;

        Button algusnupp;
        Button väljanupp;




        int secund = 30;

        Timer stopper;
        Label silt;
        TextBox aegakast;

        public Form1()
        {
            Height = 300;
            Width = 400;
            Text = "MathQuiz";


            //====kujundus===//
            BackColor = Color.LightCyan;
            ForeColor = Color.DarkViolet;


            Font = new Font("Arial", 10);

            //====kujundus===//



            silt = new Label();
            silt.Text = "Aeg";
            silt.Location = new Point(250, 20);
            silt.AutoSize = true;
            Controls.Add(silt);

            aegakast = new TextBox();
            aegakast.Location = new Point(250, 45);
            aegakast.Enabled = false;
            aegakast.Width = 100;
            aegakast.Text = secund.ToString();
            Controls.Add(aegakast);

            stopper = new Timer();
            stopper.Interval = 1000;
            stopper.Tick += Timer_Tick;


            a = randomizer.Next(1, 100);
            b = randomizer.Next(1, 100);


            //===+===//
            Label l1 = new Label();
            l1.Text = a + "    +    " + b + "  =";
            l1.Location = new Point(20, 20);
            Controls.Add(l1);

            vastus1 = new TextBox();
            vastus1.Location = new Point(165, 17);
            vastus1.Enabled = false;
            vastus1.Width = 60;
            Controls.Add(vastus1);
            //===+===//

            //===-===//
            c = randomizer.Next(1, 100);
            d = randomizer.Next(1, c + 1);

            Label l2 = new Label();
            l2.Text = c + "    -    " + d + "  =";
            l2.Location = new Point(20, 50);
            Controls.Add(l2);

            vastus2 = new TextBox();
            vastus2.Location = new Point(165, 47);
            vastus2.Enabled = false;
            vastus2.Width = 60;
            Controls.Add(vastus2);
            //===-===//


            //===*===//
            k = randomizer.Next(1, 10);
            f = randomizer.Next(1, 10);


            Label l3 = new Label();
            l3.Text = k + "    ×    " + f + "    =";
            l3.Location = new Point(20, 80);
            Controls.Add(l3);

            vastus3 = new TextBox();
            vastus3.Location = new Point(165, 77);
            vastus3.Enabled = false;
            vastus3.Width = 60;
            Controls.Add(vastus3);
            //===*===//


            //===/===//
            g = randomizer.Next(1, 10);
            h = randomizer.Next(1, 10);

            Label l4 = new Label();
            l4.Text = (g * h) + "    ÷    " + h + "    =";
            l4.Location = new Point(20, 110);
            Controls.Add(l4);

            vastus4 = new TextBox();
            vastus4.Location = new Point(165, 107);
            vastus4.Enabled = false;
            vastus4.Width = 60;
            Controls.Add(vastus4);
            //===/===//


            algusnupp = new Button();
            algusnupp.Text = "Algus";
            algusnupp.Location = new Point(70, 150);
            algusnupp.Click += StartButton_Click;
            Controls.Add(algusnupp);

            väljanupp = new Button();
            väljanupp.Text = "Väljapäss";
            väljanupp.Location = new Point(180, 150);
            väljanupp.Click += ExitButton_click;
            Controls.Add(väljanupp);
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (secund > 0)
            {
                secund--;
                aegakast.Text = secund + " sekundid";
                aegakast.Enabled = false;
            }
            else
            {
                stopper.Stop();

                oige = 0;
                vale = 0;

                if (vastus1.Text == (a + b).ToString())
                    oige++;
                else
                    vale++;

                if (vastus2.Text == (c - d).ToString())
                    oige++;
                else
                    vale++;

                if (vastus3.Text == (k * f).ToString())
                    oige++;
                else
                    vale++;

                if (vastus4.Text == g.ToString())
                    oige++;
                else
                    vale++;


                vastus1.Enabled = false;
                vastus2.Enabled = false;
                vastus3.Enabled = false;
                vastus4.Enabled = false;


                MessageBox.Show(
                    "Aeg sai läbi!\n\n" +
                    "Õige: " + oige + "\n" +
                    "Vale: " + vale
                );
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            stopper.Start();
            algusnupp.Enabled = false;

            vastus1.Enabled = true;
            vastus2.Enabled = true;
            vastus3.Enabled = true;
            vastus4.Enabled = true;


        }

        private void ExitButton_click(object sender, EventArgs e)
        {
            Close();
        }


    }
}