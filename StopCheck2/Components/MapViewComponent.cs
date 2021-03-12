using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StopCheck2.Components
{
    public class MapViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string id, float longitude, float latitude, float zoom, float size)
        {
            return Task.FromResult<IViewComponentResult>(View(new StopCheck2.Pages.Shared.Components.Map.DefaultModel() {
                Longitude = longitude,
                Latitude = latitude,
                Zoom = zoom,
                Size = size
            }));
        }
    }
}
