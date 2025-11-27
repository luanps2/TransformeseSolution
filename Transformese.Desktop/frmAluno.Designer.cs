namespace Transformese.Desktop
{
    partial class frmAluno
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCourses;
        private System.Windows.Forms.Button btnEnroll;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCourses = new System.Windows.Forms.TextBox();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.txtCourses.Multiline = true;
            this.txtCourses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCourses.Location = new System.Drawing.Point(12, 12);
            this.txtCourses.Size = new System.Drawing.Size(740, 380);

            this.btnEnroll.Location = new System.Drawing.Point(12, 410);
            this.btnEnroll.Size = new System.Drawing.Size(120, 30);
            this.btnEnroll.Text = "Matricular";
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);

            this.ClientSize = new System.Drawing.Size(764, 461);
            this.Controls.Add(this.txtCourses);
            this.Controls.Add(this.btnEnroll);
            this.Text = "Aluno Dashboard";
            this.Load += new System.EventHandler(this.frmAluno_Load);
            this.ResumeLayout(false);
        }
    }
}
