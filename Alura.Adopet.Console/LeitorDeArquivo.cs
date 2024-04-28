using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    internal class LeitorDeArquivo
    {
        public List<Pet> RealizaLeitura(string caminhoDoArquivoASerExibido)
        {
            List<Pet> ListaDePets = new List<Pet>();
            using (StreamReader sr = new StreamReader(caminhoDoArquivoASerExibido))
            {
                System.Console.WriteLine("----- Dados a serem importados -----");
                while (!sr.EndOfStream)
                {
                    // separa linha usando ponto e vírgula
                    string[]? propriedades = sr.ReadLine().Split(';');
                    // cria objeto Pet a partir da separação
                    Pet pet = new Pet(Guid.Parse(propriedades[0]),
                    propriedades[1],
                    int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro
                    );
                    ListaDePets.Add(pet);
                }
            }
            return ListaDePets;
        }
    }
}
