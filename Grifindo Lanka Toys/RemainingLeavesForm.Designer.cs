namespace Grifindo_Lanka_Toys
{
    partial class RemainingLeavesForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEMP = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblShort = new System.Windows.Forms.Label();
            this.lblCasual = new System.Windows.Forms.Label();
            this.lblAnnual = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(308, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(316, 39);
            this.label5.TabIndex = 10;
            this.label5.Text = "Remaining Leaves";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(23, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Employee Number";
            // 
            // txtEMP
            // 
            this.txtEMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEMP.Location = new System.Drawing.Point(245, 114);
            this.txtEMP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEMP.Name = "txtEMP";
            this.txtEMP.Size = new System.Drawing.Size(166, 26);
            this.txtEMP.TabIndex = 17;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(245, 158);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 32);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblShort
            // 
            this.lblShort.AutoSize = true;
            this.lblShort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShort.ForeColor = System.Drawing.SystemColors.Control;
            this.lblShort.Location = new System.Drawing.Point(332, 322);
            this.lblShort.Name = "lblShort";
            this.lblShort.Size = new System.Drawing.Size(0, 20);
            this.lblShort.TabIndex = 19;
            // 
            // lblCasual
            // 
            this.lblCasual.AutoSize = true;
            this.lblCasual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCasual.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCasual.Location = new System.Drawing.Point(332, 276);
            this.lblCasual.Name = "lblCasual";
            this.lblCasual.Size = new System.Drawing.Size(0, 20);
            this.lblCasual.TabIndex = 20;
            // 
            // lblAnnual
            // 
            this.lblAnnual.AutoSize = true;
            this.lblAnnual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnnual.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAnnual.Location = new System.Drawing.Point(332, 228);
            this.lblAnnual.Name = "lblAnnual";
            this.lblAnnual.Size = new System.Drawing.Size(0, 20);
            this.lblAnnual.TabIndex = 21;
            // 
            // RemainingLeavesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(953, 626);
            this.Controls.Add(this.lblAnnual);
            this.Controls.Add(this.lblCasual);
            this.Controls.Add(this.lblShort);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtEMP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RemainingLeavesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemainingLeavesForm";
            this.Load += new System.EventHandler(this.RemainingLeavesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEMP;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblShort;
        private System.Windows.Forms.Label lblCasual;
        private System.Windows.Forms.Label lblAnnual;
    }
}