namespace Transformese.Desktop
{
    partial class frmProfessor
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCourses;
        private System.Windows.Forms.TextBox txtStudents;
        private System.Windows.Forms.Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCourses = new System.Windows.Forms.TextBox();
            this.txtStudents = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.txtCourses.Multiline = true;
            this.txtCourses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCourses.Location = new System.Drawing.Point(12, 12);
            this.txtCourses.Size = new System.Drawing.Size(360, 400);

            this.txtStudents.Multiline = true;
            this.txtStudents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStudents.Location = new System.Drawing.Point(390, 12);
            this.txtStudents.Size = new System.Drawing.Size(360, 400);

            this.btnRefresh.Location = new System.Drawing.Point(12, 420);
            this.btnRefresh.Size = new System.Drawing.Size(120, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.ClientSize = new System.Drawing.Size(764, 461);
            this.Controls.Add(this.txtCourses);
            this.Controls.Add(this.txtStudents);
            this.Controls.Add(this.btnRefresh);
            this.Text = "Professor Dashboard";
            this.Load += new System.EventHandler(this.frmProfessor_Load);
            this.ResumeLayout(false);
        }
    }
}
