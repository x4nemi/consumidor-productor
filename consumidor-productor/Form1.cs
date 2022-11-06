namespace consumidor_productor
{
    public partial class ProductorConsumidor : Form
    {
        public ProductorConsumidor()
        {
            InitializeComponent();


            Estado1Label.ForeColor = Color.Red;
            Estado1Label.Text = "Durmiendo...";
            Estado2Label.ForeColor = Color.Red;
            Estado2Label.Text = "Durmiendo...";

            AgregarItems();

            this.KeyPreview = true;
            InstruccionLabel.Hide();
        }

        private void AgregarItems()
        {
            imageList1.Images.Add(Image.FromFile(@"..\\..\\..\\imagenes\\0.png"));
            imageList1.Images.Add(Image.FromFile(@"..\\..\\..\\imagenes\\1.png"));
            imageList1.Images.Add(Image.FromFile(@"..\\..\\..\\imagenes\\2.png"));
            imageList1.Images.Add(Image.FromFile(@"..\\..\\..\\imagenes\\3.png"));
            imageList1.Images.Add(Image.FromFile(@"..\\..\\..\\imagenes\\4.png"));
            imageList1.Images.Add(Image.FromFile(@"..\\..\\..\\imagenes\\5.png"));
            imageList1.Images.Add(Image.FromFile(@"..\\..\\..\\imagenes\\6.png"));
            imageList1.ImageSize = new Size(50, 50);
            listView1.LargeImageList = imageList1;
            

            for (int i = 0; i < 30; i++)
            {
                ListViewItem listViewItem = new ListViewItem((i + 1).ToString());
                listView1.Items.Add(listViewItem);
                listView1.Items[i].ImageIndex = 6;
            }

            imageList2.Images.Add(Image.FromFile(@"..\\..\\..\\imagenes\\l1.png"));
            imageList2.Images.Add(Image.FromFile(@"..\\..\\..\\imagenes\\l2.png"));
            imageList2.Images.Add(Image.FromFile(@"..\\..\\..\\imagenes\\l4.png"));
            imageList2.Images.Add(Image.FromFile(@"..\\..\\..\\imagenes\\l3.png"));

            imageList2.ImageSize = new Size(100, 100);
            

            // imagelist on picturebox
            pictureBox1.Image = imageList2.Images[1];
            pictureBox2.Image = imageList2.Images[3];

        }

        int tiempoConsumidor;
        int cantidadConsumidor;
        int tiempoProductor;
        int cantidadProductor;

        int posicionInicial = 0;
        int posicionFinal = 0;

        private void IniciarBoton_Click(object sender, EventArgs e)
        {
            IniciarBoton.Hide();
            InstruccionLabel.Show();
            Random random = new Random();
            // Tiempo aleatorio entre 5 y 10 segundos
            
            tiempoConsumidor = 3;
            tiempoProductor = 2;

            cantidadConsumidor = random.Next(1, 5);
            cantidadProductor = random.Next(1, 5);


            Cantidad1Label.Text = "Cantidad: " + cantidadProductor.ToString();
            Cantidad2Label.Text = "Cantidad: " + cantidadConsumidor.ToString();

            Tiempo1Label.Text = "Tiempo: " + tiempoProductor.ToString();
            Tiempo2Label.Text = "Tiempo: " + tiempoConsumidor.ToString();
            
            timer1.Start();
            timer2.Start();
            timer5.Start();
        }


        private bool Hay(bool colores)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (colores && item.ImageIndex != 6)
                {
                    return true;
                }
                else if (!colores && item.ImageIndex == 6)
                {
                    return true;
                }
            }

            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Tiempo1Label.Text = "Tiempo: " + tiempoProductor--.ToString();

            if(tiempoProductor < 0)
            {
                timer1.Stop();                
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Tiempo2Label.Text = "Tiempo: " + tiempoConsumidor--.ToString();

            if (tiempoConsumidor < 0)
            {
                timer2.Stop();

            }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
            if (cantidadProductor < 1 || listView1.Items[posicionFinal].ImageIndex < 6)
            {
                Cantidad1Label.Text = "Cantidad: " + cantidadProductor.ToString();

                Estado1Label.ForeColor = Color.Red;
                Estado1Label.Text = "Durmiendo...";
                pictureBox1.Image = imageList2.Images[1];

                timer3.Stop();

            }
            else
            {
                cantidadProductor--;
                Cantidad1Label.Text = "Cantidad: " + cantidadProductor.ToString();
                
                listView1.Items[posicionFinal].ImageIndex = (posicionFinal )% 6;
                posicionFinal++;
            }

            if (posicionFinal > 29) posicionFinal -= 30;

        }
        private void timer4_Tick(object sender, EventArgs e)
        {

            
            if (posicionInicial > 29) posicionInicial -= 30;

            if (cantidadConsumidor < 1 || listView1.Items[posicionInicial].ImageIndex == 6)//listView1.Items[posicionInicial].Text.Contains("Luna"))
            {
                Cantidad2Label.Text = "Cantidad: " + cantidadConsumidor.ToString();

                Estado2Label.ForeColor = Color.Red;
                Estado2Label.Text = "Durmiendo...";
                pictureBox2.Image = imageList2.Images[3];
                timer4.Stop();
            }
            else
            {
                cantidadConsumidor--;
                Cantidad2Label.Text = "Cantidad: " + cantidadConsumidor.ToString();
                
                listView1.Items[posicionInicial].ImageIndex = 6;
                posicionInicial++;
            }

        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if ((!Hay(true) && !timer1.Enabled) || (!timer1.Enabled && Hay(false) && !timer4.Enabled && cantidadProductor > 0))
            {
                Estado1Label.ForeColor = Color.Green;
                Estado1Label.Text = "Trabajando...";
                pictureBox1.Image = imageList2.Images[0];
                timer3.Start();
            }else if ((!Hay(false) && !timer2.Enabled) || (!timer2.Enabled && Hay(true) && !timer3.Enabled && cantidadConsumidor > 0))
            {
                Estado2Label.ForeColor = Color.Green;
                Estado2Label.Text = "Trabajando...";
                pictureBox2.Image = imageList2.Images[2];
                timer4.Start();
            }


            if (tiempoProductor <= 0 && cantidadProductor <= 0 && !timer3.Enabled)
            {
                tiempoProductor = new Random().Next(1, 4);
                cantidadProductor = new Random().Next(1, 6);
                Tiempo1Label.Text = "Tiempo: " + tiempoProductor.ToString();
                Cantidad1Label.Text = "Cantidad: " + cantidadProductor.ToString();
                timer1.Start();
            }
            if ( tiempoConsumidor <= 0 && cantidadConsumidor <= 0 && !timer4.Enabled)
            {
                tiempoConsumidor = new Random().Next(1, 4);
                cantidadConsumidor = new Random().Next(1, 6);
                Tiempo2Label.Text = "Tiempo: " + tiempoConsumidor.ToString();
                Cantidad2Label.Text = "Cantidad: " + cantidadConsumidor.ToString();
                timer2.Start();
            }

        }

        private void ProductorConsumidor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                if (timer1.Enabled) timer1.Stop();
                if (timer2.Enabled) timer2.Stop();
                if (timer3.Enabled) timer3.Stop();
                if (timer4.Enabled) timer4.Stop();

                timer5.Stop();
                this.Close();
            }
        }

        private void ProductorConsumidor_Load(object sender, EventArgs e)
        {

        }
    }
}