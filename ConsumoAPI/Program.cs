using modelos;
using Newtonsoft.Json;

namespace ConsumoAPI
{
    internal class Program
    {
        static async Task Main()
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com/users") };
            var resposta = await client.GetAsync("users");
            var conteudo = await resposta.Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<User[]>(conteudo);


            foreach (var item in users)
            {
                Console.WriteLine(
                    $"Nome: {item.Name}, " +
                    $"Email: {item.Email}, " +
                    $"Cidade: {item.Address.City}, " +
                    $"Empresa: {item.Company.Name}."
                    );
            }


        }
    }
}