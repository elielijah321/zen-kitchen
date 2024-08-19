using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;

public static class ElasticsearchHelper
{
    private static readonly string url = "https://search-court-system-x2w5ngjml56cpo7vine7p6badu.eu-north-1.es.amazonaws.com";
    private static readonly string username = "elielijah";
    private static readonly string password = "Elijah!23";
    private static readonly string index = "documents";

    private static readonly HttpClient httpClient = new HttpClient();

    public static async Task CreateIndex(DocumentObject document)
    {
        var uri = $"{url}/{index}/_doc/{document.Id}";
 
        var jsonString = JsonConvert.SerializeObject(document);

        // Set up the request
        var requestMessage = CreateRequestMessage(uri, HttpMethod.Put);
        requestMessage.Content = CreateContentBody(jsonString);

        // Send the request
        var response = await httpClient.SendAsync(requestMessage);
        var responseBody = await response.Content.ReadAsStringAsync();

        // Console.WriteLine(responseBody);
    }

    public static async Task<IEnumerable<ContentObject>> SearchDocuments(string searchQuery)
    {
        var uri = $"{url}/{index}/_search?q={searchQuery}";

        // Set up the request
        var requestMessage = CreateRequestMessage(uri, HttpMethod.Get);

        // Send the request
        var response = await httpClient.SendAsync(requestMessage);
        var responseBody = await response.Content.ReadAsStringAsync();

        ElasticSearchResponse elasticSearchResponse = JsonConvert.DeserializeObject<ElasticSearchResponse>(responseBody);

        var documentsList =  elasticSearchResponse.Hits.ContentList.Select(d => {

            return d.Content;
        });

        return documentsList;
    }

    public static async Task GetDocument(string id)
    {
        var uri = $"{url}/{index}/_doc/{id}";

        // Set up the request
        var requestMessage = CreateRequestMessage(uri, HttpMethod.Get);

        // Send the request
        var response = await httpClient.SendAsync(requestMessage);
        var responseBody = await response.Content.ReadAsStringAsync();

        // Object elasticSearchResponse = JsonConvert.DeserializeObject<DocumentObject>(responseBody);

        // Console.WriteLine(responseBody);
    }

    public static async Task DeleteDocument(string id)
    {
        var uri = $"{url}/{index}/_doc/{id}";

        // Set up the request
        var requestMessage = CreateRequestMessage(uri, HttpMethod.Delete);

        // Send the request
        var response = await httpClient.SendAsync(requestMessage);
        var responseBody = await response.Content.ReadAsStringAsync();

        Console.WriteLine(responseBody);
    }


    private static HttpRequestMessage CreateRequestMessage(string uri, HttpMethod method)
    {
        var requestMessage = new HttpRequestMessage(method, uri);

        requestMessage.Headers.Authorization = 
        new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));

        return requestMessage;
    }

    private static StringContent CreateContentBody(string jsonString)
    {
        var contentBody = new StringContent(jsonString, Encoding.UTF8, "application/json");

        return contentBody;
    }
}

