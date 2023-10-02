using RestSharp;

namespace ConsoleApp22.Api
{
    internal class BaseApiController
    {
        protected string _connectionString;
        protected RestClient _client; /* Клиент для работы с API */
        protected RestRequest _request; /* Текущий запрос  */
        protected RestResponse _responce; /* И текущий ответ */

        public BaseApiController(string url)
        {
            _connectionString = url;

            _client = new RestClient(_connectionString);

        }
    }
}
