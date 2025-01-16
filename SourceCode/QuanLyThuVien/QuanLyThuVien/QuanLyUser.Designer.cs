namespace QuanLyThuVien
{
    partial class QuanLyUser
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
            this.maskedTextBox_ll = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_nt = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Vaitro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MK = new System.Windows.Forms.TextBox();
            this.txt_TK = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_sl = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button_rl = new System.Windows.Forms.Button();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_rspass = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.comboBox_user = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox_roleuser = new System.Windows.Forms.ComboBox();
            this.button_setrole = new System.Windows.Forms.Button();
            this.button_done = new System.Windows.Forms.Button();
            this.comboBox_nv = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_del = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_seach = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_submit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maskedTextBox_ll);
            this.groupBox1.Controls.Add(this.maskedTextBox_nt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_Vaitro);
            this.groupBox1.Controls.Add(this.button_cancel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_submit);
            this.groupBox1.Controls.Add(this.txt_MK);
            this.groupBox1.Controls.Add(this.txt_TK);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1062, 302);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 622);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            this.groupBox1.UseCompatibleTextRendering = true;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // maskedTextBox_ll
            // 
            this.maskedTextBox_ll.Location = new System.Drawing.Point(346, 397);
            this.maskedTextBox_ll.Mask = "00/00/0000";
            this.maskedTextBox_ll.Name = "maskedTextBox_ll";
            this.maskedTextBox_ll.Size = new System.Drawing.Size(248, 33);
            this.maskedTextBox_ll.TabIndex = 31;
            this.maskedTextBox_ll.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBox_nt
            // 
            this.maskedTextBox_nt.Location = new System.Drawing.Point(346, 322);
            this.maskedTextBox_nt.Mask = "00/00/0000";
            this.maskedTextBox_nt.Name = "maskedTextBox_nt";
            this.maskedTextBox_nt.Size = new System.Drawing.Size(248, 33);
            this.maskedTextBox_nt.TabIndex = 30;
            this.maskedTextBox_nt.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 401);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 29);
            this.label4.TabIndex = 29;
            this.label4.Text = "Last_Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 29);
            this.label3.TabIndex = 28;
            this.label3.Text = "Ngày tạo";
            // 
            // txt_Vaitro
            // 
            this.txt_Vaitro.Enabled = false;
            this.txt_Vaitro.Location = new System.Drawing.Point(346, 253);
            this.txt_Vaitro.Name = "txt_Vaitro";
            this.txt_Vaitro.Size = new System.Drawing.Size(248, 33);
            this.txt_Vaitro.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 29);
            this.label5.TabIndex = 22;
            this.label5.Text = "Vai trò";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 29);
            this.label2.TabIndex = 19;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "Tên tài khoản";
            // 
            // txt_MK
            // 
            this.txt_MK.Enabled = false;
            this.txt_MK.Location = new System.Drawing.Point(346, 183);
            this.txt_MK.Name = "txt_MK";
            this.txt_MK.Size = new System.Drawing.Size(248, 33);
            this.txt_MK.TabIndex = 13;
            // 
            // txt_TK
            // 
            this.txt_TK.Enabled = false;
            this.txt_TK.Location = new System.Drawing.Point(346, 112);
            this.txt_TK.Name = "txt_TK";
            this.txt_TK.Size = new System.Drawing.Size(248, 33);
            this.txt_TK.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(86, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 47;
            this.label7.Text = "Số Lượng";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // button_sl
            // 
            this.button_sl.Enabled = false;
            this.button_sl.Location = new System.Drawing.Point(88, 228);
            this.button_sl.Name = "button_sl";
            this.button_sl.Size = new System.Drawing.Size(64, 49);
            this.button_sl.TabIndex = 46;
            this.button_sl.UseVisualStyleBackColor = true;
            this.button_sl.Click += new System.EventHandler(this.button_sl_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(184, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 29);
            this.label6.TabIndex = 45;
            this.label6.Text = "Tìm Kiếm";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // button_rl
            // 
            this.button_rl.Location = new System.Drawing.Point(771, 222);
            this.button_rl.Name = "button_rl";
            this.button_rl.Size = new System.Drawing.Size(170, 49);
            this.button_rl.TabIndex = 44;
            this.button_rl.Text = "Load Lại";
            this.button_rl.UseVisualStyleBackColor = true;
            this.button_rl.Click += new System.EventHandler(this.button_rl_Click);
            // 
            // textBox_search
            // 
            this.textBox_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_search.Location = new System.Drawing.Point(316, 222);
            this.textBox_search.Multiline = true;
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(214, 50);
            this.textBox_search.TabIndex = 43;
            this.textBox_search.TextChanged += new System.EventHandler(this.textBox_search_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(78, 302);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(862, 452);
            this.dataGridView1.TabIndex = 41;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button_rspass
            // 
            this.button_rspass.Location = new System.Drawing.Point(6, 35);
            this.button_rspass.Name = "button_rspass";
            this.button_rspass.Size = new System.Drawing.Size(145, 45);
            this.button_rspass.TabIndex = 50;
            this.button_rspass.Text = "Reset Password";
            this.button_rspass.UseVisualStyleBackColor = true;
            this.button_rspass.Click += new System.EventHandler(this.button_rspass_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(300, 35);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(47, 45);
            this.button_ok.TabIndex = 51;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // comboBox_user
            // 
            this.comboBox_user.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_user.FormattingEnabled = true;
            this.comboBox_user.Location = new System.Drawing.Point(166, 44);
            this.comboBox_user.Name = "comboBox_user";
            this.comboBox_user.Size = new System.Drawing.Size(119, 28);
            this.comboBox_user.TabIndex = 52;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_rspass);
            this.groupBox2.Controls.Add(this.button_ok);
            this.groupBox2.Controls.Add(this.comboBox_user);
            this.groupBox2.Location = new System.Drawing.Point(1062, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 105);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đổi Pass";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox_roleuser);
            this.groupBox3.Controls.Add(this.button_setrole);
            this.groupBox3.Controls.Add(this.button_done);
            this.groupBox3.Controls.Add(this.comboBox_nv);
            this.groupBox3.Location = new System.Drawing.Point(1494, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 155);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Phân Quyền";
            // 
            // comboBox_roleuser
            // 
            this.comboBox_roleuser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_roleuser.FormattingEnabled = true;
            this.comboBox_roleuser.Items.AddRange(new object[] {
            "staff",
            "manager"});
            this.comboBox_roleuser.Location = new System.Drawing.Point(166, 95);
            this.comboBox_roleuser.Name = "comboBox_roleuser";
            this.comboBox_roleuser.Size = new System.Drawing.Size(119, 28);
            this.comboBox_roleuser.TabIndex = 53;
            // 
            // button_setrole
            // 
            this.button_setrole.Location = new System.Drawing.Point(6, 44);
            this.button_setrole.Name = "button_setrole";
            this.button_setrole.Size = new System.Drawing.Size(145, 45);
            this.button_setrole.TabIndex = 50;
            this.button_setrole.Text = "Set Role";
            this.button_setrole.UseVisualStyleBackColor = true;
            this.button_setrole.Click += new System.EventHandler(this.button_setrole_Click);
            // 
            // button_done
            // 
            this.button_done.Location = new System.Drawing.Point(303, 86);
            this.button_done.Name = "button_done";
            this.button_done.Size = new System.Drawing.Size(96, 45);
            this.button_done.TabIndex = 51;
            this.button_done.Text = "DONE";
            this.button_done.UseVisualStyleBackColor = true;
            this.button_done.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox_nv
            // 
            this.comboBox_nv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_nv.FormattingEnabled = true;
            this.comboBox_nv.Location = new System.Drawing.Point(166, 44);
            this.comboBox_nv.Name = "comboBox_nv";
            this.comboBox_nv.Size = new System.Drawing.Size(119, 28);
            this.comboBox_nv.TabIndex = 52;
            // 
            // button1
            // 
            this.button1.Image = global::QuanLyThuVien.Properties.Resources.icons8_create_30;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(78, 833);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 91);
            this.button1.TabIndex = 54;
            this.button1.Text = "Tạo Tài Khoàn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_del
            // 
            this.button_del.Image = global::QuanLyThuVien.Properties.Resources.icons8_delete_48;
            this.button_del.Location = new System.Drawing.Point(733, 833);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(208, 91);
            this.button_del.TabIndex = 49;
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // button_edit
            // 
            this.button_edit.Image = global::QuanLyThuVien.Properties.Resources.icons8_fix_30;
            this.button_edit.Location = new System.Drawing.Point(411, 833);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(208, 91);
            this.button_edit.TabIndex = 48;
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // button_seach
            // 
            this.button_seach.Image = global::QuanLyThuVien.Properties.Resources.icons8_search_30;
            this.button_seach.Location = new System.Drawing.Point(575, 212);
            this.button_seach.Name = "button_seach";
            this.button_seach.Size = new System.Drawing.Size(60, 60);
            this.button_seach.TabIndex = 42;
            this.button_seach.UseVisualStyleBackColor = true;
            this.button_seach.Click += new System.EventHandler(this.button_seach_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Image = global::QuanLyThuVien.Properties.Resources.icons8_cancel_48;
            this.button_cancel.Location = new System.Drawing.Point(246, 498);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(129, 82);
            this.button_cancel.TabIndex = 24;
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_submit
            // 
            this.button_submit.Image = global::QuanLyThuVien.Properties.Resources.icons8_submit_48;
            this.button_submit.Location = new System.Drawing.Point(478, 498);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(129, 82);
            this.button_submit.TabIndex = 17;
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhânViênToolStripMenuItem,
            this.tàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 33);
            this.menuStrip1.TabIndex = 55;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.nhânViênToolStripMenuItem.Text = "Nhân Viên";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(99, 29);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài Khoản";
            // 
            // QuanLyUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_del);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_sl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_rl);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.button_seach);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "QuanLyUser";
            this.Text = "QuanLyUser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuanLyUser_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QuanLyUser_FormClosed);
            this.Load += new System.EventHandler(this.QuanLyUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.TextBox txt_MK;
        private System.Windows.Forms.TextBox txt_TK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_sl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_rl;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_seach;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ll;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_nt;
        private System.Windows.Forms.TextBox txt_Vaitro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_rspass;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.ComboBox comboBox_user;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox_roleuser;
        private System.Windows.Forms.Button button_setrole;
        private System.Windows.Forms.Button button_done;
        private System.Windows.Forms.ComboBox comboBox_nv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
    }
}