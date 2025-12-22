namespace MyAssessment.WebMVC.Models
{
    public class HomeBannerItem
    {
        public required string Title { get; set; }      // ANNIVERSARY/BIRTHDAY/GRAND GESTURES
        public required string ImageUrl { get; set; }   // /images/anniversary.jpg
        public required string Action { get; set; }     // e.g. "Anniversary"
        public required string Controller { get; set; } // e.g. "Products" or "Occasions"
    }
}
