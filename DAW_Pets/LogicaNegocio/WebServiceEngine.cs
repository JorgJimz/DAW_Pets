using DAW_Pets.LogicaNegocio.Interface;
using DAW_Pets.Models.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAW_Pets.LogicaNegocio
{
    public class WebServiceEngine : IWebServiceEngine
    {
        private readonly IConfiguration _config;

        public WebServiceEngine(IConfiguration _config)
        {
            this._config = _config;
        }

        public async Task<WS_Response<T>> GetAll_Service<T>(string url)
        {
            WS_Response<T> response = new WS_Response<T>();
            var uri = string.Format("{0}{1}", _config.GetValue<string>("Servicios:Servidor"), _config.GetValue<string>(url));
            Header header = new Header();
            try
            {
                var list = new List<T>();
                using (var httpClient = new HttpClient())
                {
                    using (var data = await httpClient.GetAsync(uri))
                    {
                        string apiResponse = await data.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<T>>(apiResponse);
                        response.Listado = list;
                        header.CodigoRetorno = HeaderEnum.Correcto.ToString();
                        header.DescRetorno = string.Empty;
                    }
                }
            }
            catch (Exception e)
            {
                header.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                header.DescRetorno = e.Message;
            }

            response.Header = header;
            return response;
        }

        public async Task<WS_Response<T>> GetById_Service<T>(string url, string id)
        {
            WS_Response<T> response = new WS_Response<T>();
            var obj = (T)Activator.CreateInstance(typeof(T));
            Header header = new Header();
            try
            {
                var uri = string.Format("{0}{1}{2}", _config.GetValue<string>("Servicios:Servidor"), _config.GetValue<string>(url), id);
                using (var httpClient = new HttpClient())
                {
                    using (var data = await httpClient.GetAsync(uri))
                    {
                        string apiResponse = await data.Content.ReadAsStringAsync();
                        obj = JsonConvert.DeserializeObject<T>(apiResponse);
                        response.Objeto = obj;
                        header.CodigoRetorno = HeaderEnum.Correcto.ToString();
                        header.DescRetorno = string.Empty;
                    }
                }
            }
            catch (Exception e)
            {
                header.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                header.DescRetorno = e.Message;
            }

            response.Header = header;
            return response;
        }


        public async Task<WS_Response<T>> Post_Service<T>(string url, T entity)
        {
            WS_Response<T> response = new WS_Response<T>();            
            try
            {
                var uri = string.Format("{0}{1}", _config.GetValue<string>("Servicios:Servidor"), _config.GetValue<string>(url));
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

                    using (var request = await httpClient.PostAsync(uri, content))
                    {
                        string apiResponse = await request.Content.ReadAsStringAsync();
                        response = JsonConvert.DeserializeObject<WS_Response<T>>(apiResponse);                      
                    }
                }
            }
            catch (Exception e)
            {
                response.Header.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                response.Header.DescRetorno = e.Message;
            }

            return response;
        }

        public async Task<WS_Response<T>> Put_Service<T>(string url, T entity, string Id)
        {
            WS_Response<T> response = new WS_Response<T>();
            try
            {
                var uri = string.Format("{0}{1}{2}", _config.GetValue<string>("Servicios:Servidor"), _config.GetValue<string>(url), Id);
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

                    using (var request = await httpClient.PutAsync(uri, content))
                    {
                        string apiResponse = await request.Content.ReadAsStringAsync();
                        response = JsonConvert.DeserializeObject<WS_Response<T>>(apiResponse);
                    }
                }
            }
            catch (Exception e)
            {
                response.Header.CodigoRetorno = HeaderEnum.Incorrecto.ToString();
                response.Header.DescRetorno = e.Message;
            }

            return response;
        }

    }

}
