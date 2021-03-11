using System;
using System.Text;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DataLuna.Back.Common.DemoParserProxy;
using DataLuna.Back.Common.Exceptions;

namespace DataLuna.Back.Infrastructure.DemoParse
{
    public class DemoParseProvider : IDemoParseProvider
    {
        private readonly ILogger<IDemoParseProvider> _logger;
        private readonly IHttpClientFactory _clientFactory;
        public DemoParseProvider(ILogger<IDemoParseProvider> logger, IHttpClientFactory clientFactory)
            => (_logger, _clientFactory) = (logger, clientFactory);

        public async Task<GetStatusResponse[]> GetDemosStatus()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/v1/state");
            var client = _clientFactory.CreateClient(Constants.Clients.DemoParseClient);

            try
            {
                var response = await client.SendAsync(request);
                string responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<GetStatusResponse[]>(responseString);
                }

                throw new HttpStatusCodeException(response.StatusCode, responseString);
            }
            catch (HttpStatusCodeException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<List<DemoParseResponse>> ParseDemo(DemoParseCommand command)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/demodata")
            {
                Content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json")
            };
            var client = _clientFactory.CreateClient(Constants.Clients.DemoParseClient);

            try
            {
                var response = await client.SendAsync(request);
                string responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<DemoParseResponse>>(responseString);
                }

                throw new HttpStatusCodeException(response.StatusCode, responseString);
            }
            catch (HttpStatusCodeException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<PreParseResponse[]> PreParseDemo(PreParseCommand command)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/preparse")
            {
                Content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json")
            };
            var client = _clientFactory.CreateClient(Constants.Clients.DemoParseClient);

            try
            {
                var response = await client.SendAsync(request);
                string responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<PreParseResponse[]>(responseString);
                }

                throw new HttpStatusCodeException(response.StatusCode, responseString);
            }
            catch (HttpStatusCodeException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}