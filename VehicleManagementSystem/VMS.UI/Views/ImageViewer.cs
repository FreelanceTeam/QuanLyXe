using System;
using System.Drawing;
using System.Windows.Forms;

namespace VMS.UI.Views
{
    public partial class ImageViewer : Form
    {
        private readonly Image _image;
        public ImageViewer(Image image)
        {
            InitializeComponent();
            _image = image;
        }

        private void ImageViewer_Load(object sender, EventArgs e)
        {
            picHinhAnh.Image = _image;
        }

        private void ImageViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}