using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using WebServisPostYapma.Model;

namespace WebServisPostYapma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Syracuse Üniversitesinin sunduğu ücretsiz test amaçlı kullanıma açık SOAP Web Servisi
        const string url = "https://ecs.syr.edu/faculty/fawcett/handouts/cse686/code/calcWebService/Calc.asmx";

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSayi1.Text) && !String.IsNullOrEmpty(txtSayi2.Text))
            {
                int a = Convert.ToInt32(txtSayi1.Text);
                int b = Convert.ToInt32(txtSayi2.Text);
                WebServistekiAddMetodunuCalistir(a, b);
            }
            else
            {
                MessageBox.Show("Sayı1 ve/veya Sayı2 Değerlerini Mutlaka Girmeniz Gerekir..!");
            }

        }

        public void WebServistekiAddMetodunuCalistir(int a, int b)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add(@"SOAPAction: ""http://tempuri.org/Add""");//SOAP üzerinde Add isimli metod var om
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            request.Method = "POST";

            TextReader trd = new StreamReader("XmlSorguDosyalari/topla.xml");

            string gonderilecekXmlVeri = trd.ReadToEnd();
            gonderilecekXmlVeri=gonderilecekXmlVeri.Replace("<a>int</a>","<a>"+a.ToString()+"</a>");
            gonderilecekXmlVeri = gonderilecekXmlVeri.Replace("<b>int</b>", "<b>" + b.ToString() + "</b>");
            
            XmlDocument gonderilecekXml = new XmlDocument();
            gonderilecekXml.LoadXml(gonderilecekXmlVeri);
            
            using (Stream stream = request.GetRequestStream())
            {
                gonderilecekXml.Save(stream);
            }

            using (WebResponse webSunucudanGelenCevap = request.GetResponse())
            {
                using (StreamReader srd = new StreamReader(webSunucudanGelenCevap.GetResponseStream()))
                {
                    string cevapIcindekiXmlVeri = srd.ReadToEnd();
                    txtMesaj.Text = cevapIcindekiXmlVeri;

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Envelope));
                    TextReader textReader = new StringReader(cevapIcindekiXmlVeri);
                    Envelope objEnvelope = xmlSerializer.Deserialize(textReader) as Envelope;
                    txtSonuc.Text = objEnvelope.Body.AddResponse.AddResult;
                }
            }
        }



    }
}
