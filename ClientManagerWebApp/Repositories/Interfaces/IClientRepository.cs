using ClientManager.Api.Entities;
using ClientManager.Shared.Dtos;
using ClientManager.Shared.Enums;

namespace ClientManager.Api.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Client CreateClient(ClientDto clientDto);

        Client UpdateClient(ClientDto clientDto);

        Client DeleteClient(string Id);

        Client GetClient(string Id);

        IEnumerable<Client> GetClients();

        IEnumerable<Client> SearchClient(SearchFilterDto searchFilterDto);

    }
}
