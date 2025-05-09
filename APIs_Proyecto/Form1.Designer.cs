namespace CatApiWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxBreeds;
        private System.Windows.Forms.PictureBox pictureBoxCat;
        private System.Windows.Forms.Label labelCatInfo;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxBreeds = new System.Windows.Forms.ListBox();
            this.pictureBoxCat = new System.Windows.Forms.PictureBox();
            this.labelCatInfo = new System.Windows.Forms.Label();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCat)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxBreeds
            // 
            this.listBoxBreeds.FormattingEnabled = true;
            this.listBoxBreeds.ItemHeight = 15;
            this.listBoxBreeds.Location = new System.Drawing.Point(12, 12);
            this.listBoxBreeds.Name = "listBoxBreeds";
            this.listBoxBreeds.Size = new System.Drawing.Size(200, 304);
            this.listBoxBreeds.TabIndex = 0;
            this.listBoxBreeds.SelectedIndexChanged += new System.EventHandler(this.listBoxBreeds_SelectedIndexChanged);
            // 
            // pictureBoxCat
            // 
            this.pictureBoxCat.Location = new System.Drawing.Point(230, 12);
            this.pictureBoxCat.Name = "pictureBoxCat";
            this.pictureBoxCat.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxCat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCat.TabIndex = 1;
            this.pictureBoxCat.TabStop = false;
            // 
            // labelCatInfo
            // 
            this.labelCatInfo.AutoSize = true;
            this.labelCatInfo.Location = new System.Drawing.Point(12, 330);
            this.labelCatInfo.Name = "labelCatInfo";
            this.labelCatInfo.Size = new System.Drawing.Size(0, 15);
            this.labelCatInfo.TabIndex = 2;
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(230, 330);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(140, 40);
            this.btnSaveToFile.TabIndex = 3;
            this.btnSaveToFile.Text = "Guardar JSON";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(390, 330);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 40);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Limpiar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(544, 381);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSaveToFile);
            this.Controls.Add(this.labelCatInfo);
            this.Controls.Add(this.pictureBoxCat);
            this.Controls.Add(this.listBoxBreeds);
            this.Name = "Form1";
            this.Text = "Cat API Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
