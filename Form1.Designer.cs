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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btn_shape = new System.Windows.Forms.Button();
            this.textBox_folder = new System.Windows.Forms.TextBox();
            this.btn_sf = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.textBox_dem = new System.Windows.Forms.TextBox();
            this.btn_dem = new System.Windows.Forms.Button();
            this.btn_run = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_excel
            // 
            this.textBox_excel.Location = new System.Drawing.Point(12, 93);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MediumOrchid;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            this.dataGridView2.Location = new System.Drawing.Point(12, 240);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(928, 232);
            this.dataGridView2.TabIndex = 4;
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
            this.btn_excel.BackColor = System.Drawing.Color.MediumOrchid;
            this.btn_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_excel.ForeColor = System.Drawing.Color.White;
            this.btn_excel.Location = new System.Drawing.Point(833, 89);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(100, 33);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.MediumOrchid;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 525);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(928, 234);
            this.dataGridView1.TabIndex = 7;
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
            this.button1.BackColor = System.Drawing.Color.MediumOrchid;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(833, 478);
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
            this.combo_st.Location = new System.Drawing.Point(12, 486);
            this.combo_st.Name = "combo_st";
            this.combo_st.Size = new System.Drawing.Size(121, 31);
            this.combo_st.TabIndex = 9;
            this.combo_st.Text = "시점";
            // 
            // combo_end
            // 
            this.combo_end.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_end.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_end.FormattingEnabled = true;
            this.combo_end.Location = new System.Drawing.Point(159, 486);
            this.combo_end.Name = "combo_end";
            this.combo_end.Size = new System.Drawing.Size(126, 31);
            this.combo_end.TabIndex = 10;
            this.combo_end.Text = "종점";
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.MediumOrchid;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.ForeColor = System.Drawing.Color.White;
            this.btn_clear.Location = new System.Drawing.Point(696, 478);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(104, 39);
            this.btn_clear.TabIndex = 11;
            this.btn_clear.Text = "초기화";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_shape
            // 
            this.btn_shape.BackColor = System.Drawing.Color.MediumOrchid;
            this.btn_shape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_shape.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_shape.ForeColor = System.Drawing.Color.White;
            this.btn_shape.Location = new System.Drawing.Point(833, 792);
            this.btn_shape.Name = "btn_shape";
            this.btn_shape.Size = new System.Drawing.Size(102, 45);
            this.btn_shape.TabIndex = 14;
            this.btn_shape.Text = "Shape";
            this.btn_shape.UseVisualStyleBackColor = false;
            this.btn_shape.Click += new System.EventHandler(this.btn_shape_Click);
            // 
            // textBox_folder
            // 
            this.textBox_folder.Location = new System.Drawing.Point(12, 128);
            this.textBox_folder.Name = "textBox_folder";
            this.textBox_folder.Size = new System.Drawing.Size(815, 25);
            this.textBox_folder.TabIndex = 15;
            // 
            // btn_sf
            // 
            this.btn_sf.BackColor = System.Drawing.Color.MediumOrchid;
            this.btn_sf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sf.ForeColor = System.Drawing.Color.White;
            this.btn_sf.Location = new System.Drawing.Point(833, 128);
            this.btn_sf.Name = "btn_sf";
            this.btn_sf.Size = new System.Drawing.Size(100, 37);
            this.btn_sf.TabIndex = 16;
            this.btn_sf.Text = "저장경로";
            this.btn_sf.UseVisualStyleBackColor = false;
            this.btn_sf.Click += new System.EventHandler(this.btn_sf_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 792);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(800, 29);
            this.progressBar1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 772);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Excel to Shape";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 744);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 19;
            // 
            // textBox_status
            // 
            this.textBox_status.BackColor = System.Drawing.Color.White;
            this.textBox_status.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_status.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBox_status.Location = new System.Drawing.Point(12, 839);
            this.textBox_status.Multiline = true;
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.ReadOnly = true;
            this.textBox_status.Size = new System.Drawing.Size(800, 145);
            this.textBox_status.TabIndex = 20;
            this.textBox_status.Text = "엑셀파일과 저장경로를 설정하신뒤 Shape을 눌러주세요.\r\n경로를 필터링 하실경우 시점, 종점을 선택하신후 필터링을 누르시고\r\nShape 버튼을 " +
    "눌러주세요.\r\n\r\n";
            // 
            // textBox_dem
            // 
            this.textBox_dem.Location = new System.Drawing.Point(12, 171);
            this.textBox_dem.Name = "textBox_dem";
            this.textBox_dem.Size = new System.Drawing.Size(815, 25);
            this.textBox_dem.TabIndex = 21;
            // 
            // btn_dem
            // 
            this.btn_dem.BackColor = System.Drawing.Color.MediumOrchid;
            this.btn_dem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dem.ForeColor = System.Drawing.Color.White;
            this.btn_dem.Location = new System.Drawing.Point(833, 171);
            this.btn_dem.Name = "btn_dem";
            this.btn_dem.Size = new System.Drawing.Size(100, 30);
            this.btn_dem.TabIndex = 23;
            this.btn_dem.Text = "찾아보기";
            this.btn_dem.UseVisualStyleBackColor = false;
            this.btn_dem.Click += new System.EventHandler(this.btn_dem_Click);
            // 
            // btn_run
            // 
            this.btn_run.BackColor = System.Drawing.Color.MediumOrchid;
            this.btn_run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_run.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_run.ForeColor = System.Drawing.Color.White;
            this.btn_run.Location = new System.Drawing.Point(833, 207);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(100, 27);
            this.btn_run.TabIndex = 24;
            this.btn_run.Text = "실행";
            this.btn_run.UseVisualStyleBackColor = false;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 1032);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.btn_dem);
            this.Controls.Add(this.textBox_dem);
            this.Controls.Add(this.textBox_status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_sf);
            this.Controls.Add(this.textBox_folder);
            this.Controls.Add(this.btn_shape);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.combo_end);
            this.Controls.Add(this.combo_st);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.textBox_excel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OilPipe";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.TextBox textBox_dem;
        private System.Windows.Forms.Button btn_dem;
        private System.Windows.Forms.Button btn_run;
    }
}

