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
        private Aluno alunoEditando = null;

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
        }

        private void AtualizarListaAlunos()
        {
            listBoxAlunos.Items.Clear();
            foreach (var aluno in alunos)
            {
                listBoxAlunos.Items.Add(FormatarAluno(aluno));
            }
            lblContagemAlunos.Text = $"Alunos cadastrados: {alunos.Count}";
        }

        private string FormatarAluno(Aluno a)
        {
            return $"Nome : {a.Nome} | Idade: {a.Idade} | Curso: {a.Curso} | Matrícula: {a.Matricula} | Nota: {a.Nota}";
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisaNome.Text.Trim();
            string matriculaStr = txtPesquisaMatricula.Text.Trim();
            List<Aluno> resultados = new List<Aluno>();

            if (!string.IsNullOrEmpty(nome))
                resultados = alunos.Where(a => a.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();

            else if (int.TryParse(matriculaStr, out int matricula))
                resultados = alunos.Where(a => a.Matricula == matricula).ToList();

            if (resultados.Any())
            {
                listBoxAlunos.Items.Clear();
                foreach (var aluno in resultados)
                    listBoxAlunos.Items.Add(FormatarAluno(aluno));
            }
            else
            {
                MessageBox.Show("Nenhum aluno encontrado.");
                AtualizarListaAlunos();
            }
        }

        private void listBoxAlunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAlunos.SelectedIndex >= 0)
            {
                string linha = listBoxAlunos.SelectedItem.ToString();
                int matricula = int.Parse(linha.Split('|')[3].Split(':')[1].Trim());
                alunoEditando = alunos.FirstOrDefault(a => a.Matricula == matricula);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (alunoEditando != null)
            {
                txtNome.Text = alunoEditando.Nome;
                txtIdade.Text = alunoEditando.Idade.ToString();
                txtCurso.Text = alunoEditando.Curso;
                txtMatricula.Text = alunoEditando.Matricula.ToString();
                txtNota.Text = alunoEditando.Nota.ToString();
                groupBoxCadastro.Visible = true;
            }
            else
            {
                MessageBox.Show("Selecione um aluno para editar.");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (alunoEditando != null)
            {
                if (MessageBox.Show("Deseja realmente excluir o aluno?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    alunos.Remove(alunoEditando);
                    alunoEditando = null;
                    SalvarAlunos();
                    AtualizarListaAlunos();
                }
            }
            else
            {
                MessageBox.Show("Selecione um aluno para excluir.");
            }
        }

        private void btnVerificarAprovacao_Click(object sender, EventArgs e)
        {
            if (alunoEditando != null)
            {
                string status = alunoEditando.Nota >= 70 ? "Aprovado" : "Reprovado";
                MessageBox.Show($"Aluno está {status} com nota {alunoEditando.Nota}");
            }
            else
            {
                MessageBox.Show("Selecione um aluno para verificar aprovação.");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            int matriculaNova = int.Parse(txtMatricula.Text);

            if (alunos.Any(a => a.Matricula == matriculaNova && a != alunoEditando))
            {
                MessageBox.Show("Matrícula já cadastrada para outro aluno.");
                return;
            }

            if (alunoEditando != null)
            {
                alunoEditando.Nome = txtNome.Text;
                alunoEditando.Idade = int.Parse(txtIdade.Text);
                alunoEditando.Curso = txtCurso.Text;
                alunoEditando.Matricula = matriculaNova;
                alunoEditando.Nota = int.Parse(txtNota.Text);
                alunoEditando = null;
                MessageBox.Show("Aluno atualizado com sucesso.");
            }
            else
            {
                alunos.Add(new Aluno
                {
                    Nome = txtNome.Text,
                    Idade = int.Parse(txtIdade.Text),
                    Curso = txtCurso.Text,
                    Matricula = matriculaNova,
                    Nota = int.Parse(txtNota.Text)
                });
                MessageBox.Show("Aluno cadastrado com sucesso.");
            }

            SalvarAlunos();
            AtualizarListaAlunos();
            groupBoxCadastro.Visible = false;
        }

        private void btnNovoAluno_Click(object sender, EventArgs e)
        {
            alunoEditando = null;
            txtNome.Clear();
            txtIdade.Clear();
            txtCurso.Clear();
            txtMatricula.Clear();
            txtNota.Clear();
            groupBoxCadastro.Visible = true;
        }

        private void btnAtualizarRelatorio_Click(object sender, EventArgs e)
        {
            if (alunos.Count == 0)
            {
                lblRelatorio.Text = "Nenhum aluno cadastrado.";
                return;
            }

            int aprovados = alunos.Count(a => a.Nota >= 70);
            int reprovados = alunos.Count - aprovados;
            double media = alunos.Average(a => a.Nota);
            double maxNota = alunos.Max(a => a.Nota);
            double minNota = alunos.Min(a => a.Nota);

            lblRelatorio.Text = $"Total de alunos: {alunos.Count}\n" +
                                $"Aprovados: {aprovados} ({(aprovados * 100.0 / alunos.Count):0.##}%)\n" +
                                $"Reprovados: {reprovados} ({(reprovados * 100.0 / alunos.Count):0.##}%)\n\n" +
                                $"Nota média: {media:0.00}\nNota máxima: {maxNota}\nNota mínima: {minNota}";
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
