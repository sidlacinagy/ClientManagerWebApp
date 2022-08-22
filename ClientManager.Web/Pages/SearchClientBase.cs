using ClientManager.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace ClientManager.Web.Pages
{
    public class SearchClientBase : ComponentBase
    {
        [Parameter]
        public EventCallback<SearchFilterDto> OnSearchRequested { get; set; }

        [Parameter]
        public EventCallback OnSearchReset { get; set; }
        public SearchFilterDto SearchFilterDto { get; set; }

        protected override void OnInitialized()
        {
            SearchFilterDto = new SearchFilterDto
            {
                IdNumber = "",
                FirstName = "",
                LastName = "",
                ClientType = null
            };
        }

        public async Task OnSearchRequestClick()
        {
            await OnSearchRequested.InvokeAsync(this.SearchFilterDto);
        }

        public async Task OnSearchResetClick()
        {
            SearchFilterDto = new SearchFilterDto
            {
                IdNumber = "",
                FirstName = "",
                LastName = "",
                ClientType = null
            };
            await OnSearchReset.InvokeAsync();
        }
    }
}
