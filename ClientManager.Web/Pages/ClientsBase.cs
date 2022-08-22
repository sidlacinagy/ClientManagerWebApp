using ClientManager.Shared.Dtos;
using ClientManager.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace ClientManager.Web.Pages
{
    public class ClientsBase:ComponentBase
    {
        [Inject]
        public IClientService ClientService { get; set; }

        public IEnumerable<ClientDto> Clients { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsErrorMsgShown { get; set; }
        public string SuccessMessage { get; set; }
        public bool IsSuccessMsgShown { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await GetClients();
            IsErrorMsgShown = false;
        }

        protected async Task ClientDeleted(string Id)
        {
            try
            {
                await ClientService.DeleteClient(Id);
                await GetClients();
                ShowSuccessMsg("Successfully created user with Id: " + Id);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected async Task ClientUpdated(ClientDto ClientDto)
        {
            try
            {
                await ClientService.UpdateClient(ClientDto);
                await GetClients();
                ShowSuccessMsg("Successfully updated user with Id: " + ClientDto.IdNumber);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);

            }
 
        }

        protected async Task ClientCreated(ClientDto ClientDto)
        {
            try
            {
                await ClientService.CreateClient(ClientDto);
                await GetClients();
                ShowSuccessMsg("Successfully created user with Id: " + ClientDto.IdNumber);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected async Task GetClients()
        {
            try
            {
                Clients = await ClientService.GetClients();
            }
            catch (Exception ex)
            {
               ShowError(ex.Message);
            }
        }

        protected async Task SearchClient(SearchFilterDto searchFilterDto)
        {
            try
            {
                Clients = await ClientService.SearchClients(searchFilterDto);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);

            }

        }

        protected async Task ResetSearch()
        {
            try
            {
                await GetClients();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }

        }

        protected async Task ShowError(string Errormsg)
        {
            this.IsErrorMsgShown = true;
            this.ErrorMessage = Errormsg;
            await Task.Delay(3000);
            this.IsErrorMsgShown = false;
            this.ErrorMessage = "";
            StateHasChanged();
        }

        protected async Task ShowSuccessMsg(string Successmsg)
        {
            this.IsSuccessMsgShown = true;
            this.SuccessMessage = Successmsg;
            await Task.Delay(3000);
            this.IsSuccessMsgShown = false;
            this.SuccessMessage = "";
            StateHasChanged();
        }

        protected void OrderClients(Func<ClientDto,string> orderByFunc,bool IsDesc)
        {
            List<ClientDto> tmpDtos= this.Clients.ToList().OrderBy(orderByFunc).ToList();
            if(!IsDesc)
            {
                tmpDtos.Reverse();
            }
            this.Clients = tmpDtos;
        }

    }
}
