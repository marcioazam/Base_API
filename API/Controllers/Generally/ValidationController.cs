using Application.DTOs.Validations;
using Application.Factories;
using Application.Interfaces.Factories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace API.Controllers.Generally
{
    [ApiController]
    [Route("[controller]")]
    public class ValidationController(IValidationFactory validationFactory) : Controller
    {
        private readonly IValidationFactory _validationFactory = validationFactory;
        private static readonly ConcurrentDictionary<string, Type> TypeCache = new();

        // Talvez este nao sej ao melhor jeito para buscar regras de validação, porem so saberamos apos utilização em grande escala.
        // Se necessario pode trocar isso por um dicionario declarando cada classe e suas regras de validação.
        [HttpGet]
        public ActionResult<List<ValidationRuleDTO>> ValidationRulesModel(string className)
        {
            className = "Domain.Entities." + className;

            // Utilizamos um ConcurrentDictionary para armazenar o mapeamento entre os nomes das classes e os tipos correspondentes.
            // Isso garante que a busca pelo tipo seja feita apenas uma vez por classe e que o resultado seja armazenado em cache para futuras requisições.
            var type = TypeCache.GetOrAdd(className, key =>
            {
#pragma warning disable CS8603 // Possível retorno de referência nula.
                return AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .FirstOrDefault(t =>
                    {
                        if (t is null)
                        {
                            throw new ArgumentNullException(nameof(t));
                        }
                        return t.FullName == key;
                    });
#pragma warning restore CS8603 // Possível retorno de referência nula.
            });

            if (type == null)
            {
                return BadRequest("Classe não encontrada.");
            }

#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
            var method = typeof(ValidationFactory).GetMethod("ExtractValidationRules").MakeGenericMethod(type);
#pragma warning restore CS8602 // Desreferência de uma referência possivelmente nula.

            var rules = method.Invoke(_validationFactory, null) as List<ValidationRuleDTO>;

            if (rules == null)
            {
                return BadRequest("Falha ao extrair regras de validação.");
            }

            return Ok(rules);
        }
    }
}
