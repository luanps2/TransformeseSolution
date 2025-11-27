namespace Transformese.Desktop
{
    partial class frmCreateUser
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();

            this.txtNome.Location = new System.Drawing.Point(12, 12);
            this.txtNome.Width = 300;
            this.txtNome.PlaceholderText = "Nome";

            this.txtEmail.Location = new System.Drawing.Point(12, 52);
            this.txtEmail.Width = 300;
            this.txtEmail.PlaceholderText = "Email";

            this.txtSenha.Location = new System.Drawing.Point(12, 92);
            this.txtSenha.Width = 300;
            this.txtSenha.PlaceholderText = "Senha";

            this.txtTipo.Location = new System.Drawing.Point(12, 132);
            this.txtTipo.Width = 120;
            this.txtTipo.PlaceholderText = "TipoUsuarioId (1,2,3)";

            this.btnSave.Location = new System.Drawing.Point(12, 172);
            this.btnSave.Text = "Salvar";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.ClientSize = new System.Drawing.Size(340, 220);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.btnSave);
            this.Text = "Criar Usuário";
        }
    }
}
