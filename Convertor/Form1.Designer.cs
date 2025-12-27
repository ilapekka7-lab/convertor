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
            cb1 = new ComboBox();
            lb1 = new LinkLabel();
            lb2 = new Label();
            btnUpdate = new Button();
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
            convert.Location = new Point(75, 95);
            convert.Name = "convert";
            convert.Size = new Size(117, 23);
            convert.TabIndex = 3;
            convert.Text = "конвертировать";
            convert.UseVisualStyleBackColor = true;
            convert.Click += convert_Click;
            // 
            // cb1
            // 
            cb1.FormattingEnabled = true;
            cb1.Items.AddRange(new object[] { "доллары в рубли", "рубли в доллары" });
            cb1.Location = new Point(237, 96);
            cb1.Name = "cb1";
            cb1.RightToLeft = RightToLeft.No;
            cb1.Size = new Size(121, 23);
            cb1.TabIndex = 4;
            cb1.SelectedIndexChanged += cb1_SelectedIndexChanged;
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
            lb2.Size = new Size(38, 15);
            lb2.TabIndex = 6;
            lb2.Text = "label1";
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdate);
            Controls.Add(lb2);
            Controls.Add(lb1);
            Controls.Add(cb1);
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
        private ComboBox cb1;
        private LinkLabel lb1;
        private Label lb2;
        private Button btnUpdate;
    }
}
