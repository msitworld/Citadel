namespace Citadel.RahkaranClient.Models.Data
{
    public class Filter
    {
        public string Name { get; set; }
        public FilterOperator Operator { get; set; }
        public bool Or { get; set; }
        public string[] SerializedValues { get; set; }

    }
}
