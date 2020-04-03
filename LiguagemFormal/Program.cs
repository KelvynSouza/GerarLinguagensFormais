using System;
using System.Collections.Generic;
using System.Linq;

namespace LiguagemFormal
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Criador de linguagens formais");
                Console.WriteLine("Digite as entradas, para proxima etapa envie vazio");
                Console.WriteLine("para encerrar programa digite 'exit'");
                var variaveisIniciais = new List<String>();
                string vInicio = "";
                do
                {
                    vInicio = Console.ReadLine();
                    if (vInicio == "exit")
                        Environment.Exit(0);

                    variaveisIniciais.Add(vInicio);
                } while (vInicio != "");



                var regrasVariaveis = new List<RegrasDto>();
                string vRegra = "";
                do
                {
                    var regra = new RegrasDto();
                    Console.WriteLine("Digite a variavel da regra, para encerrar envie vazio");
                    var vari = Console.ReadLine();
                    if (vari == "")
                        break;
                    regra.Variavel = Convert.ToChar(vari);
                    Console.WriteLine("Digite a regra, para encerrar envie vazio");
                    vRegra = Console.ReadLine();
                    if (vRegra == "")
                        break;
                    regra.Regra = vRegra;
                    regrasVariaveis.Add(regra);


                } while (true);

                //Limpar listas
                variaveisIniciais.RemoveAll(i => i.Equals("") || !i.Any(char.IsUpper));
                regrasVariaveis.RemoveAll(i => i.Regra.Equals("") || i.Variavel.Equals(""));




                var rnd = new Random();
                var vInicioRnd = rnd.Next(0, variaveisIniciais.Count - 1);

                var cont = 0;
                var autResult = variaveisIniciais[vInicioRnd];
                Console.WriteLine(autResult);
                while (cont < 20)
                {


                    for (int i = 0; i < autResult.Length; i++)
                    {
                        var aux = autResult.ToCharArray();
                        var a = aux[i];
                        var variaveisEncontradas = regrasVariaveis.FindAll(i => i.Variavel == a);
                        if (variaveisEncontradas.Count == 0)
                            continue;
                        if(autResult.Count(c => char.IsUpper(c))>1) 
                        {
                            variaveisEncontradas = variaveisEncontradas.FindAll(i => !i.Regra.All(char.IsUpper));
                        }
                        else
                        {
                            variaveisEncontradas = variaveisEncontradas.FindAll(i => i.Regra.Any(char.IsUpper) || (i.Regra.Any(char.IsUpper) && !i.Regra.Any(char.IsUpper)));
                        }
                        
                        if (variaveisEncontradas.Count == 0)
                            continue;
                        var regraUtilizar = variaveisEncontradas[rnd.Next(0, variaveisEncontradas.Count)];
                        autResult = autResult.Remove(i, 1);
                        autResult = autResult.Insert(i, regraUtilizar.Regra);
                        break;
                    }
                    cont += 1;
                    Console.WriteLine(autResult);
                }

            } while (true);
        }
    }
}
