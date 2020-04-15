namespace Chess
{
    partial class Form1
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
            this.SurrenderButton = new System.Windows.Forms.Button();
            this.GameBoard = new System.Windows.Forms.PictureBox();
            this.PlayerTurnLabel = new System.Windows.Forms.Label();
            this.ErrorMessageBox = new System.Windows.Forms.TextBox();
            this.WinnerLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GameBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // SurrenderButton
            // 
            this.SurrenderButton.Location = new System.Drawing.Point(850, 17);
            this.SurrenderButton.Name = "SurrenderButton";
            this.SurrenderButton.Size = new System.Drawing.Size(75, 23);
            this.SurrenderButton.TabIndex = 0;
            this.SurrenderButton.Text = "Surrender";
            this.SurrenderButton.UseVisualStyleBackColor = true;
            this.SurrenderButton.Click += new System.EventHandler(this.SurrenderButton_Click);
            // 
            // GameBoard
            // 
            this.GameBoard.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GameBoard.Location = new System.Drawing.Point(-2, 1);
            this.GameBoard.Name = "GameBoard";
            this.GameBoard.Size = new System.Drawing.Size(840, 837);
            this.GameBoard.TabIndex = 1;
            this.GameBoard.TabStop = false;
            this.GameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_Paint);
            this.GameBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Board_Click);
            // 
            // PlayerTurnLabel
            // 
            this.PlayerTurnLabel.AutoSize = true;
            this.PlayerTurnLabel.Location = new System.Drawing.Point(850, 47);
            this.PlayerTurnLabel.Name = "PlayerTurnLabel";
            this.PlayerTurnLabel.Size = new System.Drawing.Size(78, 13);
            this.PlayerTurnLabel.TabIndex = 2;
            this.PlayerTurnLabel.Text = "Player #\'s Turn";
            // 
            // ErrorMessageBox
            // 
            this.ErrorMessageBox.Location = new System.Drawing.Point(845, 626);
            this.ErrorMessageBox.Multiline = true;
            this.ErrorMessageBox.Name = "ErrorMessageBox";
            this.ErrorMessageBox.Size = new System.Drawing.Size(227, 199);
            this.ErrorMessageBox.TabIndex = 3;
            // 
            // WinnerLabel
            // 
            this.WinnerLabel.AutoSize = true;
            this.WinnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.WinnerLabel.Location = new System.Drawing.Point(842, 253);
            this.WinnerLabel.Name = "WinnerLabel";
            this.WinnerLabel.Size = new System.Drawing.Size(155, 29);
            this.WinnerLabel.TabIndex = 4;
            this.WinnerLabel.Text = "Player # Won";
            this.WinnerLabel.Visible = false;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(853, 285);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 5;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Visible = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 837);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.WinnerLabel);
            this.Controls.Add(this.ErrorMessageBox);
            this.Controls.Add(this.PlayerTurnLabel);
            this.Controls.Add(this.GameBoard);
            this.Controls.Add(this.SurrenderButton);
            this.Name = "Form1";
            this.Text = "Chess";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.GameBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SurrenderButton;
        private System.Windows.Forms.PictureBox GameBoard;
        private System.Windows.Forms.Label PlayerTurnLabel;
        private System.Windows.Forms.TextBox ErrorMessageBox;
        private System.Windows.Forms.Label WinnerLabel;
        private System.Windows.Forms.Button ResetButton;
    }
}

