using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            string opcaoUsuario = ObterOpcaoUsuario();
            int indiceAluno = 0;

            while (opcaoUsuario.ToUpper() != "X")
            { // já pega o X maiúsculo
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine("Informe a nota do aluno:");
                        // Usando Parse, a conversão é feita, mas pode causar um erro caso insiram um valor errado:
                        // decimal nota = decimal.Parse(Console.ReadLine());
                        // Usando TryParse, a conversão pode ser feita se o retorno for true:
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota)){ // Se ele conseguir fazer o parse, ele cria a variável decimal nota com o valor convertido
                           aluno.Nota = nota; 
                        } else {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }
                           alunos[indiceAluno] = aluno;
                           indiceAluno++;
                        break;
                    case "2":
                        foreach(var pessoa in alunos){
                            if(!string.IsNullOrEmpty(pessoa.Nome))
                            {
                                Console.WriteLine($"ALUNO: {pessoa.Nome} - NOTA: {pessoa.Nota}");
                            }
                        }                    
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var numAlunos = 0;
                        for (int i = 0; i < alunos.Length; i++){
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                numAlunos++;
                            }
                        }
                        var mediaGeral = notaTotal / numAlunos;
                        Conceito conceitoGeral;

                        // aplicando o enum para semântica das notas:
                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }                        

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");                  
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(); // mostra uma excessão dizendo que o valor informado está fora das opções
                }

                // Pede novamente qual item será inserido
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine(); // simplesmente deixa uma linha em branco
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine(); // Obter informação que o usuário digitar
            return opcaoUsuario;
        }
    }
}
