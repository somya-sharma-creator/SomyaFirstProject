namespace WindowsFormsApp2
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.fnamelbl = new System.Windows.Forms.Label();
            this.lastnamelbl = new System.Windows.Forms.Label();
            this.emaillbl = new System.Windows.Forms.Label();
            this.phonelbl = new System.Windows.Forms.Label();
            this.passlbl = new System.Windows.Forms.Label();
            this.firsttxt = new System.Windows.Forms.TextBox();
            this.lasttxt = new System.Windows.Forms.TextBox();
            this.emailtxt = new System.Windows.Forms.TextBox();
            this.phonetxt = new System.Windows.Forms.TextBox();
            this.passtxt = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.savebtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "user information";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // fnamelbl
            // 
            this.fnamelbl.AutoSize = true;
            this.fnamelbl.Location = new System.Drawing.Point(281, 131);
            this.fnamelbl.Name = "fnamelbl";
            this.fnamelbl.Size = new System.Drawing.Size(55, 13);
            this.fnamelbl.TabIndex = 1;
            this.fnamelbl.Text = "First name";
            // 
            // lastnamelbl
            // 
            this.lastnamelbl.AutoSize = true;
            this.lastnamelbl.Location = new System.Drawing.Point(276, 169);
            this.lastnamelbl.Name = "lastnamelbl";
            this.lastnamelbl.Size = new System.Drawing.Size(56, 13);
            this.lastnamelbl.TabIndex = 2;
            this.lastnamelbl.Text = "Last name";
            // 
            // emaillbl
            // 
            this.emaillbl.AutoSize = true;
            this.emaillbl.Location = new System.Drawing.Point(281, 221);
            this.emaillbl.Name = "emaillbl";
            this.emaillbl.Size = new System.Drawing.Size(43, 13);
            this.emaillbl.TabIndex = 3;
            this.emaillbl.Text = "Email id";
            // 
            // phonelbl
            // 
            this.phonelbl.AutoSize = true;
            this.phonelbl.Location = new System.Drawing.Point(286, 279);
            this.phonelbl.Name = "phonelbl";
            this.phonelbl.Size = new System.Drawing.Size(38, 13);
            this.phonelbl.TabIndex = 4;
            this.phonelbl.Text = "Phone";
            // 
            // passlbl
            // 
            this.passlbl.AutoSize = true;
            this.passlbl.Location = new System.Drawing.Point(276, 325);
            this.passlbl.Name = "passlbl";
            this.passlbl.Size = new System.Drawing.Size(53, 13);
            this.passlbl.TabIndex = 5;
            this.passlbl.Text = "Password";
            // 
            // firsttxt
            // 
            this.firsttxt.Location = new System.Drawing.Point(405, 124);
            this.firsttxt.Name = "firsttxt";
            this.firsttxt.Size = new System.Drawing.Size(100, 20);
            this.firsttxt.TabIndex = 6;
            this.firsttxt.TextChanged += new System.EventHandler(this.firsttxt_TextChanged);
            this.firsttxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.firsttxt_KeyPress);
            // 
            // lasttxt
            // 
            this.lasttxt.Location = new System.Drawing.Point(405, 169);
            this.lasttxt.Name = "lasttxt";
            this.lasttxt.Size = new System.Drawing.Size(100, 20);
            this.lasttxt.TabIndex = 7;
            this.lasttxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lasttxt_KeyPress);
            // 
            // emailtxt
            // 
            this.emailtxt.Location = new System.Drawing.Point(405, 218);
            this.emailtxt.Name = "emailtxt";
            this.emailtxt.Size = new System.Drawing.Size(100, 20);
            this.emailtxt.TabIndex = 8;
            this.emailtxt.Leave += new System.EventHandler(this.emailtxt_Leave);
            // 
            // phonetxt
            // 
            this.phonetxt.Location = new System.Drawing.Point(405, 272);
            this.phonetxt.Name = "phonetxt";
            this.phonetxt.Size = new System.Drawing.Size(100, 20);
            this.phonetxt.TabIndex = 9;
            this.phonetxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phonetxt_KeyPress);
            // 
            // passtxt
            // 
            this.passtxt.Location = new System.Drawing.Point(405, 318);
            this.passtxt.Name = "passtxt";
            this.passtxt.Size = new System.Drawing.Size(100, 20);
            this.passtxt.TabIndex = 10;
            this.passtxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passtxt_KeyPress);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(352, 375);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 23);
            this.savebtn.TabIndex = 11;
            this.savebtn.Text = "save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.passtxt);
            this.Controls.Add(this.phonetxt);
            this.Controls.Add(this.emailtxt);
            this.Controls.Add(this.lasttxt);
            this.Controls.Add(this.firsttxt);
            this.Controls.Add(this.passlbl);
            this.Controls.Add(this.phonelbl);
            this.Controls.Add(this.emaillbl);
            this.Controls.Add(this.lastnamelbl);
            this.Controls.Add(this.fnamelbl);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fnamelbl;
        private System.Windows.Forms.Label lastnamelbl;
        private System.Windows.Forms.Label emaillbl;
        private System.Windows.Forms.Label phonelbl;
        private System.Windows.Forms.Label passlbl;
        private System.Windows.Forms.TextBox firsttxt;
        private System.Windows.Forms.TextBox lasttxt;
        private System.Windows.Forms.TextBox emailtxt;
        private System.Windows.Forms.TextBox phonetxt;
        private System.Windows.Forms.TextBox passtxt;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button savebtn;
    }
}

