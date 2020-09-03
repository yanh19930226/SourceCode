namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.myButton3 = new WindowsFormsApplication2.MyButton();
            this.myButton2 = new WindowsFormsApplication2.MyButton();
            this.myButton1 = new WindowsFormsApplication2.MyButton();
            this.myButton11 = new WindowsFormsApplication2.MyButton1();
            this.SuspendLayout();
            // 
            // myButton3
            // 
            this.myButton3.Location = new System.Drawing.Point(99, 168);
            this.myButton3.Name = "myButton3";
            this.myButton3.Size = new System.Drawing.Size(75, 23);
            this.myButton3.TabIndex = 2;
            this.myButton3.Text = "myButton3";
            this.myButton3.UseVisualStyleBackColor = true;
            // 
            // myButton2
            // 
            this.myButton2.Location = new System.Drawing.Point(74, 86);
            this.myButton2.Name = "myButton2";
            this.myButton2.Size = new System.Drawing.Size(101, 56);
            this.myButton2.TabIndex = 1;
            this.myButton2.Text = "myButton2";
            this.myButton2.UseVisualStyleBackColor = true;
            this.myButton2.Click += new System.EventHandler(this.myButton2_Click);
            // 
            // myButton1
            // 
            this.myButton1.Location = new System.Drawing.Point(90, 36);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(75, 23);
            this.myButton1.TabIndex = 0;
            this.myButton1.Text = "myButton1";
            this.myButton1.UseVisualStyleBackColor = true;
            // 
            // myButton11
            // 
            this.myButton11.Location = new System.Drawing.Point(112, 212);
            this.myButton11.Name = "myButton11";
            this.myButton11.Size = new System.Drawing.Size(75, 23);
            this.myButton11.TabIndex = 3;
            this.myButton11.Text = "myButton11";
            this.myButton11.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.myButton11);
            this.Controls.Add(this.myButton3);
            this.Controls.Add(this.myButton2);
            this.Controls.Add(this.myButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MyButton myButton1;
        private MyButton myButton2;
        private MyButton myButton3;
        private MyButton1 myButton11;
    }
}

