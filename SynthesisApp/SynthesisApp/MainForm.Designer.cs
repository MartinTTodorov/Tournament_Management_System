namespace SynthesisApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddTournament = new System.Windows.Forms.Button();
            this.lblTournaments = new System.Windows.Forms.ListBox();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.tbMinPlayers = new System.Windows.Forms.TextBox();
            this.tbMaxPlayers = new System.Windows.Forms.TextBox();
            this.cbTypes = new System.Windows.Forms.ComboBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblMinPlayers = new System.Windows.Forms.Label();
            this.lblMaxPlayers = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.btnGenerateMatches = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblMatches = new System.Windows.Forms.ListBox();
            this.btnSaveResults = new System.Windows.Forms.Button();
            this.tbPlayer2Score = new System.Windows.Forms.TextBox();
            this.tbPlayer1Score = new System.Windows.Forms.TextBox();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblInformation = new System.Windows.Forms.Label();
            this.lblMatch = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddTournament
            // 
            this.btnAddTournament.Location = new System.Drawing.Point(17, 350);
            this.btnAddTournament.Name = "btnAddTournament";
            this.btnAddTournament.Size = new System.Drawing.Size(107, 52);
            this.btnAddTournament.TabIndex = 4;
            this.btnAddTournament.Text = "Add tournament";
            this.btnAddTournament.UseVisualStyleBackColor = true;
            this.btnAddTournament.Click += new System.EventHandler(this.btnAddTournament_Click);
            // 
            // lblTournaments
            // 
            this.lblTournaments.FormattingEnabled = true;
            this.lblTournaments.ItemHeight = 20;
            this.lblTournaments.Location = new System.Drawing.Point(6, 29);
            this.lblTournaments.Name = "lblTournaments";
            this.lblTournaments.Size = new System.Drawing.Size(295, 204);
            this.lblTournaments.TabIndex = 5;
            this.lblTournaments.SelectedIndexChanged += new System.EventHandler(this.lblTournaments_SelectedIndexChanged);
            this.lblTournaments.DoubleClick += new System.EventHandler(this.lblTournaments_DoubleClick);
            // 
            // tbInfo
            // 
            this.tbInfo.Location = new System.Drawing.Point(100, 61);
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(125, 27);
            this.tbInfo.TabIndex = 6;
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(100, 114);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(125, 27);
            this.tbLocation.TabIndex = 7;
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(100, 184);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(250, 27);
            this.dtStartDate.TabIndex = 8;
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(100, 244);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(250, 27);
            this.dtEndDate.TabIndex = 9;
            // 
            // tbMinPlayers
            // 
            this.tbMinPlayers.Location = new System.Drawing.Point(360, 20);
            this.tbMinPlayers.Name = "tbMinPlayers";
            this.tbMinPlayers.Size = new System.Drawing.Size(125, 27);
            this.tbMinPlayers.TabIndex = 10;
            // 
            // tbMaxPlayers
            // 
            this.tbMaxPlayers.Location = new System.Drawing.Point(360, 78);
            this.tbMaxPlayers.Name = "tbMaxPlayers";
            this.tbMaxPlayers.Size = new System.Drawing.Size(125, 27);
            this.tbMaxPlayers.TabIndex = 11;
            // 
            // cbTypes
            // 
            this.cbTypes.FormattingEnabled = true;
            this.cbTypes.Location = new System.Drawing.Point(100, 297);
            this.cbTypes.Name = "cbTypes";
            this.cbTypes.Size = new System.Drawing.Size(250, 28);
            this.cbTypes.TabIndex = 12;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(51, 64);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(38, 20);
            this.lblInfo.TabIndex = 13;
            this.lblInfo.Text = "Info:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(20, 121);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(69, 20);
            this.lblLocation.TabIndex = 14;
            this.lblLocation.Text = "Location:";
            // 
            // lblMinPlayers
            // 
            this.lblMinPlayers.AutoSize = true;
            this.lblMinPlayers.Location = new System.Drawing.Point(266, 20);
            this.lblMinPlayers.Name = "lblMinPlayers";
            this.lblMinPlayers.Size = new System.Drawing.Size(88, 20);
            this.lblMinPlayers.TabIndex = 15;
            this.lblMinPlayers.Text = "Min players:";
            // 
            // lblMaxPlayers
            // 
            this.lblMaxPlayers.AutoSize = true;
            this.lblMaxPlayers.Location = new System.Drawing.Point(263, 78);
            this.lblMaxPlayers.Name = "lblMaxPlayers";
            this.lblMaxPlayers.Size = new System.Drawing.Size(91, 20);
            this.lblMaxPlayers.TabIndex = 16;
            this.lblMaxPlayers.Text = "Max players:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(46, 297);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(43, 20);
            this.lblType.TabIndex = 17;
            this.lblType.Text = "Type:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(17, 184);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(77, 20);
            this.lblStartDate.TabIndex = 18;
            this.lblStartDate.Text = "Start date:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(18, 245);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(71, 20);
            this.lblEndDate.TabIndex = 19;
            this.lblEndDate.Text = "End date:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(46, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(41, 20);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "Title:";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(100, 20);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(125, 27);
            this.tbTitle.TabIndex = 21;
            // 
            // btnGenerateMatches
            // 
            this.btnGenerateMatches.Location = new System.Drawing.Point(147, 352);
            this.btnGenerateMatches.Name = "btnGenerateMatches";
            this.btnGenerateMatches.Size = new System.Drawing.Size(105, 50);
            this.btnGenerateMatches.TabIndex = 22;
            this.btnGenerateMatches.Text = "Generate matches";
            this.btnGenerateMatches.UseVisualStyleBackColor = true;
            this.btnGenerateMatches.Click += new System.EventHandler(this.btnGenerateMatches_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(797, 452);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblMatches);
            this.tabPage1.Controls.Add(this.btnSaveResults);
            this.tabPage1.Controls.Add(this.tbPlayer2Score);
            this.tabPage1.Controls.Add(this.tbPlayer1Score);
            this.tabPage1.Controls.Add(this.lblPlayer2);
            this.tabPage1.Controls.Add(this.lblPlayer1);
            this.tabPage1.Controls.Add(this.lblInformation);
            this.tabPage1.Controls.Add(this.lblMatch);
            this.tabPage1.Controls.Add(this.lblTournaments);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(789, 419);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblMatches
            // 
            this.lblMatches.FormattingEnabled = true;
            this.lblMatches.ItemHeight = 20;
            this.lblMatches.Location = new System.Drawing.Point(349, 70);
            this.lblMatches.Name = "lblMatches";
            this.lblMatches.Size = new System.Drawing.Size(199, 164);
            this.lblMatches.TabIndex = 29;
            this.lblMatches.DoubleClick += new System.EventHandler(this.lblMatches_DoubleClick);
            // 
            // btnSaveResults
            // 
            this.btnSaveResults.Location = new System.Drawing.Point(607, 382);
            this.btnSaveResults.Name = "btnSaveResults";
            this.btnSaveResults.Size = new System.Drawing.Size(94, 29);
            this.btnSaveResults.TabIndex = 28;
            this.btnSaveResults.Text = "Save results";
            this.btnSaveResults.UseVisualStyleBackColor = true;
            this.btnSaveResults.Click += new System.EventHandler(this.btnSaveResults_Click);
            // 
            // tbPlayer2Score
            // 
            this.tbPlayer2Score.Location = new System.Drawing.Point(607, 305);
            this.tbPlayer2Score.Name = "tbPlayer2Score";
            this.tbPlayer2Score.Size = new System.Drawing.Size(125, 27);
            this.tbPlayer2Score.TabIndex = 27;
            // 
            // tbPlayer1Score
            // 
            this.tbPlayer1Score.Location = new System.Drawing.Point(607, 210);
            this.tbPlayer1Score.Name = "tbPlayer1Score";
            this.tbPlayer1Score.Size = new System.Drawing.Size(125, 27);
            this.tbPlayer1Score.TabIndex = 26;
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.Location = new System.Drawing.Point(592, 261);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(64, 20);
            this.lblPlayer2.TabIndex = 25;
            this.lblPlayer2.Text = "Player 2:";
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.Location = new System.Drawing.Point(592, 168);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(64, 20);
            this.lblPlayer1.TabIndex = 24;
            this.lblPlayer1.Text = "Player 1:";
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(6, 261);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(295, 20);
            this.lblInformation.TabIndex = 23;
            this.lblInformation.Text = "Click once to select. Click twice to view info";
            // 
            // lblMatch
            // 
            this.lblMatch.AutoSize = true;
            this.lblMatch.Location = new System.Drawing.Point(329, 17);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(67, 20);
            this.lblMatch.TabIndex = 3;
            this.lblMatch.Text = "Matches:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtStartDate);
            this.tabPage2.Controls.Add(this.btnGenerateMatches);
            this.tabPage2.Controls.Add(this.btnAddTournament);
            this.tabPage2.Controls.Add(this.tbLocation);
            this.tabPage2.Controls.Add(this.lblTitle);
            this.tabPage2.Controls.Add(this.lblEndDate);
            this.tabPage2.Controls.Add(this.lblLocation);
            this.tabPage2.Controls.Add(this.tbMinPlayers);
            this.tabPage2.Controls.Add(this.lblMaxPlayers);
            this.tabPage2.Controls.Add(this.dtEndDate);
            this.tabPage2.Controls.Add(this.lblInfo);
            this.tabPage2.Controls.Add(this.tbMaxPlayers);
            this.tabPage2.Controls.Add(this.tbTitle);
            this.tabPage2.Controls.Add(this.lblStartDate);
            this.tabPage2.Controls.Add(this.lblType);
            this.tabPage2.Controls.Add(this.tbInfo);
            this.tabPage2.Controls.Add(this.lblMinPlayers);
            this.tabPage2.Controls.Add(this.cbTypes);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(789, 419);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnAddTournament;
        private ListBox lblTournaments;
        private TextBox tbInfo;
        private TextBox tbLocation;
        private DateTimePicker dtStartDate;
        private DateTimePicker dtEndDate;
        private TextBox tbMinPlayers;
        private TextBox tbMaxPlayers;
        private ComboBox cbTypes;
        private Label lblInfo;
        private Label lblLocation;
        private Label lblMinPlayers;
        private Label lblMaxPlayers;
        private Label lblType;
        private Label lblStartDate;
        private Label lblEndDate;
        private Label lblTitle;
        private TextBox tbTitle;
        private Button btnGenerateMatches;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnSaveResults;
        private TextBox tbPlayer2Score;
        private TextBox tbPlayer1Score;
        private Label lblPlayer2;
        private Label lblPlayer1;
        private Label lblInformation;
        private ListBox lblMatches;
        private Label lblMatch;
    }
}