using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Transformese.Desktop
{
    partial class LoginForm
    {
        private IContainer components = null;
        private Guna2Panel leftPanel;
        private Guna2Panel rightPanel;
        private Label lblTitle;
        private Label lblSubtitle;
        private Guna2TextBox txtEmail;
        private Guna2TextBox txtPassword;
        private Guna2CheckBox chkRemember;
        private Guna2GradientButton btnLogin;
        private LinkLabel lnkRegister;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            leftPanel = new Guna2Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            rightPanel = new Guna2Panel();
            card = new Guna2Panel();
            lblSignIn = new Label();
            txtEmail = new Guna2TextBox();
            txtPassword = new Guna2TextBox();
            chkRemember = new Guna2CheckBox();
            lnkForgot = new LinkLabel();
            btnLogin = new Guna2GradientButton();
            lblFooter = new Label();
            lnkRegister = new LinkLabel();
            leftPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            card.SuspendLayout();
            SuspendLayout();
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(lblTitle);
            leftPanel.Controls.Add(lblSubtitle);
            leftPanel.CustomizableEdges = customizableEdges1;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            leftPanel.Size = new Size(200, 100);
            leftPanel.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 23);
            lblTitle.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Location = new Point(0, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(100, 23);
            lblSubtitle.TabIndex = 1;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(card);
            rightPanel.CustomizableEdges = customizableEdges11;
            rightPanel.Location = new Point(0, 0);
            rightPanel.Name = "rightPanel";
            rightPanel.ShadowDecoration.CustomizableEdges = customizableEdges12;
            rightPanel.Size = new Size(200, 100);
            rightPanel.TabIndex = 0;
            // 
            // card
            // 
            card.Controls.Add(lblSignIn);
            card.Controls.Add(txtEmail);
            card.Controls.Add(txtPassword);
            card.Controls.Add(chkRemember);
            card.Controls.Add(lnkForgot);
            card.Controls.Add(btnLogin);
            card.Controls.Add(lblFooter);
            card.Controls.Add(lnkRegister);
            card.CustomizableEdges = customizableEdges9;
            card.Location = new Point(0, 0);
            card.Name = "card";
            card.ShadowDecoration.CustomizableEdges = customizableEdges10;
            card.Size = new Size(200, 100);
            card.TabIndex = 0;
            // 
            // lblSignIn
            // 
            lblSignIn.Location = new Point(0, 0);
            lblSignIn.Name = "lblSignIn";
            lblSignIn.Size = new Size(100, 23);
            lblSignIn.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.CustomizableEdges = customizableEdges3;
            txtEmail.DefaultText = "";
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(0, 0);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtEmail.Size = new Size(200, 36);
            txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.CustomizableEdges = customizableEdges5;
            txtPassword.DefaultText = "";
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.Location = new Point(0, 0);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtPassword.Size = new Size(200, 36);
            txtPassword.TabIndex = 2;
            // 
            // chkRemember
            // 
            chkRemember.CheckedState.BorderRadius = 0;
            chkRemember.CheckedState.BorderThickness = 0;
            chkRemember.Location = new Point(0, 0);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(104, 24);
            chkRemember.TabIndex = 3;
            chkRemember.UncheckedState.BorderRadius = 0;
            chkRemember.UncheckedState.BorderThickness = 0;
            // 
            // lnkForgot
            // 
            lnkForgot.Location = new Point(0, 0);
            lnkForgot.Name = "lnkForgot";
            lnkForgot.Size = new Size(100, 23);
            lnkForgot.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.CustomizableEdges = customizableEdges7;
            btnLogin.Font = new Font("Segoe UI", 9F);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(0, 0);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnLogin.Size = new Size(180, 45);
            btnLogin.TabIndex = 5;
            btnLogin.Click += BtnLogin_Click;
            // 
            // lblFooter
            // 
            lblFooter.Location = new Point(0, 0);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(100, 23);
            lblFooter.TabIndex = 6;
            // 
            // lnkRegister
            // 
            lnkRegister.Location = new Point(0, 0);
            lnkRegister.Name = "lnkRegister";
            lnkRegister.Size = new Size(100, 23);
            lnkRegister.TabIndex = 7;
            // 
            // LoginForm
            // 
            ClientSize = new Size(900, 560);
            Controls.Add(rightPanel);
            Controls.Add(leftPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Transformese - Login";
            leftPanel.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            card.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Guna2Panel card;
        private Label lblSignIn;
        private LinkLabel lnkForgot;
        private Label lblFooter;
    }
}
