using Application.DTOs.Validation;
using Application.Factories;
using Application.Interfaces.Factories;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidationController(IValidationFactory validationFactory) : Controller
    {
        private readonly IValidationFactory _validationFactory = validationFactory;


        [HttpGet]
        public ActionResult<List<ValidationRuleDTO>> ValidationRulesModel(string className)
        {
            className = "Domain.Models." + className;

            var type = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).FirstOrDefault(t => t.FullName == className);

            if (type == null)
            {
                return BadRequest("Classe não encontrada.");
            }

            #pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
            var method = typeof(ValidationFactory).GetMethod("ExtractValidationRules").MakeGenericMethod(type);
            #pragma warning restore CS8602 // Desreferência de uma referência possivelmente nula.

            var rules = method.Invoke(_validationFactory, null) as List<ValidationRuleDTO>;

            return Ok(rules);
        }
    }
}
