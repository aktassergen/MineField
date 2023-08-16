namespace MineField2
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
            components = new System.ComponentModel.Container();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(536, 117);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 20;
            label4.Text = "Sure Bilgisi  =";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(536, 73);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 19;
            label3.Text = "Mayın Sayisi=";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(536, 29);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 18;
            label2.Text = "Kalan Sure  =";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(640, 114);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(148, 27);
            textBox2.TabIndex = 17;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(640, 70);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(148, 27);
            textBox1.TabIndex = 16;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ControlLightLight;
            label1.Location = new Point(640, 24);
            label1.Name = "label1";
            label1.Size = new Size(148, 25);
            label1.TabIndex = 15;
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(694, 156);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 14;
            button1.Text = "Baslat";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}