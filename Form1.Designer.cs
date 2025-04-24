namespace CadastroAlunos
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCadastro;
        private System.Windows.Forms.TabPage tabRelatorios;

        private System.Windows.Forms.TextBox txtPesquisaNome;
        private System.Windows.Forms.TextBox txtPesquisaMatricula;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.ListBox listBoxAlunos;

        private System.Windows.Forms.GroupBox groupBoxCadastro;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtIdade;
        private System.Windows.Forms.TextBox txtCurso;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovoAluno;
        private System.Windows.Forms.Label lblContagemAlunos;

        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnVerificarAprovacao;

        private System.Windows.Forms.Label lblRelatorio;
        private System.Windows.Forms.Button btnAtualizarRelatorio;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCadastro = new System.Windows.Forms.TabPage();
            this.tabRelatorios = new System.Windows.Forms.TabPage();

            // Cadastro Tab Controls
            this.txtPesquisaNome = new System.Windows.Forms.TextBox();
            this.txtPesquisaMatricula = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.listBoxAlunos = new System.Windows.Forms.ListBox();
            this.lblContagemAlunos = new System.Windows.Forms.Label();

            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnVerificarAprovacao = new System.Windows.Forms.Button();
            this.btnNovoAluno = new System.Windows.Forms.Button();

            this.groupBoxCadastro = new System.Windows.Forms.GroupBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtIdade = new System.Windows.Forms.TextBox();
            this.txtCurso = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();

            // Relatorio Tab Controls
            this.lblRelatorio = new System.Windows.Forms.Label();
            this.btnAtualizarRelatorio = new System.Windows.Forms.Button();

            // TAB CONTROL
            this.tabControl.Controls.Add(this.tabCadastro);
            this.tabControl.Controls.Add(this.tabRelatorios);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;

            // TAB CADASTRO
            this.tabCadastro.Text = "Cadastro de Alunos";

            // Pesquisas
            this.txtPesquisaNome.Location = new System.Drawing.Point(20, 20);
            this.txtPesquisaNome.Width = 150;
            this.txtPesquisaNome.PlaceholderText = "Pesquisar por nome";

            this.txtPesquisaMatricula.Location = new System.Drawing.Point(180, 20);
            this.txtPesquisaMatricula.Width = 100;
            this.txtPesquisaMatricula.PlaceholderText = "Matrícula";

            this.btnPesquisar.Location = new System.Drawing.Point(290, 18);
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);

            // ListBox
            this.listBoxAlunos.Location = new System.Drawing.Point(20, 60);
            this.listBoxAlunos.Size = new System.Drawing.Size(500, 200);
            this.listBoxAlunos.SelectedIndexChanged += new System.EventHandler(this.listBoxAlunos_SelectedIndexChanged);

            this.lblContagemAlunos.Location = new System.Drawing.Point(20, 270);
            this.lblContagemAlunos.Text = "Alunos cadastrados: 0";

            // Ações
            this.btnEditar.Location = new System.Drawing.Point(540, 60);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnExcluir.Location = new System.Drawing.Point(540, 100);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            this.btnVerificarAprovacao.Location = new System.Drawing.Point(540, 140);
            this.btnVerificarAprovacao.Text = "Verificar Aprovação";
            this.btnVerificarAprovacao.Click += new System.EventHandler(this.btnVerificarAprovacao_Click);

            this.btnNovoAluno.Location = new System.Drawing.Point(540, 180);
            this.btnNovoAluno.Text = "Novo Aluno";
            this.btnNovoAluno.Click += new System.EventHandler(this.btnNovoAluno_Click);

            // Cadastro GroupBox
            this.groupBoxCadastro.Location = new System.Drawing.Point(20, 310);
            this.groupBoxCadastro.Size = new System.Drawing.Size(500, 180);
            this.groupBoxCadastro.Text = "Cadastro";
            this.groupBoxCadastro.Visible = false;

            this.txtNome.PlaceholderText = "Nome";
            this.txtIdade.PlaceholderText = "Idade";
            this.txtCurso.PlaceholderText = "Curso";
            this.txtMatricula.PlaceholderText = "Matrícula";
            this.txtNota.PlaceholderText = "Nota";

            this.txtNome.Top = 20; this.txtNome.Left = 20; this.txtNome.Width = 200;
            this.txtIdade.Top = 50; this.txtIdade.Left = 20; this.txtIdade.Width = 100;
            this.txtCurso.Top = 80; this.txtCurso.Left = 20; this.txtCurso.Width = 200;
            this.txtMatricula.Top = 110; this.txtMatricula.Left = 20; this.txtMatricula.Width = 100;
            this.txtNota.Top = 140; this.txtNota.Left = 20; this.txtNota.Width = 100;

            this.btnSalvar.Location = new System.Drawing.Point(250, 140);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.groupBoxCadastro.Controls.AddRange(new Control[] {
                txtNome, txtIdade, txtCurso, txtMatricula, txtNota, btnSalvar
            });

            this.tabCadastro.Controls.AddRange(new Control[] {
                txtPesquisaNome, txtPesquisaMatricula, btnPesquisar,
                listBoxAlunos, lblContagemAlunos,
                btnEditar, btnExcluir, btnVerificarAprovacao, btnNovoAluno,
                groupBoxCadastro
            });

            // TAB RELATÓRIOS
            this.tabRelatorios.Text = "Relatórios";
            this.lblRelatorio.Location = new System.Drawing.Point(20, 20);
            this.lblRelatorio.Size = new System.Drawing.Size(600, 200);
            this.lblRelatorio.Text = "Clique no botão para gerar o relatório.";

            this.btnAtualizarRelatorio.Location = new System.Drawing.Point(20, 230);
            this.btnAtualizarRelatorio.Text = "Atualizar Relatório";
            this.btnAtualizarRelatorio.Click += new System.EventHandler(this.btnAtualizarRelatorio_Click);

            this.tabRelatorios.Controls.Add(this.lblRelatorio);
            this.tabRelatorios.Controls.Add(this.btnAtualizarRelatorio);

            // FORM
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.tabControl);
            this.Text = "Cadastro de Alunos";
        }
    }
}
