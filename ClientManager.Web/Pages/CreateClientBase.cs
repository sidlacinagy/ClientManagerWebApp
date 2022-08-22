using ClientManager.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace ClientManager.Web.Pages
{
    public class CreateClientBase : ComponentBase
    {
        public ClientDto ClientDto { get; set; }

        [Parameter]
        public EventCallback<ClientDto> OnClientCreated { get; set; }

        protected override void OnInitialized()
        {
            ClientDto = new ClientDto
            {
                IdNumber = "",
                FirstName = "",
                LastName = "",
                PhoneNumber = "",
                Address = "",
                ClientType = ClientManager.Shared.Enums.ClientTypes.Residential
            };
        }

        public async Task OnCreateClick()
        {
            await OnClientCreated.InvokeAsync(this.ClientDto);
        }
    }
}
