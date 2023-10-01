using iText;
using iText.Kernel.Pdf;
using System.Diagnostics;

namespace WikipediaPDFCreatorDesktop
{
    public partial class Form1 : Form
    {
        string path;

        public Form1()
        {
            InitializeComponent();
            if (File.Exists("settings.txt"))
                path = File.ReadAllLines("settings.txt")[0];
            else
            {
                FolderBrowserDialog FolderDialog = new FolderBrowserDialog();
                FolderDialog.Description = "OutputPath";
                FolderDialog.ShowDialog();
                path = FolderDialog.SelectedPath;
                File.WriteAllText("settings.txt", path);
            }
        }

        private async void edit_Click(object sender, EventArgs e)
        {
            if (list.SelectedItems.Count <= 0)
                return;

            var temp = list.SelectedItem;
            int i = list.Items.IndexOf(temp);

            string t = (string)temp;
            InputBox box = new InputBox();
            t = await box.ShowAsync(t);

            list.Items.RemoveAt(i);
            list.Items.Insert(i, t);
        }

        private void remove_Click(object sender, EventArgs e)
        {
            int i = list.SelectedIndex;
            list.Items.RemoveAt(i);
        }

        private void add_Click(object sender, EventArgs e)
        {
            list.Items.Add(textBox.Text);
        }

        private void up_Click(object sender, EventArgs e)
        {
            var temp = list.SelectedItem;
            int i = list.Items.IndexOf(temp);

            if (i == 0)
                return;

            list.Items.RemoveAt(i);
            list.Items.Insert(i - 1, temp);
            list.SetSelected(i - 1, true);
        }

        private void down_Click(object sender, EventArgs e)
        {
            var temp = list.SelectedItem;
            int i = list.Items.IndexOf(temp);

            if (i == list.Items.Count - 1)
                return;

            list.Items.RemoveAt(i);
            list.Items.Insert(i + 1, temp);
            list.SetSelected(i + 1, true);
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void generateBook_Click(object sender, EventArgs e)
        {
            PDFCreator c = new PDFCreator(list.Items.Cast<string>().ToArray(), path, title.Text);
            c.finished += (x, y) => { generateBook.Enabled = true; };
            c.CreatePdf();
            generateBook.Enabled = false;
        }
    }
}