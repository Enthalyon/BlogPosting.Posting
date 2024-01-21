namespace BlogPosting.Posting.Api.Options
{
    public class MongoOptions
    {
        public string SectionName { get; } = "MongoOptions";
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }

        public MongoCollectionsOptions? Collections {  get; set; }
    }

    public class MongoCollectionsOptions
    {
        public string? Posting { get; set; }
    }

}
