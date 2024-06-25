namespace LoginRegistrationForm
{
    partial class Main
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
            this.welcome = new System.Windows.Forms.Label();
            this.insert = new System.Windows.Forms.Button();
            this.modify = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.showbooks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcome
            // 
            this.welcome.AutoSize = true;
            this.welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome.Location = new System.Drawing.Point(78, 7);
            this.welcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(92, 20);
            this.welcome.TabIndex = 1;
            this.welcome.Text = "Welcome!!";
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(9, 60);
            this.insert.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(224, 54);
            this.insert.TabIndex = 2;
            this.insert.Text = "Insert";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.button1_Click);
            // 
            // modify
            // 
            this.modify.Location = new System.Drawing.Point(9, 119);
            this.modify.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.modify.Name = "modify";
            this.modify.Size = new System.Drawing.Size(224, 59);
            this.modify.TabIndex = 3;
            this.modify.Text = "Modify";
            this.modify.UseVisualStyleBackColor = true;
            this.modify.Click += new System.EventHandler(this.button2_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(9, 240);
            this.exit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(224, 52);
            this.exit.TabIndex = 4;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // showbooks
            // 
            this.showbooks.Location = new System.Drawing.Point(9, 184);
            this.showbooks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.showbooks.Name = "showbooks";
            this.showbooks.Size = new System.Drawing.Size(224, 52);
            this.showbooks.TabIndex = 5;
            this.showbooks.Text = "Show Tabls";
            this.showbooks.UseVisualStyleBackColor = true;
            this.showbooks.Click += new System.EventHandler(this.showbooks_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 301);
            this.Controls.Add(this.showbooks);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.modify);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.welcome);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Main";
            this.Text = "main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcome;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Button modify;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button showbooks;
    }
}