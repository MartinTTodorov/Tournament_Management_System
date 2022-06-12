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
            cbTypes.DataSource = TournamentType.TournamentTypes;
            cbSports.DataSource = SportType.SportTypes;
            UpdateUI();

        }

        private void btnAddTournament_Click(object sender, EventArgs e)
        {
            try
            {
                tournamentManager.AddTournament(new Tournament(tbInfo.Text, tbTitle.Text, dtStartDate.Value, dtEndDate.Value, Convert.ToInt32(tbMinPlayers.Text), Convert.ToInt32(tbMaxPlayers.Text), tbLocation.Text, (TournamentType)cbTypes.SelectedItem, (SportType)cbSports.SelectedItem));
                UpdateUI();
                MessageBox.Show("Tournament was created successfully");
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
                tournamentManager.CreateMatches((Tournament)lblTournamentsInfo.SelectedItem);
                MessageBox.Show("Successfully generated matches");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            if (lblTournaments.SelectedIndex==-1)
            {
                MessageBox.Show("Please select a tournament");
            }
            else
            {

                Tournament tournament = (Tournament)lblTournaments.SelectedItem;
                Match match = (Match)lblMatches.SelectedItem;
                try
                {
                    matchManager.SetMatchResults(tournament, match, Convert.ToInt32(tbPlayer1Score.Text), Convert.ToInt32(tbPlayer2Score.Text));
                    if (tournamentManager.CheckForFinish(tournament))
                    {
                        MessageBox.Show("The last result for this tournament was registered and the tournament is now finished!");
                    }
                    UpdateUI();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void lblTournaments_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void lblMatches_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void lblTournaments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tournament tournament = (Tournament)lblTournaments.SelectedItem;
            try
            {
                //only loads them if they are not already loaded
                if (tournament.Matches == null)
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

        public void UpdateUI()
        {

            lblTournaments.Items.Clear();
            lblTournamentsInfo.Items.Clear();

            foreach (Tournament tournament in tournamentManager.Tournaments)
            {
                lblTournaments.Items.Add(tournament);
                lblTournamentsInfo.Items.Add(tournament);
            }
        }

        private void lblTournamentsInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tournament tournament = (Tournament)lblTournamentsInfo.SelectedItem;

            tbTitle.Text = tournament.Title;
            tbLocation.Text = tournament.Location;
            tbMinPlayers.Text = tournament.MinPlayers.ToString();
            tbMaxPlayers.Text = tournament.MaxPlayers.ToString();
            tbInfo.Text = tournament.TournamentInfo;
            dtStartDate.Value = tournament.StartDate;
            dtEndDate.Value = tournament.EndDate;
            cbTypes.SelectedItem = tournament.TournamentType;
            cbSports.SelectedItem = tournament.Sport;
        }

        private void btnDeleteTournament_Click(object sender, EventArgs e)
        {

            if (lblTournamentsInfo.SelectedIndex==-1)
            {
                MessageBox.Show("Please select a tournament first");
            }
            else
            {
                try
                {
                    tournamentManager.DeleteTournament((Tournament)lblTournamentsInfo.SelectedItem);
                    UpdateUI();
                    MessageBox.Show("Deleted successfully");

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


        }

        private void lblMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Match match = (Match)lblMatches.SelectedItem;
            lblPlayer1.Text = match.Player1.Account.Username;
            lblPlayer2.Text = match.Player2.Account.Username;
            tbPlayer1Score.Text = match.Player1Score.ToString();
            tbPlayer2Score.Text = match.Player2Score.ToString();
        }

        private void btnCancelTournament_Click(object sender, EventArgs e)
        {

        }
    }
}
