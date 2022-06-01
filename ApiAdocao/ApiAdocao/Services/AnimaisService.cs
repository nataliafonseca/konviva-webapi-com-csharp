using ApiAdocao.Domain.DTO;
using ApiAdocao.Domain.Entity;
using PrimeiraWebAPI.Services.Base;

namespace ApiAdocao.Services
{
    public class AnimaisService
    {

        private static List<Animal> listaDeAnimais;
        private static int proximoId = 1;

        public AnimaisService()
        {
            if (listaDeAnimais == null)
            {
                listaDeAnimais = new()
                {
                    new Animal()
                    {
                        Id = proximoId++,
                        Nome = "Zé Snow",
                        Idade = 9,
                        Especie = "Cachorro",
                        DataNascimento = new DateTime(2012, 10, 04),
                        NivelFofura = 5,
                        NivelCarinho = 5,
                        Email = "nat@nat.nat"
                    },
                    new Animal()
                    {
                        Id = proximoId++,
                        Nome = "Lila",
                        Idade = 0,
                        Especie = "Cachorro",
                        DataNascimento = new DateTime(2022, 05, 01),
                        NivelFofura = 5,
                        NivelCarinho = 5,
                        Email = "nat@nat.nat"
                    }
                };
            };
        }

        public ServiceResponse<Animal> Cadastrar(AnimalCreateRequest model)
        {
            List<string> especies = new()
            {
                "Cachorro", "Gato", "Coelho", "Capivara"
            };
            if (!especies.Contains(model.Especie))
                return new ServiceResponse<Animal>("Especie inválida. Só são aceitos os valores \"Cachorro\", \"Gato\", \"Coelho\" ou \"Capivara\".");

            if (model.NivelFofura < 1 || model.NivelFofura > 5)
                return new ServiceResponse<Animal>("NivelFofura inválido. Deve ser informado um valor entre 1 e 5.");

            if (model.NivelCarinho < 1 || model.NivelCarinho > 5)
                return new ServiceResponse<Animal>("NivelCarinho inválido. Deve ser informado um valor entre 1 e 5.");

            if (!model.Email.Contains("@"))
                return new ServiceResponse<Animal>("Email inválido.");

            Animal novoAnimal = new()
            {
                Id = proximoId++,
                Nome = model.Nome,
                Especie = model.Especie,
                DataNascimento = model.DataNascimento,
                NivelFofura = (int)model.NivelFofura,
                NivelCarinho = (int)model.NivelCarinho,
                Email = model.Email,
            };

            listaDeAnimais.Add(novoAnimal);

            return new ServiceResponse<Animal>(novoAnimal);
        }

        public List<Animal> ListarTodos()
        {
            return listaDeAnimais;
        }

        public ServiceResponse<Animal> PesquisarPorId(int id)
        {
            var resultado = listaDeAnimais.Where(animal => animal.Id == id).FirstOrDefault();

            if (resultado == null)
                return new ServiceResponse<Animal>("Animal não encontrado");

            return new ServiceResponse<Animal>(resultado);
        }

        public ServiceResponse<Animal> PesquisarPorNome(string nome)
        {
            var resultado = listaDeAnimais.Where(animal => animal.Nome == nome).FirstOrDefault();

            if (resultado == null)
                return new ServiceResponse<Animal>("Animal não encontrado");

            return new ServiceResponse<Animal>(resultado);
        }

        public ServiceResponse<Animal> Editar(int id, AnimalUpdateRequest model)
        {
            var resultado = listaDeAnimais.Where(animal => animal.Id == id).FirstOrDefault();

            if (resultado == null)
                return new ServiceResponse<Animal>("Animal não encontrado");

            if (model.NivelFofura < 1 || model.NivelFofura > 5)
                return new ServiceResponse<Animal>("NivelFofura inválido. Deve ser informado um valor entre 1 e 5.");

            if (model.NivelCarinho < 1 || model.NivelCarinho > 5)
                return new ServiceResponse<Animal>("NivelCarinho inválido. Deve ser informado um valor entre 1 e 5.");

            resultado.NivelFofura = (int)model.NivelFofura;
            resultado.NivelCarinho = (int)model.NivelCarinho;

            return new ServiceResponse<Animal>(resultado);
        }

        public ServiceResponse<bool> Deletar(int id)
        {
            var resultado = listaDeAnimais.Where(animal => animal.Id == id).FirstOrDefault();

            if (resultado == null)
                return new ServiceResponse<bool>("Animal não encontrado");

            listaDeAnimais.Remove(resultado);

            return new ServiceResponse<bool>(true);
        }
    }
}