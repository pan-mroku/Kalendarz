namespace gr._1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ustawienia_dnia = new System.Windows.Forms.NumericUpDown();
            this.ustaw_miesiac = new System.Windows.Forms.NumericUpDown();
            this.ustaw_rok = new System.Windows.Forms.NumericUpDown();
            this.zatwierdz_ustaw = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ustawienia_dnia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ustaw_miesiac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ustaw_rok)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(12, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 18);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(12, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(371, 340);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(389, 135);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(191, 319);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel4.Location = new System.Drawing.Point(12, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(371, 34);
            this.panel4.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel5.Location = new System.Drawing.Point(12, 65);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(371, 43);
            this.panel5.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel6.Controls.Add(this.textBox1);
            this.panel6.Controls.Add(this.zatwierdz_ustaw);
            this.panel6.Controls.Add(this.ustaw_rok);
            this.panel6.Controls.Add(this.ustaw_miesiac);
            this.panel6.Controls.Add(this.ustawienia_dnia);
            this.panel6.Location = new System.Drawing.Point(389, 25);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(191, 104);
            this.panel6.TabIndex = 3;
            // 
            // ustawienia_dnia
            // 
            this.ustawienia_dnia.BackColor = System.Drawing.SystemColors.Window;
            this.ustawienia_dnia.Location = new System.Drawing.Point(3, 14);
            this.ustawienia_dnia.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.ustawienia_dnia.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ustawienia_dnia.Name = "ustawienia_dnia";
            this.ustawienia_dnia.Size = new System.Drawing.Size(54, 20);
            this.ustawienia_dnia.TabIndex = 0;
            this.ustawienia_dnia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ustawienia_dnia.ThousandsSeparator = true;
            this.ustawienia_dnia.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ustaw_miesiac
            // 
            this.ustaw_miesiac.BackColor = System.Drawing.SystemColors.Window;
            this.ustaw_miesiac.Location = new System.Drawing.Point(63, 14);
            this.ustaw_miesiac.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.ustaw_miesiac.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ustaw_miesiac.Name = "ustaw_miesiac";
            this.ustaw_miesiac.Size = new System.Drawing.Size(44, 20);
            this.ustaw_miesiac.TabIndex = 1;
            this.ustaw_miesiac.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ustaw_miesiac.ThousandsSeparator = true;
            this.ustaw_miesiac.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ustaw_rok
            // 
            this.ustaw_rok.BackColor = System.Drawing.SystemColors.Window;
            this.ustaw_rok.Location = new System.Drawing.Point(113, 14);
            this.ustaw_rok.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ustaw_rok.Minimum = new decimal(new int[] {
            2011,
            0,
            0,
            0});
            this.ustaw_rok.Name = "ustaw_rok";
            this.ustaw_rok.Size = new System.Drawing.Size(75, 20);
            this.ustaw_rok.TabIndex = 2;
            this.ustaw_rok.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ustaw_rok.ThousandsSeparator = true;
            this.ustaw_rok.Value = new decimal(new int[] {
            2012,
            0,
            0,
            0});
            // 
            // zatwierdz_ustaw
            // 
            this.zatwierdz_ustaw.BackColor = System.Drawing.SystemColors.HighlightText;
            this.zatwierdz_ustaw.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.zatwierdz_ustaw.Location = new System.Drawing.Point(0, 81);
            this.zatwierdz_ustaw.Name = "zatwierdz_ustaw";
            this.zatwierdz_ustaw.Size = new System.Drawing.Size(191, 23);
            this.zatwierdz_ustaw.TabIndex = 3;
            this.zatwierdz_ustaw.Text = "Wpisz";
            this.zatwierdz_ustaw.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(188, 20);
            this.textBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(592, 466);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kalendarz";
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ustawienia_dnia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ustaw_miesiac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ustaw_rok)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button zatwierdz_ustaw;
        private System.Windows.Forms.NumericUpDown ustaw_rok;
        private System.Windows.Forms.NumericUpDown ustaw_miesiac;
        private System.Windows.Forms.NumericUpDown ustawienia_dnia;
    }
}

