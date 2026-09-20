using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MahtQuiz;
using PictureViewer;

namespace matching_game
{
    public partial class MainMenu : Form
    {


        Button btnPaarid;
        Button btnKviss;
        Button btnFoto;




        public MainMenu()
        {

            BackColor = Color.FromArgb(240, 235, 255);
            Font = new Font("Comic Sans MS", 9.5F, FontStyle.Bold);

            InitializeComponent();

            Height = 300;
            Width = 300;
            Text = "Peamenüü";

            btnPaarid = new Button();
            btnPaarid.Text = "Paaride mäng";
            btnPaarid.Size = new Size(200, 40);
            btnPaarid.Location = new Point(50, 40);
            btnPaarid.Click += btnPaarid_Click;
            Controls.Add(btnPaarid);

            btnKviss = new Button();
            btnKviss.Text = "Matemaatika viktoriin";
            btnKviss.Size = new Size(200, 40);
            btnKviss.Location = new Point(50, 100);
            btnKviss.Click += btnKviss_Click;
            Controls.Add(btnKviss);

            btnFoto = new Button();
            btnFoto.Text = "Pildivaataja";
            btnFoto.Size = new Size(200, 40);
            btnFoto.Location = new Point(50, 160);
            btnFoto.Click += btnFoto_Click;
            Controls.Add(btnFoto);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnPaarid_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new matching_game.Form1();
            f.FormClosed += (s, e2) => this.Show();
            f.Show();
        }

        private void btnKviss_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new MahtQuiz.Form1();
            f.FormClosed += (s, e2) => this.Show();
            f.Show();
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new PictureViewer.Form1();
            f.FormClosed += (s, e2) => this.Show();
            f.Show();
        }
    }
}