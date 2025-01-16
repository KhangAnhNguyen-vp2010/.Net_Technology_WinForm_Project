namespace QuanLyThuVien
{
    partial class DangKyNhanVien
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_mkag = new System.Windows.Forms.TextBox();
            this.textBox_mk = new System.Windows.Forms.TextBox();
            this.textBox_tentk = new System.Windows.Forms.TextBox();
            this.comboBox_vaitro = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_mkag);
            this.groupBox1.Controls.Add(this.textBox_mk);
            this.groupBox1.Controls.Add(this.textBox_tentk);
            this.groupBox1.Controls.Add(this.comboBox_vaitro);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(111, 84);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(774, 460);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đăng ký";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBox_mkag
            // 
            this.textBox_mkag.Location = new System.Drawing.Point(390, 197);
            this.textBox_mkag.Name = "textBox_mkag";
            this.textBox_mkag.Size = new System.Drawing.Size(246, 40);
            this.textBox_mkag.TabIndex = 12;
            // 
            // textBox_mk
            // 
            this.textBox_mk.Location = new System.Drawing.Point(390, 134);
            this.textBox_mk.Name = "textBox_mk";
            this.textBox_mk.Size = new System.Drawing.Size(246, 40);
            this.textBox_mk.TabIndex = 11;
            // 
            // textBox_tentk
            // 
            this.textBox_tentk.Location = new System.Drawing.Point(390, 69);
            this.textBox_tentk.Name = "textBox_tentk";
            this.textBox_tentk.Size = new System.Drawing.Size(246, 40);
            this.textBox_tentk.TabIndex = 10;
            // 
            // comboBox_vaitro
            // 
            this.comboBox_vaitro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vaitro.FormattingEnabled = true;
            this.comboBox_vaitro.Items.AddRange(new object[] {
            "staff",
            "manager"});
            this.comboBox_vaitro.Location = new System.Drawing.Point(390, 260);
            this.comboBox_vaitro.Name = "comboBox_vaitro";
            this.comboBox_vaitro.Size = new System.Drawing.Size(246, 41);
            this.comboBox_vaitro.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(224, 345);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(330, 66);
            this.button1.TabIndex = 8;
            this.button1.Text = "Đăng ký";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 263);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "Vai trò";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 200);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhập lại mật khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên tài khoản";
            // 
            // DangKyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 644);
            this.Controls.Add(this.groupBox1);
            this.Name = "DangKyNhanVien";
            this.Text = "DangKyNhanVien";
            this.Load += new System.EventHandler(this.DangKyNhanVien_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_vaitro;
        private System.Windows.Forms.TextBox textBox_mkag;
        private System.Windows.Forms.TextBox textBox_mk;
        private System.Windows.Forms.TextBox textBox_tentk;
    }
}