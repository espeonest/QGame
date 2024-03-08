namespace DHallQGame
{
    partial class DesignForm
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
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSelection = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbGreenDoor = new System.Windows.Forms.PictureBox();
            this.pbRedDoor = new System.Windows.Forms.PictureBox();
            this.pbGreenBox = new System.Windows.Forms.PictureBox();
            this.pbRedBox = new System.Windows.Forms.PictureBox();
            this.pbWall = new System.Windows.Forms.PictureBox();
            this.pbEraser = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGreenDoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRedDoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGreenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEraser)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(3243, 49);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(87, 45);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(245, 54);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(1688, 89);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(219, 62);
            this.btnGenerate.TabIndex = 15;
            this.btnGenerate.Text = "Generate Grid";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtColumns
            // 
            this.txtColumns.Location = new System.Drawing.Point(1399, 98);
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.Size = new System.Drawing.Size(218, 38);
            this.txtColumns.TabIndex = 13;
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(999, 98);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(218, 38);
            this.txtRows.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1241, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Columns:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(883, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "Rows:";
            // 
            // lblSelection
            // 
            this.lblSelection.AutoSize = true;
            this.lblSelection.ForeColor = System.Drawing.Color.Red;
            this.lblSelection.Location = new System.Drawing.Point(25, 117);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(330, 32);
            this.lblSelection.TabIndex = 18;
            this.lblSelection.Text = "no tool currently selected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 46);
            this.label1.TabIndex = 8;
            this.label1.Text = "Toolbox";
            // 
            // pbGreenDoor
            // 
            this.pbGreenDoor.Image = global::DHallQGame.Properties.Resources.GreenDoor;
            this.pbGreenDoor.Location = new System.Drawing.Point(31, 1411);
            this.pbGreenDoor.MaximumSize = new System.Drawing.Size(200, 200);
            this.pbGreenDoor.MinimumSize = new System.Drawing.Size(200, 200);
            this.pbGreenDoor.Name = "pbGreenDoor";
            this.pbGreenDoor.Size = new System.Drawing.Size(200, 200);
            this.pbGreenDoor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGreenDoor.TabIndex = 19;
            this.pbGreenDoor.TabStop = false;
            this.pbGreenDoor.Click += new System.EventHandler(this.toolBoxItem_Click);
            // 
            // pbRedDoor
            // 
            this.pbRedDoor.Image = global::DHallQGame.Properties.Resources.RedDoor;
            this.pbRedDoor.Location = new System.Drawing.Point(31, 1166);
            this.pbRedDoor.MaximumSize = new System.Drawing.Size(200, 200);
            this.pbRedDoor.MinimumSize = new System.Drawing.Size(200, 200);
            this.pbRedDoor.Name = "pbRedDoor";
            this.pbRedDoor.Size = new System.Drawing.Size(200, 200);
            this.pbRedDoor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRedDoor.TabIndex = 17;
            this.pbRedDoor.TabStop = false;
            this.pbRedDoor.Click += new System.EventHandler(this.toolBoxItem_Click);
            // 
            // pbGreenBox
            // 
            this.pbGreenBox.Image = global::DHallQGame.Properties.Resources.GreenBox;
            this.pbGreenBox.Location = new System.Drawing.Point(31, 921);
            this.pbGreenBox.MaximumSize = new System.Drawing.Size(200, 200);
            this.pbGreenBox.MinimumSize = new System.Drawing.Size(200, 200);
            this.pbGreenBox.Name = "pbGreenBox";
            this.pbGreenBox.Size = new System.Drawing.Size(200, 200);
            this.pbGreenBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGreenBox.TabIndex = 16;
            this.pbGreenBox.TabStop = false;
            this.pbGreenBox.Click += new System.EventHandler(this.toolBoxItem_Click);
            // 
            // pbRedBox
            // 
            this.pbRedBox.Image = global::DHallQGame.Properties.Resources.RedBox;
            this.pbRedBox.Location = new System.Drawing.Point(31, 676);
            this.pbRedBox.MaximumSize = new System.Drawing.Size(200, 200);
            this.pbRedBox.MinimumSize = new System.Drawing.Size(200, 200);
            this.pbRedBox.Name = "pbRedBox";
            this.pbRedBox.Size = new System.Drawing.Size(200, 200);
            this.pbRedBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRedBox.TabIndex = 14;
            this.pbRedBox.TabStop = false;
            this.pbRedBox.Click += new System.EventHandler(this.toolBoxItem_Click);
            // 
            // pbWall
            // 
            this.pbWall.Image = global::DHallQGame.Properties.Resources.Wall;
            this.pbWall.Location = new System.Drawing.Point(31, 431);
            this.pbWall.MaximumSize = new System.Drawing.Size(200, 200);
            this.pbWall.MinimumSize = new System.Drawing.Size(200, 200);
            this.pbWall.Name = "pbWall";
            this.pbWall.Size = new System.Drawing.Size(200, 200);
            this.pbWall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWall.TabIndex = 12;
            this.pbWall.TabStop = false;
            this.pbWall.Click += new System.EventHandler(this.toolBoxItem_Click);
            // 
            // pbEraser
            // 
            this.pbEraser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbEraser.Image = global::DHallQGame.Properties.Resources.Eraser;
            this.pbEraser.Location = new System.Drawing.Point(31, 186);
            this.pbEraser.MaximumSize = new System.Drawing.Size(200, 200);
            this.pbEraser.MinimumSize = new System.Drawing.Size(200, 200);
            this.pbEraser.Name = "pbEraser";
            this.pbEraser.Size = new System.Drawing.Size(200, 200);
            this.pbEraser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEraser.TabIndex = 10;
            this.pbEraser.TabStop = false;
            this.pbEraser.Click += new System.EventHandler(this.toolBoxItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pbGreenDoor);
            this.panel1.Controls.Add(this.lblSelection);
            this.panel1.Controls.Add(this.pbRedDoor);
            this.panel1.Controls.Add(this.pbGreenBox);
            this.panel1.Controls.Add(this.pbRedBox);
            this.panel1.Controls.Add(this.pbWall);
            this.panel1.Controls.Add(this.pbEraser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 1640);
            this.panel1.TabIndex = 20;
            // 
            // DesignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3243, 1931);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtColumns);
            this.Controls.Add(this.txtRows);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(2000, 1500);
            this.Name = "DesignForm";
            this.Text = "Level Designer";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGreenDoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRedDoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGreenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEraser)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSelection;
        private System.Windows.Forms.PictureBox pbRedDoor;
        private System.Windows.Forms.PictureBox pbGreenBox;
        private System.Windows.Forms.PictureBox pbRedBox;
        private System.Windows.Forms.PictureBox pbWall;
        private System.Windows.Forms.PictureBox pbEraser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbGreenDoor;
        private System.Windows.Forms.Panel panel1;
    }
}