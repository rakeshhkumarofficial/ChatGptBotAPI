using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace ChatGptBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetAIBasedResult(string SearchText)
        {
            // OpenAI API key
            string APIKey = "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";
            string answer = string.Empty;

            // Create an instance of the OpenAIAPI class with the API key
            var openai = new OpenAIAPI(APIKey);

            // Create a new CompletionRequest object with the input prompt and other parameters
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = SearchText;
            completion.Model = OpenAI_API.Models.Model.DavinciText;
            completion.MaxTokens = 500;

            // Call the CreateCompletionAsync method of the openai.Completions object to send the API request
            var result = openai.Completions.CreateCompletionAsync(completion);

            // Extract the response text from the CompletionResponse object and assign it to the 'answer' variable
            foreach (var item in result.Result.Completions) { 
            answer = item.Text;
            }

            // Return a HTTP 200 OK response to the client with the generated response as the response body
            return Ok(answer);
        }
    }
}
