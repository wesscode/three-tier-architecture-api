using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiThreeTier.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected bool OperacaoValida()
        {
            return true;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return new ObjectResult(result);
            }

            return BadRequest(new
            {
                //error = obter erros
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) //Notificar erros
            {

            }

            return CustomResponse();
        }

        protected void NotificarErro(string mensagem)
        {

        }
    }
}