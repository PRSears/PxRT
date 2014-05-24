using System;
using System.IO;
using System.Windows.Forms;

namespace PxRT
{
    public partial class PreviewWindow : Form
    {
        private string ImagePath;
        private string TempImagePath;
        private PixelWrapper Image;
        private byte Threshold;

        public PreviewWindow()
        {
            InitializeComponent();
            ImagePath = "";
            Threshold = (byte)thresholdTrackBar.Value;

            TempImagePath = "temp.png";

            if (File.Exists(TempImagePath))
                File.Delete(TempImagePath); // clear any old temps
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openImageDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ImagePath = previewBox.ImageLocation = openImageDialog.FileName;
                Image = new PixelWrapper(ImagePath);

                previewBox.Update();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (Image == null)
                return;

            DialogResult result = saveImageDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (Image != null)
                    Image.SaveAs(saveImageDialog.FileName);
            }
        }

        private void thresholdTrackBar_Scroll(object sender, EventArgs e)
        {
            Threshold = (byte)thresholdTrackBar.Value;
            thresholdTextBox.Text = "" + thresholdTrackBar.Value;
        }

        private void sortVButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 15;

            if (Image == null)
                return;
            else
                Image.Lock(); // make sure the pixels are locked

            if (Threshold == 255)
                PixelSorter.SortVerticals(Image);
            else
                PixelSorter.SortVerticalsBelowThreshold(Image, Threshold);

            progressBar.Value = 80;

            SaveTemp();
            previewBox.ImageLocation = TempImagePath;
            previewBox.Update();

            progressBar.Value = 100;
        }

        private void sortHButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 15;

            if (Image == null)
                return;
            else
                Image.Lock(); // make sure the pixels are locked

            if (Threshold == 255)
                PixelSorter.SortHorizontals(Image);
            else
                PixelSorter.SortHorizontalsBelowThreshold(Image, Threshold);

            progressBar.Value = 80;

            SaveTemp();
            previewBox.ImageLocation = TempImagePath;
            previewBox.Update();

            progressBar.Value = 100;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (Image == null)
                return;

            Image = new PixelWrapper(ImagePath);
            previewBox.ImageLocation = ImagePath;
            previewBox.Update();

            progressBar.Value = 0;
        }

        private void SaveTemp()
        {
            if (Image != null)
            {
                if (File.Exists(TempImagePath))
                    File.Delete(TempImagePath);

                Image.SaveAs(TempImagePath);
            }
        }

        private void dangerZone_Click(object sender, EventArgs e)
        {
            progressBar.Value = 15;

            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch watch2 = new System.Diagnostics.Stopwatch();

            Image = new PixelWrapper(ImagePath, false);
            Image.Load(ImagePath);

            watch.Start();
            UnsafePixelSorter.SortWhole(Image);
            watch.Stop();

            Image = new PixelWrapper(ImagePath);

            watch2.Start();
            PixelSorter.SortWhole(Image);
            watch2.Stop();

            MessageBox.Show("Unsafe: " + watch.ElapsedMilliseconds + ". Safe: " + watch2.ElapsedMilliseconds);

            SaveTemp();
            previewBox.ImageLocation = TempImagePath;
            previewBox.Update();

            progressBar.Value = 100;
        }
    }
}
