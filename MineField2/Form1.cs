using System.Drawing.Configuration;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace MineField2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Button[,] buttons = new Button[10, 10];
        private int[,] liss = new int[10, 10]; //may�nlar�n rasgele olu�turudu�u ve listeye at�ld��� yer
        private List<Button> buttonList = new List<Button>();
        private bool c = true;
        public int sbt2 = 0;//global public de sbt2 ile may�ns�z alanlar� sayd�r�p 
        //may�ns�z alan kalmad���nda kazand�n�z mesaj�n� ald�rmak i�in


        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = "mm:ss";
            label1.Text = textBox2.Text;
            timer1.Interval = 1000;

            int x = 0;
            int y = 0;
            int k = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Width = 40;
                    buttons[i, j].Height = 40;
                    buttons[i, j].ForeColor = Color.White;
                    buttons[i, j].Location = new Point(x, y);
                    buttons[i, j].Tag = new Point(i, j);
                    buttons[i, j].Click += Buttons_Click;
                    buttonList.Add(buttons[i, j]);
                    x += 31;
                    this.Controls.Add(buttons[i, j]);
                    k++;
                }
                y += 31;
                x = 0;

            }
        }




        //may�nlar�n eklendi�i metot
        private void mayinEkle()
        {
            bool result1 = int.TryParse(textBox1.Text, out int mayin);
            if (result1 == true)
            {
                for (int i = 0; i < mayin; i++)
                {
                    int xEksen = new Random().Next(0, 10);
                    int yEksen = new Random().Next(0, 10);

                    //olu�turdu�um may�n list arrayine randum konumlara -1 de�erinde may�nlar� at�yorum
                    if (liss[xEksen, yEksen] != -1)
                    {
                        liss[xEksen, yEksen] = -1;
                    }
                    else
                        i--;
                }
            }
            else
            {
                MessageBox.Show("May�n say�s� anla��lmad� tekrar yaz�n�z ");
                Application.Restart();
            }
        }

        
        
        //zaman�n format hatas�ndan kurtarmak ve minumum 30 saniye olarak ayarlanacak metot
        private void zamanFormatVeKontrol()
        {
            string time = textBox2.Text;
            var Time = time.Split(':');
            bool result1 = Int32.TryParse(Time[0], out int m);
            bool result2 = Int32.TryParse(Time[1], out int s);
            if (result1 == true && result2 == true)
            {
                if(s>=30 || m>=1)
                {}
                else
                {
                    MessageBox.Show("minumum 30 saniye girmek zorundas�n�z");
                    Application.Restart();
                }
            }
            else
            {
                MessageBox.Show("Zamanda Format hatas� var");
                Application.Restart();
            }
                
                
        }


        //mayinlar�n hepsini aktif yapma
        private void mayinAktif()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (liss[i, j] == -1)
                    {
                        buttons[i, j].BackColor = Color.Red;
                    }
                }
            }
        }


        //olu�turulan buronlara t�kland���nda olu�acak aksiyonlar
        private void Buttons_Click(object? sender, EventArgs e)
        {
            Button clickButton = (Button)sender;
            Point point = (Point)clickButton.Tag;

            int xEksenn = point.X;
            int yEksenn = point.Y;
            int sbt = 0; //sabiti ye�il bloklar�n etraf�ndaki may�nlar� bulmak i�in kulland�m
            

            if (liss[xEksenn, yEksenn] == -1)//e�er may�na bas�ld� ise yap�lacak islemler
            {                
                clickButton.BackColor = Color.Red;
                if (clickButton.BackColor == Color.Red)//eger may�na bas�ld� ise t�m may�nlar� a�ma
                {
                    mayinAktif ();
                    MessageBox.Show("Mayina bast�n�z: 10 saniye mevcut may�nlar� g�rebilirsiniz");
                    Thread.Sleep(10000);
                }
                timer1.Stop();
                DialogResult result1 = MessageBox.Show("Tekrar Oynamak �steriyor musunuz? ", "Uygulama ��k��", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    //Thread.Sleep(10000);
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }
               
            }
            else//may�na bas�lmam�� ise yap�lacak i�lemler
            {
                sbt2++;//kazand�n�z mesaj� i�in sayd�rma yap�yorum
                for (int i = xEksenn - 1; i <= xEksenn + 1; i++)//for g�ng�leri ile eksan etraf�nda d�nme
                {
                    for (int j = yEksenn - 1; j <= yEksenn + 1; j++)
                    {
                        if (i != -1 && i != 10 && j != -1 && j != 10 && liss[i, j] == -1)
                     //-1 ve 10 de�ilse demek istedi�im eksenlerin d���nda de�ilse demek istedi�im yer
                     //liss arrayi ile de -1 olan yani may�n olan yerleri saymak i�in kulland���m yer
                        {
                            sbt++;
                            clickButton.BackColor = Color.Green;
                            clickButton.Text = sbt.ToString();
                        }
                        else//etraf�nda may�n yoksa 0 olsun
                        {
                            clickButton.BackColor = Color.Green;
                            clickButton.Text = sbt.ToString();
                        }
                    }
                }
            }
            int may = Convert.ToInt32(textBox1.Text);
            if (100 - may == sbt2)
            {
                MessageBox.Show("Oyunu Kazand�n�z. Tebrikler");

            }
        }


        //butona bas�ld���nda yap�lan k�s�m
        private void button1_Click(object sender, EventArgs e)
        {
            zamanFormatVeKontrol();//zaman�n format hatas�ndan kurtarmak ve minumum 30 saniye olarak ayarlanacak metot
            timer1.Start();//geri say�m ba�l�yor
            mayinEkle();
        }


        // zaman� geri sayd�rman�n yap�ld��� k�s�m
        private void timer1_Tick(object sender, EventArgs e)
        {

            while (c)
            {
                label1.Text = textBox2.Text;
                c = false;
            }
            string time = label1.Text;
            var Time = time.Split(':');
            bool result1 = Int32.TryParse(Time[0], out int m);
            bool result2 = Int32.TryParse(Time[1], out int s);

            if (result1 == true && result2 == true)
            {
               
                int Munite = m;
                int Secound = s;
                if (Secound > 0)
                {
                    Secound--;
                }
                if (Secound == 0)
                {
                    if (Munite == 0 && Secound == 0)
                    {
                        timer1.Stop();
                        label1.Text = Munite.ToString() + ":" + Secound.ToString(); 
                        
                        mayinAktif();//s�re bitti�i i�in t�m may�nlar aktif

                        DialogResult result3 = MessageBox.Show("S�reniz Bitti. Tekrar Oynamak �steriyor Musunuz? ", "Uygulama ��k��", MessageBoxButtons.YesNo);
                        if (result3 == DialogResult.Yes)
                        {
                            Thread.Sleep(5000);
                            Application.Restart();
                        }
                        else
                        {
                            Application.Exit();
                           
                        }
                                               
                    }
                    Munite--;
                    Secound = 60;
                }
                label1.Text = Munite.ToString() + ":" + Secound.ToString();
            }
        }
    }
}