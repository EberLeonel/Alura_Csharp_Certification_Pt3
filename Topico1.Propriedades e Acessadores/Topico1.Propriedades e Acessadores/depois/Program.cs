using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topico1
{
    class Program
    {
        static void Main(string[] args)
        {
            Funcionario vFuncionario = new Funcionario();
            vFuncionario.Salario = 1000;

            Console.WriteLine(vFuncionario.Salario);

            vFuncionario.Salario = -1200;
            Console.WriteLine(vFuncionario.Salario);
        }
    }

    class Funcionario
    {
        decimal salario;

        public decimal Salario //Encapsulamento do campo salario
        {
            get
            {
                return salario;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("salario não pode ser negativo");
                }
                salario = value;
            }
        }
        private decimal rg; //comando propfull 

        public decimal RG
        {
            get { return rg; }
            set { rg = value; }
        }

        public decimal Cpf { get; set; }

    }
}
