
namespace BlazorWebsite.Components.Pages
{
    public partial class Home
    {
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                StateHasChanged();
            }
        }
    }
}