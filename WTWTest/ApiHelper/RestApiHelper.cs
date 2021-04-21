using RestSharp;

namespace WTWTest.ApiHelper
{
    public static class RestApiHelper
    {
        public static RestClient client;
        public static RestRequest request;

        public static RestClient SetUrl(string endpoint)
        {
            return client = new RestClient(endpoint);
        }

        public static RestRequest CreateRequest()
        {
            request = new RestRequest(Method.GET);
            return request;
        }

        public static IRestResponse GetResponse()
        {
            return client.Execute(request);
        }
    }
}
