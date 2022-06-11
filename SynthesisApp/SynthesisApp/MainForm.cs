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
        MatchManager matchManager = new MatchManager(new MatchesDB());
        public MainForm()
        {
            InitializeComponent();
            lblTournaments.DataSource = tournamentManager.Tournaments;
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
            
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerateMatches_Click(object sender, EventArgs e)
        {
            try
            {
                tournamentManager.CreateMatches((Tournament)lblTournaments.SelectedItem);
                MessageBox.Show("Successfully generated matches");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            Tournament tournament = (Tournament)lblTournaments.SelectedItem;
            Match match = (Match)lblMatches.SelectedItem;
            try
            {
                matchManager.SetMatchResults(tournament, match, Convert.ToInt32(tbPlayer1Score.Text), Convert.ToInt32(tbPlayer2Score.Text));

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblTournaments_DoubleClick(object sender, EventArgs e)
        {
            Tournament tournament = (Tournament)lblTournaments.SelectedItem;
            try
            {
                //only load them if they are not already loaded
                if (tournament.Matches==null) // should this validation be in the manager
                {
                    tournamentManager.RetrieveMatches(tournament);
                }
                lblMatches.DataSource = tournament.Matches;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblMatches_DoubleClick(object sender, EventArgs e)
        {
            Match match = (Match)lblMatches.SelectedItem;
            lblPlayer1.Text = match.Player1.Account.Username;
            lblPlayer2.Text = match.Player2.Account.Username;
            tbPlayer1Score.Text = match.Player1Score.ToString();
            tbPlayer2Score.Text = match.Player2Score.ToString();
        }

        private void lblTournaments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
