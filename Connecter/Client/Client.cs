using Connecter.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;

namespace Connecter.Client
{
    public class Client<T> : IClient<T> where T : class
    {
        protected readonly HttpClient _HttpClient;
        protected readonly ServiceSetting _ServiceSetting;
        protected readonly string _ControllerName;

        public Client(HttpClient httpClient, IOptions<ServiceSetting> serviceSetting, IHttpContextAccessor httpContext)
        {
            httpClient.BaseAddress = new Uri(serviceSetting.Value.ClientHost);
            _HttpClient = httpClient;
            _ServiceSetting = serviceSetting.Value;
            //var AccessToken = Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.GetTokenAsync(httpContext.HttpContext, "access_token").Result;
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            _ControllerName = typeof(T).Name;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            HttpResponseMessage response = await _HttpClient.GetAsync($"{_ControllerName}/GetAll");
            if (response.IsSuccessStatusCode)
            {
                string objReponse = await response.Content.ReadAsStringAsync();
                IEnumerable<T> objResult = JsonConvert.DeserializeObject<IEnumerable<T>>(objReponse);
                return objResult;
            }
            return null;
        }

        public async Task<T> GetByID(int Id)
        {
            HttpResponseMessage response = await _HttpClient.GetAsync($"{_ControllerName}/GetByID?Id=" + Id);
            if (response.IsSuccessStatusCode)
            {
                var objReponse = await response.Content.ReadAsStringAsync();
                var objResult = JsonConvert.DeserializeObject<T>(objReponse);
                return objResult;
            }
            return default(T);
        }
        public async Task<Response> Insert(T objDto)
        {
            string result = String.Empty;
            JObject resultt = new JObject();

            StringContent content = new StringContent(JsonConvert.SerializeObject(objDto), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage Response = await _HttpClient.PostAsync($"{_ControllerName}/Insert", content);
            if (Response.IsSuccessStatusCode)
            {
                result = await Response.Content.ReadAsStringAsync();
                return new Response
                {
                    IsSuccess = true,
                    StatusCode = Response.StatusCode,
                    Result = JObject.Parse(result)
                };
            }
            else
            {
                result = await Response.Content.ReadAsStringAsync();

                Failed Failed = JsonConvert.DeserializeObject<Failed>(result);

                return new Response
                {
                    IsSuccess = false,
                    StatusCode = Response.StatusCode,
                    Result = Failed.Errors
                };
            }
        }
        public async Task<Response> Update(T objDto)
        {
            string result = String.Empty;
            JObject resultt = new JObject();

            StringContent content = new StringContent(JsonConvert.SerializeObject(objDto), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage Response = await _HttpClient.PostAsync($"{_ControllerName}/Update", content);
            if (Response.IsSuccessStatusCode)
            {
                result = await Response.Content.ReadAsStringAsync();
                //return JsonConvert.DeserializeObject<DTO.Area>(result);
                return new Response
                {
                    IsSuccess = true,
                    StatusCode = Response.StatusCode,
                    Result = resultt
                };
            }
            else
            {
                result = await Response.Content.ReadAsStringAsync();

                Failed Failed = JsonConvert.DeserializeObject<Failed>(result);

                return new Response
                {
                    IsSuccess = false,
                    StatusCode = Response.StatusCode,
                    Result = Failed.Errors
                };
            }
        }
        public async Task<T> Delete(T objDto)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(_ServiceSetting.ClientHost + $"{_ControllerName}/Delete"),
                Content = new StringContent(JsonConvert.SerializeObject(objDto), System.Text.Encoding.UTF8, "application/json")
            };

            HttpResponseMessage Response = await _HttpClient.SendAsync(request);
            if (Response.IsSuccessStatusCode)
            {
                string result = await Response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
            else
            {
                return default(T);
            }
        }
    }

}
