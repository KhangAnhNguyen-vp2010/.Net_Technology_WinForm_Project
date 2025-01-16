namespace QuanLyThuVien
{
    partial class TheLoai
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
            this.label7 = new System.Windows.Forms.Label();
            this.button_sl = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_rl = new System.Windows.Forms.Button();
            this.button_seach = new System.Windows.Forms.Button();
            this.button_del = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_submit = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_ma = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tácGiảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhàXuấtBảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thểLoạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_foradmin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 35;
            this.label7.Text = "Số Lượng";
            // 
            // button_sl
            // 
            this.button_sl.Enabled = false;
            this.button_sl.Location = new System.Drawing.Point(190, 179);
            this.button_sl.Name = "button_sl";
            this.button_sl.Size = new System.Drawing.Size(64, 49);
            this.button_sl.TabIndex = 34;
            this.button_sl.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(286, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 29);
            this.label6.TabIndex = 33;
            this.label6.Text = "Tìm Kiếm";
            // 
            // textBox_search
            // 
            this.textBox_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_search.Location = new System.Drawing.Point(418, 172);
            this.textBox_search.Multiline = true;
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(214, 49);
            this.textBox_search.TabIndex = 31;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(190, 289);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(852, 264);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button_rl
            // 
            this.button_rl.Image = global::QuanLyThuVien.Properties.Resources.icons8_reload_50;
            this.button_rl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_rl.Location = new System.Drawing.Point(872, 131);
            this.button_rl.Name = "button_rl";
            this.button_rl.Size = new System.Drawing.Size(170, 90);
            this.button_rl.TabIndex = 32;
            this.button_rl.Text = "Load Lại";
            this.button_rl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_rl.UseVisualStyleBackColor = true;
            this.button_rl.Click += new System.EventHandler(this.button_rl_Click);
            // 
            // button_seach
            // 
            this.button_seach.Image = global::QuanLyThuVien.Properties.Resources.icons8_search_30;
            this.button_seach.Location = new System.Drawing.Point(675, 172);
            this.button_seach.Name = "button_seach";
            this.button_seach.Size = new System.Drawing.Size(76, 49);
            this.button_seach.TabIndex = 30;
            this.button_seach.UseVisualStyleBackColor = true;
            this.button_seach.Click += new System.EventHandler(this.button_seach_Click);
            // 
            // button_del
            // 
            this.button_del.Image = global::QuanLyThuVien.Properties.Resources.icons8_delete_48;
            this.button_del.Location = new System.Drawing.Point(834, 663);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(208, 78);
            this.button_del.TabIndex = 38;
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // button_edit
            // 
            this.button_edit.Image = global::QuanLyThuVien.Properties.Resources.icons8_fix_30;
            this.button_edit.Location = new System.Drawing.Point(512, 663);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(208, 78);
            this.button_edit.TabIndex = 37;
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // button_add
            // 
            this.button_add.Image = global::QuanLyThuVien.Properties.Resources.icons8_add_48;
            this.button_add.Location = new System.Drawing.Point(195, 663);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(208, 78);
            this.button_add.TabIndex = 36;
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button_cancel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_submit);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.textBox_name);
            this.groupBox1.Controls.Add(this.textBox_ma);
            this.groupBox1.Location = new System.Drawing.Point(1129, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 610);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // button_cancel
            // 
            this.button_cancel.Image = global::QuanLyThuVien.Properties.Resources.icons8_cancel_48;
            this.button_cancel.Location = new System.Drawing.Point(201, 429);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(129, 79);
            this.button_cancel.TabIndex = 24;
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
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
            this.label3.Location = new System.Drawing.Point(93, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Mô Tả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tên Loại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Mã Loại";
            // 
            // button_submit
            // 
            this.button_submit.Image = global::QuanLyThuVien.Properties.Resources.icons8_submit_48;
            this.button_submit.Location = new System.Drawing.Point(393, 429);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(129, 79);
            this.button_submit.TabIndex = 17;
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(251, 209);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(227, 150);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(251, 141);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(227, 26);
            this.textBox_name.TabIndex = 13;
            // 
            // textBox_ma
            // 
            this.textBox_ma.Location = new System.Drawing.Point(251, 99);
            this.textBox_ma.Name = "textBox_ma";
            this.textBox_ma.Size = new System.Drawing.Size(227, 26);
            this.textBox_ma.TabIndex = 12;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tácGiảToolStripMenuItem,
            this.nhàXuấtBảnToolStripMenuItem,
            this.sáchToolStripMenuItem,
            this.thểLoạiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 33);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tácGiảToolStripMenuItem
            // 
            this.tácGiảToolStripMenuItem.Name = "tácGiảToolStripMenuItem";
            this.tácGiảToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.tácGiảToolStripMenuItem.Text = "Tác Giả";
            this.tácGiảToolStripMenuItem.Click += new System.EventHandler(this.tácGiảToolStripMenuItem_Click);
            // 
            // nhàXuấtBảnToolStripMenuItem
            // 
            this.nhàXuấtBảnToolStripMenuItem.Name = "nhàXuấtBảnToolStripMenuItem";
            this.nhàXuấtBảnToolStripMenuItem.Size = new System.Drawing.Size(131, 29);
            this.nhàXuấtBảnToolStripMenuItem.Text = "Nhà Xuất Bản";
            this.nhàXuấtBảnToolStripMenuItem.Click += new System.EventHandler(this.nhàXuấtBảnToolStripMenuItem_Click);
            // 
            // sáchToolStripMenuItem
            // 
            this.sáchToolStripMenuItem.Name = "sáchToolStripMenuItem";
            this.sáchToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.sáchToolStripMenuItem.Text = "Sách";
            this.sáchToolStripMenuItem.Click += new System.EventHandler(this.sáchToolStripMenuItem_Click);
            // 
            // thểLoạiToolStripMenuItem
            // 
            this.thểLoạiToolStripMenuItem.Name = "thểLoạiToolStripMenuItem";
            this.thểLoạiToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.thểLoạiToolStripMenuItem.Text = "Thể Loại";
            this.thểLoạiToolStripMenuItem.Click += new System.EventHandler(this.thểLoạiToolStripMenuItem_Click);
            // 
            // button_foradmin
            // 
            this.button_foradmin.Location = new System.Drawing.Point(1129, 73);
            this.button_foradmin.Name = "button_foradmin";
            this.button_foradmin.Size = new System.Drawing.Size(103, 36);
            this.button_foradmin.TabIndex = 41;
            this.button_foradmin.Text = "Enable";
            this.button_foradmin.UseVisualStyleBackColor = true;
            this.button_foradmin.Click += new System.EventHandler(this.button_foradmin_Click);
            // 
            // TheLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.button_foradmin);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_del);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_sl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_rl);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.button_seach);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TheLoai";
            this.Text = "TheLoai";
            this.Load += new System.EventHandler(this.TheLoai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_sl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_rl;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_seach;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_ma;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tácGiảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhàXuấtBảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thểLoạiToolStripMenuItem;
        private System.Windows.Forms.Button button_foradmin;
    }
}