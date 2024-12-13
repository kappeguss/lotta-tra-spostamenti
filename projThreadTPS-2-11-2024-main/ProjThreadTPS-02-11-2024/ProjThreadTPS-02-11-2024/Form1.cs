namespace ProjThreadTPS_02_11_2024
{
    public partial class Form1 : Form
    {
        private bool gameOver = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        public void MuoviSinistra(Object obj)
        {
            Button button1 = (Button)obj;
            Random rnd = new Random();
            int aggiorna = -10;
            int num;
            while (!gameOver)
            {
                num = rnd.Next(50);
                button1.Location = new Point(button1.Location.X + aggiorna, button1.Location.Y);
                if (button1.Location.X <= 0)
                {
                    gameOver = true;
                    MessageBox.Show("HAI VINTO CAMERATA!!!", "VITTORIA");
                }
                Thread.Sleep(num);
            }
        }

        public void MuoviDestra(Object obj)
        {
            Button button1 = (Button)obj;
            Random rnd = new Random();
            int aggiorna = 10;
            int num;
            while (!gameOver)
            {
                num = rnd.Next(5000);
                button1.Location = new Point(button1.Location.X + aggiorna, button1.Location.Y);
                if (button1.Location.X >= ClientSize.Width - button1.Width)
                {
                    gameOver = true;
                    MessageBox.Show("HAI VINTO CAMERATA!!!", "VITTORIA");
                }
                Thread.Sleep(num);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Button button1 = new Button();
            button1.Size = new Size(100, 100);
            button1.Location = new Point((ClientSize.Width / 2) - (button1.Width / 2), (ClientSize.Height / 2) - (button1.Height / 2));
            this.Controls.Add(button1);

            Control.CheckForIllegalCrossThreadCalls = false;
            Thread sinistro = new Thread(MuoviSinistra);
            //legge pos pulsante, aspetta tempo random, aggiorna posizione pulsante di 10 pixel e modifica posizione pulsante
            Thread destro = new Thread(MuoviDestra);
            sinistro.Start(button1);
            destro.Start(button1);
            sinistro.Join();
            destro.Join();
        }
    }
}