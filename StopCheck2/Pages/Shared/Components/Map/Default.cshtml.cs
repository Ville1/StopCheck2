using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StopCheck2.Pages.Shared.Components.Map
{
    public class DefaultModel : PageModel
    {
        public void OnGet()
        { }
        public string Id { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public float Zoom { get; set; }
        public float Size { get; set; }

        public string MapElementId { get { return string.Format("Map{0}", Id); } }
        public string SizeCss { get { return string.Format("{0}px", Size); } }
    }
}
