namespace BreadMaster
{
    partial class FormRM
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
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.buttonIns = new System.Windows.Forms.Button();
            this.textBoxRName = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonCSelect = new System.Windows.Forms.Button();
            this.textBoxCId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCNameJp = new System.Windows.Forms.TextBox();
            this.textBoxCNameEn = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(95, 644);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 52;
            this.buttonReset.Text = "リセット";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(471, 646);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 51;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(14, 646);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 50;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(552, 645);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 49;
            this.buttonDel.Text = "削除";
            this.buttonDel.UseVisualStyleBackColor = true;
            // 
            // buttonUpd
            // 
            this.buttonUpd.Location = new System.Drawing.Point(633, 646);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(75, 23);
            this.buttonUpd.TabIndex = 48;
            this.buttonUpd.Text = "更新";
            this.buttonUpd.UseVisualStyleBackColor = true;
            // 
            // buttonIns
            // 
            this.buttonIns.Location = new System.Drawing.Point(714, 646);
            this.buttonIns.Name = "buttonIns";
            this.buttonIns.Size = new System.Drawing.Size(75, 23);
            this.buttonIns.TabIndex = 47;
            this.buttonIns.Text = "追加";
            this.buttonIns.UseVisualStyleBackColor = true;
            this.buttonIns.Click += new System.EventHandler(this.buttonIns_Click);
            // 
            // textBoxRName
            // 
            this.textBoxRName.Location = new System.Drawing.Point(13, 47);
            this.textBoxRName.Name = "textBoxRName";
            this.textBoxRName.Size = new System.Drawing.Size(776, 19);
            this.textBoxRName.TabIndex = 46;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(13, 11);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(100, 19);
            this.textBoxId.TabIndex = 45;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(13, 547);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(776, 73);
            this.textBoxLog.TabIndex = 44;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 151);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(776, 375);
            this.dataGridView1.TabIndex = 43;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // buttonCSelect
            // 
            this.buttonCSelect.Location = new System.Drawing.Point(390, 644);
            this.buttonCSelect.Name = "buttonCSelect";
            this.buttonCSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonCSelect.TabIndex = 53;
            this.buttonCSelect.Text = "国選択";
            this.buttonCSelect.UseVisualStyleBackColor = true;
            this.buttonCSelect.Click += new System.EventHandler(this.buttonCSelect_Click);
            // 
            // textBoxCId
            // 
            this.textBoxCId.Location = new System.Drawing.Point(238, 644);
            this.textBoxCId.Name = "textBoxCId";
            this.textBoxCId.ReadOnly = true;
            this.textBoxCId.Size = new System.Drawing.Size(132, 19);
            this.textBoxCId.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 647);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 55;
            this.label1.Text = "国ID";
            // 
            // textBoxCNameJp
            // 
            this.textBoxCNameJp.Location = new System.Drawing.Point(14, 83);
            this.textBoxCNameJp.Name = "textBoxCNameJp";
            this.textBoxCNameJp.ReadOnly = true;
            this.textBoxCNameJp.Size = new System.Drawing.Size(775, 19);
            this.textBoxCNameJp.TabIndex = 56;
            // 
            // textBoxCNameEn
            // 
            this.textBoxCNameEn.Location = new System.Drawing.Point(14, 117);
            this.textBoxCNameEn.Name = "textBoxCNameEn";
            this.textBoxCNameEn.ReadOnly = true;
            this.textBoxCNameEn.Size = new System.Drawing.Size(775, 19);
            this.textBoxCNameEn.TabIndex = 57;
            // 
            // FormRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 688);
            this.Controls.Add(this.textBoxCNameEn);
            this.Controls.Add(this.textBoxCNameJp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCId);
            this.Controls.Add(this.buttonCSelect);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonUpd);
            this.Controls.Add(this.buttonIns);
            this.Controls.Add(this.textBoxRName);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormRM";
            this.Text = "FormRM";
            this.Load += new System.EventHandler(this.FormRM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonIns;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonCSelect;
        private System.Windows.Forms.TextBox textBoxRName;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxCId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCNameJp;
        private System.Windows.Forms.TextBox textBoxCNameEn;
    }
}