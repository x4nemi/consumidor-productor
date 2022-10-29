namespace consumidor_productor
{
    public partial class ProductorConsumidor : Form
    {
        public ProductorConsumidor()
        {
            InitializeComponent();

            AgregarItems();

            this.KeyPreview = true;
            InstruccionLabel.Hide();
        }

        private void AgregarItems()
        {
            imageList1.Images.Add(Image.FromFile(@"C:\\Users\\ximgv\\Downloads\\moon.png"));
            imageList1.Images.Add(Image.FromFile(@"C:\\Users\\ximgv\\Downloads\\sun.png"));
            imageList1.ImageSize = new Size(70, 70);
            listView1.LargeImageList = imageList1;
            

            for (int i = 0; i < 25; i++)
            {
                ListViewItem listViewItem = new ListViewItem("Luna\n" + (i + 1).ToString());
                listView1.Items.Add(listViewItem);
                listView1.Items[i].ImageIndex = 0;
            }
        }

        int tiempoConsumidor;
        int cantidadConsumidor;
        int tiempoProductor;
        int cantidadProductor;

        int posicionInicial = 0;
        int posicionFinal = 0;

        string turno = "Nadie";
        
        private void IniciarBoton_Click(object sender, EventArgs e)
        {
            IniciarBoton.Hide();
            InstruccionLabel.Show();
            Random random = new Random();
            // Tiempo aleatorio entre 5 y 10 segundos
            int n1 = random.Next(5, 9);
            int n2 = random.Next(5, 10);

            while (n1 <= n2)
            {
                n1 = new Random().Next(5, 10);
                n2 = new Random().Next(5, 9);
            }

            tiempoConsumidor = n1;
            tiempoProductor = n2;

            cantidadConsumidor = random.Next(4, 8);
            cantidadProductor = random.Next(4, 8);


            Cantidad1Label.Text = "Cantidad: " + cantidadProductor.ToString();
            Cantidad2Label.Text = "Cantidad: " + cantidadConsumidor.ToString();

            Tiempo1Label.Text = "Tiempo: " + tiempoProductor.ToString();
            Tiempo2Label.Text = "Tiempo: " + tiempoConsumidor.ToString();

            //VerificarEstados();
            Estado2Label.Text = "Estado: Mimido";
            Estado1Label.Text = "Estado: Mimido";

            timer1.Start();
            timer2.Start();
            timer5.Start();
        }


        private bool Hay(string objeto)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Text.Contains(objeto))
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
            Estado1Label.Text = "Estado: Trabajando";
            if (cantidadProductor < 1 || listView1.Items[posicionFinal].Text.Contains("Sol"))
            {
                Cantidad1Label.Text = "Cantidad: " + cantidadProductor.ToString();
                turno = "Consumidor";
                Estado1Label.Text = "Estado: Mimido";
                timer3.Stop();

            }
            else
            {
                cantidadProductor--;
                Cantidad1Label.Text = "Cantidad: " + cantidadProductor.ToString();

                listView1.Items[posicionFinal].Text = "Sol\n" + (posicionFinal + 1);
                listView1.Items[posicionFinal].ImageIndex = 1;
                posicionFinal++;
            }

            if (posicionFinal > 24) posicionFinal -= 25;

        }
        private void timer4_Tick(object sender, EventArgs e)
        {

            Estado2Label.Text = "Estado: Trabajando";
            Estado2Label.ForeColor = Color.Pink;
            if (posicionInicial > 24) posicionInicial -= 25;

            if (cantidadConsumidor < 1 || listView1.Items[posicionInicial].Text.Contains("Luna"))
            {
                Cantidad2Label.Text = "Cantidad: " + cantidadConsumidor.ToString();
               
                Estado2Label.Text = "Estado: Mimido";
                Estado2Label.ForeColor = Color.Black;
                timer4.Stop();
            }
            else
            {
                cantidadConsumidor--;
                Cantidad2Label.Text = "Cantidad: " + cantidadConsumidor.ToString();

                listView1.Items[posicionInicial].Text = "Luna\n"+(posicionInicial + 1).ToString();
                listView1.Items[posicionInicial].ImageIndex = 0;
                posicionInicial++;
            }

        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if ((!Hay("Sol") && !timer1.Enabled) || (!timer1.Enabled && Hay("Luna") && !timer4.Enabled && cantidadProductor > 0))
            {
                timer3.Start();
            }else if ((!Hay("Luna") && !timer2.Enabled) || (!timer2.Enabled && Hay("Sol") && !timer3.Enabled && cantidadConsumidor > 0))
            {
                timer4.Start();
            }


            if (tiempoProductor <= 0 && cantidadProductor <= 0 && !timer3.Enabled)
            {
                tiempoProductor = new Random().Next(5, 7);
                cantidadProductor = new Random().Next(1, 5);
                Tiempo1Label.Text = "Tiempo: " + tiempoProductor.ToString();
                Cantidad1Label.Text = "Cantidad: " + cantidadProductor.ToString();
                timer1.Start();
            }
            if ( tiempoConsumidor <= 0 && cantidadConsumidor <= 0 && !timer4.Enabled)
            {
                tiempoConsumidor = new Random().Next(5, 10);
                cantidadConsumidor = new Random().Next(5, 11);
                Tiempo2Label.Text = "Tiempo: " + tiempoConsumidor.ToString();
                Cantidad2Label.Text = "Cantidad: " + cantidadConsumidor.ToString();
                timer2.Start();
            }

        }

        private void ProductorConsumidor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                timer5.Stop();
                this.Close();
            }
        }
    }
}