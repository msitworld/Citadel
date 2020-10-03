namespace Citadel.RahkaranClient.Models.Data
{
    public class FetchModel
    {
        public string Name { get; set; }
        public string TypeName { get; set; }
        public string ComponentName { get; set; }
        public string EntityName { get; set; }
        public Filter[] Filters { get; set; }
        public string[] NamedFilters { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Parameter[] Parameters { get; set; }
        public string SearchText { get; set; }
        public Sort[] Sorts { get; set; }
        public string ViewName { get; set; }

    }
}
