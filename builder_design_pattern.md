<!-- problem get, body 20-30 iteem send how to send which pattern send  -->

using System;
using System.Collections.Generic;

public class HttpRequest
{
    public string Method;
    public string url;
    public IDictionary<string,string> Headers = new Dictionary<string,string>();
    public string Body;

    public HttpRequest(string Method, string url, IDictionary<string,string> Headers, string Body)
    {
        this.Method = Method;
        this.url = url;
        this.Headers = Headers;
        this.Body = Body;
    }

    public void Send()
    {
        Console.WriteLine(Method);
        Console.WriteLine(url);
        Console.WriteLine(Body);

        foreach(var item in Headers)
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        } 
    }
}

class Program
{
    static void Main(string[] args)
    {
        IDictionary<string, string> headers = new Dictionary<string, string>();

        headers.Add("Content-Type", "application/json");
        headers.Add("Authorization", "Bearer 12345");

        HttpRequest request = new HttpRequest(
            "POST",
            "/api/user",
            headers,
            "{ \"name\": \"Nafis\" }"
        );

        request.Send();   
    }
}


<!-- solve -->



public class HttpRequest
{
    public string Method;
    public string url;
    public IDictionary<string,string> Headers;
    public string Body;

    public HttpRequest(string Method, string url, IDictionary<string,string> Headers, string Body)
    {
        this.Method = Method;
        this.url = url;
        this.Headers = Headers;
        this.Body = Body;
    }

    public void Send()
    {
        Console.WriteLine(Method);
        Console.WriteLine(url);
        Console.WriteLine(Body);

        foreach(var item in Headers)
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        } 
    }
}

public class HttpRequestBuilder
{
    private HttpRequest request = new HttpRequest(
        "",
        "",
        new Dictionary<string,string>(),
        ""
    );

    public HttpRequestBuilder SetMethod(string method)
    {
        request.Method = method;
        return this;
    }

    public HttpRequestBuilder SetUrl(string url)
    {
        request.url = url;
        return this;
    }

    public HttpRequestBuilder AddHeader(string key, string value)
    {
        request.Headers.Add(key, value);
        return this;
    }

    public HttpRequestBuilder SetBody(string body)
    {
        request.Body = body;
        return this;
    }

    public HttpRequest Build()
    {
        return request;
    }
}

class Program
{
    static void Main(string[] args)
    {
        HttpRequest request = new HttpRequestBuilder()
            .SetMethod("POST")
            .SetUrl("/api/user")
            .AddHeader("Content-Type", "application/json")
            .AddHeader("Authorization", "Bearer 12345")
            .SetBody("{ \"name\": \"Nafis\" }")
            .Build();

        request.Send();
    }
}