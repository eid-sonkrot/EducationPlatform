using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenAI_API;
using OpenAI_API.Completions;
using RestSharp;


namespace Domain.Service
{
    public class OpenAIService
    {
        private readonly string _apiKey;
        private readonly OpenAIAPI _openAIAPI;
        public OpenAIService(IConfiguration configuration)
        {
            _apiKey = configuration["OpenAI:ApiKey"];
            _openAIAPI = new OpenAIAPI(_apiKey);
        }

        public async Task<string> AskQuestionAsync(string question)
        {
            CompletionRequest completion = new CompletionRequest();
            string answer = string.Empty;
            completion.Prompt = question;
            completion.Model = OpenAI_API.Models.Model.DefaultChatModel;
            completion.MaxTokens = 200;
            var result =await _openAIAPI.Completions.CreateCompletionAsync(completion);
            if (result != null)
            {
                foreach (var item in result.Completions)
                {
                    answer = item.Text;
                }
            }
            return answer;
        }
    }
}
