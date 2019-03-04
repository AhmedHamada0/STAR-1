using STAR_TEAM.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STAR_TEAM.PL.Times
{
    public partial class Times : Form
    {
        public Times()
        {
            InitializeComponent();
        }
        bool FirstLoadForm = true;
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void sub_Click(object sender, EventArgs e)
        {
            bool ok = false;
            List<bool> arr = new List<bool>();
            for (int x = 1; x <= 42; x++)
            {
                CheckBox checkbox = (CheckBox)this.Controls.Find("T" + x.ToString(), true)[0];
                if (checkbox.Checked == true)
                {
                    arr.Add(true); ok = true;
                }
                else { arr.Add(false); }
            }
            if (ok == true)
            {
                BaseClass.TimesList = arr;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error, No Selected Times!");
            }
        }

        private void iTalk_Button_11_Click(object sender, EventArgs e)
        {
            BaseClass.TimesList.Clear();
            this.Close();
        }

        public void SetChecked()
        {
            for (int x = 7; x <= 36; x++)
            {
                CheckBox checkbox = (CheckBox)this.Controls.Find("T" + x.ToString(), true)[0];
                checkbox.Checked = true;
            }

        }

        public void SelectRow(int R)
        {
            if (FirstLoadForm == false)
            {
                int v = 0;
                switch (R)
                {
                    case 1:
                        v = 1;
                        break;
                    case 2:
                        v = 2;
                        break;
                    case 3:
                        v = 3;
                        break;
                    case 4:
                        v = 4;
                        break;
                    case 5:
                        v = 5;
                        break;
                    case 6:
                        v = 6;
                        break;
                    case 7:
                        v = 7;
                        break;
                    default:
                        break;
                }

                CS_ClassLibraryTester.SLCOnOffBox BigCheckbox = (CS_ClassLibraryTester.SLCOnOffBox)this.Controls.Find("R" + v.ToString(), true)[0];
                for (int i = (v * 6) - 5; i <= (v * 6); i++)
                {
                    if (BigCheckbox.Checked != true)
                    {
                        CheckBox checkbox = (CheckBox)this.Controls.Find("T" + i.ToString(), true)[0];
                        checkbox.Checked = false;
                    }
                    else
                    {
                        CheckBox checkbox = (CheckBox)this.Controls.Find("T" + i.ToString(), true)[0];
                        checkbox.Checked = true;
                    }
                }
            }
        }

        private void Times_Load(object sender, EventArgs e)
        {
            for (int x = 1; x <= 42; x += 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    CheckBox checkbox = (CheckBox)this.Controls.Find("T" + (x + i).ToString(), true)[0];
                    if (checkbox.Checked == true)
                    {
                        int o = x;
                        CS_ClassLibraryTester.SLCOnOffBox BigCheckbox = (CS_ClassLibraryTester.SLCOnOffBox)this.Controls.Find("R" + (o / 6 + 1).ToString(), true)[0];
                        BigCheckbox.Checked = true;
                        break;
                    }
                }
            }
            FirstLoadForm = false;
        }

        private void R1_CheckedChanged(object sender)
        {
            SelectRow(1);
        }

        private void R2_CheckedChanged(object sender)
        {
            SelectRow(2);
        }

        private void R3_CheckedChanged(object sender)
        {
            SelectRow(3);
        }

        private void R4_CheckedChanged(object sender)
        {
            SelectRow(4);
        }

        private void R5_CheckedChanged(object sender)
        {
            SelectRow(5);
        }

        private void R6_CheckedChanged(object sender)
        {
            SelectRow(6);
        }

        private void R7_CheckedChanged(object sender)
        {
            SelectRow(7);
        }
    }
}
