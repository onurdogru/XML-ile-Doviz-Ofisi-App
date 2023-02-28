using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//1.ADIM : XML dosyasını aktif etmek için kütüphanesini ekleriz
using System.Xml;



namespace Doviz_Ofisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //2.ADIM
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml"; //bu linke tıklayıp sayfa kodlarını görüntüle deriz.
            var xmldosya = new XmlDocument(); //xmlDocument nesnedir. //Buranın mantığı topluca veri çekeceğimiz yerin nesnesini oluştururuz.
            xmldosya.Load(bugun);
            //NOT: bugün değişkenin içine atılan linki, xmldosya değişkeninin içine ata.




            //3.ADIM
            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lblDOLARALIS.Text = dolaralis;
            //NOT: Bu adımla beraber Dolar Alış karşısındaki veriyi görmüş oluruz...

            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lblDOLARSATIS.Text = dolarsatis;

            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lblEUROALIS.Text = euroalis;

            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lblEUROSATIS.Text = eurosatis;


        }

        private void btnDOLARAL_Click(object sender, EventArgs e)
        {
            txtKUR.Text = lblDOLARALIS.Text;

        }
    }
}
