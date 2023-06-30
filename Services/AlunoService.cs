using System.Linq.Expressions;
using Models;
using Services.Interfaces;

namespace Services
{

    public class AlunoService : IAlunoService
    {
        private readonly IConfiguration Configuration;

        public AlunoService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Response CalcularMedia(Aluno aluno)
        {
                var media = (aluno.Notas.Sum()) / aluno.Notas.Count();

                Response response = new Response()
                {
                    Nome = aluno.Nome,
                    Media = media,
                    Situacao = media >= 6 ? "Aprovado" : "Reprovado"
                };

               return response;
            }
            
        }
    }
