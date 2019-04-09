using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(WebBrowser1_Navigated);
        }

        private void WebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.Text = webBrowser1.Document.Url.ToString();
            MSHTML.HTMLDocument doc = (MSHTML.HTMLDocument)webBrowser1.Document.DomDocument;
            MSHTML.HTMLDocumentEvents2_Event iEvent;
            iEvent = (MSHTML.HTMLDocumentEvents2_Event)doc;
            iEvent.onclick += new MSHTML.HTMLDocumentEvents2_onclickEventHandler(ClickEventHandler);
            
        }

        private bool ClickEventHandler(MSHTML.IHTMLEventObj e)
        {
            string id = e.srcElement.id;
            string tag = e.srcElement.tagName;
            //string innerHTML = e.srcElement.innerHTML;
            //string Text = e.srcElement.innerText;
            textBox2.Text = "id: " + id
                       + "\r\nTag: " + tag;
            //textBox2.Text = e.srcElement.title;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Value = Convert.ToInt32(e.CurrentProgress);
                progressBar1.Maximum = Convert.ToInt32(e.MaximumProgress);
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
