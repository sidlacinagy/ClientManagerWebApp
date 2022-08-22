using ClientManager.Shared.Dtos;
using ClientManager.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace ClientManager.Web.Pages
{
    public class DisplayClientBase : ComponentBase
    {
        
        public ClientDto ClientDto { get; set; }

        public ClientDto UpdatedClientDto { get; set; }

        [Parameter]
        public ClientDto ClientDtoParam { get; set; }

        [Parameter]
        public EventCallback<string> OnClientDeleted { get; set; }

        [Parameter]
        public EventCallback<ClientDto> OnClientUpdated { get; set; }

        public bool IsEditMode { get; set; }

        protected override void OnParametersSet()
        {     
            if (!ClientDtoParam.Equals(ClientDto))
            {
                IsEditMode = false;
                UpdatedClientDto = ClientDtoParam.ShallowCopy();
                ClientDto = ClientDtoParam.ShallowCopy();
            }
        }
        public async Task OnDeleteClick()
        {
            await OnClientDeleted.InvokeAsync(this.ClientDto.IdNumber);
            IsEditMode = false;
        }

        public async Task OnUpdateClick()
        {
            await OnClientUpdated.InvokeAsync(this.UpdatedClientDto);
            IsEditMode = false;
        }



    }
}
