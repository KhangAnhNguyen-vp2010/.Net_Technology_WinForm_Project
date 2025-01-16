namespace QuanLyThuVien
{
    partial class PhieuPhat
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_da = new System.Windows.Forms.RadioButton();
            this.radio_chua = new System.Windows.Forms.RadioButton();
            this.textBox_tienphat = new System.Windows.Forms.TextBox();
            this.textBox_mash = new System.Windows.Forms.TextBox();
            this.textBox_madg = new System.Windows.Forms.TextBox();
            this.textBox_mapm = new System.Windows.Forms.TextBox();
            this.maskedTextBox_ngaylap = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_sl = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_sumtien = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.phiếuMươnjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuPhạtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.độcGiảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_rl = new System.Windows.Forms.Button();
            this.button_seach = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_submit = new System.Windows.Forms.Button();
            this.button_del = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(142, 508);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(863, 453);
            this.dataGridView1.TabIndex = 42;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_da);
            this.groupBox1.Controls.Add(this.radio_chua);
            this.groupBox1.Controls.Add(this.textBox_tienphat);
            this.groupBox1.Controls.Add(this.textBox_mash);
            this.groupBox1.Controls.Add(this.textBox_madg);
            this.groupBox1.Controls.Add(this.textBox_mapm);
            this.groupBox1.Controls.Add(this.maskedTextBox_ngaylap);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button_cancel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_submit);
            this.groupBox1.Location = new System.Drawing.Point(142, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(863, 367);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            this.groupBox1.UseCompatibleTextRendering = true;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radioButton_da
            // 
            this.radioButton_da.AutoSize = true;
            this.radioButton_da.Location = new System.Drawing.Point(167, 288);
            this.radioButton_da.Name = "radioButton_da";
            this.radioButton_da.Size = new System.Drawing.Size(136, 24);
            this.radioButton_da.TabIndex = 44;
            this.radioButton_da.TabStop = true;
            this.radioButton_da.Text = "Đã thanh toán";
            this.radioButton_da.UseVisualStyleBackColor = true;
            // 
            // radio_chua
            // 
            this.radio_chua.AutoSize = true;
            this.radio_chua.Location = new System.Drawing.Point(167, 244);
            this.radio_chua.Name = "radio_chua";
            this.radio_chua.Size = new System.Drawing.Size(153, 24);
            this.radio_chua.TabIndex = 43;
            this.radio_chua.TabStop = true;
            this.radio_chua.Text = "Chưa thanh toán";
            this.radio_chua.UseVisualStyleBackColor = true;
            // 
            // textBox_tienphat
            // 
            this.textBox_tienphat.Location = new System.Drawing.Point(429, 163);
            this.textBox_tienphat.Name = "textBox_tienphat";
            this.textBox_tienphat.Size = new System.Drawing.Size(96, 26);
            this.textBox_tienphat.TabIndex = 42;
            this.textBox_tienphat.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox_mash
            // 
            this.textBox_mash.Location = new System.Drawing.Point(694, 78);
            this.textBox_mash.Name = "textBox_mash";
            this.textBox_mash.Size = new System.Drawing.Size(96, 26);
            this.textBox_mash.TabIndex = 40;
            // 
            // textBox_madg
            // 
            this.textBox_madg.Location = new System.Drawing.Point(429, 78);
            this.textBox_madg.Name = "textBox_madg";
            this.textBox_madg.Size = new System.Drawing.Size(96, 26);
            this.textBox_madg.TabIndex = 39;
            // 
            // textBox_mapm
            // 
            this.textBox_mapm.Location = new System.Drawing.Point(167, 78);
            this.textBox_mapm.Name = "textBox_mapm";
            this.textBox_mapm.Size = new System.Drawing.Size(96, 26);
            this.textBox_mapm.TabIndex = 38;
            // 
            // maskedTextBox_ngaylap
            // 
            this.maskedTextBox_ngaylap.Location = new System.Drawing.Point(167, 163);
            this.maskedTextBox_ngaylap.Mask = "00/00/0000";
            this.maskedTextBox_ngaylap.Name = "maskedTextBox_ngaylap";
            this.maskedTextBox_ngaylap.Size = new System.Drawing.Size(96, 26);
            this.maskedTextBox_ngaylap.TabIndex = 36;
            this.maskedTextBox_ngaylap.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_ngaylap.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox_ngaylap_MaskInputRejected);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(306, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 20);
            this.label8.TabIndex = 26;
            this.label8.Text = "Tiền Phạt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(584, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Mã Sách";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-50, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Ngày Lập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Mã Độc Giả";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Mã PM";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1030, 615);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 57;
            this.label9.Text = "Số Lượng";
            // 
            // button_sl
            // 
            this.button_sl.Enabled = false;
            this.button_sl.Location = new System.Drawing.Point(1034, 656);
            this.button_sl.Name = "button_sl";
            this.button_sl.Size = new System.Drawing.Size(54, 49);
            this.button_sl.TabIndex = 56;
            this.button_sl.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1029, 471);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 29);
            this.label10.TabIndex = 62;
            this.label10.Text = "Tìm Kiếm";
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(1034, 521);
            this.textBox_search.Multiline = true;
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(226, 46);
            this.textBox_search.TabIndex = 60;
            // 
            // button_sumtien
            // 
            this.button_sumtien.Location = new System.Drawing.Point(1034, 766);
            this.button_sumtien.Name = "button_sumtien";
            this.button_sumtien.Size = new System.Drawing.Size(302, 48);
            this.button_sumtien.TabIndex = 64;
            this.button_sumtien.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phiếuMươnjToolStripMenuItem,
            this.phiếuPhạtToolStripMenuItem,
            this.độcGiảToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 33);
            this.menuStrip1.TabIndex = 65;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // phiếuMươnjToolStripMenuItem
            // 
            this.phiếuMươnjToolStripMenuItem.Name = "phiếuMươnjToolStripMenuItem";
            this.phiếuMươnjToolStripMenuItem.Size = new System.Drawing.Size(120, 29);
            this.phiếuMươnjToolStripMenuItem.Text = "Phiếu Mượn";
            this.phiếuMươnjToolStripMenuItem.Click += new System.EventHandler(this.phiếuMươnjToolStripMenuItem_Click);
            // 
            // phiếuPhạtToolStripMenuItem
            // 
            this.phiếuPhạtToolStripMenuItem.Name = "phiếuPhạtToolStripMenuItem";
            this.phiếuPhạtToolStripMenuItem.Size = new System.Drawing.Size(107, 29);
            this.phiếuPhạtToolStripMenuItem.Text = "Phiếu Phạt";
            // 
            // độcGiảToolStripMenuItem
            // 
            this.độcGiảToolStripMenuItem.Name = "độcGiảToolStripMenuItem";
            this.độcGiảToolStripMenuItem.Size = new System.Drawing.Size(86, 29);
            this.độcGiảToolStripMenuItem.Text = "Độc Giả";
            this.độcGiảToolStripMenuItem.Click += new System.EventHandler(this.độcGiảToolStripMenuItem_Click);
            // 
            // button_rl
            // 
            this.button_rl.Image = global::QuanLyThuVien.Properties.Resources.icons8_reload_50;
            this.button_rl.Location = new System.Drawing.Point(1189, 625);
            this.button_rl.Name = "button_rl";
            this.button_rl.Size = new System.Drawing.Size(147, 80);
            this.button_rl.TabIndex = 63;
            this.button_rl.UseVisualStyleBackColor = true;
            this.button_rl.Click += new System.EventHandler(this.button_rl_Click);
            // 
            // button_seach
            // 
            this.button_seach.Image = global::QuanLyThuVien.Properties.Resources.icons8_search_30;
            this.button_seach.Location = new System.Drawing.Point(1285, 521);
            this.button_seach.Name = "button_seach";
            this.button_seach.Size = new System.Drawing.Size(51, 46);
            this.button_seach.TabIndex = 61;
            this.button_seach.UseVisualStyleBackColor = true;
            this.button_seach.Click += new System.EventHandler(this.button_seach_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Image = global::QuanLyThuVien.Properties.Resources.icons8_cancel_48;
            this.button_cancel.Location = new System.Drawing.Point(527, 270);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(129, 61);
            this.button_cancel.TabIndex = 24;
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_submit
            // 
            this.button_submit.Image = global::QuanLyThuVien.Properties.Resources.icons8_submit_48;
            this.button_submit.Location = new System.Drawing.Point(661, 203);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(129, 61);
            this.button_submit.TabIndex = 17;
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // button_del
            // 
            this.button_del.Image = global::QuanLyThuVien.Properties.Resources.icons8_delete_48;
            this.button_del.Location = new System.Drawing.Point(1417, 896);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(208, 65);
            this.button_del.TabIndex = 41;
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // button_edit
            // 
            this.button_edit.Image = global::QuanLyThuVien.Properties.Resources.icons8_fix_30;
            this.button_edit.Location = new System.Drawing.Point(1417, 758);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(208, 65);
            this.button_edit.TabIndex = 40;
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // button_add
            // 
            this.button_add.Image = global::QuanLyThuVien.Properties.Resources.icons8_add_48;
            this.button_add.Location = new System.Drawing.Point(1417, 625);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(208, 65);
            this.button_add.TabIndex = 39;
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // PhieuPhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.button_sumtien);
            this.Controls.Add(this.button_rl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button_seach);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button_sl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_del);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PhieuPhat";
            this.Text = "PhieuPhat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PhieuPhat_FormClosing);
            this.Load += new System.EventHandler(this.PhieuPhat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_madg;
        private System.Windows.Forms.TextBox textBox_mapm;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ngaylap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.TextBox textBox_tienphat;
        private System.Windows.Forms.TextBox textBox_mash;
        private System.Windows.Forms.RadioButton radioButton_da;
        private System.Windows.Forms.RadioButton radio_chua;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_sl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_seach;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_rl;
        private System.Windows.Forms.Button button_sumtien;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem phiếuMươnjToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuPhạtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem độcGiảToolStripMenuItem;
    }
}