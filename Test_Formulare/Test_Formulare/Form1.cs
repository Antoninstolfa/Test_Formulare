using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Test_Formulare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form NovaHra;
        Button Ulozit;
        TextBox textbox1;
        ColorDialog colordialog1;
        Color back = Color.White;
        FontDialog fontdialog1;
        Font font = null;
        bool novahra = false;

        private void button1_Click(object sender, EventArgs e)
        {
            NovaHra = new Form();
            novahra = true;

            Label labelJmeno = new Label();
            labelJmeno.Location = new Point(10,10);
            labelJmeno.Text = "Jméno:";

            textbox1 = new TextBox();
            textbox1.Location = new Point(50, 10);
            textbox1.Size = new Size(100, 20);

            Ulozit = new Button();
            Ulozit.Location = new Point(30, 35);
            Ulozit.Size = new Size(70, 20);
            Ulozit.Text = "Uložit";
            Ulozit.Click += Ulozit_Click;

            NovaHra.Controls.Add(textbox1);
            NovaHra.Controls.Add(labelJmeno);
            NovaHra.Controls.Add(Ulozit);

            if(NovaHra.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void Ulozit_Click(object sender, EventArgs e)
        {
            Form Ulozeni = new Form();
            
            if(textbox1.TextLength == 0)
            {
                MessageBox.Show("Zadejte jméno!");
            }
            else
            {
                Ulozeni.Show();
                StreamWriter zapisovac = new StreamWriter("hra.txt");

                DateTime now = DateTime.Now;
                zapisovac.WriteLine(textbox1.Text + ";" + now);
                zapisovac.Close();
                MessageBox.Show("Data Ulozena.");
                Ulozeni.Close();
                NovaHra.Close();
            }
        }

        Form Nastaveni;
        Button UlozitNastaveni;
        Button ZrusitNastaveni;
        CheckBox checkbox;

        private void button2_Click(object sender, EventArgs e)
        {
            Nastaveni = new Form();

            colordialog1 = new ColorDialog();

            fontdialog1 = new FontDialog();

            Button pozadi = new Button();
            pozadi.Location = new Point(10, 10);
            pozadi.Size = new Size(70, 20);
            pozadi.Text = "Barva pozadí";
            pozadi.Click += pozadi_Click;

            Button zmenafont = new Button();
            zmenafont.Location = new Point(90, 10);
            zmenafont.Size = new Size(70,20);
            zmenafont.Text = "Font";
            zmenafont.Click += zmenafont_Click;

            checkbox = new CheckBox();
            checkbox.Location = new Point(10,40);
            checkbox.Text = "FullScreen";

            UlozitNastaveni = new Button();
            UlozitNastaveni.Location = new Point(10, 60);
            UlozitNastaveni.Size = new Size(70, 20);
            UlozitNastaveni.Text = "Uložit";
            UlozitNastaveni.Click += UlozitNastaveni_Click;

            ZrusitNastaveni = new Button();
            ZrusitNastaveni.Location = new Point(90, 60);
            ZrusitNastaveni.Size = new Size(70, 20);
            ZrusitNastaveni.Text = "Zrušit";
            ZrusitNastaveni.Click += ZrusitNastaveni_Click;

            Nastaveni.Controls.Add(pozadi);
            Nastaveni.Controls.Add(zmenafont);
            Nastaveni.Controls.Add(checkbox);
            Nastaveni.Controls.Add(UlozitNastaveni);
            Nastaveni.Controls.Add(ZrusitNastaveni);

            Nastaveni.Show();
        }

        private void pozadi_Click(object sender, EventArgs e)
        {
            if(colordialog1.ShowDialog() == DialogResult.OK)
            {
                back = colordialog1.Color;
            }
        }

        private void zmenafont_Click(object sender, EventArgs e)
        {
            if(fontdialog1.ShowDialog() == DialogResult.OK) 
            {
                font = fontdialog1.Font;
            }
        }

        private void UlozitNastaveni_Click(object sender, EventArgs e)
        {
            this.BackColor = back;
            this.Font = font;
            Nastaveni.BackColor = back;
            Nastaveni.Font = font;
            if(novahra == true)
            {
                NovaHra.BackColor = back;
                NovaHra.Font = font;
            }
            if(checkbox.Checked == true)
            {
                this.Size = new Size(2500,1000);
                this.Location = new Point(0, 0);
            }
        }

         private void ZrusitNastaveni_Click(Object sender, EventArgs e)
        {
            Nastaveni.Close();
        }

        Form Nacist;
        Button vybrat;
        Button Dalsi;

        private void button3_Click(object sender, EventArgs e)
        {
            Nacist = new Form();

            StreamReader ctenar = new StreamReader("hra.txt");

            Label label = new Label();
            label.Location = new Point(100, 10);
            while(!ctenar.EndOfStream)
            {
                label.Text = ctenar.ReadLine();
            }

            vybrat = new Button();
            vybrat.Location = new Point(10, 40);
            vybrat.Size = new Size(70, 20);
            vybrat.Text = "Vybrat";
            vybrat.Click += vybrat_Click;

            Dalsi = new Button();
            Dalsi.Location = new Point(90, 40);
            Dalsi.Size = new Size(70, 20);
            Dalsi.Text = "Další";
            Dalsi.Click += Dalsi_Click;

            Nacist.Controls.Add(label);
            Nacist.Controls.Add(vybrat);
            Nacist.Controls.Add(Dalsi);

            if(Nacist.ShowDialog() == DialogResult.OK)
            {

            }

            ctenar.Close();
        }

        private void vybrat_Click(object sender, EventArgs e)
        {
            Nacist.Close();s
        }

        private void Dalsi_Click(object sender, EventArgs e)
        {

        }

        Form Ukoncit;
        Button ano;
        Button ne;

        private void button4_Click(object sender, EventArgs e)
        {
            Ukoncit = new Form();
            Ukoncit.Size = new Size(200, 100);

            ano = new Button();
            ano.Location = new Point(10, 10);
            ano.Size = new Size(70, 20);
            ano.Text = "Ano";
            ano.Click += ano_Click;

            ne = new Button();
            ne.Location = new Point(90,10);
            ne.Size = new Size(70,20);
            ne.Text = "Ne";
            ne.Click += ne_Click;

            Ukoncit.Controls.Add(ano);
            Ukoncit.Controls.Add(ne);

            if(Ukoncit.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void ano_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ne_Click(object sender, EventArgs e)
        {
            Ukoncit.Close();
        }
    }
}
