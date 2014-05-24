namespace PxRT
{
    partial class PreviewWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewWindow));
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.openButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.saveButton = new System.Windows.Forms.Button();
            this.sortVButton = new System.Windows.Forms.Button();
            this.sortHButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.resetButton = new System.Windows.Forms.Button();
            this.thresholdTextBox = new System.Windows.Forms.TextBox();
            this.thresholdTrackBar = new System.Windows.Forms.TrackBar();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dangerZone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // previewBox
            // 
            this.previewBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("previewBox.BackgroundImage")));
            this.previewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewBox.Location = new System.Drawing.Point(0, 0);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(1186, 696);
            this.previewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewBox.TabIndex = 0;
            this.previewBox.TabStop = false;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(3, 3);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open...";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.openButton);
            this.flowLayoutPanel1.Controls.Add(this.saveButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(203, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(84, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save As...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // sortVButton
            // 
            this.sortVButton.Location = new System.Drawing.Point(520, 3);
            this.sortVButton.Name = "sortVButton";
            this.sortVButton.Size = new System.Drawing.Size(92, 23);
            this.sortVButton.TabIndex = 2;
            this.sortVButton.Text = "Sort Verticals";
            this.sortVButton.UseVisualStyleBackColor = true;
            this.sortVButton.Click += new System.EventHandler(this.sortVButton_Click);
            // 
            // sortHButton
            // 
            this.sortHButton.Location = new System.Drawing.Point(618, 3);
            this.sortHButton.Name = "sortHButton";
            this.sortHButton.Size = new System.Drawing.Size(93, 23);
            this.sortHButton.TabIndex = 3;
            this.sortHButton.Text = "Sort Horizontals";
            this.sortHButton.UseVisualStyleBackColor = true;
            this.sortHButton.Click += new System.EventHandler(this.sortHButton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.progressBar);
            this.flowLayoutPanel2.Controls.Add(this.resetButton);
            this.flowLayoutPanel2.Controls.Add(this.sortHButton);
            this.flowLayoutPanel2.Controls.Add(this.sortVButton);
            this.flowLayoutPanel2.Controls.Add(this.thresholdTextBox);
            this.flowLayoutPanel2.Controls.Add(this.thresholdTrackBar);
            this.flowLayoutPanel2.Controls.Add(this.thresholdLabel);
            this.flowLayoutPanel2.Controls.Add(this.dangerZone);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(979, 51);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(798, 3);
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(178, 23);
            this.progressBar.TabIndex = 4;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(717, 3);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // thresholdTextBox
            // 
            this.thresholdTextBox.Enabled = false;
            this.thresholdTextBox.Location = new System.Drawing.Point(488, 3);
            this.thresholdTextBox.Name = "thresholdTextBox";
            this.thresholdTextBox.Size = new System.Drawing.Size(26, 20);
            this.thresholdTextBox.TabIndex = 8;
            this.thresholdTextBox.Text = "255";
            // 
            // thresholdTrackBar
            // 
            this.thresholdTrackBar.Location = new System.Drawing.Point(227, 3);
            this.thresholdTrackBar.Maximum = 255;
            this.thresholdTrackBar.Name = "thresholdTrackBar";
            this.thresholdTrackBar.Size = new System.Drawing.Size(255, 45);
            this.thresholdTrackBar.TabIndex = 7;
            this.thresholdTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.thresholdTrackBar.Value = 255;
            this.thresholdTrackBar.Scroll += new System.EventHandler(this.thresholdTrackBar_Scroll);
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Location = new System.Drawing.Point(164, 0);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.thresholdLabel.Size = new System.Drawing.Size(57, 18);
            this.thresholdLabel.TabIndex = 6;
            this.thresholdLabel.Text = "Threshold:";
            // 
            // openImageDialog
            // 
            this.openImageDialog.Filter = "Image Files(*.png;*.JPG;*.BMP)|*.png;*.jpg;*.bmp|All files (*.*)|*.*";
            this.openImageDialog.InitialDirectory = "D:\\code\\PixelSort\\PxRT\\Tests";
            // 
            // saveImageDialog
            // 
            this.saveImageDialog.DefaultExt = "png";
            this.saveImageDialog.FileName = "new1.png";
            this.saveImageDialog.Filter = "Image Files(*.png;*.JPG;*.BMP)|*.png;*.jpg;*.bmp|All files (*.*)|*.*";
            this.saveImageDialog.InitialDirectory = "D:\\code\\PixelSort\\PxRT\\Tests";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 665);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(1186, 31);
            this.splitContainer1.SplitterDistance = 203;
            this.splitContainer1.TabIndex = 4;
            // 
            // dangerZone
            // 
            this.dangerZone.Location = new System.Drawing.Point(59, 3);
            this.dangerZone.Name = "dangerZone";
            this.dangerZone.Size = new System.Drawing.Size(99, 23);
            this.dangerZone.TabIndex = 10;
            this.dangerZone.Text = "DANGER ZONE";
            this.dangerZone.UseVisualStyleBackColor = true;
            this.dangerZone.Click += new System.EventHandler(this.dangerZone_Click);
            // 
            // PreviewWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 696);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.previewBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1008, 500);
            this.Name = "PreviewWindow";
            this.Text = "PxRT Preview";
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBar)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button sortVButton;
        private System.Windows.Forms.Button sortHButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.TrackBar thresholdTrackBar;
        private System.Windows.Forms.TextBox thresholdTextBox;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
        private System.Windows.Forms.SaveFileDialog saveImageDialog;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button dangerZone;
    }
}