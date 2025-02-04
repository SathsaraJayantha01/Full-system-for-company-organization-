namespace Grifindo_Lanka_Toys
{
    partial class AdminDashboard
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
            this.components = new System.ComponentModel.Container();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.registerEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approveRejectLeavesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defineLeaveQuotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defineRoasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLeaveReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTime.Location = new System.Drawing.Point(687, 598);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(167, 69);
            this.lblTime.TabIndex = 22;
            this.lblTime.Text = "Time";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDate.Location = new System.Drawing.Point(698, 692);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(76, 31);
            this.lblDate.TabIndex = 21;
            this.lblDate.Text = "Date";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerEmployeeToolStripMenuItem,
            this.approveRejectLeavesToolStripMenuItem,
            this.defineLeaveQuotasToolStripMenuItem,
            this.defineRoasterToolStripMenuItem,
            this.viewLeaveReportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1172, 28);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // registerEmployeeToolStripMenuItem
            // 
            this.registerEmployeeToolStripMenuItem.Name = "registerEmployeeToolStripMenuItem";
            this.registerEmployeeToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.registerEmployeeToolStripMenuItem.Text = "Register Employee";
            this.registerEmployeeToolStripMenuItem.Click += new System.EventHandler(this.registerEmployeeToolStripMenuItem_Click);
            // 
            // approveRejectLeavesToolStripMenuItem
            // 
            this.approveRejectLeavesToolStripMenuItem.Name = "approveRejectLeavesToolStripMenuItem";
            this.approveRejectLeavesToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.approveRejectLeavesToolStripMenuItem.Text = "Approve/Reject Leaves";
            this.approveRejectLeavesToolStripMenuItem.Click += new System.EventHandler(this.approveRejectLeavesToolStripMenuItem_Click);
            // 
            // defineLeaveQuotasToolStripMenuItem
            // 
            this.defineLeaveQuotasToolStripMenuItem.Name = "defineLeaveQuotasToolStripMenuItem";
            this.defineLeaveQuotasToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.defineLeaveQuotasToolStripMenuItem.Text = "Define Leave Quotas";
            this.defineLeaveQuotasToolStripMenuItem.Click += new System.EventHandler(this.defineLeaveQuotasToolStripMenuItem_Click);
            // 
            // defineRoasterToolStripMenuItem
            // 
            this.defineRoasterToolStripMenuItem.Name = "defineRoasterToolStripMenuItem";
            this.defineRoasterToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.defineRoasterToolStripMenuItem.Text = "Define Roaster";
            this.defineRoasterToolStripMenuItem.Click += new System.EventHandler(this.defineRoasterToolStripMenuItem_Click);
            // 
            // viewLeaveReportsToolStripMenuItem
            // 
            this.viewLeaveReportsToolStripMenuItem.Name = "viewLeaveReportsToolStripMenuItem";
            this.viewLeaveReportsToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this.viewLeaveReportsToolStripMenuItem.Text = "View Leave Reports";
            this.viewLeaveReportsToolStripMenuItem.Click += new System.EventHandler(this.viewLeaveReportsToolStripMenuItem_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::Grifindo_Lanka_Toys.Properties.Resources.leave;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.MediumVioletRed;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(24, 537);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(101, 100);
            this.button5.TabIndex = 24;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::Grifindo_Lanka_Toys.Properties.Resources._46373725;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.MediumVioletRed;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(24, 416);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(101, 98);
            this.button6.TabIndex = 23;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::Grifindo_Lanka_Toys.Properties.Resources.icons8_close_window_96;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.MediumVioletRed;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(24, 641);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 97);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::Grifindo_Lanka_Toys.Properties.Resources.quota;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.MediumVioletRed;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(24, 287);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 102);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Grifindo_Lanka_Toys.Properties.Resources.icons8_approval_96;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.MediumVioletRed;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(24, 166);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 101);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Grifindo_Lanka_Toys.Properties.Resources.icons8_add_user_male_80;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.MediumVioletRed;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(24, 52);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 97);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(1172, 781);
            this.ControlBox = false;
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AdminDashboard";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registerEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approveRejectLeavesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defineLeaveQuotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defineRoasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLeaveReportsToolStripMenuItem;
    }
}