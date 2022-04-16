
namespace OOD
{
    partial class SeriesForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbxAddTitle = new System.Windows.Forms.TextBox();
            this.tbxAddEpisodes = new System.Windows.Forms.TextBox();
            this.tbxAddSeasons = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddSeries = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUploadCover = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbxDeleteId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(351, 553);
            this.dataGridView1.TabIndex = 0;
            // 
            // tbxAddTitle
            // 
            this.tbxAddTitle.Location = new System.Drawing.Point(515, 110);
            this.tbxAddTitle.Name = "tbxAddTitle";
            this.tbxAddTitle.Size = new System.Drawing.Size(163, 23);
            this.tbxAddTitle.TabIndex = 2;
            // 
            // tbxAddEpisodes
            // 
            this.tbxAddEpisodes.Location = new System.Drawing.Point(481, 163);
            this.tbxAddEpisodes.Name = "tbxAddEpisodes";
            this.tbxAddEpisodes.Size = new System.Drawing.Size(66, 23);
            this.tbxAddEpisodes.TabIndex = 4;
            // 
            // tbxAddSeasons
            // 
            this.tbxAddSeasons.Location = new System.Drawing.Point(645, 163);
            this.tbxAddSeasons.Name = "tbxAddSeasons";
            this.tbxAddSeasons.Size = new System.Drawing.Size(66, 23);
            this.tbxAddSeasons.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(580, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(481, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Episodes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(645, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Seasons";
            // 
            // btnAddSeries
            // 
            this.btnAddSeries.Location = new System.Drawing.Point(550, 201);
            this.btnAddSeries.Name = "btnAddSeries";
            this.btnAddSeries.Size = new System.Drawing.Size(86, 47);
            this.btnAddSeries.TabIndex = 10;
            this.btnAddSeries.Text = "Add Series";
            this.btnAddSeries.UseVisualStyleBackColor = true;
            this.btnAddSeries.Click += new System.EventHandler(this.btnAddSeries_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(378, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 128);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // btnUploadCover
            // 
            this.btnUploadCover.Location = new System.Drawing.Point(371, 162);
            this.btnUploadCover.Name = "btnUploadCover";
            this.btnUploadCover.Size = new System.Drawing.Size(104, 23);
            this.btnUploadCover.TabIndex = 12;
            this.btnUploadCover.Text = "Upload Cover";
            this.btnUploadCover.UseVisualStyleBackColor = true;
            this.btnUploadCover.Click += new System.EventHandler(this.btnUploadCover_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(541, 443);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 47);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete Series";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbxDeleteId
            // 
            this.tbxDeleteId.Location = new System.Drawing.Point(550, 414);
            this.tbxDeleteId.Name = "tbxDeleteId";
            this.tbxDeleteId.Size = new System.Drawing.Size(66, 23);
            this.tbxDeleteId.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(538, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "ID to be removed";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(515, 561);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(145, 42);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update Selected Item";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(643, 14);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(145, 34);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Back To Management";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // SeriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 647);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxDeleteId);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUploadCover);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddSeries);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxAddSeasons);
            this.Controls.Add(this.tbxAddEpisodes);
            this.Controls.Add(this.tbxAddTitle);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SeriesForm";
            this.Text = "SeriesForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbxAddTitle;
        private System.Windows.Forms.TextBox tbxAddEpisodes;
        private System.Windows.Forms.TextBox tbxAddSeasons;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddSeries;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnUploadCover;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tbxDeleteId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnBack;
    }
}