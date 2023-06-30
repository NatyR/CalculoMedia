using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;
using Models;
namespace CalculoMedia.Controllers;

[ApiController]
[Route("[controller]")]

public class AlunoController : ControllerBase
{
    private readonly IAlunoService _alunoService;

    public AlunoController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    [HttpPost("calc")]
    public Response CalcularMedia([FromBody] Aluno aluno)
    {
        try
        {
            var request = _alunoService.CalcularMedia(aluno);
            return request;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}




