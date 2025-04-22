namespace CadastroAlunos
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtPesquisaMatricula;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Panel panelCadastro;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtIdade;
        private System.Windows.Forms.TextBox txtCurso;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAprovacaoGeral;
        private System.Windows.Forms.ListBox listBoxAlunos;
        private System.Windows.Forms.Label lblContagemAlunos;
        private System.Windows.Forms.Button btnNovoAluno;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtPesquisaMatricula = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.panelCadastro = new System.Windows.Forms.Panel();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtIdade = new System.Windows.Forms.TextBox();
            this.txtCurso = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAprovacaoGeral = new System.Windows.Forms.Button();
            this.listBoxAlunos = new System.Windows.Forms.ListBox();
            this.lblContagemAlunos = new System.Windows.Forms.Label();
            this.btnNovoAluno = new System.Windows.Forms.Button();
            this.panelCadastro.SuspendLayout();
            this.SuspendLayout();

            // txtPesquisaMatricula
            this.txtPesquisaMatricula.Location = new System.Drawing.Point(20, 20);
            this.txtPesquisaMatricula.Size = new System.Drawing.Size(150, 20);
            this.txtPesquisaMatricula.PlaceholderText = "Matrícula";

            // btnPesquisar
            this.btnPesquisar.Location = new System.Drawing.Point(180, 18);
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);

            // panelCadastro
            this.panelCadastro.Controls.Add(this.txtNome);
            this.panelCadastro.Controls.Add(this.txtIdade);
            this.panelCadastro.Controls.Add(this.txtCurso);
            this.panelCadastro.Controls.Add(this.txtMatricula);
            this.panelCadastro.Controls.Add(this.txtNota);
            this.panelCadastro.Controls.Add(this.btnSalvar);
            this.panelCadastro.Location = new System.Drawing.Point(20, 60);
            this.panelCadastro.Size = new System.Drawing.Size(300, 180);
            this.panelCadastro.Visible = false;

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(10, 10);
            this.txtNome.PlaceholderText = "Nome";

            // txtIdade
            this.txtIdade.Location = new System.Drawing.Point(10, 40);
            this.txtIdade.PlaceholderText = "Idade";

            // txtCurso
            this.txtCurso.Location = new System.Drawing.Point(10, 70);
            this.txtCurso.PlaceholderText = "Curso";

            // txtMatricula
            this.txtMatricula.Location = new System.Drawing.Point(10, 100);
            this.txtMatricula.PlaceholderText = "Matrícula";

            // txtNota
            this.txtNota.Location = new System.Drawing.Point(10, 130);
            this.txtNota.PlaceholderText = "Nota";

            // btnSalvar
            this.btnSalvar.Location = new System.Drawing.Point(100, 160);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // btnAprovacaoGeral
            this.btnAprovacaoGeral.Location = new System.Drawing.Point(20, 260);
            this.btnAprovacaoGeral.Size = new System.Drawing.Size(150, 30);
            this.btnAprovacaoGeral.Text = "Aprovação Geral";
            this.btnAprovacaoGeral.Click += new System.EventHandler(this.btnAprovacaoGeral_Click);

            // btnNovoAluno
            this.btnNovoAluno.Location = new System.Drawing.Point(180, 260);
            this.btnNovoAluno.Size = new System.Drawing.Size(150, 30);
            this.btnNovoAluno.Text = "Cadastrar novo aluno";
            this.btnNovoAluno.Click += new System.EventHandler(this.btnNovoAluno_Click);

            // lblContagemAlunos
            this.lblContagemAlunos.Location = new System.Drawing.Point(350, 0);
            this.lblContagemAlunos.Size = new System.Drawing.Size(300, 20);
            this.lblContagemAlunos.Text = "Alunos cadastrados : 0";

            // listBoxAlunos
            this.listBoxAlunos.Location = new System.Drawing.Point(350, 20);
            this.listBoxAlunos.Size = new System.Drawing.Size(600, 270);
            this.listBoxAlunos.Font = new System.Drawing.Font("Consolas", 9);

            // Form1
            this.ClientSize = new System.Drawing.Size(980, 320);
            this.Controls.Add(this.txtPesquisaMatricula);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.panelCadastro);
            this.Controls.Add(this.btnAprovacaoGeral);
            this.Controls.Add(this.btnNovoAluno);
            this.Controls.Add(this.lblContagemAlunos);
            this.Controls.Add(this.listBoxAlunos);
            this.Text = "Cadastro de Alunos";
            this.panelCadastro.ResumeLayout(false);
            this.panelCadastro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}