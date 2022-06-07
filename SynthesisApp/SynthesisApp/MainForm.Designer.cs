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
            this.cbTournaments = new System.Windows.Forms.ComboBox();
            this.cbMatches = new System.Windows.Forms.ComboBox();
            this.lblTournament = new System.Windows.Forms.Label();
            this.lblMatch = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // cbTournaments
            // 
            this.cbTournaments.FormattingEnabled = true;
            this.cbTournaments.Location = new System.Drawing.Point(116, 12);
            this.cbTournaments.Name = "cbTournaments";
            this.cbTournaments.Size = new System.Drawing.Size(151, 28);
            this.cbTournaments.TabIndex = 0;
            this.cbTournaments.SelectedIndexChanged += new System.EventHandler(this.cbTournaments_SelectedIndexChanged);
            // 
            // cbMatches
            // 
            this.cbMatches.FormattingEnabled = true;
            this.cbMatches.Location = new System.Drawing.Point(362, 12);
            this.cbMatches.Name = "cbMatches";
            this.cbMatches.Size = new System.Drawing.Size(151, 28);
            this.cbMatches.TabIndex = 1;
            // 
            // lblTournament
            // 
            this.lblTournament.AutoSize = true;
            this.lblTournament.Location = new System.Drawing.Point(13, 15);
            this.lblTournament.Name = "lblTournament";
            this.lblTournament.Size = new System.Drawing.Size(97, 20);
            this.lblTournament.TabIndex = 2;
            this.lblTournament.Text = "Tournaments:";
            // 
            // lblMatch
            // 
            this.lblMatch.AutoSize = true;
            this.lblMatch.Location = new System.Drawing.Point(289, 20);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(67, 20);
            this.lblMatch.TabIndex = 3;
            this.lblMatch.Text = "Matches:";
            // 
            // btnAddTournament
            // 
            this.btnAddTournament.Location = new System.Drawing.Point(13, 386);
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
            this.lblTournaments.Location = new System.Drawing.Point(569, 12);
            this.lblTournaments.Name = "lblTournaments";
            this.lblTournaments.Size = new System.Drawing.Size(219, 204);
            this.lblTournaments.TabIndex = 5;
            // 
            // tbInfo
            // 
            this.tbInfo.Location = new System.Drawing.Point(116, 109);
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(125, 27);
            this.tbInfo.TabIndex = 6;
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(116, 162);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(125, 27);
            this.tbLocation.TabIndex = 7;
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(116, 232);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(250, 27);
            this.dtStartDate.TabIndex = 8;
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(116, 292);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(250, 27);
            this.dtEndDate.TabIndex = 9;
            // 
            // tbMinPlayers
            // 
            this.tbMinPlayers.Location = new System.Drawing.Point(388, 110);
            this.tbMinPlayers.Name = "tbMinPlayers";
            this.tbMinPlayers.Size = new System.Drawing.Size(125, 27);
            this.tbMinPlayers.TabIndex = 10;
            // 
            // tbMaxPlayers
            // 
            this.tbMaxPlayers.Location = new System.Drawing.Point(388, 168);
            this.tbMaxPlayers.Name = "tbMaxPlayers";
            this.tbMaxPlayers.Size = new System.Drawing.Size(125, 27);
            this.tbMaxPlayers.TabIndex = 11;
            // 
            // cbTypes
            // 
            this.cbTypes.FormattingEnabled = true;
            this.cbTypes.Location = new System.Drawing.Point(116, 345);
            this.cbTypes.Name = "cbTypes";
            this.cbTypes.Size = new System.Drawing.Size(250, 28);
            this.cbTypes.TabIndex = 12;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(67, 112);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(38, 20);
            this.lblInfo.TabIndex = 13;
            this.lblInfo.Text = "Info:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(36, 169);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(69, 20);
            this.lblLocation.TabIndex = 14;
            this.lblLocation.Text = "Location:";
            // 
            // lblMinPlayers
            // 
            this.lblMinPlayers.AutoSize = true;
            this.lblMinPlayers.Location = new System.Drawing.Point(294, 110);
            this.lblMinPlayers.Name = "lblMinPlayers";
            this.lblMinPlayers.Size = new System.Drawing.Size(88, 20);
            this.lblMinPlayers.TabIndex = 15;
            this.lblMinPlayers.Text = "Min players:";
            // 
            // lblMaxPlayers
            // 
            this.lblMaxPlayers.AutoSize = true;
            this.lblMaxPlayers.Location = new System.Drawing.Point(291, 168);
            this.lblMaxPlayers.Name = "lblMaxPlayers";
            this.lblMaxPlayers.Size = new System.Drawing.Size(91, 20);
            this.lblMaxPlayers.TabIndex = 16;
            this.lblMaxPlayers.Text = "Max players:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(62, 345);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(43, 20);
            this.lblType.TabIndex = 17;
            this.lblType.Text = "Type:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(33, 232);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(77, 20);
            this.lblStartDate.TabIndex = 18;
            this.lblStartDate.Text = "Start date:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(34, 293);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(71, 20);
            this.lblEndDate.TabIndex = 19;
            this.lblEndDate.Text = "End date:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(62, 75);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(41, 20);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "Title:";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(116, 68);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(125, 27);
            this.tbTitle.TabIndex = 21;
            // 
            // btnGenerateMatches
            // 
            this.btnGenerateMatches.Location = new System.Drawing.Point(408, 386);
            this.btnGenerateMatches.Name = "btnGenerateMatches";
            this.btnGenerateMatches.Size = new System.Drawing.Size(105, 50);
            this.btnGenerateMatches.TabIndex = 22;
            this.btnGenerateMatches.Text = "Generate matches";
            this.btnGenerateMatches.UseVisualStyleBackColor = true;
            this.btnGenerateMatches.Click += new System.EventHandler(this.btnGenerateMatches_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenerateMatches);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblMaxPlayers);
            this.Controls.Add(this.lblMinPlayers);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.cbTypes);
            this.Controls.Add(this.tbMaxPlayers);
            this.Controls.Add(this.tbMinPlayers);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.lblTournaments);
            this.Controls.Add(this.btnAddTournament);
            this.Controls.Add(this.lblMatch);
            this.Controls.Add(this.lblTournament);
            this.Controls.Add(this.cbMatches);
            this.Controls.Add(this.cbTournaments);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbTournaments;
        private ComboBox cbMatches;
        private Label lblTournament;
        private Label lblMatch;
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
    }
}