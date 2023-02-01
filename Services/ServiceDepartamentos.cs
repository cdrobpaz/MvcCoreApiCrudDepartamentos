using MvcCoreApiCrudDepartamentos.Models;
using System.Net.Http.Headers;

namespace MvcCoreApiCrudDepartamentos.Services
{
    public class ServiceDepartamentos
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue header;
        public ServiceDepartamentos(string url)
        {
            this.UrlApi = url;
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }
        private async Task<T> GetDatosApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request); 
                if(response.IsSuccessStatusCode)
                {
                    T datos = await response.Content.ReadAsAsync<T>();
                    return datos;
                }
                else
                {
                    return default(T);
                }
            }
        }
        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            string request = "/api/departamentos";
            List<Departamento> empleados = await GetDatosApiAsync<List<Departamento>>(request);
            return empleados;
        }
        public async Task<Departamento> FindDepartamentoAsync(int id)
        {
            string request = "/api/departamentos/" + id;
            Departamento dept = await GetDatosApiAsync<Departamento>(request);
            return dept;
        }
        public async Task<List<Departamento>> FindLocalidadAsync(string localidad)
        {
            string request = "/api/departamentos/findlocalidad/" + localidad;
            List<Departamento> depts = await GetDatosApiAsync<List<Departamento>>(request);
            return depts;
        }
        public async Task<List<string>> GetLocalidadesAsync()
        {
            string request = "/api/departamentos/localidades";
            List<String> localidades = await GetDatosApiAsync<List<String>>(request);
            return localidades;
        }
    }
}
