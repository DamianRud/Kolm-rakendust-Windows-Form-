using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matching_game
{
    public partial class Form1 : Form
    {
        Random juhuarv = new Random();
        List<string> ikoonid = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        Label esimeneValitud = null;

        Label teineValitud = null;

        TableLayoutPanel tabel = new TableLayoutPanel();
        System.Windows.Forms.Timer taimer = new System.Windows.Forms.Timer();

        //===== TAIMER =====//
        System.Windows.Forms.Timer aegTaimer = new System.Windows.Forms.Timer();
        int sekundid = 0;
        //===== TAIMER =====//

        public Form1()
        {
            InitializeComponent();
            EhitaMängulaud();

            //===== TAIMER =====//
            FormClosed += (s, e) => aegTaimer.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MääraIkoonidRuutudele();
        }

        private void EhitaMängulaud()
        {
            Text = "Paarilise leidmise mäng";
            ClientSize = new Size(550, 550);
            StartPosition = FormStartPosition.CenterScreen;

            tabel.BackColor = Color.CornflowerBlue;
            tabel.Dock = DockStyle.Fill;
            tabel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tabel.ColumnCount = 4;
            tabel.RowCount = 4;

            for (int i = 0; i < 4; i++)
            {
                tabel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tabel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            }

            for (int i = 0; i < 16; i++)
            {
                Label silt = new Label
                {
                    BackColor = Color.CornflowerBlue,
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Webdings", 48F, FontStyle.Bold),
                    UseCompatibleTextRendering = true,
                    Text = "c"
                };
                silt.Click += Silt_Klõps;
                tabel.Controls.Add(silt);
            }

            Controls.Add(tabel);

            taimer.Interval = 750;
            taimer.Tick += Taimer_Tiks;

            //===== TAIMER =====//
            aegTaimer.Interval = 1000;
            aegTaimer.Tick += AegTaimer_Tiks;
        }


        private void MääraIkoonidRuutudele()
        {

            foreach (Control element in tabel.Controls)
            {
                Label ikooniSilt = element as Label;
                if (ikooniSilt != null)
                {
                    int juhuslikArv = juhuarv.Next(ikoonid.Count);
                    ikooniSilt.Text = ikoonid[juhuslikArv];

                    ikooniSilt.ForeColor = ikooniSilt.BackColor;
                    ikoonid.RemoveAt(juhuslikArv);
                }
            }
        }

        //===== TAIMER =====//
        private void AegTaimer_Tiks(object sender, EventArgs e)
        {
            sekundid++;
            Text = "Paarilise leidmise mäng - Aeg: " + sekundid + " s";
        }

        private void Silt_Klõps(object sender, EventArgs e)
        {

            if (taimer.Enabled)
                return;

            Label klõpsatudSilt = sender as Label;

            if (klõpsatudSilt != null)
            {

                if (klõpsatudSilt.ForeColor == Color.Black)
                    return;

                //===== TAIMER =====//
                if (!aegTaimer.Enabled)
                    aegTaimer.Start();

                if (esimeneValitud == null)
                {
                    esimeneValitud = klõpsatudSilt;
                    esimeneValitud.ForeColor = Color.Black;
                    return;
                }
                teineValitud = klõpsatudSilt;
                teineValitud.ForeColor = Color.Black;

                KontrolliVõitjat();

                if (esimeneValitud.Text == teineValitud.Text)
                {
                    esimeneValitud = null;
                    teineValitud = null;
                    return;
                }
                taimer.Start();
            }
        }

        private void Taimer_Tiks(object sender, EventArgs e)
        {
            taimer.Stop();

            if (esimeneValitud != null)
                esimeneValitud.ForeColor = esimeneValitud.BackColor;
            if (teineValitud != null)
                teineValitud.ForeColor = teineValitud.BackColor;
            esimeneValitud = null;
            teineValitud = null;
        }

        private void KontrolliVõitjat()
        {
            foreach (Control element in tabel.Controls)
            {
                Label ikooniSilt = element as Label;
                if (ikooniSilt != null)
                {
                    if (ikooniSilt.ForeColor == ikooniSilt.BackColor)
                        return;
                }
            }

            //===== TAIMER =====//
            aegTaimer.Stop();

            MessageBox.Show("Sa leidsid kõik paarid!\nAeg: " + sekundid + " s", "Palju õnne");
            Close();
        }
    }
}