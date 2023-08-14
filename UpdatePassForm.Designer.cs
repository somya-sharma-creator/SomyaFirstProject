namespace WindowsFormsApp2
{
    partial class UpdatePassForm
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
            this.updatelbl = new System.Windows.Forms.Label();
            this.newpasslbl = new System.Windows.Forms.Label();
            this.newpasswordtxt = new System.Windows.Forms.TextBox();
            this.updatebtnn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // updatelbl
            // 
            this.updatelbl.AutoSize = true;
            this.updatelbl.Location = new System.Drawing.Point(318, 58);
            this.updatelbl.Name = "updatelbl";
            this.updatelbl.Size = new System.Drawing.Size(90, 13);
            this.updatelbl.TabIndex = 0;
            this.updatelbl.Text = "Update password";
            // 
            // newpasslbl
            // 
            this.newpasslbl.AutoSize = true;
            this.newpasslbl.Location = new System.Drawing.Point(206, 158);
            this.newpasslbl.Name = "newpasslbl";
            this.newpasslbl.Size = new System.Drawing.Size(75, 13);
            this.newpasslbl.TabIndex = 1;
            this.newpasslbl.Text = "new password";
            // 
            // newpasswordtxt
            // 
            this.newpasswordtxt.Location = new System.Drawing.Point(400, 155);
            this.newpasswordtxt.Name = "newpasswordtxt";
            this.newpasswordtxt.Size = new System.Drawing.Size(100, 20);
            this.newpasswordtxt.TabIndex = 3;
            this.newpasswordtxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.newpasswordtxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.newpasswordtxt_KeyPress);
            // 
            // updatebtnn
            // 
            this.updatebtnn.Location = new System.Drawing.Point(321, 231);
            this.updatebtnn.Name = "updatebtnn";
            this.updatebtnn.Size = new System.Drawing.Size(75, 23);
            this.updatebtnn.TabIndex = 5;
            this.updatebtnn.Text = "Update";
            this.updatebtnn.UseVisualStyleBackColor = true;
            this.updatebtnn.Click += new System.EventHandler(this.updatebtnn_Click);
            // 
            // UpdatePassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.updatebtnn);
            this.Controls.Add(this.newpasswordtxt);
            this.Controls.Add(this.newpasslbl);
            this.Controls.Add(this.updatelbl);
            this.Name = "UpdatePassForm";
            this.Text = "UpdatePassForm";
            this.Load += new System.EventHandler(this.UpdatePassForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label updatelbl;
        private System.Windows.Forms.Label newpasslbl;
        private System.Windows.Forms.TextBox newpasswordtxt;
        private System.Windows.Forms.Button updatebtnn;
    }
}