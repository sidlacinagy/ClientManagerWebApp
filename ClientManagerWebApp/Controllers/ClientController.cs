using ClientManager.Api.Entities;
using ClientManager.Api.Repositories.Interfaces;
using ClientManager.Shared.Dtos;
using ClientManager.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ClientManager.Api.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository ClientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            this.ClientRepository = clientRepository;
        }

        public static ClientDto ConvertToDtoFromClient(Client client)
        {
            if (null == client.FirstName) client.FirstName = "";
            if (null == client.LastName) client.LastName = "";

            return new ClientDto
            {
                IdNumber = client.IdNumber,
                FirstName = client.FirstName,
                LastName = client.LastName,
                PhoneNumber = client.PhoneNumber,
                Address = client.Address,
                ClientType = client.ClientType,
            };
        }

        [HttpGet("getall")]
        public IActionResult GetAllClients()
        {
           IEnumerable<Client> clients = this.ClientRepository.GetClients();
           List<ClientDto> clientDtos = new List<ClientDto>();
           foreach(Client client in clients)
            {
                ClientDto dto = ConvertToDtoFromClient(client);
                clientDtos.Add(dto);
            }
            return Ok(clientDtos);
        }

        [HttpPost("create")]
        public IActionResult CreateClient(ClientDto clientDto)
        {
            try
            {
                this.ClientRepository.CreateClient(clientDto);
                return Ok(clientDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("update")]
        public IActionResult UpdateClient(ClientDto clientDto)
        {
            try
            {
                this.ClientRepository.UpdateClient(clientDto);
                return Ok(clientDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("delete/{Id}")]
        public IActionResult DeleteClient(string Id)
        {
            try
            {
                this.ClientRepository.DeleteClient(Id);
                return Ok(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("search")]
        public IActionResult SearchClient(SearchFilterDto searchFilterDto)
        {
            IEnumerable<Client> clients = this.ClientRepository.SearchClient(searchFilterDto);
            List<ClientDto> clientDtos = new List<ClientDto>();
            foreach (Client client in clients)
            {
                ClientDto dto = ConvertToDtoFromClient(client);
                clientDtos.Add(dto);
            }
            return Ok(clientDtos);
        }

    }
}
