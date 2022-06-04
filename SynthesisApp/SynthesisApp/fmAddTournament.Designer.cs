namespace SynthesisApp
{
    partial class fmAddTournament
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
            this.SuspendLayout();
            // 
            // btnAddTournament
            // 
            this.btnAddTournament.Location = new System.Drawing.Point(56, 317);
            this.btnAddTournament.Name = "btnAddTournament";
            this.btnAddTournament.Size = new System.Drawing.Size(94, 29);
            this.btnAddTournament.TabIndex = 0;
            this.btnAddTournament.Text = "Add";
            this.btnAddTournament.UseVisualStyleBackColor = true;
            this.btnAddTournament.Click += new System.EventHandler(this.btnAddTournament_Click);
            // 
            // fmAddTournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddTournament);
            this.Name = "fmAddTournament";
            this.Text = "fmAddTournament";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAddTournament;
    }
}