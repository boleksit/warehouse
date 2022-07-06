using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WPF_App.Models;

namespace WPF_App;

public static class WebApi
{
    private static string baseUrl = "http://localhost/api";
    
    public static async Task<string> GetPackageByIdAsync(string id)
    {
        string result;
        using HttpClient client = new HttpClient();
        var response = await client.GetAsync($"{baseUrl}/package/{id}");

        result = await response.Content.ReadAsStringAsync();
        return result;
    }

    public static async Task<List<Box>> GetAllPackages()
    {
        using HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Globals.LoggedInUserToken);
        var response = await client.GetAsync($"{baseUrl}/package");
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Box>>(result); 
    }

    public static async Task<string?> AuthenticateUser(string email, string password)
    {
        string endpoint = $"{baseUrl}/account/login";
        string json = JsonConvert.SerializeObject(new
            {
                email = email,
                password = password
            }
        );
        StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        using HttpClient client = new HttpClient();
        var response = await client.PostAsync(endpoint, httpContent);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var result =await response.Content.ReadAsStringAsync();
            return result;
        }
        
        return null;
    }

    public static async Task<bool> RegisterUser(string email, string password, string confirmPassword, string name)
    {
        string endpoint = $"{baseUrl}/account/register";
        string json = JsonConvert.SerializeObject(new
        {
            email = email,
            password = password,
            confirmPassword = confirmPassword,
            name = name,
            roleId = 3
        });
        StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        using HttpClient client = new HttpClient();
        var response = await client.PostAsync(endpoint, httpContent);
        if (response.StatusCode == HttpStatusCode.OK)
            return true;
        return false;
    }
}