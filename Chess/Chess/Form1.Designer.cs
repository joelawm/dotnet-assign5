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
            this.SurrenderButton.Location = new System.Drawing.Point(1699, 32);
            this.SurrenderButton.Margin = new System.Windows.Forms.Padding(6);
            this.SurrenderButton.Name = "SurrenderButton";
            this.SurrenderButton.Size = new System.Drawing.Size(150, 44);
            this.SurrenderButton.TabIndex = 0;
            this.SurrenderButton.Text = "Surrender";
            this.SurrenderButton.UseVisualStyleBackColor = true;
            // 
            // GameBoard
            // 
            this.GameBoard.BackColor = System.Drawing.SystemColors.ControlLight;
            this.GameBoard.Location = new System.Drawing.Point(-4, 1);
            this.GameBoard.Margin = new System.Windows.Forms.Padding(6);
            this.GameBoard.Name = "GameBoard";
            this.GameBoard.Size = new System.Drawing.Size(1680, 1609);
            this.GameBoard.TabIndex = 1;
            this.GameBoard.TabStop = false;
            this.GameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_Paint);
            this.GameBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Board_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1915, 1609);
            this.Controls.Add(this.GameBoard);
            this.Controls.Add(this.SurrenderButton);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Chess";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.GameBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SurrenderButton;
        private System.Windows.Forms.PictureBox GameBoard;
    }
}

