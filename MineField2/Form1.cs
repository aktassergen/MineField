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
        private int[,] liss = new int[10, 10]; //mayýnlarýn rasgele oluþturuduðu ve listeye atýldýðý yer
        private List<Button> buttonList = new List<Button>();
        private bool c = true;
        public int sbt2 = 0;//global public de sbt2 ile mayýnsýz alanlarý saydýrýp 
        //mayýnsýz alan kalmadýðýnda kazandýnýz mesajýný aldýrmak için


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




        //mayýnlarýn eklendiði metot
        private void mayinEkle()
        {
            bool result1 = int.TryParse(textBox1.Text, out int mayin);
            if (result1 == true)
            {
                for (int i = 0; i < mayin; i++)
                {
                    int xEksen = new Random().Next(0, 10);
                    int yEksen = new Random().Next(0, 10);

                    //oluþturduðum mayýn list arrayine randum konumlara -1 deðerinde mayýnlarý atýyorum
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
                MessageBox.Show("Mayýn sayýsý anlaþýlmadý tekrar yazýnýz ");
                Application.Restart();
            }
        }

        
        
        //zamanýn format hatasýndan kurtarmak ve minumum 30 saniye olarak ayarlanacak metot
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
                    MessageBox.Show("minumum 30 saniye girmek zorundasýnýz");
                    Application.Restart();
                }
            }
            else
            {
                MessageBox.Show("Zamanda Format hatasý var");
                Application.Restart();
            }
                
                
        }


        //mayinlarýn hepsini aktif yapma
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


        //oluþturulan buronlara týklandýðýnda oluþacak aksiyonlar
        private void Buttons_Click(object? sender, EventArgs e)
        {
            Button clickButton = (Button)sender;
            Point point = (Point)clickButton.Tag;

            int xEksenn = point.X;
            int yEksenn = point.Y;
            int sbt = 0; //sabiti yeþil bloklarýn etrafýndaki mayýnlarý bulmak için kullandým
            

            if (liss[xEksenn, yEksenn] == -1)//eðer mayýna basýldý ise yapýlacak islemler
            {                
                clickButton.BackColor = Color.Red;
                if (clickButton.BackColor == Color.Red)//eger mayýna basýldý ise tüm mayýnlarý açma
                {
                    mayinAktif ();
                    MessageBox.Show("Mayina bastýnýz: 10 saniye mevcut mayýnlarý görebilirsiniz");
                    Thread.Sleep(10000);
                }
                timer1.Stop();
                DialogResult result1 = MessageBox.Show("Tekrar Oynamak Ýsteriyor musunuz? ", "Uygulama Çýkýþ", MessageBoxButtons.YesNo);
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
            else//mayýna basýlmamýþ ise yapýlacak iþlemler
            {
                sbt2++;//kazandýnýz mesajý için saydýrma yapýyorum
                for (int i = xEksenn - 1; i <= xEksenn + 1; i++)//for göngüleri ile eksan etrafýnda dönme
                {
                    for (int j = yEksenn - 1; j <= yEksenn + 1; j++)
                    {
                        if (i != -1 && i != 10 && j != -1 && j != 10 && liss[i, j] == -1)
                     //-1 ve 10 deðilse demek istediðim eksenlerin dýþýnda deðilse demek istediðim yer
                     //liss arrayi ile de -1 olan yani mayýn olan yerleri saymak için kullandýðým yer
                        {
                            sbt++;
                            clickButton.BackColor = Color.Green;
                            clickButton.Text = sbt.ToString();
                        }
                        else//etrafýnda mayýn yoksa 0 olsun
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
                MessageBox.Show("Oyunu Kazandýnýz. Tebrikler");

            }
        }


        //butona basýldýðýnda yapýlan kýsým
        private void button1_Click(object sender, EventArgs e)
        {
            zamanFormatVeKontrol();//zamanýn format hatasýndan kurtarmak ve minumum 30 saniye olarak ayarlanacak metot
            timer1.Start();//geri sayým baþlýyor
            mayinEkle();
        }


        // zamaný geri saydýrmanýn yapýldýðý kýsým
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
                        
                        mayinAktif();//süre bittiði için tüm mayýnlar aktif

                        DialogResult result3 = MessageBox.Show("Süreniz Bitti. Tekrar Oynamak Ýsteriyor Musunuz? ", "Uygulama Çýkýþ", MessageBoxButtons.YesNo);
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