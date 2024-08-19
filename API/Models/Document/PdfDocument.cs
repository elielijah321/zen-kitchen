using System.Collections.Generic;
using Newtonsoft.Json;

public class ContentObject
{

    public ContentObject(string id, string content)
    {
        Id = id;
        Content = content;
    }

    public string Id { get; set; }
    public string Content { get; set; }
}

public class ElasticSearchResponse
{
    [JsonProperty("hits")]
    public Hits Hits { get; set; }
}

public class Hits
{
    [JsonProperty("hits")]
    public List<ContentResult> ContentList { get; set; }
}

public class ContentResult
{
    [JsonProperty("_source")]
    public ContentObject Content { get; set; }
}