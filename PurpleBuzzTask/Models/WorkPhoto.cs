namespace PurpleBuzzTask.Models
{
    public class WorkPhoto
    {
        public int Id { get; set; }
        public int WorkId { get; set; }
        public Work? Work { get; set; }
        public bool IsCover { get; set; }
        public string ImgUrl { get; set; }
    }
}
