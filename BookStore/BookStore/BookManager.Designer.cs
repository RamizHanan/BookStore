namespace BookStore
{
    partial class BookManager
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxISBN = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.LabelPrice = new System.Windows.Forms.Label();
            this.LabelISBN = new System.Windows.Forms.Label();
            this.LabelAuthor = new System.Windows.Forms.Label();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxNewPrice = new System.Windows.Forms.TextBox();
            this.textBoxNewISBN = new System.Windows.Forms.TextBox();
            this.textBoxNewAuthor = new System.Windows.Forms.TextBox();
            this.textBoxNewTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CancelAdd = new System.Windows.Forms.Button();
            this.buttonNewBook = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 436);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonCancel);
            this.tabPage1.Controls.Add(this.buttonSave);
            this.tabPage1.Controls.Add(this.buttonBack);
            this.tabPage1.Controls.Add(this.textBoxPrice);
            this.tabPage1.Controls.Add(this.textBoxISBN);
            this.tabPage1.Controls.Add(this.textBoxAuthor);
            this.tabPage1.Controls.Add(this.textBoxTitle);
            this.tabPage1.Controls.Add(this.LabelPrice);
            this.tabPage1.Controls.Add(this.LabelISBN);
            this.tabPage1.Controls.Add(this.LabelAuthor);
            this.tabPage1.Controls.Add(this.LabelTitle);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(780, 410);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Edit Book";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(654, 252);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(109, 23);
            this.buttonCancel.TabIndex = 25;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click_1);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(654, 200);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(109, 23);
            this.buttonSave.TabIndex = 24;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click_1);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(654, 95);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(109, 23);
            this.buttonBack.TabIndex = 22;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click_1);
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(51, 284);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(168, 20);
            this.textBoxPrice.TabIndex = 21;
            // 
            // textBoxISBN
            // 
            this.textBoxISBN.Location = new System.Drawing.Point(51, 239);
            this.textBoxISBN.Name = "textBoxISBN";
            this.textBoxISBN.Size = new System.Drawing.Size(322, 20);
            this.textBoxISBN.TabIndex = 20;
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(51, 193);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(322, 20);
            this.textBoxAuthor.TabIndex = 19;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(51, 143);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(569, 20);
            this.textBoxTitle.TabIndex = 18;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // LabelPrice
            // 
            this.LabelPrice.AutoSize = true;
            this.LabelPrice.Location = new System.Drawing.Point(4, 287);
            this.LabelPrice.Name = "LabelPrice";
            this.LabelPrice.Size = new System.Drawing.Size(34, 13);
            this.LabelPrice.TabIndex = 17;
            this.LabelPrice.Text = "Price:";
            // 
            // LabelISBN
            // 
            this.LabelISBN.AutoSize = true;
            this.LabelISBN.Location = new System.Drawing.Point(4, 242);
            this.LabelISBN.Name = "LabelISBN";
            this.LabelISBN.Size = new System.Drawing.Size(35, 13);
            this.LabelISBN.TabIndex = 16;
            this.LabelISBN.Text = "ISBN:";
            // 
            // LabelAuthor
            // 
            this.LabelAuthor.AutoSize = true;
            this.LabelAuthor.Location = new System.Drawing.Point(4, 200);
            this.LabelAuthor.Name = "LabelAuthor";
            this.LabelAuthor.Size = new System.Drawing.Size(41, 13);
            this.LabelAuthor.TabIndex = 15;
            this.LabelAuthor.Text = "Author:";
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.Location = new System.Drawing.Point(9, 146);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(30, 13);
            this.LabelTitle.TabIndex = 14;
            this.LabelTitle.Text = "Title:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(51, 94);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(569, 21);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.Text = "Edit an Existing Book";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.textBoxNewPrice);
            this.tabPage2.Controls.Add(this.textBoxNewISBN);
            this.tabPage2.Controls.Add(this.textBoxNewAuthor);
            this.tabPage2.Controls.Add(this.textBoxNewTitle);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.CancelAdd);
            this.tabPage2.Controls.Add(this.buttonNewBook);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(780, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add Book";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxNewPrice
            // 
            this.textBoxNewPrice.Location = new System.Drawing.Point(73, 232);
            this.textBoxNewPrice.Name = "textBoxNewPrice";
            this.textBoxNewPrice.Size = new System.Drawing.Size(168, 20);
            this.textBoxNewPrice.TabIndex = 34;
            // 
            // textBoxNewISBN
            // 
            this.textBoxNewISBN.Location = new System.Drawing.Point(73, 187);
            this.textBoxNewISBN.Name = "textBoxNewISBN";
            this.textBoxNewISBN.Size = new System.Drawing.Size(322, 20);
            this.textBoxNewISBN.TabIndex = 33;
            // 
            // textBoxNewAuthor
            // 
            this.textBoxNewAuthor.Location = new System.Drawing.Point(73, 141);
            this.textBoxNewAuthor.Name = "textBoxNewAuthor";
            this.textBoxNewAuthor.Size = new System.Drawing.Size(322, 20);
            this.textBoxNewAuthor.TabIndex = 32;
            // 
            // textBoxNewTitle
            // 
            this.textBoxNewTitle.Location = new System.Drawing.Point(73, 91);
            this.textBoxNewTitle.Name = "textBoxNewTitle";
            this.textBoxNewTitle.Size = new System.Drawing.Size(569, 20);
            this.textBoxNewTitle.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "ISBN:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Author:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Title:";
            // 
            // CancelAdd
            // 
            this.CancelAdd.Location = new System.Drawing.Point(648, 225);
            this.CancelAdd.Name = "CancelAdd";
            this.CancelAdd.Size = new System.Drawing.Size(109, 23);
            this.CancelAdd.TabIndex = 26;
            this.CancelAdd.Text = "Cancel";
            this.CancelAdd.UseVisualStyleBackColor = true;
            this.CancelAdd.Click += new System.EventHandler(this.CancelAdd_Click);
            // 
            // buttonNewBook
            // 
            this.buttonNewBook.Location = new System.Drawing.Point(648, 171);
            this.buttonNewBook.Name = "buttonNewBook";
            this.buttonNewBook.Size = new System.Drawing.Size(109, 23);
            this.buttonNewBook.TabIndex = 24;
            this.buttonNewBook.Text = "Add Book";
            this.buttonNewBook.UseVisualStyleBackColor = true;
            this.buttonNewBook.Click += new System.EventHandler(this.buttonNewBook_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(648, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BookManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "BookManager";
            this.Text = "BookManager";
            this.Load += new System.EventHandler(this.BookManager_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxISBN;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label LabelPrice;
        private System.Windows.Forms.Label LabelISBN;
        private System.Windows.Forms.Label LabelAuthor;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxNewPrice;
        private System.Windows.Forms.TextBox textBoxNewISBN;
        private System.Windows.Forms.TextBox textBoxNewAuthor;
        private System.Windows.Forms.TextBox textBoxNewTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CancelAdd;
        private System.Windows.Forms.Button buttonNewBook;
        private System.Windows.Forms.Button button1;
    }
}