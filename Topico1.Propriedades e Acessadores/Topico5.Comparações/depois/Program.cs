using System;
using System.Collections.Generic;

namespace Topico5
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno aluno1 = new Aluno
            {
                Nome = "José da Silva",
                DataNascimento = new DateTime(1990, 1, 1)
            };

            Aluno aluno2 = new Aluno
            {
                Nome = "José da Silva",
                DataNascimento = new DateTime(1995, 1, 1)
            };

            Aluno aluno3 = new Aluno
            {
                Nome = "josé da silva",
                DataNascimento = new DateTime(1990, 1, 1)
            };

            Console.WriteLine(aluno1.Equals(aluno2));
            Console.WriteLine(aluno1.Equals(aluno3));
            Console.WriteLine(aluno2.Equals(aluno3));

            Aluno aluno4 = new Aluno
            {
                Nome = "ANDRÉ DOS SANTOS",
                DataNascimento = new DateTime(1970, 1, 1)
            };

            Aluno aluno5 = new Aluno
            {
                Nome = "Ana de Souza",
                DataNascimento = new DateTime(1990, 1, 1)
            };

            List<Aluno> alunos = new List<Aluno>()
            {
                aluno1,
                aluno2,
                aluno3,
                aluno4,
                aluno5
            };

            alunos.Sort();
            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }
        }
    }

    class Aluno : IComparable
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}, Data nascimento: {DataNascimento:dd/MM/yyyy}";
        }

        public override bool Equals(object obj) //command override equals
        {
            Aluno vOutroAluno = obj as Aluno;
            if (vOutroAluno == null)
            {
                return false;
            }
            return this.Nome.Equals(vOutroAluno.Nome, StringComparison.CurrentCultureIgnoreCase)
                && this.DataNascimento.Equals(vOutroAluno.DataNascimento);
        }

        public override int GetHashCode()
        {
            var hashCode = -1523756618;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + DataNascimento.GetHashCode();
            return hashCode;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Aluno outroObj = obj as Aluno;
            if (outroObj == null)
            {
                throw new ArgumentException("Objeto não é um aluno");
            }

            int resultado = this.DataNascimento.CompareTo(outroObj.DataNascimento);
            if (resultado == 0)
            {
                this.Nome.CompareTo(outroObj.Nome);
            }
            return resultado;
        }
    }
}