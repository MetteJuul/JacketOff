﻿using RestSharp;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIClient {
    public static class RestClientExtensions {

        //These two methods enables Json serialization and HTTP calls in one line 
        public static async Task<IRestResponse<T>> RequestAsync<T>(this RestClient client, Method method, string resource = null, object body = null) {
            
            var request = new RestRequest(resource, method, DataFormat.Json);
            if (body != null) {
                request.AddJsonBody(JsonSerializer.Serialize(body));
            }
            return await client.ExecuteAsync<T>(request, method);

        }

        public static async Task<IRestResponse> RequestAsync(this RestClient client, Method method, string resource = null, object body = null) {

            var request = new RestRequest(resource, method, DataFormat.Json);
            if (body != null) {

                request.AddJsonBody(JsonSerializer.Serialize(body));
            }
            return await client.ExecuteAsync(request, method);
        }
    }
}
