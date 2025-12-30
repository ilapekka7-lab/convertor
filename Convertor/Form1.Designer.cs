namespace Convertor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tb1 = new TextBox();
            convert = new Button();
            cbOut = new ComboBox();
            lb1 = new LinkLabel();
            lb2 = new Label();
            btnUpdate = new Button();
            cbIn = new ComboBox();
            tbConsole = new TextBox();
            SuspendLayout();
            // 
            // tb1
            // 
            tb1.Location = new Point(75, 40);
            tb1.Name = "tb1";
            tb1.Size = new Size(75, 23);
            tb1.TabIndex = 1;
            // 
            // convert
            // 
            convert.Location = new Point(397, 95);
            convert.Name = "convert";
            convert.Size = new Size(117, 23);
            convert.TabIndex = 3;
            convert.Text = "конвертировать";
            convert.UseVisualStyleBackColor = true;
            convert.Click += convert_Click;
            // 
            // cbOut
            // 
            cbOut.FormattingEnabled = true;
            cbOut.Items.AddRange(new object[] { "доллары в рубли", "рубли в доллары" });
            cbOut.Location = new Point(75, 96);
            cbOut.Name = "cbOut";
            cbOut.RightToLeft = RightToLeft.No;
            cbOut.Size = new Size(121, 23);
            cbOut.TabIndex = 4;
            cbOut.SelectedIndexChanged += cbOut_SelectedIndexChanged;
            // 
            // lb1
            // 
            lb1.AutoSize = true;
            lb1.LinkColor = Color.Black;
            lb1.Location = new Point(90, 154);
            lb1.Name = "lb1";
            lb1.Size = new Size(41, 15);
            lb1.TabIndex = 5;
            lb1.TabStop = true;
            lb1.Text = "вывод";
            // 
            // lb2
            // 
            lb2.AutoSize = true;
            lb2.Location = new Point(237, 48);
            lb2.Name = "lb2";
            lb2.Size = new Size(32, 15);
            lb2.TabIndex = 6;
            lb2.Text = "курс";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(237, 146);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(169, 23);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "button1";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // cbIn
            // 
            cbIn.FormattingEnabled = true;
            cbIn.Location = new Point(237, 96);
            cbIn.Name = "cbIn";
            cbIn.Size = new Size(121, 23);
            cbIn.TabIndex = 8;
            cbIn.SelectedIndexChanged += cbIn_SelectedIndexChanged;
            // 
            // tbConsole
            // 
            tbConsole.Location = new Point(277, 247);
            tbConsole.Multiline = true;
            tbConsole.Name = "tbConsole";
            tbConsole.Size = new Size(304, 191);
            tbConsole.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbConsole);
            Controls.Add(cbIn);
            Controls.Add(btnUpdate);
            Controls.Add(lb2);
            Controls.Add(lb1);
            Controls.Add(cbOut);
            Controls.Add(convert);
            Controls.Add(tb1);
            Name = "Form1";
            Text = "Form1";
            TransparencyKey = Color.Gainsboro;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tb1;
        private Button convert;
        private ComboBox cbOut;
        private LinkLabel lb1;
        private Label lb2;
        private Button btnUpdate;
        private ComboBox cbIn;
        private TextBox tbConsole;
    }
}
