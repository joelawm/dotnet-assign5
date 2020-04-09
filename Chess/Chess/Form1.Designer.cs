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
            ((System.ComponentModel.ISupportInitialize)(this.GameBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // SurrenderButton
            // 
            this.SurrenderButton.Location = new System.Drawing.Point(1062, 12);
            this.SurrenderButton.Name = "SurrenderButton";
            this.SurrenderButton.Size = new System.Drawing.Size(75, 23);
            this.SurrenderButton.TabIndex = 0;
            this.SurrenderButton.Text = "Surrender";
            this.SurrenderButton.UseVisualStyleBackColor = true;
            // 
            // GameBoard
            // 
            this.GameBoard.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GameBoard.Location = new System.Drawing.Point(12, 12);
            this.GameBoard.Name = "GameBoard";
            this.GameBoard.Size = new System.Drawing.Size(1024, 1024);
            this.GameBoard.TabIndex = 1;
            this.GameBoard.TabStop = false;
            this.GameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_Paint);
            this.GameBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Board_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 1052);
            this.Controls.Add(this.GameBoard);
            this.Controls.Add(this.SurrenderButton);
            this.Name = "Form1";
            this.Text = "Chess";
            ((System.ComponentModel.ISupportInitialize)(this.GameBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SurrenderButton;
        private System.Windows.Forms.PictureBox GameBoard;
    }
}

