using STAR_TEAM.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STAR_TEAM.PL
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }
        public static Main M = new Main();

        private void Loading_Load(object sender, EventArgs e)
        {
            M.Opacity = 0;
            M.Show();
        }

        private void Loading_Time_Tick(object sender, EventArgs e)
        {
            Tx.Stop();
            Loading_Time.Stop();
            this.Hide();
            M.Opacity = 100;
        }

        private void Tx_Tick(object sender, EventArgs e)
        {
            if (Load_Tx.Text == "Loading") { Load_Tx.Text = "Loading."; }
            else if (Load_Tx.Text == "Loading.") { Load_Tx.Text = "Loading.."; }
            else if (Load_Tx.Text == "Loading..") { Load_Tx.Text = "Loading..."; }
            else if (Load_Tx.Text == "Loading...") { Load_Tx.Text = "Loading"; }
            else { Load_Tx.Text = "Loading"; }
        }

    }
}
