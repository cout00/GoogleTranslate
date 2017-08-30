using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleTranslate
{
    public partial class emptyForm :Form
    {
        public emptyForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var key = "trnsl.1.1.20170830T095657Z.cebe39bf87ebd94c.0b9492d1930a6c88ff7b712891d7e8c46910f402";

            var conString = $"https://translate.yandex.net/api/v1.5/tr.json/translate?key= {key} &lang=en-ru&text=hello world";
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(conString);
            req.Method = "POST";
            req.Accept = "*/*";
            req.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse rest = (HttpWebResponse)req.GetResponse();
            using (StreamReader stream = new StreamReader(rest.GetResponseStream(), Encoding.UTF8))
            {
                richTextBox1.Text = stream.ReadToEnd();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += Clipboard.GetText();
        }
    }
}
