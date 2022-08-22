using ClientManager.Shared.Dtos;
using ClientManager.Web.Services.Interfaces;
using System.Net.Http.Json;

namespace ClientManager.Web.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient httpClient;

        public ClientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ClientDto> CreateClient(ClientDto Dto)
        {
            try
            {
                var response = await this.httpClient.PostAsJsonAsync($"api/client/create", Dto);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ClientDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> DeleteClient(string Id)
        {
            try
            {
                var response = await this.httpClient.GetAsync($"api/client/delete/"+Id);

                if (response.IsSuccessStatusCode)
                {

                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ClientDto>> GetClients()
        {
            try
            {
                var response = await this.httpClient.GetAsync($"api/client/getall");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ClientDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<ClientDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ClientDto>> SearchClients(SearchFilterDto searchFilterDto)
        {
            try
            {
                var response = await this.httpClient.PostAsJsonAsync($"api/client/search", searchFilterDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ClientDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ClientDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClientDto> UpdateClient(ClientDto Dto)
        {
            try
            {
                var response = await this.httpClient.PostAsJsonAsync($"api/client/update", Dto);

                if (response.IsSuccessStatusCode)
                {     
                    return await response.Content.ReadFromJsonAsync<ClientDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
