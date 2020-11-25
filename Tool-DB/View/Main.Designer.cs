
namespace Tool_DB.View
{
    partial class Main
    {
        ///


        /// Required designer variable.
        ///
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstDataSQL = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SQL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFormat = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSQLChar = new System.Windows.Forms.TextBox();
            this.txtInputSQL = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExcute = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lstInputParam = new System.Windows.Forms.DataGridView();
            this.KEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtOuputSQL = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstDataSQL)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstInputParam)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(838, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 922);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(838, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtStatus
            // 
            this.txtStatus.Margin = new System.Windows.Forms.Padding(740, 3, 0, 2);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(45, 17);
            this.txtStatus.Text = "Status: ";
            // 
            // lstDataSQL
            // 
            this.lstDataSQL.AllowUserToAddRows = false;
            this.lstDataSQL.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lstDataSQL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.lstDataSQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.lstDataSQL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.SQL});
            this.lstDataSQL.Location = new System.Drawing.Point(6, 20);
            this.lstDataSQL.MultiSelect = false;
            this.lstDataSQL.Name = "lstDataSQL";
            this.lstDataSQL.ReadOnly = true;
            this.lstDataSQL.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lstDataSQL.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.lstDataSQL.RowHeadersVisible = false;
            this.lstDataSQL.RowTemplate.Height = 21;
            this.lstDataSQL.RowTemplate.ReadOnly = true;
            this.lstDataSQL.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lstDataSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lstDataSQL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lstDataSQL.Size = new System.Drawing.Size(392, 410);
            this.lstDataSQL.TabIndex = 6;
            this.lstDataSQL.Visible = false;
            this.lstDataSQL.SelectionChanged += new System.EventHandler(this.lstDataSQL_SelectionChanged);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "ID";
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Width = 170;
            // 
            // SQL
            // 
            this.SQL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SQL.DataPropertyName = "SQL";
            this.SQL.HeaderText = "SQL";
            this.SQL.Name = "SQL";
            this.SQL.ReadOnly = true;
            this.SQL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SQL.Width = 218;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFormat);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSQLChar);
            this.groupBox1.Controls.Add(this.txtInputSQL);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 438);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input SQL";
            // 
            // btnFormat
            // 
            this.btnFormat.Location = new System.Drawing.Point(242, 401);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(75, 28);
            this.btnFormat.TabIndex = 12;
            this.btnFormat.Text = "Format";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(323, 401);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 28);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(6, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "SQL Characters:";
            // 
            // txtSQLChar
            // 
            this.txtSQLChar.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSQLChar.Location = new System.Drawing.Point(134, 404);
            this.txtSQLChar.Name = "txtSQLChar";
            this.txtSQLChar.Size = new System.Drawing.Size(102, 23);
            this.txtSQLChar.TabIndex = 9;
            // 
            // txtInputSQL
            // 
            this.txtInputSQL.Location = new System.Drawing.Point(6, 20);
            this.txtInputSQL.Name = "txtInputSQL";
            this.txtInputSQL.Size = new System.Drawing.Size(392, 375);
            this.txtInputSQL.TabIndex = 8;
            this.txtInputSQL.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExcute);
            this.groupBox2.Controls.Add(this.btnConvert);
            this.groupBox2.Controls.Add(this.lstInputParam);
            this.groupBox2.Location = new System.Drawing.Point(12, 473);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 438);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Param";
            // 
            // btnExcute
            // 
            this.btnExcute.Location = new System.Drawing.Point(322, 401);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(75, 28);
            this.btnExcute.TabIndex = 18;
            this.btnExcute.Text = "Run SQL";
            this.btnExcute.UseVisualStyleBackColor = true;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(241, 401);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 28);
            this.btnConvert.TabIndex = 17;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            // 
            // lstInputParam
            // 
            this.lstInputParam.AllowUserToAddRows = false;
            this.lstInputParam.AllowUserToDeleteRows = false;
            this.lstInputParam.AllowUserToResizeRows = false;
            this.lstInputParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.lstInputParam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KEY,
            this.VALUE});
            this.lstInputParam.Location = new System.Drawing.Point(6, 20);
            this.lstInputParam.MultiSelect = false;
            this.lstInputParam.Name = "lstInputParam";
            this.lstInputParam.RowHeadersVisible = false;
            this.lstInputParam.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.lstInputParam.RowTemplate.Height = 21;
            this.lstInputParam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.lstInputParam.Size = new System.Drawing.Size(392, 375);
            this.lstInputParam.TabIndex = 15;
            this.lstInputParam.Visible = false;
            // 
            // KEY
            // 
            this.KEY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.KEY.DataPropertyName = "KEY";
            this.KEY.HeaderText = "KEY";
            this.KEY.MinimumWidth = 100;
            this.KEY.Name = "KEY";
            this.KEY.ReadOnly = true;
            this.KEY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.KEY.Width = 222;
            // 
            // VALUE
            // 
            this.VALUE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.VALUE.DataPropertyName = "VALUE";
            this.VALUE.HeaderText = "VALUE";
            this.VALUE.MinimumWidth = 100;
            this.VALUE.Name = "VALUE";
            this.VALUE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VALUE.Width = 150;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstDataSQL);
            this.groupBox3.Location = new System.Drawing.Point(422, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(404, 438);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "List SQL";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtOuputSQL);
            this.groupBox4.Location = new System.Drawing.Point(422, 473);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(404, 438);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ouput SQL";
            // 
            // txtOuputSQL
            // 
            this.txtOuputSQL.Location = new System.Drawing.Point(6, 20);
            this.txtOuputSQL.Name = "txtOuputSQL";
            this.txtOuputSQL.Size = new System.Drawing.Size(392, 409);
            this.txtOuputSQL.TabIndex = 8;
            this.txtOuputSQL.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 944);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool Compare SQL";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstDataSQL)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstInputParam)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txtStatus;
        private System.Windows.Forms.DataGridView lstDataSQL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtInputSQL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSQLChar;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView lstInputParam;
        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox txtOuputSQL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SQL;
        private System.Windows.Forms.DataGridViewTextBoxColumn KEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALUE;
    }
}