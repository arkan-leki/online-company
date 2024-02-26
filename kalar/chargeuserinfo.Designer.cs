namespace online
{
    partial class chargeuserinfo
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
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox32 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.send = new System.Windows.Forms.ComboBox();
            this.rec = new System.Windows.Forms.ComboBox();
            this.price = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.note = new System.Windows.Forms.TextBox();
            this.label140 = new System.Windows.Forms.Label();
            this.label141 = new System.Windows.Forms.Label();
            this.barwar = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox32)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "گواستنەوەی پارە";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(306, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = ":بریکاری نێردەر";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::online.Properties.Resources.Group_571;
            this.pictureBox3.Location = new System.Drawing.Point(28, 525);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(173, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox32
            // 
            this.pictureBox32.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox32.Image = global::online.Properties.Resources.Group_56;
            this.pictureBox32.Location = new System.Drawing.Point(207, 525);
            this.pictureBox32.Name = "pictureBox32";
            this.pictureBox32.Size = new System.Drawing.Size(168, 48);
            this.pictureBox32.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox32.TabIndex = 27;
            this.pictureBox32.TabStop = false;
            this.pictureBox32.Click += new System.EventHandler(this.pictureBox32_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(306, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = ":بریکاری وەرگر";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(308, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "بر";
            // 
            // send
            // 
            this.send.FormattingEnabled = true;
            this.send.Location = new System.Drawing.Point(31, 92);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(270, 21);
            this.send.TabIndex = 415;
            // 
            // rec
            // 
            this.rec.FormattingEnabled = true;
            this.rec.Location = new System.Drawing.Point(28, 162);
            this.rec.Name = "rec";
            this.rec.Size = new System.Drawing.Size(270, 21);
            this.rec.TabIndex = 416;
            // 
            // price
            // 
            this.price.BackColor = System.Drawing.Color.White;
            this.price.Depth = 0;
            this.price.ForeColor = System.Drawing.Color.White;
            this.price.Hint = "";
            this.price.Location = new System.Drawing.Point(28, 226);
            this.price.MaxLength = 32767;
            this.price.MouseState = MaterialSkin.MouseState.HOVER;
            this.price.Name = "price";
            this.price.Padding = new System.Windows.Forms.Padding(5);
            this.price.PasswordChar = '\0';
            this.price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.price.SelectedText = "";
            this.price.SelectionLength = 0;
            this.price.SelectionStart = 0;
            this.price.Size = new System.Drawing.Size(270, 23);
            this.price.TabIndex = 418;
            this.price.TabStop = false;
            this.price.Text = "0";
            this.price.UseSystemPasswordChar = false;
            // 
            // note
            // 
            this.note.Location = new System.Drawing.Point(28, 349);
            this.note.Multiline = true;
            this.note.Name = "note";
            this.note.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.note.Size = new System.Drawing.Size(271, 118);
            this.note.TabIndex = 439;
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label140.Location = new System.Drawing.Point(308, 350);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(37, 16);
            this.label140.TabIndex = 438;
            this.label140.Text = "تێبینی";
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label141.Location = new System.Drawing.Point(308, 294);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(37, 16);
            this.label141.TabIndex = 437;
            this.label141.Text = "بەروار";
            // 
            // barwar
            // 
            this.barwar.CustomFormat = "yyyy/MM/dd";
            this.barwar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.barwar.Location = new System.Drawing.Point(29, 294);
            this.barwar.Name = "barwar";
            this.barwar.Size = new System.Drawing.Size(270, 20);
            this.barwar.TabIndex = 436;
            // 
            // chargeuserinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(419, 585);
            this.Controls.Add(this.note);
            this.Controls.Add(this.label140);
            this.Controls.Add(this.label141);
            this.Controls.Add(this.barwar);
            this.Controls.Add(this.price);
            this.Controls.Add(this.rec);
            this.Controls.Add(this.send);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox32);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "chargeuserinfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "chaneuserinfo";
            this.Load += new System.EventHandler(this.chaneuserinfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox32)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox32;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox send;
        private System.Windows.Forms.ComboBox rec;
        private MaterialSkin.Controls.MaterialSingleLineTextField price;
        private System.Windows.Forms.TextBox note;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.Label label141;
        private System.Windows.Forms.DateTimePicker barwar;
    }
}