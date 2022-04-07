
namespace OOD
{
    partial class ItemManagement
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnRedirectManga = new System.Windows.Forms.Button();
            this.btnRedirectBook = new System.Windows.Forms.Button();
            this.btnRedirectComic = new System.Windows.Forms.Button();
            this.btnRedirectSeries = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(292, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(505, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a category to modify";
            // 
            // btnRedirectManga
            // 
            this.btnRedirectManga.BackColor = System.Drawing.Color.DarkRed;
            this.btnRedirectManga.Location = new System.Drawing.Point(116, 213);
            this.btnRedirectManga.Name = "btnRedirectManga";
            this.btnRedirectManga.Size = new System.Drawing.Size(177, 139);
            this.btnRedirectManga.TabIndex = 1;
            this.btnRedirectManga.Text = "Manga";
            this.btnRedirectManga.UseVisualStyleBackColor = false;
            this.btnRedirectManga.Click += new System.EventHandler(this.btnRedirectManga_Click);
            // 
            // btnRedirectBook
            // 
            this.btnRedirectBook.BackColor = System.Drawing.Color.DarkRed;
            this.btnRedirectBook.Location = new System.Drawing.Point(341, 213);
            this.btnRedirectBook.Name = "btnRedirectBook";
            this.btnRedirectBook.Size = new System.Drawing.Size(177, 139);
            this.btnRedirectBook.TabIndex = 2;
            this.btnRedirectBook.Text = "Books";
            this.btnRedirectBook.UseVisualStyleBackColor = false;
            // 
            // btnRedirectComic
            // 
            this.btnRedirectComic.BackColor = System.Drawing.Color.DarkRed;
            this.btnRedirectComic.Location = new System.Drawing.Point(563, 213);
            this.btnRedirectComic.Name = "btnRedirectComic";
            this.btnRedirectComic.Size = new System.Drawing.Size(177, 139);
            this.btnRedirectComic.TabIndex = 3;
            this.btnRedirectComic.Text = "Comics";
            this.btnRedirectComic.UseVisualStyleBackColor = false;
            // 
            // btnRedirectSeries
            // 
            this.btnRedirectSeries.BackColor = System.Drawing.Color.DarkRed;
            this.btnRedirectSeries.Location = new System.Drawing.Point(776, 213);
            this.btnRedirectSeries.Name = "btnRedirectSeries";
            this.btnRedirectSeries.Size = new System.Drawing.Size(177, 139);
            this.btnRedirectSeries.TabIndex = 4;
            this.btnRedirectSeries.Text = "Series";
            this.btnRedirectSeries.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(13, 25);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Go Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ItemManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 543);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRedirectSeries);
            this.Controls.Add(this.btnRedirectComic);
            this.Controls.Add(this.btnRedirectBook);
            this.Controls.Add(this.btnRedirectManga);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "ItemManagement";
            this.Text = "ItemManagement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRedirectManga;
        private System.Windows.Forms.Button btnRedirectBook;
        private System.Windows.Forms.Button btnRedirectComic;
        private System.Windows.Forms.Button btnRedirectSeries;
        private System.Windows.Forms.Button btnBack;
    }
}