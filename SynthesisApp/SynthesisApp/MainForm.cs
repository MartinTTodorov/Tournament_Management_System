using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SynthesisApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            cbTournaments.DataSource = null;

        }

        private void btnAddTournament_Click(object sender, EventArgs e)
        {

        }

        private void cbTournaments_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMatches.DataSource = null;
        }
    }
}
