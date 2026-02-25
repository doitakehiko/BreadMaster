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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BreadMaster
{
    public partial class Form1 : Form
    {
        string connectionString = BreadMasterAppConstants.connectionString;
        string sCrLf = BreadMasterAppConstants.sCrLf;
        private bool flgUpd = false;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handles the Load event of the form by initializing the DataGridView and loading data from the database.
        /// </summary>
        /// <remarks>This method configures the DataGridView for read-only, single-row selection and
        /// attempts to populate it with data from the database when the form loads. If the form is in update mode, the
        /// DataGridView is disabled. Any connection or data retrieval errors are logged to the associated log
        /// textbox.</remarks>
        /// <param name="sender">The source of the event, typically the form being loaded.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            if (flgUpd) {   
                dataGridView1.Enabled = false;
            } else
            {
                dataGridView1.Enabled = true;
            }

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            string sql = "SELECT * FROM vMaster";
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
  

        /// <summary>
        /// Handles the MouseClick event for the DataGridView to populate related text boxes with the values from the
        /// selected row.
        /// </summary>
        /// <remarks>This method updates multiple text boxes with the values from the clicked row in the
        /// DataGridView. Only clicks on valid data rows (excluding header and new row) will trigger the
        /// update.</remarks>
        /// <param name="sender">The source of the event, typically the DataGridView control.</param>
        /// <param name="e">A MouseEventArgs that contains the event data, including mouse button and click location.</param>
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            // クリックされた位置の情報を取得
            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                // 行インデックスと列インデックスを取得
                int rowIndex = hit.RowIndex;
                if (rowIndex < 0 || rowIndex >= dataGridView1.Rows.Count - 1) return;

                textBoxId.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                textBoxFName.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                textBoxSauce.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                textBoxSandwich.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                textBoxRName.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                textBoxBName.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                textBoxCNameJp.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
                textBoxCNameEn.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
                textBoxCode.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();

                textBoxFId.Text = dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();
                textBoxSauceId.Text = dataGridView1.Rows[rowIndex].Cells[10].Value.ToString();
                textBoxSandwichId.Text = dataGridView1.Rows[rowIndex].Cells[11].Value.ToString();
                textBoxBId.Text = dataGridView1.Rows[rowIndex].Cells[12].Value.ToString();
                textBoxRId.Text = dataGridView1.Rows[rowIndex].Cells[13].Value.ToString();

            }
        }
        /// <summary>
        /// Handles the Click event of the buttonF control by displaying the FormF dialog and updating related fields
        /// based on user input.
        /// </summary>
        /// <remarks>If the user confirms the dialog by clicking OK, the method updates the associated
        /// text boxes with values from FormF and sets the update flag if the input is valid. The form is reloaded after
        /// the operation completes.</remarks>
        /// <param name="sender">The source of the event, typically the buttonF control.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
        private void buttonF_Click(object sender, EventArgs e)
        {
            FormF f = new FormF();
            f.setid(textBoxFId.Text);
            f.setname(textBoxFName.Text);
            f.ShowDialog(this);
            if (f.DialogResult == DialogResult.OK)
            {
                textBoxFName.Text = f.getname();
                textBoxFId.Text = f.getid();
                if( checkInput())
                {
                    flgUpd = true;
                }
            }
            f.Dispose();
            Form1_Load(sender, e);
        }
        /// <summary>
        /// Handles the Click event of the Sauce button, allowing the user to select or edit sauce information using a
        /// modal dialog.
        /// </summary>
        /// <remarks>If the user confirms their selection in the dialog, the sauce information in the
        /// associated text boxes is updated. The method also reloads the form data after the dialog is
        /// closed.</remarks>
        /// <param name="sender">The source of the event, typically the Sauce button.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
        private void buttonSauce_Click(object sender, EventArgs e)
        {
            FormSauce f = new FormSauce();
            f.setid(textBoxSauceId.Text);
            f.setname(textBoxSauce.Text);
            f.ShowDialog(this);
            if (f.DialogResult == DialogResult.OK)
            {
                textBoxSauce.Text = f.getname();
                textBoxSauceId.Text = f.getid(); ;
                if (checkInput())
                {
                    flgUpd = true;
                }

            }
            f.Dispose();
            Form1_Load(sender, e);
        }
        /// <summary>
        /// Handles the Click event of the Sandwich button, displaying the sandwich selection dialog and updating the
        /// related fields based on user input.
        /// </summary>
        /// <remarks>If the user confirms their selection in the sandwich dialog, the sandwich name and ID
        /// fields are updated. The method also reloads the form data after the dialog is closed.</remarks>
        /// <param name="sender">The source of the event, typically the Sandwich button.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
        private void buttonSandwich_Click(object sender, EventArgs e)
        {
            FormSandwich f = new FormSandwich();
            f.setid(textBoxSandwichId.Text);
            f.setname(textBoxSandwich.Text);
            f.ShowDialog(this);
            if (f.DialogResult == DialogResult.OK)
            {
                textBoxSandwich.Text = f.getname();
                textBoxSandwichId.Text = f.getid();
                if (checkInput())
                {
                    flgUpd = true;
                } 
            }
            f.Dispose();
            Form1_Load(sender, e);
        }
        /// <summary>
        /// Handles the Click event of the Button B control, displaying FormB as a modal dialog and updating related
        /// fields based on user input.
        /// </summary>
        /// <remarks>If the user confirms their input in FormB, the method updates the associated text
        /// boxes and sets the update flag if the input is valid. The form is reloaded after the operation
        /// completes.</remarks>
        /// <param name="sender">The source of the event, typically the Button B control.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
        private void buttonB_Click(object sender, EventArgs e)
        {
            FormB f = new FormB();
            f.setid(textBoxBId.Text);
            f.setname(textBoxBName.Text);
            f.ShowDialog(this);
            if (f.DialogResult == DialogResult.OK)
            {
                textBoxBId.Text = f.getid();
                textBoxBName.Text = f.getname();
                if (checkInput())
                {
                    flgUpd = true;
                }
            }
            f.Dispose();
            Form1_Load(sender, e);
        }
        /// <summary>
        /// Handles the Click event of the C button, displaying the FormR dialog and updating related text fields based
        /// on the user's input.
        /// </summary>
        /// <remarks>If the user confirms their input in the FormR dialog, the method updates several text
        /// fields with values from the dialog and sets an update flag if the input is valid. The form is reloaded after
        /// the operation completes.</remarks>
        /// <param name="sender">The source of the event, typically the button that was clicked.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
        private void buttonC_Click(object sender, EventArgs e)
        {
            FormR f = new FormR();
            f.setid(textBoxRId.Text);
            f.ShowDialog(this);
            if (f.DialogResult == DialogResult.OK)
            {
                textBoxRName.Text = f.getTextBoxRName();
                textBoxCNameJp.Text = f.getTextBoxNameJp();
                textBoxCNameEn.Text = f.getTextBoxNameEn();
                textBoxCode.Text = f.getTextBoxCode();
                textBoxRId.Text = f.getRId();
                if (checkInput())
                {
                    flgUpd = true;
                }
            }
            f.Dispose();
            Form1_Load(sender, e);
        }
        /// <summary>
        /// Determines whether any of the relevant input text boxes contain a non-empty value.  
        /// </summary>
        /// <returns>true if at least one of the input text boxes is not empty; otherwise, false.</returns>
        private Boolean checkInput()
        {
            if (textBoxFId.Text != "" | textBoxSauceId.Text != "" | textBoxSandwichId.Text != "" | textBoxRId.Text != "" | textBoxBId.Text != "")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Handles the Click event of the Insert button, displaying the FormIns dialog for inserting new records and   
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonIns_Click(object sender, EventArgs e)
        {
            if (textBoxSandwichId.Text == "" | textBoxRId.Text == "" | textBoxBId.Text == "")
            {
                MessageBox.Show("サンドイッチ、地域、ブレッドを登録してください");
                return;
            }
            FormIns f = new FormIns();
            f.setTextBoxFId(textBoxFId.Text);
            f.setTextBoxSauceId(textBoxSauceId.Text);
            f.setTextBoxSandwichId(textBoxSandwichId.Text);
            f.setTextBoxBId(textBoxBId.Text);
            f.setTextBoxRId(textBoxRId.Text);

            f.setTextBoxFname(textBoxFName.Text);
            f.setTextBoxSauceName(textBoxSauce.Text);
            f.setTextBoxSandwichName(textBoxSandwich.Text);
            f.setTextBoxRName(textBoxRName.Text);
            f.setTextBoxBName(textBoxBName.Text);
            f.setTextBoxCNameJp(textBoxCNameJp.Text);
            f.setTextBoxCNameEn(textBoxCNameEn.Text);
            f.setTextBoxCCode(textBoxCode.Text);


            f.ShowDialog(this);
            flgUpd = false;
            if (f.DialogResult == DialogResult.OK)
            {
                textBoxId.Text = f.getTextBoxId();
                textBoxFId.Text = f.getTextBoxFId();
                textBoxSauceId.Text = f.getTextBoxSauceId();
                textBoxSandwichId.Text = f.getTextBoxSandwichId();
                textBoxBId.Text = f.getTextBoxBId();
                textBoxRId.Text = f.getTextBoxRId();
                textBoxFName.Text = f.getTextBoxFName();
                textBoxSauce.Text = f.getTextBoxSauceName();
                textBoxSandwich.Text = f.getTextBoxSandwichName();
                textBoxRName.Text = f.getTextBoxRName();
                textBoxBName.Text = f.getTextBoxBName();
                textBoxCNameJp.Text = f.getTextBoxCNameJp();
                textBoxCNameEn.Text = f.getTextBoxCNameEn();
                textBoxCode.Text = f.getTextBoxCCode();
            }
            f.Dispose();
            Form1_Load(sender, e);

        }
        /// <summary>
        /// Handles the Click event of the Update button, displaying the FormUpd dialog for updating existing records and
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (textBoxSandwichId.Text == "" | textBoxRId.Text == "" | textBoxBId.Text == "")
            {
                MessageBox.Show("サンドイッチ、地域、ブレッドを登録してください");
                return;
            }
            FormUpd f = new FormUpd();
            f.setTextBoxId(textBoxId.Text);
            f.setTextBoxFId(textBoxFId.Text);
            f.setTextBoxSauceId(textBoxSauceId.Text);
            f.setTextBoxSandwichId(textBoxSandwichId.Text);
            f.setTextBoxBId(textBoxBId.Text);
            f.setTextBoxRId(textBoxRId.Text);
            f.setTextBoxFName(textBoxFName.Text);
            f.setTextBoxSauceName(textBoxSauce.Text);
            f.setTextBoxSandwichName(textBoxSandwich.Text);
            f.setTextBoxRName(textBoxRName.Text);
            f.setTextBoxBName(textBoxBName.Text);
            f.setTextBoxNameJp(textBoxCNameJp.Text);
            f.setTextBoxNameEn(textBoxCNameEn.Text);
            f.setTextBoxCCode(textBoxCode.Text);
            f.ShowDialog(this);
            flgUpd = false;

            f.Dispose();
            Form1_Load(sender, e);

        }
        /// <summary>
        /// Handles the Click event of the buttonFClr control, clearing the text boxes related to the "F" entity.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFClr_Click(object sender, EventArgs e)
        {
            textBoxFName.Clear();
            textBoxFId.Clear();
        }
        /// <summary>
        /// Handles the Click event of the buttonSauceClr control, clearing the text boxes related to the "Sauce" entity.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSauceClr_Click(object sender, EventArgs e)
        {
            textBoxSauce.Clear();
            textBoxSauceId.Clear();
        }
        /// <summary>
        /// Handles the Click event of the buttonSandwichClr control, clearing the text boxes related to the "Sandwich" entity.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxId.Clear();
            textBoxFName.Clear();
            textBoxSauce.Clear();
            textBoxSandwich.Clear();    
            textBoxRName.Clear();
            textBoxBName.Clear();
            textBoxCNameJp.Clear(); 
            textBoxCNameEn.Clear();
            textBoxCode.Clear();
            textBoxFId.Clear();
            textBoxSauceId.Clear();
            textBoxSandwichId.Clear();
            textBoxBId.Clear();
            textBoxRId.Clear();
            flgUpd = false;
            Form1_Load(sender, e);
        }
        /// <summary>
        /// Handles the Click event of the buttonDel control, deleting the selected record from the database based on the ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == "")
            {
                MessageBox.Show("IDが入力されていません。");
                return;
            }
            string sqlDel = "DELETE FROM bread_master WHERE id = :id";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("接続成功");
                    textBoxLog.Text = sCrLf + "接続成功" + textBoxLog.Text;
                    using (OracleCommand command = new OracleCommand(sqlDel, connection))
                    {
                        command.Parameters.Add(new OracleParameter("id", int.Parse(textBoxId.Text)));
                        int rowsAffected = command.ExecuteNonQuery();
                        textBoxLog.Text = sCrLf + $"{rowsAffected} 行が削除されました。" + textBoxLog.Text;
                        MessageBox.Show($"{rowsAffected} 行が削除されました。");
                        buttonReset_Click(sender, e);
                        Form1_Load(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                textBoxLog.Text = sCrLf + $"エラー: {ex.Message}" + textBoxLog.Text;
                Console.WriteLine($"エラー: {ex.Message}");
            }

        }
        /// <summary>
        /// Handles the Click event of the buttonList control, displaying the FormList dialog to show a list of records from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonList_Click(object sender, EventArgs e)
        {
            FormList f = new FormList();
            f.ShowDialog(this);

            f.Dispose();
        }
    }
}
