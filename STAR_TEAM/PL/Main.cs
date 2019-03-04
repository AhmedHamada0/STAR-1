using STAR_TEAM.Classes;
using STAR_TEAM.PL;
using STAR_TEAM.PL.Times;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTalk;

namespace STAR_TEAM
{
    public partial class Main : Form
    {
        public BaseClass _Base = new BaseClass();
        public Main()
        {
            InitializeComponent();
            
        }

        public bool IsReady = true; //false;

        public void CreateDB()
        {
            Thread t = new Thread(() =>
            {
                BaseClass.db.Database.CreateIfNotExists();
                BaseClass.DB_IsCreated = true;
            });
            t.IsBackground = true;
            t.Priority = ThreadPriority.Highest;
            t.Start();
        }

        public void ClearAll()
        {
            Teach_Name.Text = "";
            Teach_Email.Text = "";
            Teach_Phone.Text = "";
            Teach_About.Text = "";
            Teach_Add.Text = "Add";
            Teach_ID.Text = "ID";
            Teach_List.Enabled = true;
            T_Refresh.Enabled = true;
            Class_Name.Text = "";
            Class_Add.Text = "Add";
            Class_ID.Text = "ID";
            Class_list.Enabled = true;
            C_Refresh.Enabled = true;
            Place_Name.Text = "";
            Place_Add.Text = "Add";
            Place_ID.Text = "ID";
            Places_list.Enabled = true;
            P_Refresh.Enabled = true;
            Sub_Name.Text = "";
            TimePerWeek.Text = "";
            Sub_Add.Text = "Add";
            Sub_ID.Text = "ID";
            Sub_List.Enabled = true;
            S_Refresh.Enabled = true;
            BaseClass.TimesList = new List<bool>();
            BaseClass.CSelectedList = new List<Class>();
            BaseClass.TSelectedList = new List<Teacher>();
        }

        public void ViewsRefresh(string c)
        {
            Thread t = new Thread(() =>
            {
                while (BaseClass.DB_IsCreated == false)
                {
                    Thread.Sleep(2000);
                }
            ClearAll();
            switch (c)
            {
                case ("T"):
                    Teach_List.Items.Clear();
                    List<Teacher> T_List = BaseClass.db.Teachers.ToList();
                    foreach (var o in T_List)
                    {
                        string[] List_item = { o.Teacher_ID.ToString(), o.Teach_Name, o.Teach_Type, o.Teach_Email, o.Teach_Phone };
                        var ListViewItem = new ListViewItem(List_item);
                        Teach_List.Items.Add(ListViewItem);
                    }
                    break;

                case ("P"):
                    Places_list.Items.Clear();
                    List<Place> P_List = BaseClass.db.Places.ToList();
                    foreach (var o in P_List)
                    {
                        string[] List_item = { o.Place_ID.ToString(), o.Place_Name, o.PDescribtion_place };
                        var ListViewItem = new ListViewItem(List_item);
                        Places_list.Items.Add(ListViewItem);
                    }
                    break;

                case ("C"):
                    Class_list.Items.Clear();
                    List<Class> C_List = BaseClass.db.Classes.ToList();
                    foreach (var o in C_List)
                    {
                        string[] List_item = { o.Class_ID.ToString(), o.Class_Name, o.Class_IsCreadet.ToString(), o.Class_Group };
                        var ListViewItem = new ListViewItem(List_item);
                        Class_list.Items.Add(ListViewItem);
                    }
                    break;

                case ("S"):
                    Sub_List.Items.Clear();
                    List<Subject> S_List = BaseClass.db.Subjects.ToList();
                    foreach (var o in S_List)
                    {
                        string[] List_item = { o.Sub_ID.ToString(), o.Sub_Name, o.Is_Group.ToString(), o.SDescreption_place, o.Sub_Timebyweek.ToString() };
                        var ListViewItem = new ListViewItem(List_item);
                        Sub_List.Items.Add(ListViewItem);
                    }
                    break;

                case (""):
                case ("All"):
                default:
                    Teach_List.Items.Clear();
                    Places_list.Items.Clear();
                    Class_list.Items.Clear();
                    Sub_List.Items.Clear();
                    List<Teacher> T_List1 = BaseClass.db.Teachers.ToList();
                    foreach (var o in T_List1)
                    {
                        string[] List_item = { o.Teacher_ID.ToString(), o.Teach_Name, o.Teach_Type, o.Teach_Email, o.Teach_Phone };
                        var ListViewItem = new ListViewItem(List_item);
                        Teach_List.Items.Add(ListViewItem);
                    }
                    List<Place> P_List1 = BaseClass.db.Places.ToList();
                    foreach (var o in P_List1)
                    {
                        string[] List_item = { o.Place_ID.ToString(), o.Place_Name, o.PDescribtion_place };
                        var ListViewItem = new ListViewItem(List_item);
                        Places_list.Items.Add(ListViewItem);
                    }
                    List<Class> C_List1 = BaseClass.db.Classes.ToList();
                    foreach (var o in C_List1)
                    {
                        string[] List_item = { o.Class_ID.ToString(), o.Class_Name, o.Class_IsCreadet.ToString(), o.Class_Group };
                        var ListViewItem = new ListViewItem(List_item);
                        Class_list.Items.Add(ListViewItem);
                    }
                    List<Subject> S_List1 = BaseClass.db.Subjects.ToList();
                    foreach (var o in S_List1)
                    {
                        string[] List_item = { o.Sub_ID.ToString(), o.Sub_Name, o.Is_Group.ToString(), o.SDescreption_place, o.Sub_Timebyweek.ToString() };
                        var ListViewItem = new ListViewItem(List_item);
                        Sub_List.Items.Add(ListViewItem);
                    }
                    break;
            }
                // if (BaseClass.db.Teachers.Count() > 0 && BaseClass.db.Classes.Count() > 0 && BaseClass.db.Places.Count() > 0 && BaseClass.db.Subjects.Count() > 0) { IsReady = true; } else { IsReady = false; }
            });
            t.IsBackground = true;
            t.Priority = ThreadPriority.Highest;
            t.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateDB();
        }
        
        private void iTalk_Button_17_Click(object sender, EventArgs e)
        {
            if (BaseClass.db.Database.Exists() == true)
            {
                BaseClass.db.Database.Delete();
            }
            Application.Exit();
        }
      
        private void T_Times_Click(object sender, EventArgs e)
        {
            while (BaseClass.DB_IsCreated == false)
            {
                Thread.Sleep(2000);
            }
            Times tform = new Times();
            //////////////////////////
            if (IS_Edit_Mode && BaseClass.TimesList.Count > 0)
            {
                for (int i = 1; i <= 42; i++)
                {
                    CheckBox checkbox = (CheckBox)tform.Controls.Find("T" + i.ToString(), true)[0];
                    checkbox.Checked = BaseClass.TimesList[i - 1];
                }
            }         // old cheked
            else tform.SetChecked();
            //////////////////////////
            tform.ShowDialog();
            if (BaseClass.TimesList != null && BaseClass.TimesList.Count > 0)
            {
                MessageBox.Show("Times are sets!");
            }
            else { MessageBox.Show("Time are not sets!"); ClearAll(); }
        }

        private void Teach_Add_Click(object sender, EventArgs e)
        {
            while (BaseClass.DB_IsCreated == false)
            {
                Thread.Sleep(2000);
            }
            if (Teach_Name.Text != "" && Teach_Type.Text != "" && BaseClass.TimesList.Count > 0)
            {
                if (Teach_Add.Text == "Edit")
                {
                    Teacher T = BaseClass.db.Teachers.FirstOrDefault(a => a.Teacher_ID.ToString() == Teach_ID.Text);
                    if (T != null)
                    {
                        T.Teach_Name = Teach_Name.Text;
                        T.Teach_Type = Teach_Type.Text;
                        T.Teach_Email = Teach_Email.Text;
                        T.Teach_Phone = Teach_Phone.Text;
                        T.TAvalabile_period = String.Join(",", BaseClass.TimesList);
                        T.Teach_About = Teach_About.Text;
                        Teach_Name.Text = "";
                        Teach_Email.Text = "";
                        Teach_Phone.Text = "";
                        Teach_About.Text = "";
                        BaseClass.TimesList = new List<bool>();
                        Teach_Add.Text = "Add";
                        Teach_ID.Text = "ID";
                        Teach_List.Enabled = true;
                        T_Refresh.Enabled = true;
                        BaseClass.db.SaveChanges();
                        ViewsRefresh("T");
                        MessageBox.Show("Done!");
                    }
                    else
                    {
                        MessageBox.Show("Error, Invalid ID!");
                    }
                }
                else
                {
                    byte id = BaseClass.GenerateRandom();
                    List<Teacher> T = BaseClass.db.Teachers.ToList();
                    foreach (var o in T)
                    {
                        if (o.Teacher_ID == id) { id += 1; }
                    }
                    Teacher NewTeacher = new Teacher
                    {
                        Teacher_ID = id,
                        Teach_Name = Teach_Name.Text,
                        Teach_Type = Teach_Type.Text,
                        TAvalabile_period = String.Join(",", BaseClass.TimesList),
                        Teach_Email = Teach_Email.Text,
                        Teach_Phone = Teach_Phone.Text,
                        Teach_About = Teach_About.Text
                    };
                    BaseClass.db.Teachers.Add(NewTeacher);
                    BaseClass.db.SaveChanges();
                    ViewsRefresh("T");
                    MessageBox.Show("Done!");
                }
            }
            else
            {
                MessageBox.Show("Data Error!");
            }
        }

        private void Teach_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Teach_List.SelectedItems.Count == 0) return;
            ListViewItem item = Teach_List.SelectedItems[0];
            //fill the text boxes
            Teach_ID.Text = item.SubItems[0].Text;
        }

        private void Class_Times_Click(object sender, EventArgs e)
        {
            while (BaseClass.DB_IsCreated == false)
            {
                Thread.Sleep(2000);
            }
            Times tform = new Times();
            //////////////////////////
            if (IS_Edit_Mode && BaseClass.TimesList.Count > 0)
            {
                for (int i = 1; i <= 42; i++)
                {
                    CheckBox checkbox = (CheckBox)tform.Controls.Find("T" + i.ToString(), true)[0];
                    checkbox.Checked = BaseClass.TimesList[i - 1];
                }
            }         // old cheked
            else tform.SetChecked();
            //////////////////////////
            tform.ShowDialog();
            if (BaseClass.TimesList != null && BaseClass.TimesList.Count > 0)
            {
                MessageBox.Show("Times are sets!");
            }
            else { MessageBox.Show("Time are not sets!"); ClearAll(); }
        }
        //==========================
        private void Class_Add_Click(object sender, EventArgs e)
        {
            while (BaseClass.DB_IsCreated == false)
            {
                Thread.Sleep(2000);
            }
            if (Class_Name.Text != "" && Class_IsCreadet.Text != "" && G_group.Text != "" && G_year.Text != "" && BaseClass.TimesList.Count > 0)
            {
                if (Class_Add.Text == "Edit")
                {
                    Class C = BaseClass.db.Classes.FirstOrDefault(a => a.Class_ID.ToString() == Class_ID.Text);
                    if (C != null)
                    {
                        C.Class_Name = Class_Name.Text;
                        C.Class_Group = G_group.Text + G_year.Text;
                        if (Class_IsCreadet.Text == "True") { C.Class_IsCreadet = true; } else { C.Class_IsCreadet = false; }
                        C.CAvalabile_period = String.Join(",", BaseClass.TimesList);
                        IS_Edit_Mode = false;
                        Class_Name.Text = "";
                        BaseClass.TimesList = new List<bool>();
                        Class_Add.Text = "Add";
                        Class_ID.Text = "ID";
                        Class_list.Enabled = true;
                        C_Refresh.Enabled = true;
                        BaseClass.db.SaveChanges();
                        ViewsRefresh("C");
                        MessageBox.Show("Done!");
                    }
                    else
                    {
                        MessageBox.Show("Error, Invalid ID!");
                    }
                }
                else
                {
                    byte id = BaseClass.GenerateRandom();
                    List<Class> T = BaseClass.db.Classes.ToList();
                    foreach (var o in T)
                    {
                        if (o.Class_ID == id) { id += 1; }
                    }
                    Class NewClass = new Class
                    {
                        Class_ID = id,
                        Class_Name = Class_Name.Text,
                        Class_Group = (G_group.Text + G_year.Text),
                        CAvalabile_period = String.Join(",", BaseClass.TimesList)
                    };

                    if (Class_IsCreadet.Text == "True")
                    {
                        NewClass.Class_IsCreadet = true;
                    }
                    else { NewClass.Class_IsCreadet = false; }

                    BaseClass.db.Classes.Add(NewClass);
                    BaseClass.db.SaveChanges();
                    ViewsRefresh("C");
                    MessageBox.Show("Done!");
                }
            }
            else
            {
                MessageBox.Show("Data Error!");
            }

        }

        private void Place_Add_Click(object sender, EventArgs e)
        {
            while (BaseClass.DB_IsCreated == false)
            {
                Thread.Sleep(2000);
            }
            if (Place_Name.Text != "" && PDes_Place.Text != "")
            {
                if (Place_Add.Text == "Edit")
                {
                    Place P = BaseClass.db.Places.FirstOrDefault(a => a.Place_ID.ToString() == Place_ID.Text);
                    if (P != null)
                    {
                        P.Place_Name = Place_Name.Text;
                        P.PDescribtion_place = PDes_Place.Text;
                        Place_Name.Text = "";
                        Place_Add.Text = "Add";
                        Place_ID.Text = "ID";
                        Places_list.Enabled = true;
                        P_Refresh.Enabled = true;
                        BaseClass.db.SaveChanges();
                        ViewsRefresh("P");
                        MessageBox.Show("Done!");
                    }
                    else
                    {
                        MessageBox.Show("Error, Invalid ID!");
                    }
                }
                else
                {
                    byte id = BaseClass.GenerateRandom();
                    List<Place> T = BaseClass.db.Places.ToList();
                    foreach (var o in T)
                    {
                        if (o.Place_ID == id) { id += 1; }
                    }
                    Place NewPlace = new Place
                    {
                        Place_ID = id,
                        Place_Name = Place_Name.Text,
                        PDescribtion_place = PDes_Place.Text
                    };
                    BaseClass.db.Places.Add(NewPlace);
                    BaseClass.db.SaveChanges();
                    ViewsRefresh("P");
                    MessageBox.Show("Done!");
                }
            }
            else
            {
                MessageBox.Show("Data Error!");
            }
        }

        private void Sub_ClassList_Click(object sender, EventArgs e)
        {
            while (BaseClass.DB_IsCreated == false)
            {
                Thread.Sleep(2000);
            }
            PL.Lists.Classes cf = new PL.Lists.Classes();
            cf.ShowDialog();
            if (BaseClass.CSelectedList.Count > 0)
            {
                MessageBox.Show("Classes are selected!");
            }
            else { MessageBox.Show("Error, Classes are not selected!"); ClearAll(); }
        }

        private void Sub_TeachList_Click(object sender, EventArgs e)
        {
            while (BaseClass.DB_IsCreated == false)
            {
                Thread.Sleep(2000);
            }
            PL.Lists.Teachers tf = new PL.Lists.Teachers();
            tf.ShowDialog();
            if (BaseClass.TSelectedList.Count > 0)
            {
                MessageBox.Show("Teachers are selected!");
            }
            else { MessageBox.Show("Error, Teachers are not selected!"); ClearAll(); }
        }

        private void Sub_Add_Click(object sender, EventArgs e)
        {
            while (BaseClass.DB_IsCreated == false)
            {
                Thread.Sleep(2000);
            }
            if (TimePerWeek.Text == "1" || TimePerWeek.Text == "2")
            {
                if (Sub_Name.Text != "" && Sub_IsGroup.Text != "" && Sub_DP.Text != "" && TimePerWeek.Text != "" && BaseClass.CSelectedList.Count > 0 && BaseClass.TSelectedList.Count > 0)
                {
                    if (Sub_Add.Text == "Edit")
                    {
                        Subject S = BaseClass.db.Subjects.FirstOrDefault(a => a.Sub_ID.ToString() == Sub_ID.Text);
                        if (S != null)
                        {
                            S.Sub_Name = Sub_Name.Text;
                            if (Sub_IsGroup.Text == "True") { S.Is_Group = true; } else { S.Is_Group = false; }
                            S.Sub_Timebyweek = Convert.ToInt16(TimePerWeek.Text);
                            S.SDescreption_place = Sub_DP.Text;
                            S.Sub_ClassList = BaseClass.CSelectedList;
                            S.Sub_TeachList = BaseClass.TSelectedList;
                            Sub_Name.Text = "";
                            TimePerWeek.Text = "";
                            BaseClass.CSelectedList = new List<Class>();
                            BaseClass.TSelectedList = new List<Teacher>();
                            Sub_Add.Text = "Add";
                            Sub_ID.Text = "ID";
                            Sub_List.Enabled = true;
                            S_Refresh.Enabled = true;
                            BaseClass.db.SaveChanges();
                            ViewsRefresh("S");
                            MessageBox.Show("Done!");
                        }
                        else
                        {
                            MessageBox.Show("Error, Invalid ID!");
                        }
                    }
                    else
                    {
                        byte id = BaseClass.GenerateRandom();
                        List<Subject> S = BaseClass.db.Subjects.ToList();
                        foreach (var o in S)
                        {
                            if (o.Sub_ID == id) { id += 1; }
                        }
                        Subject NewSub = new Subject
                        {
                            Sub_ID = id,
                            Sub_Name = Sub_Name.Text,
                            Sub_Timebyweek = Convert.ToInt16(TimePerWeek.Text),
                            Sub_ClassList = BaseClass.CSelectedList,
                            Sub_TeachList = BaseClass.TSelectedList,
                            SDescreption_place = Sub_DP.Text
                        };
                        if (Sub_IsGroup.Text == "True")
                        {
                            NewSub.Is_Group = true;
                        }
                        else { NewSub.Is_Group = false; }
                        BaseClass.db.Subjects.Add(NewSub);
                        BaseClass.db.SaveChanges();
                        ViewsRefresh("S");
                        MessageBox.Show("Done!");
                    }
                }
                else
                {
                    MessageBox.Show("Data Error!");
                }
            }
            else
            {
                MessageBox.Show("Subject Time/s per week is only ( 1 or 2 ) times!");
                TimePerWeek.Text = "";
            }
        }

        private void TimePerWeek_TextChanged(object sender, EventArgs e)
        {

        }

        private void S_Refresh_Click(object sender, EventArgs e)
        {
            ViewsRefresh("S");
        }

        private void Sub_Edit_Click(object sender, EventArgs e)
        {
            while (BaseClass.DB_IsCreated == false)
            {
                Thread.Sleep(2000);
            }
            if (Sub_ID.Text != "" && Sub_ID.Text != "ID")
            {
                Subject S = BaseClass.db.Subjects.FirstOrDefault(a => a.Sub_ID.ToString() == Sub_ID.Text);
                if (S != null)
                {
                    Sub_Name.Text = S.Sub_Name;
                    Sub_IsGroup.Text = S.Is_Group.ToString();
                    Sub_DP.Text = S.SDescreption_place;
                    TimePerWeek.Text = S.Sub_Timebyweek.ToString();
                    BaseClass.CSelectedList = S.Sub_ClassList;
                    BaseClass.TSelectedList = S.Sub_TeachList;
                    Sub_List.Enabled = false;
                    S_Refresh.Enabled = false;
                    Sub_Add.Text = "Edit";
                }
                else
                {
                    MessageBox.Show("Error, Invalid ID!");
                }
            }
            else
            {
                MessageBox.Show("Error, No item selected!");
            }
        }

        private void C_Refresh_Click(object sender, EventArgs e)
        {
            ViewsRefresh("C");
        }

        private void P_Refresh_Click(object sender, EventArgs e)
        {
            ViewsRefresh("P");
        }

        private void T_Refresh_Click(object sender, EventArgs e)
        {
            ViewsRefresh("T");
        }

        private void Teach_Edit_Click(object sender, EventArgs e)
        {
            while (BaseClass.DB_IsCreated == false)
            {
                Thread.Sleep(2000);
            }
            IS_Edit_Mode = Class_Add.Text == "Edit" ? false : true;
            if (Teach_ID.Text != "" && Teach_ID.Text != "ID")
            {
                Teacher T = BaseClass.db.Teachers.FirstOrDefault(a => a.Teacher_ID.ToString() == Teach_ID.Text);
                if (T != null)
                {
                    Teach_Name.Text = T.Teach_Name;
                    Teach_Type.Text = T.Teach_Type;
                    Teach_Email.Text = T.Teach_Email;
                    Teach_Phone.Text = T.Teach_Phone;
                    List<string> Stringslist = T.TAvalabile_period.Split(',').ToList();
                    foreach (var o in Stringslist)
                    {
                        if (o == "True" || o == "true") { BaseClass.TimesList.Add(true); } else { BaseClass.TimesList.Add(false); }
                    }
                    Teach_About.Text = T.Teach_About;
                    if (T.TAvalabile_period != "")
                    {
                        Times tf = new Times();
                        for (int x = 1; x <= 42; x++)
                        {
                            CheckBox checkbox = (CheckBox)tf.Controls.Find("T" + x.ToString(), true)[0];
                            if (BaseClass.TimesList[x - 1] == true)
                            {
                                checkbox.Checked = true;
                            }
                            else { checkbox.Checked = false; }
                        }
                    }
                    Teach_List.Enabled = false;
                    T_Refresh.Enabled = false;
                    Teach_Add.Text = "Edit";
                }
                else
                {
                    MessageBox.Show("Error, Invalid ID!");
                }
            }
            else
            {
                MessageBox.Show("Error, No item selected!");
            }
        }
        static bool IS_Edit_Mode = false;
        private void Class_Edit_Click(object sender, EventArgs e)
        {
            while (BaseClass.DB_IsCreated == false)
            {
                Thread.Sleep(2000);
            }
            IS_Edit_Mode = Class_Add.Text == "Edit" ? false : true;
            if (Class_ID.Text != "" && Class_ID.Text != "ID")
            {
                Class C = BaseClass.db.Classes.FirstOrDefault(a => a.Class_ID.ToString() == Class_ID.Text);
                if (C != null)
                {
                    Class_Name.Text = C.Class_Name;
                    Class_IsCreadet.Text = C.Class_IsCreadet.ToString();
                    G_group.Text = C.Class_Group[0].ToString();
                    G_year.Text = C.Class_Group[1].ToString();
                    List<string> Stringslist = C.CAvalabile_period.Split(',').ToList();
                    foreach (var o in Stringslist)
                    {
                        if (o == "True" || o == "true") { BaseClass.TimesList.Add(true); } else { BaseClass.TimesList.Add(false); }
                    }
                    if (C.CAvalabile_period != "")
                    {
                        Times tf = new Times();
                        for (int x = 1; x <= 42; x++)
                        {
                            CheckBox checkbox = (CheckBox)tf.Controls.Find("T" + x.ToString(), true)[0];
                            if (BaseClass.TimesList[x - 1] == true)
                            {
                                checkbox.Checked = true;
                            }
                            else { checkbox.Checked = false; }
                        }
                    }
                    Class_list.Enabled = false;
                    C_Refresh.Enabled = false;
                    Class_Add.Text = "Edit";
                }
                else
                {
                    MessageBox.Show("Error, Invalid ID!");
                }
            }
            else
            {
                MessageBox.Show("Error, No item selected!");
            }
        }

        private void Place_Edit_Click(object sender, EventArgs e)
        {
            while (BaseClass.DB_IsCreated == false)
            {
                Thread.Sleep(2000);
            }
            if (Place_ID.Text != "" && Place_ID.Text != "ID")
            {
                Place P = BaseClass.db.Places.FirstOrDefault(a => a.Place_ID.ToString() == Place_ID.Text);
                if (P != null)
                {
                    Place_Name.Text = P.Place_Name;
                    PDes_Place.Text = P.PDescribtion_place;
                    Places_list.Enabled = false;
                    P_Refresh.Enabled = false;
                    Place_Add.Text = "Edit";
                }
                else
                {
                    MessageBox.Show("Error, Invalid ID!");
                }
            }
            else
            {
                MessageBox.Show("Error, No item selected!");
            }
        }

        private void App_Exit_Click(object sender, EventArgs e)
        {
            if (BaseClass.db.Database.Exists() == true)
            {
                BaseClass.db.Database.Delete();
            }
            Application.Exit();
        }
       
        private void Run_btn_Click(object sender, EventArgs e)
        {
            if (IsReady == true)
            {
                _Base.RunFunction();
            }
            else
            {
                MessageBox.Show("Please, Complete the data entry first!");
            }
        }

        private void Sub_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Sub_List.SelectedItems.Count == 0) return;
            ListViewItem item = Sub_List.SelectedItems[0];
            //fill the text boxes
            Sub_ID.Text = item.SubItems[0].Text;
        }

        private void Class_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Class_list.SelectedItems.Count == 0) return;
            ListViewItem item = Class_list.SelectedItems[0];
            //fill the text boxes
            Class_ID.Text = item.SubItems[0].Text;
        }

        private void Places_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Places_list.SelectedItems.Count == 0) return;
            ListViewItem item = Places_list.SelectedItems[0];
            //fill the text boxes
            Place_ID.Text = item.SubItems[0].Text;
        }
        /// <summary>
        /// when click to button in left will open it panel
        /// </summary>
        private void Tap_Click(object sender, EventArgs e)
        {
            _1P.Visible = _2P.Visible = _3P.Visible = _4P.Visible = _5P.Visible = false;
            int num = sender.GetType() != _1B.GetType() ?
                int.Parse(((iTalk_Button_1)sender).Name[1].ToString()) : int.Parse(((iTalk_Button_2)sender).Name[1].ToString());
            var L = Controls.Find("_" + num + "P", true)[0];
            L.Visible = true;
            /*
            _1P.Visible = false;
            _2P.Visible = false;
            _4P.Visible = false;
            _5P.Visible = true;
            _3P.Visible = false;
            ViewsRefresh("S");
             */
        }
    }
}
