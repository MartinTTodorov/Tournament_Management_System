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
        TournamentManager tournamentManager = new TournamentManager(new TournamentsDB(), new TournamentsDB());
        public MainForm()
        {
            InitializeComponent();
            cbTournaments.DataSource = tournamentManager.Tournaments;
            cbTypes.DataSource = TournamentType.TournamentTypes;
            

        }

        private void btnAddTournament_Click(object sender, EventArgs e)
        {
            try
            {
                tournamentManager.AddTournament(new Tournament(tbInfo.Text, tbTitle.Text, dtStartDate.Value, dtEndDate.Value, Convert.ToInt32(tbMinPlayers.Text), Convert.ToInt32(tbMaxPlayers.Text), tbLocation.Text, (TournamentType)cbTypes.SelectedItem));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Wrong data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbTournaments_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMatches.DataSource = null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerateMatches_Click(object sender, EventArgs e)
        {
            try
            {
                tournamentManager.CreateMatches((Tournament)cbTournaments.SelectedItem);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Successfully generated matches");
            }

        }
    }
}
