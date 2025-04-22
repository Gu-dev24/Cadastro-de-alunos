using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CadastroAlunos
{
    public partial class Form1 : Form
    {
        private string filePath = "Alunos.txt";
        private List<Aluno> alunos = new List<Aluno>();
        private Aluno alunoEditando = null; // Armazena aluno em edição

        public Form1()
        {
            InitializeComponent();
            VerificarArquivo();
            CarregarAlunos();
            AtualizarListaAlunos();
        }

        private void VerificarArquivo()
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("Cadastro de alunos");
                    sw.WriteLine("Alunos cadastrados : 0");
                }
            }
        }

        private void CarregarAlunos()
        {
            alunos.Clear();
            string[] linhas = File.ReadAllLines(filePath);
            for (int i = 2; i < linhas.Length; i++)
            {
                var dados = linhas[i].Split('|');
                var aluno = new Aluno
                {
                    Nome = dados[0].Split(':')[1].Trim(),
                    Idade = int.Parse(dados[1].Split(':')[1].Trim()),
                    Curso = dados[2].Split(':')[1].Trim(),
                    Matricula = int.Parse(dados[3].Split(':')[1].Trim()),
                    Nota = int.Parse(dados[4].Split(':')[1].Trim())
                };
                alunos.Add(aluno);
            }
            AtualizarContagem();
        }

        private void SalvarAlunos()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Cadastro de alunos");
                sw.WriteLine($"Alunos cadastrados : {alunos.Count}");
                foreach (var aluno in alunos)
                {
                    sw.WriteLine($"Nome : {aluno.Nome} | Idade: {aluno.Idade} | Curso: {aluno.Curso} | Matrícula: {aluno.Matricula} | Nota: {aluno.Nota}");
                }
            }
            AtualizarContagem();
        }

        private void AtualizarListaAlunos()
        {
            listBoxAlunos.Items.Clear();
            foreach (var aluno in alunos)
            {
                listBoxAlunos.Items.Add($"Nome : {aluno.Nome} | Idade: {aluno.Idade} | Curso: {aluno.Curso} | Matrícula: {aluno.Matricula} | Nota: {aluno.Nota}");
            }
            AtualizarContagem();
        }

        private void AtualizarContagem()
        {
            lblContagemAlunos.Text = $"Alunos cadastrados : {alunos.Count}";
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPesquisaMatricula.Text, out int matricula))
            {
                MessageBox.Show("Digite uma matrícula válida!");
                return;
            }

            var aluno = alunos.FirstOrDefault(a => a.Matricula == matricula);
            if (aluno == null)
            {
                if (MessageBox.Show("Aluno não encontrado. Deseja cadastrar?", "Novo Aluno", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    LimparCamposCadastro();
                    txtMatricula.Text = txtPesquisaMatricula.Text;
                    panelCadastro.Visible = true;
                    alunoEditando = null;
                }
            }
            else
            {
                string dados = $"Nome : {aluno.Nome} | Idade: {aluno.Idade} | Curso: {aluno.Curso} | Matrícula: {aluno.Matricula} | Nota: {aluno.Nota}";

                var resultado = MessageBox.Show(
                    $"Aluno encontrado:\n{dados}\n\nEscolha uma ação:\n- Editar (clique em 'Sim')\n- Excluir (clique em 'Não')\n- Verificar aprovação (clique em 'Cancelar')",
                    "Aluno encontrado",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                if (resultado == DialogResult.Yes) // Editar
                {
                    alunoEditando = aluno;
                    txtNome.Text = aluno.Nome;
                    txtIdade.Text = aluno.Idade.ToString();
                    txtCurso.Text = aluno.Curso;
                    txtMatricula.Text = aluno.Matricula.ToString();
                    txtNota.Text = aluno.Nota.ToString();
                    panelCadastro.Visible = true;
                }
                else if (resultado == DialogResult.No) // Excluir
                {
                    if (MessageBox.Show("Deseja realmente excluir este aluno?", "Excluir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        alunos.Remove(aluno);
                        SalvarAlunos();
                        AtualizarListaAlunos();
                        MessageBox.Show("Aluno excluído com sucesso!");
                    }
                }
                else if (resultado == DialogResult.Cancel) // Verificar aprovação
                {
                    string status = aluno.Nota > 69 ? "Aprovado" : "Reprovado";
                    MessageBox.Show($"Aluno está {status}\nNota: {aluno.Nota}", "Verificar aprovação");
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            int matriculaNova = int.Parse(txtMatricula.Text);

            // Verifica se matrícula existe em outro aluno
            if (alunos.Any(a => a.Matricula == matriculaNova && a != alunoEditando))
            {
                MessageBox.Show("Matrícula já existente. Não é possível cadastrar o aluno.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (alunoEditando != null)
            {
                // Atualizar dados do aluno existente
                alunoEditando.Nome = txtNome.Text;
                alunoEditando.Idade = int.Parse(txtIdade.Text);
                alunoEditando.Curso = txtCurso.Text;
                alunoEditando.Matricula = matriculaNova;
                alunoEditando.Nota = int.Parse(txtNota.Text);

                alunoEditando = null;
                MessageBox.Show("Dados do aluno atualizados com sucesso!");
            }
            else
            {
                // Novo cadastro
                var novoAluno = new Aluno
                {
                    Nome = txtNome.Text,
                    Idade = int.Parse(txtIdade.Text),
                    Curso = txtCurso.Text,
                    Matricula = matriculaNova,
                    Nota = int.Parse(txtNota.Text)
                };

                alunos.Add(novoAluno);
                MessageBox.Show("Aluno cadastrado com sucesso!");
            }

            SalvarAlunos();
            AtualizarListaAlunos();
            panelCadastro.Visible = false;
        }

        private void btnAprovacaoGeral_Click(object sender, EventArgs e)
        {
            int aprovados = alunos.Count(a => a.Nota > 69);
            int reprovados = alunos.Count - aprovados;
            double total = alunos.Count;

            string mensagem = $"Aprovados: {aprovados} ({(aprovados / total * 100):0.##}%)\n" +
                              $"Reprovados: {reprovados} ({(reprovados / total * 100):0.##}%)";
            MessageBox.Show(mensagem, "Aprovação Geral");
        }

        private void btnNovoAluno_Click(object sender, EventArgs e)
        {
            LimparCamposCadastro();
            panelCadastro.Visible = true;
            alunoEditando = null;
        }

        private void LimparCamposCadastro()
        {
            txtNome.Text = "";
            txtIdade.Text = "";
            txtCurso.Text = "";
            txtMatricula.Text = "";
            txtNota.Text = "";
        }
    }

    public class Aluno
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Curso { get; set; }
        public int Matricula { get; set; }
        public int Nota { get; set; }
    }
}