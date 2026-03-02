namespace BreadMaster
{
    partial class FormR
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
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxNameEn = new System.Windows.Forms.TextBox();
            this.textBoxNameJp = new System.Windows.Forms.TextBox();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.textBoxRName = new System.Windows.Forms.TextBox();
            this.buttonRM = new System.Windows.Forms.Button();
            this.textBoxCId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(903, 364);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(12, 400);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(903, 100);
            this.textBoxLog.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(759, 513);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 16;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(12, 513);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxNameEn
            // 
            this.textBoxNameEn.Location = new System.Drawing.Point(624, 5);
            this.textBoxNameEn.Name = "textBoxNameEn";
            this.textBoxNameEn.Size = new System.Drawing.Size(232, 19);
            this.textBoxNameEn.TabIndex = 14;
            this.textBoxNameEn.TextChanged += new System.EventHandler(this.textBoxNameEn_TextChanged);
            // 
            // textBoxNameJp
            // 
            this.textBoxNameJp.Location = new System.Drawing.Point(333, 5);
            this.textBoxNameJp.Name = "textBoxNameJp";
            this.textBoxNameJp.Size = new System.Drawing.Size(276, 19);
            this.textBoxNameJp.TabIndex = 13;
            this.textBoxNameJp.TextChanged += new System.EventHandler(this.textBoxNameJp_TextChanged);
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(863, 5);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(52, 19);
            this.textBoxCode.TabIndex = 19;
            this.textBoxCode.TextChanged += new System.EventHandler(this.textBoxCode_TextChanged);
            this.textBoxCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCode_KeyPress);
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(13, 5);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(59, 19);
            this.textBoxId.TabIndex = 20;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(93, 513);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 31;
            this.buttonReset.Text = "リセット";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // textBoxRName
            // 
            this.textBoxRName.Location = new System.Drawing.Point(78, 5);
            this.textBoxRName.Name = "textBoxRName";
            this.textBoxRName.ReadOnly = true;
            this.textBoxRName.Size = new System.Drawing.Size(249, 19);
            this.textBoxRName.TabIndex = 32;
            // 
            // buttonRM
            // 
            this.buttonRM.Location = new System.Drawing.Point(840, 511);
            this.buttonRM.Name = "buttonRM";
            this.buttonRM.Size = new System.Drawing.Size(75, 23);
            this.buttonRM.TabIndex = 33;
            this.buttonRM.Text = "地域マスター";
            this.buttonRM.UseVisualStyleBackColor = true;
            this.buttonRM.Click += new System.EventHandler(this.buttonRIns_Click);
            // 
            // textBoxCId
            // 
            this.textBoxCId.Location = new System.Drawing.Point(229, 516);
            this.textBoxCId.Name = "textBoxCId";
            this.textBoxCId.ReadOnly = true;
            this.textBoxCId.Size = new System.Drawing.Size(100, 19);
            this.textBoxCId.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 519);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "国ID";
            // 
            // FormR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 548);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCId);
            this.Controls.Add(this.buttonRM);
            this.Controls.Add(this.textBoxRName);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxNameEn);
            this.Controls.Add(this.textBoxNameJp);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormR";
            this.Text = "FormR";
            this.Load += new System.EventHandler(this.FormR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxNameEn;
        private System.Windows.Forms.TextBox textBoxNameJp;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox textBoxRName;
        private System.Windows.Forms.Button buttonRM;
        private System.Windows.Forms.TextBox textBoxCId;
        private System.Windows.Forms.Label label1;
    }
}