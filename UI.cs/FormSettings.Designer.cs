namespace Ex05.UI
{
    partial class FormSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFirstPlayer = new System.Windows.Forms.TextBox();
            this.textBoxSecondPlayer = new System.Windows.Forms.TextBox();
            this.buttonAgainstPlayer = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Player Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Second Player Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Board Size:";
            // 
            // textBoxFirstPlayer
            // 
            this.textBoxFirstPlayer.Location = new System.Drawing.Point(154, 35);
            this.textBoxFirstPlayer.Name = "textBoxFirstPlayer";
            this.textBoxFirstPlayer.Size = new System.Drawing.Size(120, 20);
            this.textBoxFirstPlayer.TabIndex = 3;
            // 
            // textBoxSecondPlayer
            // 
            this.textBoxSecondPlayer.BackColor = System.Drawing.Color.DarkGray;
            this.textBoxSecondPlayer.Enabled = false;
            this.textBoxSecondPlayer.Location = new System.Drawing.Point(154, 77);
            this.textBoxSecondPlayer.Name = "textBoxSecondPlayer";
            this.textBoxSecondPlayer.Size = new System.Drawing.Size(120, 20);
            this.textBoxSecondPlayer.TabIndex = 4;
            this.textBoxSecondPlayer.Text = "-computer-";
            // 
            // buttonAgainstPlayer
            // 
            this.buttonAgainstPlayer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAgainstPlayer.Location = new System.Drawing.Point(301, 77);
            this.buttonAgainstPlayer.Name = "buttonAgainstPlayer";
            this.buttonAgainstPlayer.Size = new System.Drawing.Size(120, 20);
            this.buttonAgainstPlayer.TabIndex = 5;
            this.buttonAgainstPlayer.Text = "Against a Friend";
            this.buttonAgainstPlayer.UseVisualStyleBackColor = true;
            this.buttonAgainstPlayer.Click += new System.EventHandler(this.buttonAgainstPlayer_Click_1);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Lime;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(301, 164);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(106, 46);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = false;
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.BackColor = System.Drawing.Color.Violet;
            this.buttonBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBoardSize.Location = new System.Drawing.Point(62, 164);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(110, 63);
            this.buttonBoardSize.TabIndex = 7;
            this.buttonBoardSize.Text = "4x4";
            this.buttonBoardSize.UseVisualStyleBackColor = false;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSize_Click);
            // 
            // FormSettings
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 259);
            this.Controls.Add(this.buttonBoardSize);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonAgainstPlayer);
            this.Controls.Add(this.textBoxSecondPlayer);
            this.Controls.Add(this.textBoxFirstPlayer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFirstPlayer;
        private System.Windows.Forms.TextBox textBoxSecondPlayer;
        private System.Windows.Forms.Button buttonAgainstPlayer;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonBoardSize;
    }
}