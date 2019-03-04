using STAR_TEAM.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STAR_TEAM.PL.Lists
{
    public partial class Teachers : Form
    {
        public Teachers()
        {
            InitializeComponent();
        }

        public void RefreshTeachers()
        {
            Teach_List.Items.Clear();
            List<Teacher> C_List = BaseClass.db.Teachers.ToList();
            foreach (var o in C_List)
            {
                string[] List_item = { o.Teacher_ID.ToString(), o.Teach_Name, o.Teach_Email, o.Teach_Type };
                var ListViewItem = new ListViewItem(List_item);
                Teach_List.Items.Add(ListViewItem);
            }
            foreach (ListViewItem itemRow in this.Teach_List.Items)
            {
                foreach (var o in BaseClass.TSelectedList)
                {
                    if (o.Teacher_ID.ToString() == itemRow.SubItems[0].Text)
                    {
                        itemRow.BackColor = Color.Green; itemRow.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void TxSearch_Teach_TextChanged(object sender, EventArgs e)
        {
            Teach_List.Items.Clear();
            TxSearch_Teach.Text = TxSearch_Teach.Text.Replace(" ", string.Empty);
            if (TxSearch_Teach.Text != "" && TxSearch_Teach.Text != "Search")
            {
                List<Teacher> Teach_Search = BaseClass.db.Teachers.Where(a => (a.Teach_Name.Contains(TxSearch_Teach.Text)) || (a.Teach_Email.Contains(TxSearch_Teach.Text)) || (a.Teach_Phone.Contains(TxSearch_Teach.Text))).ToList();
                foreach (var o in Teach_Search)
                {
                    string[] List_item = { o.Teacher_ID.ToString(), o.Teach_Name, o.Teach_Email, o.Teach_Type };
                    var ListViewItem = new ListViewItem(List_item);
                    Teach_List.Items.Add(ListViewItem);
                }
            }
            else
            {
                RefreshTeachers();
            }
        }

        private void Teachers_Load(object sender, EventArgs e)
        {
            RefreshTeachers();
        }

        private void Teach_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Teach_List.SelectedItems.Count == 0) return;
            ListViewItem item = Teach_List.SelectedItems[0];
            //fill the text boxes
            TxID.Text = item.SubItems[0].Text;
            Teacher s = BaseClass.TSelectedList.FirstOrDefault(a => a.Teacher_ID.ToString() == TxID.Text);
            if (s == null)
            {
                Del_btn.Visible = false;
                Add_btn.Visible = true;
            }
            else
            {
                Del_btn.Visible = true; Add_btn.Visible = false;
            }
        }

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            RefreshTeachers();
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            Teacher t = BaseClass.db.Teachers.FirstOrDefault(a => a.Teacher_ID.ToString() == TxID.Text);
            if (t != null)
            {
                Teacher s = BaseClass.TSelectedList.FirstOrDefault(a => a.Teacher_ID.ToString() == TxID.Text);
                if (s == null) { BaseClass.TSelectedList.Add(t); }
                else { MessageBox.Show("Error, this Teacher already exists!"); }
            }
            else { MessageBox.Show("Error, Invalid ID!"); }
            RefreshTeachers();
        }

        private void Del_btn_Click(object sender, EventArgs e)
        {
            Teacher t = BaseClass.TSelectedList.FirstOrDefault(a => a.Teacher_ID.ToString() == TxID.Text);
            if (t != null)
            {
                BaseClass.TSelectedList.Remove(t);
                MessageBox.Show("Done!  [Deleted]");
            }
            else { MessageBox.Show("Error, this Teacher does not selected!"); }
            RefreshTeachers();
        }

        private void SearchTx_Tick(object sender, EventArgs e)
        {
            if(TxSearch_Teach.Text == "")
            {
                TxSearch_Teach.Text = "Search";
                RefreshTeachers();
            }
        }

        private void TxSearch_Teach_MouseMove(object sender, MouseEventArgs e)
        {
            TxSearch_Teach.Text = "";
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
