namespace DatabaseProject
{
    partial class AdminPage
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
            this.GetInfo = new System.Windows.Forms.Button();
            this.DBtxt = new System.Windows.Forms.TextBox();
            this.AaddUserBtn = new System.Windows.Forms.Button();
            this.DeleteUserBtn = new System.Windows.Forms.Button();
            this.EditUserBtn = new System.Windows.Forms.Button();
            this.txtDeleteName = new System.Windows.Forms.TextBox();
            this.txtDeleteEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GetInfo
            // 
            this.GetInfo.Location = new System.Drawing.Point(619, 8);
            this.GetInfo.Name = "GetInfo";
            this.GetInfo.Size = new System.Drawing.Size(75, 23);
            this.GetInfo.TabIndex = 11;
            this.GetInfo.Text = "Get DB Info";
            this.GetInfo.UseVisualStyleBackColor = true;
            this.GetInfo.Click += new System.EventHandler(this.GetInfo_Click);
            // 
            // DBtxt
            // 
            this.DBtxt.Location = new System.Drawing.Point(562, 37);
            this.DBtxt.Multiline = true;
            this.DBtxt.Name = "DBtxt";
            this.DBtxt.Size = new System.Drawing.Size(202, 346);
            this.DBtxt.TabIndex = 12;
            // 
            // AaddUserBtn
            // 
            this.AaddUserBtn.Location = new System.Drawing.Point(37, 21);
            this.AaddUserBtn.Name = "AaddUserBtn";
            this.AaddUserBtn.Size = new System.Drawing.Size(75, 23);
            this.AaddUserBtn.TabIndex = 13;
            this.AaddUserBtn.Text = "Add User";
            this.AaddUserBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteUserBtn
            // 
            this.DeleteUserBtn.Location = new System.Drawing.Point(198, 21);
            this.DeleteUserBtn.Name = "DeleteUserBtn";
            this.DeleteUserBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteUserBtn.TabIndex = 14;
            this.DeleteUserBtn.Text = "Delete User";
            this.DeleteUserBtn.UseVisualStyleBackColor = true;
            this.DeleteUserBtn.Click += new System.EventHandler(this.DeleteUserBtn_Click);
            // 
            // EditUserBtn
            // 
            this.EditUserBtn.Location = new System.Drawing.Point(391, 21);
            this.EditUserBtn.Name = "EditUserBtn";
            this.EditUserBtn.Size = new System.Drawing.Size(75, 23);
            this.EditUserBtn.TabIndex = 15;
            this.EditUserBtn.Text = "Edit User";
            this.EditUserBtn.UseVisualStyleBackColor = true;
            // 
            // txtDeleteName
            // 
            this.txtDeleteName.Location = new System.Drawing.Point(188, 67);
            this.txtDeleteName.Name = "txtDeleteName";
            this.txtDeleteName.Size = new System.Drawing.Size(100, 20);
            this.txtDeleteName.TabIndex = 16;
            // 
            // txtDeleteEmail
            // 
            this.txtDeleteEmail.Location = new System.Drawing.Point(188, 114);
            this.txtDeleteEmail.Name = "txtDeleteEmail";
            this.txtDeleteEmail.Size = new System.Drawing.Size(100, 20);
            this.txtDeleteEmail.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Email:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(722, 8);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 23);
            this.ExitBtn.TabIndex = 20;
            this.ExitBtn.Text = "Close";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // AdminPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDeleteEmail);
            this.Controls.Add(this.txtDeleteName);
            this.Controls.Add(this.EditUserBtn);
            this.Controls.Add(this.DeleteUserBtn);
            this.Controls.Add(this.AaddUserBtn);
            this.Controls.Add(this.DBtxt);
            this.Controls.Add(this.GetInfo);
            this.Name = "AdminPage";
            this.Text = "AdminPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetInfo;
        private System.Windows.Forms.TextBox DBtxt;
        private System.Windows.Forms.Button AaddUserBtn;
        private System.Windows.Forms.Button DeleteUserBtn;
        private System.Windows.Forms.Button EditUserBtn;
        private System.Windows.Forms.TextBox txtDeleteName;
        private System.Windows.Forms.TextBox txtDeleteEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ExitBtn;
    }
}