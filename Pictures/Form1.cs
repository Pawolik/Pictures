using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Pictures.Properties;

namespace Pictures
{
    public partial class Form1 : Form
    {
        private string imagePath;

        public Form1()
        {
            InitializeComponent();
            //MessageBox.Show("Program pozwala wyświelić pliki z dysku. \n Jeżeli chcesz aby program pamiętał wybrany obraz kliknij ZAPISZ. \n W celu wyczyszczenia programu kliknij usuń.");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Zdjęcie.ShowDialog();
            imagePath = Zdjęcie.FileName;
            pbxBox.Image = Image.FromFile(imagePath);

            if (imagePath != null)
            {
                btnClear.Visible = true;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pbxBox.Image = null;
            btnClear.Visible = false;
            File.Delete("image_path.txt");
            imagePath = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @"(*.jpg, *.jpeg, *.png)| *.jpg; *.jpeg; *.png" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbxBox.Image.Save(saveFileDialog.FileName);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                File.WriteAllText("image_path.txt", imagePath);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("image_path.txt"))
            {
                imagePath = File.ReadAllText("image_path.txt");
                if (!string.IsNullOrEmpty(imagePath))
                {
                    pbxBox.ImageLocation = imagePath;
                    btnClear.Visible = true;
                }
            }
        }
    }
}
