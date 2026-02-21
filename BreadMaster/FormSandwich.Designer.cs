namespace BreadMaster
{
    partial class FormSandwich
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
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.buttonIns = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonType = new System.Windows.Forms.Button();
            this.buttonI = new System.Windows.Forms.Button();
            this.textBoxTypeId = new System.Windows.Forms.TextBox();
            this.textBoxTName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTClr = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(372, 297);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(12, 340);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(776, 98);
            this.textBoxLog.TabIndex = 1;
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(551, 453);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 14;
            this.buttonDel.Text = "削除";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonUpd
            // 
            this.buttonUpd.Location = new System.Drawing.Point(632, 454);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(75, 23);
            this.buttonUpd.TabIndex = 13;
            this.buttonUpd.Text = "更新";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.buttonUpd_Click);
            // 
            // buttonIns
            // 
            this.buttonIns.Location = new System.Drawing.Point(713, 454);
            this.buttonIns.Name = "buttonIns";
            this.buttonIns.Size = new System.Drawing.Size(75, 23);
            this.buttonIns.TabIndex = 12;
            this.buttonIns.Text = "追加";
            this.buttonIns.UseVisualStyleBackColor = true;
            this.buttonIns.Click += new System.EventHandler(this.buttonIns_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(118, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(380, 19);
            this.textBoxName.TabIndex = 11;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(12, 12);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(100, 19);
            this.textBoxId.TabIndex = 10;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(12, 453);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(470, 454);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 17;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(93, 454);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 34;
            this.buttonReset.Text = "リセット";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonType
            // 
            this.buttonType.Location = new System.Drawing.Point(257, 453);
            this.buttonType.Name = "buttonType";
            this.buttonType.Size = new System.Drawing.Size(75, 23);
            this.buttonType.TabIndex = 35;
            this.buttonType.Text = "タイプ";
            this.buttonType.UseVisualStyleBackColor = true;
            this.buttonType.Click += new System.EventHandler(this.buttonType_Click);
            // 
            // buttonI
            // 
            this.buttonI.Location = new System.Drawing.Point(360, 454);
            this.buttonI.Name = "buttonI";
            this.buttonI.Size = new System.Drawing.Size(75, 23);
            this.buttonI.TabIndex = 36;
            this.buttonI.Text = "食材";
            this.buttonI.UseVisualStyleBackColor = true;
            this.buttonI.Click += new System.EventHandler(this.buttonI_Click);
            // 
            // textBoxTypeId
            // 
            this.textBoxTypeId.Location = new System.Drawing.Point(794, 79);
            this.textBoxTypeId.Name = "textBoxTypeId";
            this.textBoxTypeId.ReadOnly = true;
            this.textBoxTypeId.Size = new System.Drawing.Size(100, 19);
            this.textBoxTypeId.TabIndex = 37;
            // 
            // textBoxTName
            // 
            this.textBoxTName.Location = new System.Drawing.Point(514, 12);
            this.textBoxTName.Name = "textBoxTName";
            this.textBoxTName.ReadOnly = true;
            this.textBoxTName.Size = new System.Drawing.Size(274, 19);
            this.textBoxTName.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(794, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "タイプID";
            // 
            // buttonTClr
            // 
            this.buttonTClr.Location = new System.Drawing.Point(796, 12);
            this.buttonTClr.Name = "buttonTClr";
            this.buttonTClr.Size = new System.Drawing.Size(84, 23);
            this.buttonTClr.TabIndex = 40;
            this.buttonTClr.Text = "タイプクリア";
            this.buttonTClr.UseVisualStyleBackColor = true;
            this.buttonTClr.Click += new System.EventHandler(this.buttonTClr_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(406, 37);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.Size = new System.Drawing.Size(382, 300);
            this.dataGridView2.TabIndex = 41;
            // 
            // FormSandwich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 505);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.buttonTClr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTName);
            this.Controls.Add(this.textBoxTypeId);
            this.Controls.Add(this.buttonI);
            this.Controls.Add(this.buttonType);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonUpd);
            this.Controls.Add(this.buttonIns);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormSandwich";
            this.Text = "FormSandwich";
            this.Load += new System.EventHandler(this.FormSandwich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonIns;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonType;
        private System.Windows.Forms.Button buttonI;
        private System.Windows.Forms.TextBox textBoxTypeId;
        private System.Windows.Forms.TextBox textBoxTName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTClr;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}