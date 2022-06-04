using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer;
using DataAccessLayer;
using Entities;

namespace SynthesisApp
{
    public partial class MainForm : Form
    {
        TournamentManager tournamentManager = new TournamentManager(new TournamentsDB());
        public MainForm()
        {
            InitializeComponent();
            cbTournaments.DataSource = tournamentManager.Tournaments;
            cbTypes.DataSource = TournamentType.TournamentTypes;
            

        }

        private void btnAddTournament_Click(object sender, EventArgs e)
        {
            fmAddTournament form = new fmAddTournament(tournamentManager);
            form.Show();
        }

        private void cbTournaments_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMatches.DataSource = null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
