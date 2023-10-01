using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WikipediaPDFCreatorDesktop
{
    public partial class InputBox : Form
    {
        bool buttonClicked = false;
        event EventHandler accepted;
        event EventHandler canceled;

        public InputBox()
        {
            InitializeComponent();
        }

        public async Task<string> ShowAsync(string text)
        {
            textBox.Text = text;
            accepted += (x, y) => { text = textBox.Text; buttonClicked = true; };
            canceled += (x, y) => { buttonClicked = true; };
            this.ShowDialog();

            while(!buttonClicked)
            {
                await Task.Delay(100);
            }

            return text;
        }

        private void accept_Click(object sender, EventArgs e)
        {
            accepted.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            canceled.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
