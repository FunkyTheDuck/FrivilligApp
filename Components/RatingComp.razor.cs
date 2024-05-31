using FrontendModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    partial class RatingComp
    {
        [Parameter]
        public Ratings Rating { get; set; }
        public int AmountOfEmptyStars { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                AmountOfEmptyStars = (5 - Rating.Rating);
                StateHasChanged();
            }
        }
    }
}