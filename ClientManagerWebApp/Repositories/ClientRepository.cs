using ClientManager.Api.Database;
using ClientManager.Api.Entities;
using ClientManager.Api.Repositories.Interfaces;
using ClientManager.Shared.Dtos;
using ClientManager.Shared.Enums;

namespace ClientManager.Api.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientManagerDbContext clientManagerDbContext;

        public ClientRepository(ClientManagerDbContext clientManagerDbContext)
        {
           this.clientManagerDbContext = clientManagerDbContext;
        }
        public static Client ConvertToClientFromDto(ClientDto clientDto)
        {
           
            //company client
            if (clientDto.ClientType.Equals(ClientTypes.Company))
            {
                try
                {
                    return Client.CreateCompanyClient(clientDto.IdNumber, clientDto.PhoneNumber, clientDto.Address, clientDto.LastName, clientDto.FirstName);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            //resident client
            else if (clientDto.ClientType.Equals(ClientTypes.Residential))
            {
                try
                {
                    return Client.CreateResidentClient(clientDto.IdNumber, clientDto.PhoneNumber, clientDto.Address, clientDto.LastName, clientDto.FirstName);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                throw new ArgumentException("Client Type doesn't exist"); 
            }
        }

        public Client CreateClient(ClientDto clientDto)
        {
            Client? client = null;
            try
            {
                client = ConvertToClientFromDto(clientDto);
            }
            catch(Exception ex)
            {
                throw;
            }

           if (this.clientManagerDbContext.Client.Find(client.IdNumber) != null)
           {
                throw new ArgumentException("User already exists");
           }
           this.clientManagerDbContext.Client.Add(client);
           this.clientManagerDbContext.SaveChanges();
           return client;

        }

        public Client DeleteClient(string Id)
        {
            Client? client = this.clientManagerDbContext.Client.Find(Id);
            if (client == null)
            {
                throw new ArgumentException("User doesn't exist");
            }
            this.clientManagerDbContext.Client.Remove(client);
            this.clientManagerDbContext.SaveChanges();
            return client;

        }

        public IEnumerable<Client> GetClients()
        {
            List<Client> clients = this.clientManagerDbContext.Client.ToList();
            return clients;
        }

        public IEnumerable<Client> SearchClient(SearchFilterDto searchFilterDto)
        {
            if (searchFilterDto.FirstName == null) searchFilterDto.FirstName = "";
            if (searchFilterDto.LastName == null) searchFilterDto.LastName = "";
            if (searchFilterDto.IdNumber == null) searchFilterDto.IdNumber = "";

            List<Client> clients = new List<Client>();
            if (searchFilterDto.ClientType == null)
            {
                clients = this.clientManagerDbContext.Client
                    .Where(c => c.FirstName.StartsWith(searchFilterDto.FirstName) 
                    && c.LastName.StartsWith(searchFilterDto.LastName) 
                    && c.IdNumber.StartsWith(searchFilterDto.IdNumber)).ToList();
            }
            else
            {
                clients = this.clientManagerDbContext.Client
                   .Where(c => c.FirstName.StartsWith(searchFilterDto.FirstName) 
                   && c.LastName.StartsWith(searchFilterDto.LastName) 
                   && c.ClientType.Equals(searchFilterDto.ClientType)
                   && c.IdNumber.StartsWith(searchFilterDto.IdNumber)).ToList();
            }
            
            return clients;
        }

        public Client UpdateClient(ClientDto clientDto)
        {
            Client? client = null;
            try
            {
                client = ConvertToClientFromDto(clientDto);
            }
            catch (Exception ex)
            {
                throw;
            }

            if (this.clientManagerDbContext.Client.Find(client.IdNumber) == null)
            {
                throw new ArgumentException("User doesn't exist / cannot modify Id");
            }
            this.clientManagerDbContext.ChangeTracker.Clear();
            this.clientManagerDbContext.Client.Update(client);
            this.clientManagerDbContext.SaveChanges();
            return client;

        }

        public Client GetClient(string Id)
        {
            Client? client = null;

            client = this.clientManagerDbContext.Client.Find(Id);

            if (client == null)
            {
                throw new ArgumentException("User doesn't exist");
            }

            return client;

        }

    }
}
