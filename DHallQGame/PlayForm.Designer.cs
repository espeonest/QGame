namespace DHallQGame
{
    partial class PlayForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInstructions2 = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.lblBoxes = new System.Windows.Forms.Label();
            this.lblMoves = new System.Windows.Forms.Label();
            this.txtBoxes = new System.Windows.Forms.TextBox();
            this.txtMoves = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblSelected = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1891, 60);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.mainMenuToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(87, 50);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            this.mainMenuToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.mainMenuToolStripMenuItem.Text = "Exit";
            this.mainMenuToolStripMenuItem.Click += new System.EventHandler(this.mainMenuToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblSelected);
            this.panel1.Controls.Add(this.lblInstructions2);
            this.panel1.Controls.Add(this.lblInstructions);
            this.panel1.Controls.Add(this.btnRight);
            this.panel1.Controls.Add(this.btnLeft);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.lblBoxes);
            this.panel1.Controls.Add(this.lblMoves);
            this.panel1.Controls.Add(this.txtBoxes);
            this.panel1.Controls.Add(this.txtMoves);
            this.panel1.Location = new System.Drawing.Point(2, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 1379);
            this.panel1.TabIndex = 1;
            // 
            // lblInstructions2
            // 
            this.lblInstructions2.AutoSize = true;
            this.lblInstructions2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblInstructions2.Location = new System.Drawing.Point(16, 1284);
            this.lblInstructions2.Name = "lblInstructions2";
            this.lblInstructions2.Size = new System.Drawing.Size(385, 39);
            this.lblInstructions2.TabIndex = 9;
            this.lblInstructions2.Text = "buttons above to move it";
            this.lblInstructions2.Visible = false;
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblInstructions.Location = new System.Drawing.Point(16, 1245);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(465, 39);
            this.lblInstructions.TabIndex = 8;
            this.lblInstructions.Text = "Select a box and then use the";
            this.lblInstructions.Visible = false;
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.Gold;
            this.btnRight.Enabled = false;
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.ForeColor = System.Drawing.Color.White;
            this.btnRight.Location = new System.Drawing.Point(424, 964);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(190, 190);
            this.btnRight.TabIndex = 7;
            this.btnRight.Text = "RIGHT";
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.Color.Gold;
            this.btnLeft.Enabled = false;
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.ForeColor = System.Drawing.Color.White;
            this.btnLeft.Location = new System.Drawing.Point(11, 964);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(190, 190);
            this.btnLeft.TabIndex = 6;
            this.btnLeft.Text = "LEFT";
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.Gold;
            this.btnDown.Enabled = false;
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.ForeColor = System.Drawing.Color.White;
            this.btnDown.Location = new System.Drawing.Point(218, 964);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(190, 190);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "DOWN";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.Gold;
            this.btnUp.Enabled = false;
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.ForeColor = System.Drawing.Color.White;
            this.btnUp.Location = new System.Drawing.Point(218, 759);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(190, 190);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "UP";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lblBoxes
            // 
            this.lblBoxes.AutoSize = true;
            this.lblBoxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoxes.Location = new System.Drawing.Point(14, 155);
            this.lblBoxes.Name = "lblBoxes";
            this.lblBoxes.Size = new System.Drawing.Size(221, 46);
            this.lblBoxes.TabIndex = 3;
            this.lblBoxes.Text = "Boxes Left:";
            // 
            // lblMoves
            // 
            this.lblMoves.AutoSize = true;
            this.lblMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoves.Location = new System.Drawing.Point(14, 49);
            this.lblMoves.Name = "lblMoves";
            this.lblMoves.Size = new System.Drawing.Size(159, 46);
            this.lblMoves.TabIndex = 2;
            this.lblMoves.Text = "Moves: ";
            // 
            // txtBoxes
            // 
            this.txtBoxes.Location = new System.Drawing.Point(22, 212);
            this.txtBoxes.Name = "txtBoxes";
            this.txtBoxes.ReadOnly = true;
            this.txtBoxes.Size = new System.Drawing.Size(225, 38);
            this.txtBoxes.TabIndex = 1;
            this.txtBoxes.Text = "0";
            // 
            // txtMoves
            // 
            this.txtMoves.Location = new System.Drawing.Point(22, 106);
            this.txtMoves.Name = "txtMoves";
            this.txtMoves.ReadOnly = true;
            this.txtMoves.Size = new System.Drawing.Size(225, 38);
            this.txtMoves.TabIndex = 0;
            this.txtMoves.Text = "0";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "*";
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.Location = new System.Drawing.Point(35, 643);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(0, 39);
            this.lblSelected.TabIndex = 10;
            // 
            // PlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1891, 1453);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PlayForm";
            this.Text = "PlayForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInstructions2;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Label lblBoxes;
        private System.Windows.Forms.Label lblMoves;
        private System.Windows.Forms.TextBox txtBoxes;
        private System.Windows.Forms.TextBox txtMoves;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lblSelected;
    }
}