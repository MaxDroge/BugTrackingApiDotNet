namespace BugTrackingApiDotNet.DTOs
{
    public class UpdateBugDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
    }
}