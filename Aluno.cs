using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadastroDeAlunos
{
    public class Aluno
    {
        private int matricula;
        private string nome;
        private double n1;
        private double n2;
        private double media;
        private string status;

        // Construtor vazio
        public Aluno() { }

        // Construtor com parâmetros (opcional, mas útil)
        public Aluno(int matricula, string nome, double n1, double n2, double media, string status)
        {
            this.matricula = matricula;
            this.nome = nome;
            this.n1 = n1;
            this.n2 = n2;
            this.media = media;
            this.status = status;
        }

        // Métodos Getters e Setters exigidos pelo estilo do professor
        public int getMatricula() { return matricula; }
        public void setMatricula(int matricula) { this.matricula = matricula; }

        public string getNome() { return nome; }
        public void setNome(string nome) { this.nome = nome; }

        public double getN1() { return n1; }
        public void setN1(double n1) { this.n1 = n1; }

        public double getN2() { return n2; }
        public void setN2(double n2) { this.n2 = n2; }

        public double getMedia() { return media; }
        public void setMedia(double media) { this.media = media; }

        public string getStatus() { return status; }
        public void setStatus(string status) { this.status = status; }
    }
}