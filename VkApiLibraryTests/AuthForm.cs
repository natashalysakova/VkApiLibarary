using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VkApiLibraryTests
{
    public partial class AuthForm : Form
    {
        public AuthForm(string permissions)
        {
            InitializeComponent();
            webBrowser1.Navigate("https://oauth.vk.com/authorize?client_id=4436659&scope=" + permissions + "&redirect_uri=http://oauth.vk.com/blank.html&display=page&response_type=token");
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {

        }

        private string userId, token;

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            string pattern = @"=\w+";

            Regex Reg = new Regex(pattern);
            MatchCollection mc = Regex.Matches(webBrowser1.Url.ToString(), pattern);

            token = mc[0].Value.Remove(0, 1);
            try
            {
                userId = mc[2].Value.Remove(0, 1);
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public string[] GetRes()
        {
            return new[] { userId, token };
        }
    }
}
