namespace News_Mediator_API.Repository.Models
{
    public class FilterData
    {
        public int page { get; set; }
        public float pageSize { get; set; }
        public string columnName { get; set; }
        public string find { get; set; }
        public string sortOrder { get; set; }
    }
}
