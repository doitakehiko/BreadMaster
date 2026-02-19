namespace BreadMaster
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxFName = new System.Windows.Forms.TextBox();
            this.textBoxSauce = new System.Windows.Forms.TextBox();
            this.textBoxSandwich = new System.Windows.Forms.TextBox();
            this.textBoxRName = new System.Windows.Forms.TextBox();
            this.textBoxBName = new System.Windows.Forms.TextBox();
            this.textBoxCNameJp = new System.Windows.Forms.TextBox();
            this.textBoxCNameEn = new System.Windows.Forms.TextBox();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.buttonF = new System.Windows.Forms.Button();
            this.buttonSauce = new System.Windows.Forms.Button();
            this.buttonSandwich = new System.Windows.Forms.Button();
            this.buttonB = new System.Windows.Forms.Button();
            this.buttonC = new System.Windows.Forms.Button();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.buttonIns = new System.Windows.Forms.Button();
            this.buttonFClr = new System.Windows.Forms.Button();
            this.buttonSauceClr = new System.Windows.Forms.Button();
            this.textBoxFId = new System.Windows.Forms.TextBox();
            this.textBoxSauceId = new System.Windows.Forms.TextBox();
            this.textBoxSandwichId = new System.Windows.Forms.TextBox();
            this.textBoxBId = new System.Windows.Forms.TextBox();
            this.textBoxRId = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 190);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(1114, 401);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(12, 597);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(1114, 154);
            this.textBoxLog.TabIndex = 1;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(12, 12);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(44, 19);
            this.textBoxId.TabIndex = 2;
            // 
            // textBoxFName
            // 
            this.textBoxFName.Location = new System.Drawing.Point(76, 12);
            this.textBoxFName.Name = "textBoxFName";
            this.textBoxFName.ReadOnly = true;
            this.textBoxFName.Size = new System.Drawing.Size(387, 19);
            this.textBoxFName.TabIndex = 3;
            // 
            // textBoxSauce
            // 
            this.textBoxSauce.Location = new System.Drawing.Point(76, 57);
            this.textBoxSauce.Name = "textBoxSauce";
            this.textBoxSauce.ReadOnly = true;
            this.textBoxSauce.Size = new System.Drawing.Size(387, 19);
            this.textBoxSauce.TabIndex = 4;
            // 
            // textBoxSandwich
            // 
            this.textBoxSandwich.Location = new System.Drawing.Point(76, 107);
            this.textBoxSandwich.Name = "textBoxSandwich";
            this.textBoxSandwich.ReadOnly = true;
            this.textBoxSandwich.Size = new System.Drawing.Size(387, 19);
            this.textBoxSandwich.TabIndex = 5;
            // 
            // textBoxRName
            // 
            this.textBoxRName.Location = new System.Drawing.Point(642, 12);
            this.textBoxRName.Name = "textBoxRName";
            this.textBoxRName.ReadOnly = true;
            this.textBoxRName.Size = new System.Drawing.Size(124, 19);
            this.textBoxRName.TabIndex = 6;
            // 
            // textBoxBName
            // 
            this.textBoxBName.Location = new System.Drawing.Point(642, 109);
            this.textBoxBName.Name = "textBoxBName";
            this.textBoxBName.ReadOnly = true;
            this.textBoxBName.Size = new System.Drawing.Size(403, 19);
            this.textBoxBName.TabIndex = 7;
            // 
            // textBoxCNameJp
            // 
            this.textBoxCNameJp.Location = new System.Drawing.Point(772, 12);
            this.textBoxCNameJp.Name = "textBoxCNameJp";
            this.textBoxCNameJp.ReadOnly = true;
            this.textBoxCNameJp.Size = new System.Drawing.Size(127, 19);
            this.textBoxCNameJp.TabIndex = 8;
            // 
            // textBoxCNameEn
            // 
            this.textBoxCNameEn.Location = new System.Drawing.Point(905, 12);
            this.textBoxCNameEn.Name = "textBoxCNameEn";
            this.textBoxCNameEn.ReadOnly = true;
            this.textBoxCNameEn.Size = new System.Drawing.Size(116, 19);
            this.textBoxCNameEn.TabIndex = 9;
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(1027, 12);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.ReadOnly = true;
            this.textBoxCode.Size = new System.Drawing.Size(47, 19);
            this.textBoxCode.TabIndex = 10;
            // 
            // buttonF
            // 
            this.buttonF.Location = new System.Drawing.Point(469, 10);
            this.buttonF.Name = "buttonF";
            this.buttonF.Size = new System.Drawing.Size(62, 23);
            this.buttonF.TabIndex = 11;
            this.buttonF.Text = "フィリング";
            this.buttonF.UseVisualStyleBackColor = true;
            this.buttonF.Click += new System.EventHandler(this.buttonF_Click);
            // 
            // buttonSauce
            // 
            this.buttonSauce.Location = new System.Drawing.Point(469, 57);
            this.buttonSauce.Name = "buttonSauce";
            this.buttonSauce.Size = new System.Drawing.Size(53, 23);
            this.buttonSauce.TabIndex = 12;
            this.buttonSauce.Text = "ソース";
            this.buttonSauce.UseVisualStyleBackColor = true;
            this.buttonSauce.Click += new System.EventHandler(this.buttonSauce_Click);
            // 
            // buttonSandwich
            // 
            this.buttonSandwich.Location = new System.Drawing.Point(469, 105);
            this.buttonSandwich.Name = "buttonSandwich";
            this.buttonSandwich.Size = new System.Drawing.Size(82, 23);
            this.buttonSandwich.TabIndex = 13;
            this.buttonSandwich.Text = "サンドイッチ";
            this.buttonSandwich.UseVisualStyleBackColor = true;
            this.buttonSandwich.Click += new System.EventHandler(this.buttonSandwich_Click);
            // 
            // buttonB
            // 
            this.buttonB.Location = new System.Drawing.Point(1051, 109);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(75, 23);
            this.buttonB.TabIndex = 14;
            this.buttonB.Text = "ブレッド";
            this.buttonB.UseVisualStyleBackColor = true;
            this.buttonB.Click += new System.EventHandler(this.buttonB_Click);
            // 
            // buttonC
            // 
            this.buttonC.Location = new System.Drawing.Point(974, 57);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(100, 23);
            this.buttonC.TabIndex = 17;
            this.buttonC.Text = "国";
            this.buttonC.UseVisualStyleBackColor = true;
            this.buttonC.Click += new System.EventHandler(this.buttonC_Click);
            // 
            // buttonUpd
            // 
            this.buttonUpd.Location = new System.Drawing.Point(1175, 109);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(75, 23);
            this.buttonUpd.TabIndex = 20;
            this.buttonUpd.Text = "編集";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.buttonUpd_Click);
            // 
            // buttonIns
            // 
            this.buttonIns.Location = new System.Drawing.Point(1175, 76);
            this.buttonIns.Name = "buttonIns";
            this.buttonIns.Size = new System.Drawing.Size(75, 23);
            this.buttonIns.TabIndex = 21;
            this.buttonIns.Text = "新規登録";
            this.buttonIns.UseVisualStyleBackColor = true;
            this.buttonIns.Click += new System.EventHandler(this.buttonIns_Click);
            // 
            // buttonFClr
            // 
            this.buttonFClr.Location = new System.Drawing.Point(537, 10);
            this.buttonFClr.Name = "buttonFClr";
            this.buttonFClr.Size = new System.Drawing.Size(84, 23);
            this.buttonFClr.TabIndex = 23;
            this.buttonFClr.Text = "フィリングクリア";
            this.buttonFClr.UseVisualStyleBackColor = true;
            this.buttonFClr.Click += new System.EventHandler(this.buttonFClr_Click);
            // 
            // buttonSauceClr
            // 
            this.buttonSauceClr.Location = new System.Drawing.Point(537, 57);
            this.buttonSauceClr.Name = "buttonSauceClr";
            this.buttonSauceClr.Size = new System.Drawing.Size(75, 23);
            this.buttonSauceClr.TabIndex = 24;
            this.buttonSauceClr.Text = "ソースクリア";
            this.buttonSauceClr.UseVisualStyleBackColor = true;
            this.buttonSauceClr.Click += new System.EventHandler(this.buttonSauceClr_Click);
            // 
            // textBoxFId
            // 
            this.textBoxFId.Location = new System.Drawing.Point(1150, 205);
            this.textBoxFId.Name = "textBoxFId";
            this.textBoxFId.ReadOnly = true;
            this.textBoxFId.Size = new System.Drawing.Size(100, 19);
            this.textBoxFId.TabIndex = 25;
            // 
            // textBoxSauceId
            // 
            this.textBoxSauceId.Location = new System.Drawing.Point(1150, 272);
            this.textBoxSauceId.Name = "textBoxSauceId";
            this.textBoxSauceId.ReadOnly = true;
            this.textBoxSauceId.Size = new System.Drawing.Size(100, 19);
            this.textBoxSauceId.TabIndex = 26;
            // 
            // textBoxSandwichId
            // 
            this.textBoxSandwichId.Location = new System.Drawing.Point(1154, 338);
            this.textBoxSandwichId.Name = "textBoxSandwichId";
            this.textBoxSandwichId.ReadOnly = true;
            this.textBoxSandwichId.Size = new System.Drawing.Size(100, 19);
            this.textBoxSandwichId.TabIndex = 27;
            // 
            // textBoxBId
            // 
            this.textBoxBId.Location = new System.Drawing.Point(1150, 413);
            this.textBoxBId.Name = "textBoxBId";
            this.textBoxBId.ReadOnly = true;
            this.textBoxBId.Size = new System.Drawing.Size(100, 19);
            this.textBoxBId.TabIndex = 28;
            // 
            // textBoxRId
            // 
            this.textBoxRId.Location = new System.Drawing.Point(1150, 483);
            this.textBoxRId.Name = "textBoxRId";
            this.textBoxRId.ReadOnly = true;
            this.textBoxRId.Size = new System.Drawing.Size(100, 19);
            this.textBoxRId.TabIndex = 29;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(1175, 36);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 30;
            this.buttonReset.Text = "リセット";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1148, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "フィリングID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1150, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "ソースID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1152, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "サンドイッチID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1154, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "ブレッドID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1150, 452);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 35;
            this.label5.Text = "地域ID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 763);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxRId);
            this.Controls.Add(this.textBoxBId);
            this.Controls.Add(this.textBoxSandwichId);
            this.Controls.Add(this.textBoxSauceId);
            this.Controls.Add(this.textBoxFId);
            this.Controls.Add(this.buttonSauceClr);
            this.Controls.Add(this.buttonFClr);
            this.Controls.Add(this.buttonIns);
            this.Controls.Add(this.buttonUpd);
            this.Controls.Add(this.buttonC);
            this.Controls.Add(this.buttonB);
            this.Controls.Add(this.buttonSandwich);
            this.Controls.Add(this.buttonSauce);
            this.Controls.Add(this.buttonF);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.textBoxCNameEn);
            this.Controls.Add(this.textBoxCNameJp);
            this.Controls.Add(this.textBoxBName);
            this.Controls.Add(this.textBoxRName);
            this.Controls.Add(this.textBoxSandwich);
            this.Controls.Add(this.textBoxSauce);
            this.Controls.Add(this.textBoxFName);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "BreadMaster";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxFName;
        private System.Windows.Forms.TextBox textBoxSauce;
        private System.Windows.Forms.TextBox textBoxSandwich;
        private System.Windows.Forms.TextBox textBoxRName;
        private System.Windows.Forms.TextBox textBoxBName;
        private System.Windows.Forms.TextBox textBoxCNameJp;
        private System.Windows.Forms.TextBox textBoxCNameEn;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Button buttonF;
        private System.Windows.Forms.Button buttonSauce;
        private System.Windows.Forms.Button buttonSandwich;
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.Button buttonC;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonIns;
        private System.Windows.Forms.Button buttonFClr;
        private System.Windows.Forms.Button buttonSauceClr;
        private System.Windows.Forms.TextBox textBoxFId;
        private System.Windows.Forms.TextBox textBoxSauceId;
        private System.Windows.Forms.TextBox textBoxSandwichId;
        private System.Windows.Forms.TextBox textBoxBId;
        private System.Windows.Forms.TextBox textBoxRId;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

