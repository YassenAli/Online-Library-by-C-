namespace LoginRegistrationForm
{
    partial class userMainForm
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
            this.showbooks = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.modify = new System.Windows.Forms.Button();
            this.welcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // showbooks
            // 
            this.showbooks.Location = new System.Drawing.Point(12, 144);
            this.showbooks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showbooks.Name = "showbooks";
            this.showbooks.Size = new System.Drawing.Size(299, 64);
            this.showbooks.TabIndex = 10;
            this.showbooks.Text = "Show Tabls";
            this.showbooks.UseVisualStyleBackColor = true;
            this.showbooks.Click += new System.EventHandler(this.showbooks_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(12, 212);
            this.exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(299, 64);
            this.exit.TabIndex = 9;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click_1);
            // 
            // modify
            // 
            this.modify.Location = new System.Drawing.Point(12, 67);
            this.modify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modify.Name = "modify";
            this.modify.Size = new System.Drawing.Size(299, 73);
            this.modify.TabIndex = 8;
            this.modify.Text = "Modify";
            this.modify.UseVisualStyleBackColor = true;
            this.modify.Click += new System.EventHandler(this.modify_Click);
            // 
            // welcome
            // 
            this.welcome.AutoSize = true;
            this.welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome.Location = new System.Drawing.Point(104, 10);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(116, 25);
            this.welcome.TabIndex = 6;
            this.welcome.Text = "Welcome!!";
            // 
            // userMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 326);
            this.Controls.Add(this.showbooks);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.modify);
            this.Controls.Add(this.welcome);
            this.Name = "userMainForm";
            this.Text = "userMainForm";
            this.Load += new System.EventHandler(this.userMainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showbooks;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button modify;
        private System.Windows.Forms.Label welcome;
    }
}