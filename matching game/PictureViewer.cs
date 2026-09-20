using System;
using System.Drawing;
using System.Windows.Forms;


namespace PictureViewer
{
    public partial class Form1 : Form
    {
        Button naitapilt;
        Button valjanupp;
        Button taustvaarv;
        Button emaldada;


        CheckBox mruut;

        ColorDialog värviDialoog;
        PictureBox pildiKast1;
        OpenFileDialog vestlus;

        public Form1()
        {


            BackColor = Color.FromArgb(240, 235, 255);
            Font = new Font("Comic Sans MS", 9.5F, FontStyle.Bold);


            Height = 800;
            Width = 1000;
            Text = "Pildivaataja";

            naitapilt = new Button();
            naitapilt.Text = "Näita pilt";
            naitapilt.Location = new Point(610, 700);
            naitapilt.Size = new Size(160, 30);
            naitapilt.Click += showButton_Click;
            Controls.Add(naitapilt);

            valjanupp = new Button();
            valjanupp.Text = "kinni";
            valjanupp.Location = new Point(770, 700);
            valjanupp.Size = new Size(160, 30);
            valjanupp.Click += closeButton_Click;
            Controls.Add(valjanupp);

            värviDialoog = new ColorDialog();

            taustvaarv = new Button();
            taustvaarv.Text = "Taustavärvi seadistamine";
            taustvaarv.Size = new Size(160, 30);
            taustvaarv.Location = new Point(450, 700);
            taustvaarv.Click += backgroundButton_Click;
            Controls.Add(taustvaarv);

            pildiKast1 = new PictureBox();
            pildiKast1.Size = new Size(800, 600);
            pildiKast1.Location = new Point(90, 50);
            pildiKast1.BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(pildiKast1);

            vestlus = new OpenFileDialog();

            emaldada = new Button();
            emaldada.Text = "Pildi tühjendamine";
            emaldada.Size = new Size(160, 30);
            emaldada.Location = new Point(300, 700);
            emaldada.Click += clearButton_Click;
            Controls.Add(emaldada);


            mruut = new CheckBox();
            mruut.Text = "Venitus";
            mruut.Location = new Point(90, 705);
            mruut.AutoSize = true;
            mruut.CheckedChanged += mruut_CheckedChanged;
            Controls.Add(mruut);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            if (värviDialoog.ShowDialog() == DialogResult.OK)
            {
                pildiKast1.BackColor = värviDialoog.Color;
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            vestlus.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*";
            if (vestlus.ShowDialog() == DialogResult.OK)
            {
                pildiKast1.Load(vestlus.FileName);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            pildiKast1.Image = null;
        }

        private void mruut_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut.Checked)
                pildiKast1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pildiKast1.SizeMode = PictureBoxSizeMode.Normal;
        }
    }
}