namespace Gra_w_Zycie
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.Var1 = new System.Windows.Forms.NumericUpDown();
            this.Var3 = new System.Windows.Forms.NumericUpDown();
            this.Var2 = new System.Windows.Forms.NumericUpDown();
            this.Var4 = new System.Windows.Forms.NumericUpDown();
            this.NextGen = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Licznik = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.NumberOfCells = new System.Windows.Forms.NumericUpDown();
            this.ChangeSize = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Var1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Var3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Var2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Var4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfCells)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainPanel.Location = new System.Drawing.Point(279, 1);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(500, 500);
            this.MainPanel.TabIndex = 0;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            this.MainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseMove);
            // 
            // Var1
            // 
            this.Var1.Location = new System.Drawing.Point(35, 42);
            this.Var1.Name = "Var1";
            this.Var1.Size = new System.Drawing.Size(28, 20);
            this.Var1.TabIndex = 1;
            this.Var1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Var3
            // 
            this.Var3.Location = new System.Drawing.Point(99, 42);
            this.Var3.Name = "Var3";
            this.Var3.Size = new System.Drawing.Size(28, 20);
            this.Var3.TabIndex = 2;
            this.Var3.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Var2
            // 
            this.Var2.Location = new System.Drawing.Point(69, 42);
            this.Var2.Name = "Var2";
            this.Var2.Size = new System.Drawing.Size(28, 20);
            this.Var2.TabIndex = 3;
            this.Var2.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Var4
            // 
            this.Var4.Location = new System.Drawing.Point(133, 42);
            this.Var4.Name = "Var4";
            this.Var4.Size = new System.Drawing.Size(28, 20);
            this.Var4.TabIndex = 4;
            this.Var4.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // NextGen
            // 
            this.NextGen.Location = new System.Drawing.Point(35, 68);
            this.NextGen.Name = "NextGen";
            this.NextGen.Size = new System.Drawing.Size(126, 34);
            this.NextGen.TabIndex = 5;
            this.NextGen.Text = "Next Generation";
            this.NextGen.UseVisualStyleBackColor = true;
            this.NextGen.Click += new System.EventHandler(this.NextGen_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 37);
            this.button1.TabIndex = 6;
            this.button1.Text = "Random Life Seed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Licznik
            // 
            this.Licznik.Location = new System.Drawing.Point(109, 12);
            this.Licznik.Name = "Licznik";
            this.Licznik.Size = new System.Drawing.Size(86, 24);
            this.Licznik.TabIndex = 8;
            this.Licznik.Paint += new System.Windows.Forms.PaintEventHandler(this.Licznik_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Generation:";
            // 
            // NumberOfCells
            // 
            this.NumberOfCells.Location = new System.Drawing.Point(12, 481);
            this.NumberOfCells.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumberOfCells.Name = "NumberOfCells";
            this.NumberOfCells.Size = new System.Drawing.Size(85, 20);
            this.NumberOfCells.TabIndex = 10;
            this.NumberOfCells.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ChangeSize
            // 
            this.ChangeSize.Location = new System.Drawing.Point(99, 481);
            this.ChangeSize.Name = "ChangeSize";
            this.ChangeSize.Size = new System.Drawing.Size(174, 21);
            this.ChangeSize.TabIndex = 11;
            this.ChangeSize.Text = "Ustaw Rozmiar";
            this.ChangeSize.UseVisualStyleBackColor = true;
            this.ChangeSize.Click += new System.EventHandler(this.ChangeSize_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 434);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(146, 434);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Load";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 504);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(569, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tip: Czy wiedziałeś, że możesz zaimportować do tego programu dowolny model popula" +
    "cji, za pomocą edycji pliku XML?";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(75, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(86, 24);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(75, 218);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(86, 24);
            this.panel2.TabIndex = 9;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Born";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Dead";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(188, 118);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown1.TabIndex = 17;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(188, 77);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown2.TabIndex = 18;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "X";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 520);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ChangeSize);
            this.Controls.Add(this.NumberOfCells);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Licznik);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NextGen);
            this.Controls.Add(this.Var4);
            this.Controls.Add(this.Var2);
            this.Controls.Add(this.Var3);
            this.Controls.Add(this.Var1);
            this.Controls.Add(this.MainPanel);
            this.Name = "Form1";
            this.Text = "GameLife";
            ((System.ComponentModel.ISupportInitialize)(this.Var1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Var3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Var2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Var4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfCells)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.NumericUpDown Var1;
        private System.Windows.Forms.NumericUpDown Var3;
        private System.Windows.Forms.NumericUpDown Var2;
        private System.Windows.Forms.NumericUpDown Var4;
        private System.Windows.Forms.Button NextGen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel Licznik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumberOfCells;
        private System.Windows.Forms.Button ChangeSize;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

