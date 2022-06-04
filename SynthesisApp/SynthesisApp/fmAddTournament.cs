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
    public partial class fmAddTournament : Form
    {
        private TournamentManager tournamentManager;
        public fmAddTournament(TournamentManager tournamentManager)
        {
            InitializeComponent();
            this.tournamentManager = tournamentManager;
        }


        private void btnAddTournament_Click(object sender, EventArgs e)
        {
            //Tournament tournament = new Tournament();
            //tournamentManager.AddTournament(tournament);
        }
    }
}
