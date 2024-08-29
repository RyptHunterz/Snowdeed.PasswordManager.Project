using Snowdeed.PasswordManager.Tests;
using Snowdeed.PasswordManager.Tests.Models;
using System.Text;
using System.Text.Json;

HttpClient httpClient = new();

//CreateAccountModel createModel = new()
//{
//    AccountEmail = "stephane@ducoroy.be",
//    Password = "p@159qLREZA",
//    EmailContact = "stephane@ducoroy.be"
//};

//var (hash, salt) = new PasswordHasher().Hash(createModel.Password);

//createModel.PasswordHash = hash;
//createModel.Salt = salt;

//var json = JsonSerializer.Serialize(createModel);
//var data = new StringContent(json, Encoding.UTF8, "application/json");
//await httpClient.PostAsync("http://localhost:5100/account/", data);

LoginAccountModel loginAccountModel = new()
{
    AccountEmail = "stephane@ducoroy.be",
    Password = "p@159qLREZA",
};

var response = await httpClient.GetAsync($"http://localhost:5100/account/{loginAccountModel.AccountEmail}");

if (response.IsSuccessStatusCode)
{
    string jsonContent = await response.Content.ReadAsStringAsync();
    AccountModel? accountModel = JsonSerializer.Deserialize<AccountModel>(jsonContent);

    if (accountModel != null)
    {
        var passwordHash = new PasswordHasher().Hash(loginAccountModel.Password, accountModel.Salt);

        response = await httpClient.GetAsync($"http://localhost:5100/account/{loginAccountModel.AccountEmail}/{passwordHash}");
        jsonContent = await response.Content.ReadAsStringAsync();

        Console.WriteLine(jsonContent);
    }
}

Console.ReadLine();