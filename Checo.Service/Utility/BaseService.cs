using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Checo.Service
{
    public class BaseService
    {
        protected IMapper _mapper;

        public async Task<HttpResponseMessage> PostAsync(object data, string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    HttpContent content = new StringContent(json);
                    return await client.PostAsync(url, content);
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}