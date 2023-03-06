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

namespace Pictures
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Program pozwala wyświelić pliki z dysku. \n Jeżeli chcesz aby program pamiętał wybrany obraz kliknij ZAPISZ. \n W celu wyczyszczenia programu kliknij usuń.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Zdjęcie.ShowDialog();
            string filePath = Zdjęcie.FileName;
            pbxBox.Image = Image.FromFile(filePath);
            if (filePath != null)
            {
                btnClear.Visible = true;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pbxBox.Image = null;
            btnClear.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @"JPG|*.jpg" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbxBox.Image.Save(saveFileDialog.FileName);
                }
            }
        }
    }
}
