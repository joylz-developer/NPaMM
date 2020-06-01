namespace NPaMM {
  partial class Form1 {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent() {
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label4 = new System.Windows.Forms.Label();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.button3 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.textBox4 = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.button4 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.listView1 = new System.Windows.Forms.ListView();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(680, 549);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(861, 581);
      this.tabControl1.TabIndex = 1;
      this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.splitContainer1);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(853, 555);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Network diagram";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer1.Location = new System.Drawing.Point(3, 3);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
      this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
      this.splitContainer1.Size = new System.Drawing.Size(847, 549);
      this.splitContainer1.SplitterDistance = 680;
      this.splitContainer1.TabIndex = 1;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.textBox3);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Controls.Add(this.button3);
      this.groupBox2.Controls.Add(this.button2);
      this.groupBox2.Controls.Add(this.textBox2);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Location = new System.Drawing.Point(3, 147);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(161, 140);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Bind";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(61, 37);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(10, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "-";
      // 
      // textBox3
      // 
      this.textBox3.Location = new System.Drawing.Point(72, 33);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(44, 20);
      this.textBox3.TabIndex = 8;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(57, 85);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(16, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "or";
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(16, 101);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(100, 23);
      this.button3.TabIndex = 6;
      this.button3.Text = "Remove bind";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(16, 59);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(100, 23);
      this.button2.TabIndex = 3;
      this.button2.Text = "Add bind";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(16, 33);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(44, 20);
      this.textBox2.TabIndex = 5;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 17);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(30, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Time";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.textBox4);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.button4);
      this.groupBox1.Controls.Add(this.button1);
      this.groupBox1.Controls.Add(this.textBox1);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Location = new System.Drawing.Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(161, 138);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Model";
      // 
      // textBox4
      // 
      this.textBox4.Location = new System.Drawing.Point(18, 77);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new System.Drawing.Size(117, 20);
      this.textBox4.TabIndex = 5;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(20, 61);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(44, 13);
      this.label5.TabIndex = 4;
      this.label5.Text = "Number";
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(79, 103);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(56, 23);
      this.button4.TabIndex = 3;
      this.button4.Text = "Edit";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(18, 103);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(55, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "Add";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(18, 35);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(117, 20);
      this.textBox1.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(15, 19);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Name";
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.groupBox3);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(853, 555);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Сalculations";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.listView1);
      this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
      this.groupBox3.Location = new System.Drawing.Point(3, 3);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(384, 549);
      this.groupBox3.TabIndex = 0;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Data";
      // 
      // listView1
      // 
      this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView1.HideSelection = false;
      this.listView1.Location = new System.Drawing.Point(3, 16);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(378, 530);
      this.listView1.TabIndex = 0;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(861, 581);
      this.Controls.Add(this.tabControl1);
      this.Name = "Form1";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Network planning and management models";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
    }
}

