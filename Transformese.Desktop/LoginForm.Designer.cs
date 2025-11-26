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
        private Guna2BorderlessForm gunaBorderless;
        private Guna2DragControl gunaDrag;
        private Guna2Panel leftPanel;
        private Guna2Panel rightPanel;
        private Label lblTitle;
        private Label lblSubtitle;
        private Guna2PictureBox picHero;
        private Guna2TextBox txtEmail;
        private Guna2TextBox txtPassword;
        private Guna2CheckBox chkRemember;
        private Guna2GradientButton btnLogin;
        private Guna2Button btnRegister;
        private Guna2ControlBox btnClose;
        private PictureBox logoBox;
        private Label lblFooter;

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
            components = new Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            gunaBorderless = new Guna2BorderlessForm(components);
            gunaDrag = new Guna2DragControl(components);
            rightPanel = new Guna2Panel();
            btnClose = new Guna2ControlBox();
            logoBox = new PictureBox();
            avatarFrame = new Panel();
            avatarPic = new Guna2CirclePictureBox();
            lblPrompt = new Label();
            txtEmail = new Guna2TextBox();
            txtPassword = new Guna2TextBox();
            chkRemember = new Guna2CheckBox();
            btnLogin = new Guna2GradientButton();
            btnRegister = new Guna2Button();
            lblFooter = new Label();
            leftPanel = new Guna2Panel();
            picHero = new Guna2PictureBox();
            lblTitle = new Label();
            lblSubtitle = new Label();
            rightPanel.SuspendLayout();
            ((ISupportInitialize)logoBox).BeginInit();
            avatarFrame.SuspendLayout();
            ((ISupportInitialize)avatarPic).BeginInit();
            leftPanel.SuspendLayout();
            ((ISupportInitialize)picHero).BeginInit();
            SuspendLayout();
            // 
            // gunaBorderless
            // 
            gunaBorderless.ContainerControl = this;
            gunaBorderless.DockIndicatorTransparencyValue = 0.6D;
            gunaBorderless.TransparentWhileDrag = true;
            // 
            // gunaDrag
            // 
            gunaDrag.DockIndicatorTransparencyValue = 0.6D;
            gunaDrag.TargetControl = rightPanel;
            gunaDrag.UseTransparentDrag = true;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(lblPrompt);
            rightPanel.Controls.Add(txtEmail);
            rightPanel.Controls.Add(txtPassword);
            rightPanel.Controls.Add(chkRemember);
            rightPanel.Controls.Add(btnLogin);
            rightPanel.Controls.Add(btnRegister);
            rightPanel.Controls.Add(lblFooter);
            rightPanel.CustomizableEdges = customizableEdges12;
            rightPanel.Location = new Point(0, 0);
            rightPanel.Name = "rightPanel";
            rightPanel.ShadowDecoration.CustomizableEdges = customizableEdges13;
            rightPanel.Size = new Size(200, 100);
            rightPanel.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.CustomizableEdges = customizableEdges2;
            btnClose.FillColor = Color.FromArgb(139, 152, 166);
            btnClose.IconColor = Color.White;
            btnClose.Location = new Point(40, 151);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnClose.Size = new Size(45, 29);
            btnClose.TabIndex = 0;
            btnClose.Click += BtnClose_Click;
            // 
            // logoBox
            // 
            logoBox.Location = new Point(334, 151);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(100, 50);
            logoBox.TabIndex = 1;
            logoBox.TabStop = false;
            // 
            // avatarFrame
            // 
            avatarFrame.Controls.Add(avatarPic);
            avatarFrame.Location = new Point(174, 180);
            avatarFrame.Name = "avatarFrame";
            avatarFrame.Size = new Size(200, 100);
            avatarFrame.TabIndex = 2;
            // 
            // avatarPic
            // 
            avatarPic.ImageRotate = 0F;
            avatarPic.Location = new Point(0, 0);
            avatarPic.Name = "avatarPic";
            avatarPic.ShadowDecoration.CustomizableEdges = customizableEdges1;
            avatarPic.Size = new Size(64, 64);
            avatarPic.TabIndex = 0;
            avatarPic.TabStop = false;
            // 
            // lblPrompt
            // 
            lblPrompt.Location = new Point(0, 0);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(100, 23);
            lblPrompt.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.CustomizableEdges = customizableEdges4;
            txtEmail.DefaultText = "";
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(0, 0);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges5;
            txtEmail.Size = new Size(200, 36);
            txtEmail.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.CustomizableEdges = customizableEdges6;
            txtPassword.DefaultText = "";
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.Location = new Point(0, 0);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges7;
            txtPassword.Size = new Size(200, 36);
            txtPassword.TabIndex = 5;
            // 
            // chkRemember
            // 
            chkRemember.CheckedState.BorderRadius = 0;
            chkRemember.CheckedState.BorderThickness = 0;
            chkRemember.Location = new Point(0, 0);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(104, 24);
            chkRemember.TabIndex = 6;
            chkRemember.UncheckedState.BorderRadius = 0;
            chkRemember.UncheckedState.BorderThickness = 0;
            // 
            // btnLogin
            // 
            btnLogin.CustomizableEdges = customizableEdges8;
            btnLogin.Font = new Font("Segoe UI", 9F);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(0, 0);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges9;
            btnLogin.Size = new Size(180, 45);
            btnLogin.TabIndex = 7;
            btnLogin.Click += BtnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.CustomizableEdges = customizableEdges10;
            btnRegister.Font = new Font("Segoe UI", 9F);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(0, 0);
            btnRegister.Name = "btnRegister";
            btnRegister.ShadowDecoration.CustomizableEdges = customizableEdges11;
            btnRegister.Size = new Size(180, 45);
            btnRegister.TabIndex = 8;
            btnRegister.Click += BtnRegister_Click;
            // 
            // lblFooter
            // 
            lblFooter.Location = new Point(0, 0);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(100, 23);
            lblFooter.TabIndex = 9;
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(picHero);
            leftPanel.Controls.Add(lblTitle);
            leftPanel.Controls.Add(lblSubtitle);
            leftPanel.CustomizableEdges = customizableEdges16;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.ShadowDecoration.CustomizableEdges = customizableEdges17;
            leftPanel.Size = new Size(200, 100);
            leftPanel.TabIndex = 1;
            // 
            // picHero
            // 
            picHero.CustomizableEdges = customizableEdges14;
            picHero.ImageRotate = 0F;
            picHero.Location = new Point(0, 0);
            picHero.Name = "picHero";
            picHero.ShadowDecoration.CustomizableEdges = customizableEdges15;
            picHero.Size = new Size(300, 200);
            picHero.TabIndex = 0;
            picHero.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 23);
            lblTitle.TabIndex = 1;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Location = new Point(0, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(100, 23);
            lblSubtitle.TabIndex = 2;
            // 
            // LoginForm
            // 
            ClientSize = new Size(920, 560);
            Controls.Add(avatarFrame);
            Controls.Add(logoBox);
            Controls.Add(btnClose);
            Controls.Add(rightPanel);
            Controls.Add(leftPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += LoginForm_Load;
            rightPanel.ResumeLayout(false);
            ((ISupportInitialize)logoBox).EndInit();
            avatarFrame.ResumeLayout(false);
            ((ISupportInitialize)avatarPic).EndInit();
            leftPanel.ResumeLayout(false);
            ((ISupportInitialize)picHero).EndInit();
            ResumeLayout(false);
        }

        private Panel avatarFrame;
        private Guna2CirclePictureBox avatarPic;
        private Label lblPrompt;
    }
}
