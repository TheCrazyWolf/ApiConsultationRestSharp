using ConsoleApp22.Models;
using RestSharp;

namespace ConsoleApp22.Api
{
    internal class Catalog : BaseApiController
    {
        public Catalog(string url) : base(url)
        {
        }

        public RestResponse AddGoods(string token, Goods goods)
        {
                           /* Название и контроллера метода в API и тип запроса*/
            _request = new RestRequest("/Catalog/AddGood", Method.Post);

            /* Передача параметра в заголовке */
            _request.AddHeader("token", token);

            /* Передача параметра в теле */
            _request.AddBody(goods);
            /* Выполнение запрса */
            _responce = _client.Execute(_request);
            /* Возврат результата */
            return _responce;
        }

        public RestResponse GetGoods(string token)
        {
            _request = new RestRequest("/Catalog/GetGoods", Method.Get);

            _request.AddParameter("token", token);

            _responce = _client.Execute(_request);

            return _responce;
        }

        public RestResponse DeleteGoods(string token, string guid)
        {
            _request = new RestRequest("/Catalog/DeleteGood", Method.Delete);

            _request.AddHeader("token", token);
            _request.AddHeader("guidGood", guid);

            _responce = _client.Execute(_request);
            return _responce;
        }
    }
}
