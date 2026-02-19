using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreadMaster
{
    public partial class FormRM : Form
    {
        string connectionString = BreadMasterAppConstants.connectionString;
        string sCrLf = BreadMasterAppConstants.sCrLf;
        public FormRM()
        {
            InitializeComponent();
        }

        private void FormRM_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            string sql = "SELECT * FROM vRegionMaster";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("接続成功");
                    textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        OracleDataAdapter adapter = new OracleDataAdapter(sql, connection);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // DataGridViewにデータをバインド [2]
                        dataGridView1.DataSource = dataTable;
                        textBoxLog.Text = sCrLf + sql + textBoxLog.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;

                Console.WriteLine($"エラー: {ex.Message}");
            }
        }

        private void buttonCSelect_Click(object sender, EventArgs e)
        {
            FormC f = new FormC();
            f.ShowDialog(this);
            if (f.DialogResult == DialogResult.OK)
            {
                textBoxCId.Text = f.getid();
                textBoxCNameJp.Text = f.getnamejp();
                textBoxCNameEn.Text = f.getnameen();

            }

            f.Dispose();
        }
        public string getid()
        {
            return textBoxId.Text;
        }
        public string getname()
        {
            return textBoxRName.Text;
        }
        public string getcnamejp()
        {
            return textBoxCNameJp.Text;
        }
        public string getcnameen()
        {
            return textBoxCNameEn.Text;
        }
        public string getcid()
        {
            return textBoxCId.Text;
        }
        public void setid(string id)
        {
            textBoxId.Text = id;
        }


        private void buttonIns_Click(object sender, EventArgs e)
        {
            if (textBoxRName.Text == "")
            {
                MessageBox.Show("名前が入力されていません。");
                return;
            }
            if (textBoxCId.Text == "")
            {
                MessageBox.Show("国IDが入力されていません。");
                return;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                // 行インデックスと列インデックスを取得
                int rowIndex = hit.RowIndex;
                textBoxId.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                textBoxRName.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                textBoxCNameJp.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                textBoxCNameEn.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                textBoxCId.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            }
        }
    }
}
