namespace Task
{
    public class HttpHandler
    {
        HttpResult _currentLog;
        public HttpResult CurrentLog { get { return _currentLog; } }

        public string Process(string url, string body, string response) // обработка хедлера 
        {
            var httpResult = new HttpResult
            {
                Url = url,
                RequestBody = body,
                ResponseBody = response
            };

            //очищаем secure данные в httpResult, либо создаем новый clearedHttpResult на основе httpResult
            var clearedHttpResult = new HttpResult();
            clearedHttpResult.Url = httpResult.Url;
            clearedHttpResult.RequestBody = httpResult.RequestBody;
            clearedHttpResult.ResponseBody = httpResult.ResponseBody;
            clearedHttpResult.SecureProperties();

            Log(clearedHttpResult);

            return response;
        }

        /// <summary>
        /// Логирует данные запроса, они должны быть уже без данных которые нужно защищать
        /// </summary>
        /// <param name="result"></param>
        protected void Log(HttpResult result)
        {
            _currentLog = new HttpResult
            {
                Url = result.Url,
                RequestBody = result.RequestBody,
                ResponseBody = result.ResponseBody
            };
        }
    }
}