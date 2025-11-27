namespace Transformese.Desktop
{
    partial class frmAdmin
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlCards;
        private Guna.UI2.WinForms.Guna2Panel cardUsers;
        private Guna.UI2.WinForms.Guna2Panel cardCourses;
        private Guna.UI2.WinForms.Guna2Panel cardUnits;
        private Guna.UI2.WinForms.Guna2Panel cardEnrollments;
        private System.Windows.Forms.Label lblUsersCount;
        private System.Windows.Forms.Label lblCoursesCount;
        private System.Windows.Forms.Label lblUnitsCount;
        private System.Windows.Forms.Label lblEnrollmentsCount;
        private Guna.UI2.WinForms.Guna2Panel pnlChartPlaceholder;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCourses;
        private Guna.UI2.WinForms.Guna2DataGridView dgvUsers;
        private Guna.UI2.WinForms.Guna2DataGridView dgvUnits;
        private Guna.UI2.WinForms.Guna2Button btnCreateUser;
        private Guna.UI2.WinForms.Guna2Button btnCreateCourse;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlCards = new Guna.UI2.WinForms.Guna2Panel();
            this.cardUsers = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUsersCount = new System.Windows.Forms.Label();
            this.cardCourses = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCoursesCount = new System.Windows.Forms.Label();
            this.cardUnits = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUnitsCount = new System.Windows.Forms.Label();
            this.cardEnrollments = new Guna.UI2.WinForms.Guna2Panel();
            this.lblEnrollmentsCount = new System.Windows.Forms.Label();
            this.pnlChartPlaceholder = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvCourses = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvUsers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvUnits = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnCreateUser = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreateCourse = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 60;
            this.pnlHeader.FillColor = System.Drawing.Color.White;
            this.pnlHeader.ShadowDecoration.Parent = this.pnlHeader;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(12);
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.btnCreateCourse);
            this.pnlHeader.Controls.Add(this.btnCreateUser);

            // btnRefresh
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRefresh.Location = new System.Drawing.Point(980, 12);
            this.btnRefresh.Size = new System.Drawing.Size(90, 36);

            // btnCreateCourse
            this.btnCreateCourse.Text = "Criar Curso";
            this.btnCreateCourse.Location = new System.Drawing.Point(860, 12);
            this.btnCreateCourse.Size = new System.Drawing.Size(110, 36);

            // btnCreateUser
            this.btnCreateUser.Text = "Criar Usuário";
            this.btnCreateUser.Location = new System.Drawing.Point(740, 12);
            this.btnCreateUser.Size = new System.Drawing.Size(110, 36);

            // pnlCards
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Height = 120;
            this.pnlCards.FillColor = System.Drawing.Color.Transparent;
            this.pnlCards.Padding = new System.Windows.Forms.Padding(12);
            this.pnlCards.Controls.Add(this.cardUsers);
            this.pnlCards.Controls.Add(this.cardCourses);
            this.pnlCards.Controls.Add(this.cardUnits);
            this.pnlCards.Controls.Add(this.cardEnrollments);
            this.pnlCards.Location = new System.Drawing.Point(0, 60);

            // cardUsers
            this.cardUsers.Size = new System.Drawing.Size(220, 96);
            this.cardUsers.Location = new System.Drawing.Point(12, 12);
            this.cardUsers.FillColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.cardUsers.BorderRadius = 8;
            this.cardUsers.Controls.Add(this.lblUsersCount);

            this.lblUsersCount.ForeColor = System.Drawing.Color.White;
            this.lblUsersCount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblUsersCount.Location = new System.Drawing.Point(16, 20);
            this.lblUsersCount.AutoSize = true;
            this.lblUsersCount.Text = "0\nUsers";

            // cardCourses
            this.cardCourses.Size = new System.Drawing.Size(220, 96);
            this.cardCourses.Location = new System.Drawing.Point(250, 12);
            this.cardCourses.FillColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.cardCourses.BorderRadius = 8;
            this.cardCourses.Controls.Add(this.lblCoursesCount);

            this.lblCoursesCount.ForeColor = System.Drawing.Color.White;
            this.lblCoursesCount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCoursesCount.Location = new System.Drawing.Point(16, 20);
            this.lblCoursesCount.AutoSize = true;
            this.lblCoursesCount.Text = "0\nCursos";

            // cardUnits
            this.cardUnits.Size = new System.Drawing.Size(220, 96);
            this.cardUnits.Location = new System.Drawing.Point(490, 12);
            this.cardUnits.FillColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.cardUnits.BorderRadius = 8;
            this.cardUnits.Controls.Add(this.lblUnitsCount);

            this.lblUnitsCount.ForeColor = System.Drawing.Color.White;
            this.lblUnitsCount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblUnitsCount.Location = new System.Drawing.Point(16, 20);
            this.lblUnitsCount.AutoSize = true;
            this.lblUnitsCount.Text = "0\nUnidades";

            // cardEnrollments
            this.cardEnrollments.Size = new System.Drawing.Size(220, 96);
            this.cardEnrollments.Location = new System.Drawing.Point(730, 12);
            this.cardEnrollments.FillColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.cardEnrollments.BorderRadius = 8;
            this.cardEnrollments.Controls.Add(this.lblEnrollmentsCount);

            this.lblEnrollmentsCount.ForeColor = System.Drawing.Color.White;
            this.lblEnrollmentsCount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblEnrollmentsCount.Location = new System.Drawing.Point(16, 20);
            this.lblEnrollmentsCount.AutoSize = true;
            this.lblEnrollmentsCount.Text = "0\nMatriculas";

            // pnlChartPlaceholder
            this.pnlChartPlaceholder.Location = new System.Drawing.Point(12, 200);
            this.pnlChartPlaceholder.Size = new System.Drawing.Size(1058, 220);
            this.pnlChartPlaceholder.BorderRadius = 6;
            this.pnlChartPlaceholder.FillColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // dgvCourses
            this.dgvCourses.Location = new System.Drawing.Point(12, 440);
            this.dgvCourses.Size = new System.Drawing.Size(520, 260);
            this.dgvCourses.ReadOnly = true;
            this.dgvCourses.AllowUserToAddRows = false;

            // dgvUsers
            this.dgvUsers.Location = new System.Drawing.Point(548, 440);
            this.dgvUsers.Size = new System.Drawing.Size(522, 260);
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.AllowUserToAddRows = false;

            // dgvUnits
            this.dgvUnits.Location = new System.Drawing.Point(12, 720);
            this.dgvUnits.Size = new System.Drawing.Size(1058, 180);
            this.dgvUnits.ReadOnly = true;
            this.dgvUnits.AllowUserToAddRows = false;

            // Form
            this.ClientSize = new System.Drawing.Size(1082, 920);
            this.Controls.Add(this.dgvUnits);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.dgvCourses);
            this.Controls.Add(this.pnlChartPlaceholder);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlHeader);
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.frmAdmin_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
