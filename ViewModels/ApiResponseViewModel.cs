using Microsoft.AspNetCore.Mvc;

namespace EstoqueApi.ViewModel;

public class ApiResponseViewModel
{
        public static ObjectResult Ok<T>(T data)
        {
            return new OkObjectResult(new ResultViewModel<T>(data));
        }

        public static ObjectResult Created<T>(string location, T data)
        {
            return new CreatedResult(location, new ResultViewModel<T>(data));
        }

        public static ObjectResult BadRequest(string message = "Nao encontrado")
        {
            return new BadRequestObjectResult(new ResultViewModel<string>(message));
        }

        public static ObjectResult NotFound(string message)
        {
            return new NotFoundObjectResult(new ResultViewModel<string>(message));
        }

        public static ObjectResult InternalError(string message = "Erro interno no servidor")
        {
            return new ObjectResult(new ResultViewModel<string>(message))
            {
                StatusCode = 500
            };
       }
}