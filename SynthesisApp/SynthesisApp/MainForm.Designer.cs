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
            this.SuspendLayout();
            // 
            // cbTournaments
            // 
            this.cbTournaments.FormattingEnabled = true;
            this.cbTournaments.Location = new System.Drawing.Point(117, 78);
            this.cbTournaments.Name = "cbTournaments";
            this.cbTournaments.Size = new System.Drawing.Size(151, 28);
            this.cbTournaments.TabIndex = 0;
            this.cbTournaments.SelectedIndexChanged += new System.EventHandler(this.cbTournaments_SelectedIndexChanged);
            // 
            // cbMatches
            // 
            this.cbMatches.FormattingEnabled = true;
            this.cbMatches.Location = new System.Drawing.Point(117, 138);
            this.cbMatches.Name = "cbMatches";
            this.cbMatches.Size = new System.Drawing.Size(151, 28);
            this.cbMatches.TabIndex = 1;
            // 
            // lblTournament
            // 
            this.lblTournament.AutoSize = true;
            this.lblTournament.Location = new System.Drawing.Point(14, 81);
            this.lblTournament.Name = "lblTournament";
            this.lblTournament.Size = new System.Drawing.Size(97, 20);
            this.lblTournament.TabIndex = 2;
            this.lblTournament.Text = "Tournaments:";
            // 
            // lblMatch
            // 
            this.lblMatch.AutoSize = true;
            this.lblMatch.Location = new System.Drawing.Point(44, 146);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(67, 20);
            this.lblMatch.TabIndex = 3;
            this.lblMatch.Text = "Matches:";
            // 
            // btnAddTournament
            // 
            this.btnAddTournament.Location = new System.Drawing.Point(22, 236);
            this.btnAddTournament.Name = "btnAddTournament";
            this.btnAddTournament.Size = new System.Drawing.Size(107, 52);
            this.btnAddTournament.TabIndex = 4;
            this.btnAddTournament.Text = "Add tournament";
            this.btnAddTournament.UseVisualStyleBackColor = true;
            this.btnAddTournament.Click += new System.EventHandler(this.btnAddTournament_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddTournament);
            this.Controls.Add(this.lblMatch);
            this.Controls.Add(this.lblTournament);
            this.Controls.Add(this.cbMatches);
            this.Controls.Add(this.cbTournaments);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbTournaments;
        private ComboBox cbMatches;
        private Label lblTournament;
        private Label lblMatch;
        private Button btnAddTournament;
    }
}