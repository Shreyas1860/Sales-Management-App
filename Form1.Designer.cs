namespace SALES_PROJECT
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
            this.sign_in = new System.Windows.Forms.Label();
            this.usrname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cust_login = new System.Windows.Forms.Button();
            this.seller_login = new System.Windows.Forms.Button();
            this.shipper_login = new System.Windows.Forms.Button();
            this.AdminLogin = new System.Windows.Forms.Button();
            this.signup = new System.Windows.Forms.Button();
            this.forgot_pswd = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sign_in
            // 
            this.sign_in.AutoSize = true;
            this.sign_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign_in.Location = new System.Drawing.Point(133, 50);
            this.sign_in.Name = "sign_in";
            this.sign_in.Size = new System.Drawing.Size(123, 31);
            this.sign_in.TabIndex = 0;
            this.sign_in.Text = "SIGN IN";
            // 
            // usrname
            // 
            this.usrname.AutoSize = true;
            this.usrname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrname.Location = new System.Drawing.Point(94, 137);
            this.usrname.Name = "usrname";
            this.usrname.Size = new System.Drawing.Size(77, 15);
            this.usrname.TabIndex = 1;
            this.usrname.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // cust_login
            // 
            this.cust_login.Location = new System.Drawing.Point(58, 287);
            this.cust_login.Name = "cust_login";
            this.cust_login.Size = new System.Drawing.Size(141, 23);
            this.cust_login.TabIndex = 3;
            this.cust_login.Text = "Customer Login";
            this.cust_login.UseVisualStyleBackColor = true;
            this.cust_login.Click += new System.EventHandler(this.cust_login_Click);
            // 
            // seller_login
            // 
            this.seller_login.Location = new System.Drawing.Point(222, 287);
            this.seller_login.Name = "seller_login";
            this.seller_login.Size = new System.Drawing.Size(150, 23);
            this.seller_login.TabIndex = 4;
            this.seller_login.Text = "Seller Login";
            this.seller_login.UseVisualStyleBackColor = true;
            this.seller_login.Click += new System.EventHandler(this.seller_login_Click);
            // 
            // shipper_login
            // 
            this.shipper_login.Location = new System.Drawing.Point(58, 316);
            this.shipper_login.Name = "shipper_login";
            this.shipper_login.Size = new System.Drawing.Size(141, 23);
            this.shipper_login.TabIndex = 5;
            this.shipper_login.Text = "Shipper Login";
            this.shipper_login.UseVisualStyleBackColor = true;
            this.shipper_login.Click += new System.EventHandler(this.shipper_login_Click);
            // 
            // AdminLogin
            // 
            this.AdminLogin.Location = new System.Drawing.Point(222, 316);
            this.AdminLogin.Name = "AdminLogin";
            this.AdminLogin.Size = new System.Drawing.Size(150, 23);
            this.AdminLogin.TabIndex = 6;
            this.AdminLogin.Text = "Admin Login";
            this.AdminLogin.UseVisualStyleBackColor = true;
            this.AdminLogin.Click += new System.EventHandler(this.AdminLogin_Click);
            // 
            // signup
            // 
            this.signup.Location = new System.Drawing.Point(177, 381);
            this.signup.Name = "signup";
            this.signup.Size = new System.Drawing.Size(75, 23);
            this.signup.TabIndex = 7;
            this.signup.Text = "SIGN UP";
            this.signup.UseVisualStyleBackColor = true;
            this.signup.Click += new System.EventHandler(this.signup_Click);
            // 
            // forgot_pswd
            // 
            this.forgot_pswd.Location = new System.Drawing.Point(209, 207);
            this.forgot_pswd.Name = "forgot_pswd";
            this.forgot_pswd.Size = new System.Drawing.Size(140, 23);
            this.forgot_pswd.TabIndex = 8;
            this.forgot_pswd.Text = "Forgot Password?";
            this.forgot_pswd.UseVisualStyleBackColor = true;
            this.forgot_pswd.Click += new System.EventHandler(this.forgot_pswd_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(191, 135);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(191, 162);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SALES_PROJECT.Properties.Resources.pexels_fauxels_3183198;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(431, 482);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.forgot_pswd);
            this.Controls.Add(this.signup);
            this.Controls.Add(this.AdminLogin);
            this.Controls.Add(this.shipper_login);
            this.Controls.Add(this.seller_login);
            this.Controls.Add(this.cust_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usrname);
            this.Controls.Add(this.sign_in);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sign_in;
        private System.Windows.Forms.Label usrname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cust_login;
        private System.Windows.Forms.Button seller_login;
        private System.Windows.Forms.Button shipper_login;
        private System.Windows.Forms.Button AdminLogin;
        private System.Windows.Forms.Button signup;
        private System.Windows.Forms.Button forgot_pswd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

