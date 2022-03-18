namespace YilanOyunu
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.GameArea = new System.Windows.Forms.Panel();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.scoreHeaderLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.baitHeaderLabel = new System.Windows.Forms.Label();
            this.baitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(571, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "BAŞLAT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(686, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "RESET";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GameArea
            // 
            this.GameArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameArea.Location = new System.Drawing.Point(12, 47);
            this.GameArea.Name = "GameArea";
            this.GameArea.Size = new System.Drawing.Size(770, 517);
            this.GameArea.TabIndex = 2;
            // 
            // GameTimer
            // 
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(214, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // scoreHeaderLabel
            // 
            this.scoreHeaderLabel.AutoSize = true;
            this.scoreHeaderLabel.Location = new System.Drawing.Point(281, 13);
            this.scoreHeaderLabel.Name = "scoreHeaderLabel";
            this.scoreHeaderLabel.Size = new System.Drawing.Size(0, 13);
            this.scoreHeaderLabel.TabIndex = 4;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(338, 12);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(0, 13);
            this.scoreLabel.TabIndex = 5;
            // 
            // baitHeaderLabel
            // 
            this.baitHeaderLabel.AutoSize = true;
            this.baitHeaderLabel.Location = new System.Drawing.Point(395, 12);
            this.baitHeaderLabel.Name = "baitHeaderLabel";
            this.baitHeaderLabel.Size = new System.Drawing.Size(0, 13);
            this.baitHeaderLabel.TabIndex = 6;
            // 
            // baitLabel
            // 
            this.baitLabel.AutoSize = true;
            this.baitLabel.Location = new System.Drawing.Point(453, 12);
            this.baitLabel.Name = "baitLabel";
            this.baitLabel.Size = new System.Drawing.Size(0, 13);
            this.baitLabel.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YilanOyunu.Properties.Resources.indir;
            this.ClientSize = new System.Drawing.Size(794, 571);
            this.Controls.Add(this.baitLabel);
            this.Controls.Add(this.baitHeaderLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.scoreHeaderLabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.GameArea);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel GameArea;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label scoreHeaderLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label baitHeaderLabel;
        private System.Windows.Forms.Label baitLabel;
    }
}

