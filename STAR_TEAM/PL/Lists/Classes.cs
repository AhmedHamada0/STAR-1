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
    public partial class Classes : Form
    {
        public Classes()
        {
            InitializeComponent();
        }

        public void RefreshClasses()
        {
            Classes_List.Items.Clear();
            List<Class> C_List = BaseClass.db.Classes.ToList();
            foreach (var o in C_List)
            {
                string[] List_item = { o.Class_ID.ToString(), o.Class_Name, o.Class_IsCreadet.ToString() };
                var ListViewItem = new ListViewItem(List_item);
                Classes_List.Items.Add(ListViewItem);
            }
            foreach (ListViewItem itemRow in this.Classes_List.Items)
            {
                foreach(var o in BaseClass.CSelectedList)
                {
                    if (o.Class_ID.ToString() ==  itemRow.SubItems[0].Text)
                    {
                        itemRow.BackColor = Color.Green; itemRow.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void Classes_Load(object sender, EventArgs e)
        {
            RefreshClasses();
        }

        private void TxSearch_Class_TextChanged(object sender, EventArgs e)
        {
            Classes_List.Items.Clear();
            TxSearch_Class.Text = TxSearch_Class.Text.Replace(" ", string.Empty);
            if (TxSearch_Class.Text != "" && TxSearch_Class.Text != "Search")
            {
                List<Class> Class_Search = BaseClass.db.Classes.Where(a => (a.Class_Name.Contains(TxSearch_Class.Text))).ToList();
                foreach (var o in Class_Search)
                {
                    string[] List_item = { o.Class_ID.ToString(), o.Class_Name, o.Class_IsCreadet.ToString() };
                    var ListViewItem = new ListViewItem(List_item);
                    Classes_List.Items.Add(ListViewItem);
                }
            }
            else
            {
                RefreshClasses();
            }
        }

        private void Classes_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Classes_List.SelectedItems.Count == 0) return;
            ListViewItem item = Classes_List.SelectedItems[0];
            //fill the text boxes
            TxID.Text = item.SubItems[0].Text;
            Class s = BaseClass.CSelectedList.FirstOrDefault(a => a.Class_ID.ToString() == TxID.Text);
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

        private void Add_btn_Click(object sender, EventArgs e)
        {
            Class c = BaseClass.db.Classes.FirstOrDefault(a => a.Class_ID.ToString() == TxID.Text);
            if (c != null)
            {
                Class s = BaseClass.CSelectedList.FirstOrDefault(a => a.Class_ID.ToString() == TxID.Text);
                if (s == null) { BaseClass.CSelectedList.Add(c); }
                else { MessageBox.Show("Error, this class already exists!"); }
            }
            else { MessageBox.Show("Error, Invalid ID!"); }
            RefreshClasses();
        }

        private void Del_btn_Click(object sender, EventArgs e)
        {
            Class s = BaseClass.CSelectedList.FirstOrDefault(a => a.Class_ID.ToString() == TxID.Text);
            if(s != null)
            {
                BaseClass.CSelectedList.Remove(s);
                MessageBox.Show("Done!  [Deleted]");
            }
            else { MessageBox.Show("Error, this class does not selected!"); }
            RefreshClasses();
        }

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            RefreshClasses();
        }

        private void SearchTx_Tick(object sender, EventArgs e)
        {
            if (TxSearch_Class.Text == "")
            {
                TxSearch_Class.Text = "Search";
                RefreshClasses();
            }
        }

        private void TxSearch_Class_MouseMove(object sender, MouseEventArgs e)
        {
            TxSearch_Class.Text = "";
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
