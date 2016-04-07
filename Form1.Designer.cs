namespace GeneticTest
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnNewGen = new System.Windows.Forms.Button();
            this.btnNextGen = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.StatusStrip();
            this.stsGeneration = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsAvgDistance = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsOther = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tmr
            // 
            this.tmr.Interval = 200;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(223, 410);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "Generate 200 more generations";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(411, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(242, 394);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnNewGen
            // 
            this.btnNewGen.Location = new System.Drawing.Point(411, 414);
            this.btnNewGen.Name = "btnNewGen";
            this.btnNewGen.Size = new System.Drawing.Size(124, 32);
            this.btnNewGen.TabIndex = 4;
            this.btnNewGen.Text = "New generation";
            this.btnNewGen.UseVisualStyleBackColor = true;
            this.btnNewGen.Click += new System.EventHandler(this.btnNewGen_Click);
            // 
            // btnNextGen
            // 
            this.btnNextGen.Location = new System.Drawing.Point(541, 417);
            this.btnNextGen.Name = "btnNextGen";
            this.btnNextGen.Size = new System.Drawing.Size(111, 29);
            this.btnNextGen.TabIndex = 5;
            this.btnNextGen.Text = "Next Generation";
            this.btnNextGen.UseVisualStyleBackColor = true;
            this.btnNextGen.Click += new System.EventHandler(this.btnNextGen_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsGeneration,
            this.stsAvgDistance,
            this.stsOther});
            this.status.Location = new System.Drawing.Point(0, 452);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(660, 22);
            this.status.TabIndex = 6;
            this.status.Text = "statusStrip1";
            // 
            // stsGeneration
            // 
            this.stsGeneration.Name = "stsGeneration";
            this.stsGeneration.Size = new System.Drawing.Size(77, 17);
            this.stsGeneration.Text = "Generation: 1";
            // 
            // stsAvgDistance
            // 
            this.stsAvgDistance.Name = "stsAvgDistance";
            this.stsAvgDistance.Size = new System.Drawing.Size(110, 17);
            this.stsAvgDistance.Text = "Average Distance: 8";
            // 
            // stsOther
            // 
            this.stsOther.Name = "stsOther";
            this.stsOther.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 474);
            this.Controls.Add(this.status);
            this.Controls.Add(this.btnNextGen);
            this.Controls.Add(this.btnNewGen);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnNewGen;
        private System.Windows.Forms.Button btnNextGen;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel stsGeneration;
        private System.Windows.Forms.ToolStripStatusLabel stsAvgDistance;
        private System.Windows.Forms.ToolStripStatusLabel stsOther;
    }
}

