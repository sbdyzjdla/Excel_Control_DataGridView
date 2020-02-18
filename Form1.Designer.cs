namespace OilPipe
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox_excel = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.grid_start1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_end1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_x1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_y1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_z1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_dem1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_dep1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_excel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grid_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_dem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_dep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.combo_st = new System.Windows.Forms.ComboBox();
            this.combo_end = new System.Windows.Forms.ComboBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_shape = new System.Windows.Forms.Button();
            this.textBox_folder = new System.Windows.Forms.TextBox();
            this.btn_sf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_excel
            // 
            this.textBox_excel.Location = new System.Drawing.Point(14, 58);
            this.textBox_excel.Name = "textBox_excel";
            this.textBox_excel.Size = new System.Drawing.Size(815, 25);
            this.textBox_excel.TabIndex = 2;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid_start1,
            this.grid_end1,
            this.grid_x1,
            this.grid_y1,
            this.grid_z1,
            this.grid_dem1,
            this.grid_dep1});
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.Location = new System.Drawing.Point(14, 131);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(928, 256);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick_1);
            this.dataGridView2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // grid_start1
            // 
            this.grid_start1.HeaderText = "시점";
            this.grid_start1.MinimumWidth = 6;
            this.grid_start1.Name = "grid_start1";
            this.grid_start1.Width = 125;
            // 
            // grid_end1
            // 
            this.grid_end1.HeaderText = "종점";
            this.grid_end1.MinimumWidth = 6;
            this.grid_end1.Name = "grid_end1";
            this.grid_end1.Width = 125;
            // 
            // grid_x1
            // 
            this.grid_x1.HeaderText = "X";
            this.grid_x1.MinimumWidth = 6;
            this.grid_x1.Name = "grid_x1";
            this.grid_x1.Width = 125;
            // 
            // grid_y1
            // 
            this.grid_y1.HeaderText = "Y";
            this.grid_y1.MinimumWidth = 6;
            this.grid_y1.Name = "grid_y1";
            this.grid_y1.Width = 125;
            // 
            // grid_z1
            // 
            this.grid_z1.HeaderText = "Z";
            this.grid_z1.MinimumWidth = 6;
            this.grid_z1.Name = "grid_z1";
            this.grid_z1.Width = 125;
            // 
            // grid_dem1
            // 
            this.grid_dem1.HeaderText = "DEM";
            this.grid_dem1.MinimumWidth = 6;
            this.grid_dem1.Name = "grid_dem1";
            this.grid_dem1.Width = 125;
            // 
            // grid_dep1
            // 
            this.grid_dep1.HeaderText = "심도";
            this.grid_dep1.MinimumWidth = 6;
            this.grid_dep1.Name = "grid_dep1";
            this.grid_dep1.Width = 125;
            // 
            // btn_excel
            // 
            this.btn_excel.BackColor = System.Drawing.Color.Crimson;
            this.btn_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_excel.ForeColor = System.Drawing.Color.White;
            this.btn_excel.Location = new System.Drawing.Point(835, 54);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(100, 29);
            this.btn_excel.TabIndex = 5;
            this.btn_excel.Text = "찾아보기";
            this.btn_excel.UseVisualStyleBackColor = false;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid_start,
            this.grid_end,
            this.grid_x,
            this.grid_y,
            this.grid_z,
            this.grid_dem,
            this.grid_dep});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(14, 440);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(928, 287);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // grid_start
            // 
            this.grid_start.HeaderText = "시점";
            this.grid_start.MinimumWidth = 6;
            this.grid_start.Name = "grid_start";
            this.grid_start.Width = 125;
            // 
            // grid_end
            // 
            this.grid_end.HeaderText = "종점";
            this.grid_end.MinimumWidth = 6;
            this.grid_end.Name = "grid_end";
            this.grid_end.Width = 125;
            // 
            // grid_x
            // 
            this.grid_x.HeaderText = "X";
            this.grid_x.MinimumWidth = 6;
            this.grid_x.Name = "grid_x";
            this.grid_x.Width = 125;
            // 
            // grid_y
            // 
            this.grid_y.HeaderText = "Y";
            this.grid_y.MinimumWidth = 6;
            this.grid_y.Name = "grid_y";
            this.grid_y.Width = 125;
            // 
            // grid_z
            // 
            this.grid_z.HeaderText = "Z";
            this.grid_z.MinimumWidth = 6;
            this.grid_z.Name = "grid_z";
            this.grid_z.Width = 125;
            // 
            // grid_dem
            // 
            this.grid_dem.HeaderText = "DEM";
            this.grid_dem.MinimumWidth = 6;
            this.grid_dem.Name = "grid_dem";
            this.grid_dem.Width = 125;
            // 
            // grid_dep
            // 
            this.grid_dep.HeaderText = "심도";
            this.grid_dep.MinimumWidth = 6;
            this.grid_dep.Name = "grid_dep";
            this.grid_dep.Width = 125;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(835, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "필터링";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // combo_st
            // 
            this.combo_st.BackColor = System.Drawing.Color.White;
            this.combo_st.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_st.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_st.FormattingEnabled = true;
            this.combo_st.Location = new System.Drawing.Point(14, 401);
            this.combo_st.Name = "combo_st";
            this.combo_st.Size = new System.Drawing.Size(121, 31);
            this.combo_st.TabIndex = 9;
            this.combo_st.Text = "시점";
            this.combo_st.SelectedIndexChanged += new System.EventHandler(this.combo_st_SelectedIndexChanged);
            // 
            // combo_end
            // 
            this.combo_end.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_end.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_end.FormattingEnabled = true;
            this.combo_end.Location = new System.Drawing.Point(161, 401);
            this.combo_end.Name = "combo_end";
            this.combo_end.Size = new System.Drawing.Size(126, 31);
            this.combo_end.TabIndex = 10;
            this.combo_end.Text = "종점";
            this.combo_end.SelectedIndexChanged += new System.EventHandler(this.combo_end_SelectedIndexChanged);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.Crimson;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.ForeColor = System.Drawing.Color.White;
            this.btn_clear.Location = new System.Drawing.Point(14, 740);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(104, 47);
            this.btn_clear.TabIndex = 11;
            this.btn_clear.Text = "초기화";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Crimson;
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(432, 740);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(97, 47);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "저장";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 50);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(898, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "OilPipe";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_shape
            // 
            this.btn_shape.BackColor = System.Drawing.Color.Crimson;
            this.btn_shape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_shape.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_shape.ForeColor = System.Drawing.Color.White;
            this.btn_shape.Location = new System.Drawing.Point(833, 740);
            this.btn_shape.Name = "btn_shape";
            this.btn_shape.Size = new System.Drawing.Size(102, 47);
            this.btn_shape.TabIndex = 14;
            this.btn_shape.Text = "Shape";
            this.btn_shape.UseVisualStyleBackColor = false;
            this.btn_shape.Click += new System.EventHandler(this.btn_shape_Click);
            // 
            // textBox_folder
            // 
            this.textBox_folder.Location = new System.Drawing.Point(14, 93);
            this.textBox_folder.Name = "textBox_folder";
            this.textBox_folder.Size = new System.Drawing.Size(815, 25);
            this.textBox_folder.TabIndex = 15;
            this.textBox_folder.TextChanged += new System.EventHandler(this.textBox_folder_TextChanged);
            // 
            // btn_sf
            // 
            this.btn_sf.BackColor = System.Drawing.Color.Crimson;
            this.btn_sf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sf.ForeColor = System.Drawing.Color.White;
            this.btn_sf.Location = new System.Drawing.Point(835, 93);
            this.btn_sf.Name = "btn_sf";
            this.btn_sf.Size = new System.Drawing.Size(100, 32);
            this.btn_sf.TabIndex = 16;
            this.btn_sf.Text = "저장경로";
            this.btn_sf.UseVisualStyleBackColor = false;
            this.btn_sf.Click += new System.EventHandler(this.btn_sf_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(949, 801);
            this.Controls.Add(this.btn_sf);
            this.Controls.Add(this.textBox_folder);
            this.Controls.Add(this.btn_shape);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.combo_end);
            this.Controls.Add(this.combo_st);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.textBox_excel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_excel;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox combo_st;
        private System.Windows.Forms.ComboBox combo_end;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_save;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_start1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_end1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_x1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_y1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_z1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_dem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_dep1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_x;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_y;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_z;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_dem;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_dep;
        private System.Windows.Forms.Button btn_shape;
        private System.Windows.Forms.TextBox textBox_folder;
        private System.Windows.Forms.Button btn_sf;
    }
}

