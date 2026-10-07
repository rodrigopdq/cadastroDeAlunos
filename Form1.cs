using System;
using System.Data;
using System.Windows.Forms;

namespace cadastroDeAlunos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Carrega os dados no grid assim que a tela abre
            AtualizarGrid();
        }

        // --- BOTÃO SALVAR ---
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Equals(""))
            {
                MessageBox.Show("Informe o nome do aluno.");
                return;
            }

            try
            {
                // Pega as notas digitadas
                double n1 = double.Parse(textBox3.Text);
                double n2 = double.Parse(textBox4.Text);

                // Calcula a média automaticamente
                double media = (n1 + n2) / 2.0;

                // Exibe o resultado na caixa de texto da média (textBox5)
                textBox5.Text = media.ToString("F2");

                // Define o status automaticamente com base na média
                string status = media >= 6.0 ? "Aprovado" : "Reprovado";

                // Cria o objeto Aluno com os dados calculados
                Aluno alunoReg = new Aluno(
                    int.Parse(textBox1.Text),   // Matrícula
                    textBox6.Text,              // Nome
                    n1,                         // N1
                    n2,                         // N2
                    media,                      // Média calculada
                    status                      // Status automático
                );

                // Salva no banco
                AlunoDB alunoBD = new AlunoDB();
                alunoBD.IncluirAluno(alunoReg);

                MessageBox.Show("Registro salvo com sucesso.");

                button2.PerformClick(); // Limpa e atualiza a tela automaticamente
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
        }

        // --- BOTÃO LIMPAR / ATUALIZAR ---
        private void button2_Click(object sender, EventArgs e)
        {
            AlunoDB alunoBD = new AlunoDB();

            textBox1.Text = "";
            textBox6.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            textBox1.Focus();
            dataGridView1.DataSource = alunoBD.getAlunos();
        }

        // --- BOTÃO SAIR ---
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AtualizarGrid()
        {
            try
            {
                AlunoDB alunoDB = new AlunoDB();
                dataGridView1.DataSource = alunoDB.getAlunos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }

        
    }
}