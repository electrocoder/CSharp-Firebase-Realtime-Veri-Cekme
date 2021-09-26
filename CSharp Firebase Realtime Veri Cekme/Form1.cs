using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace CSharp_Firebase_Realtime_Veri_Cekme
{
    public partial class Form1 : Form
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            // Firebase projesinin url adresi
            BasePath = "https://csharp-firebase-realtime-db-default-rtdb.europe-west1.firebasedatabase.app/",
            // Firebase setting sayfasindan aldigimiz secret key
            AuthSecret = "i3ZeUx4ZsRMFCVAgXfGptljpMWujdu8TmKTA2xFZ"
        };

        // Firebase client
        IFirebaseClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Butona basildiginda Firebase Client baglanti acilir 
            client = new FireSharp.FirebaseClient(config);

            // Eger hata var ise null doner
            if (client == null)
                MessageBox.Show("Bağlantı hatasi.");


            // Firebase database i olustururken directory olusturmadigimiz icin GetAsync icerisini bos biraktik
            FirebaseResponse response = await client.GetAsync("");

            // response ile donen sonuclari Data.cs ye aktardik
            Data result = response.ResultAs<Data>();

            // Sonuclari ekrandaki textBox lara yazdirdik
            textBox1.Text = result.Data_1;
            textBox2.Text = result.Data_2;
        }
    }
}
