using ClientManager.Shared.Dtos;

namespace ClientManager.Web.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetClients();
        Task<IEnumerable<ClientDto>> SearchClients(SearchFilterDto searchFilterDto);
        Task<string> DeleteClient(string Id);
        Task<ClientDto> UpdateClient (ClientDto dto);
        Task<ClientDto> CreateClient(ClientDto dto);
    }
}
