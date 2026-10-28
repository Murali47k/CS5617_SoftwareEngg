using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using System.Globalization;

namespace AzureFunApp
{
    public class SquareNumber
    {
        [Function("SquareNumber")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "SquareNumber")] HttpRequest req)
        {
            string? input = req.Query["number"];

            if (string.IsNullOrEmpty(input) ||
                !double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double number) ||
                !double.IsFinite(number))
            {
                return new BadRequestObjectResult(new { error = "Please provide a valid finite number using '?number=value'." });
            }

            double square = number * number;

            return new OkObjectResult(new { number, square });
        }
    }
}