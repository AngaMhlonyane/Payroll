using System;
using RestSharp;
using Newtonsoft.Json.Linq;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        string baseUrl = "http://localhost:81/PayrollFrameworkDB"; // Replace with your Acumatica instance URL
        string endpoint = "/entity/Default/17.200.001"; // Replace with your actual endpoint version
        string username = "AngaA"; // Replace with your integration username
        string password = "Acumatica123"; // Replace with your integration password

        // Step 1: Create RestClient
        var options = new RestClientOptions(baseUrl)
        {
            ThrowOnAnyError = true, // Automatically handle errors
           // Timeout = 10000 // Set timeout (in milliseconds)
        };
        var client = new RestClient(options);

        // Step 2: Login to Acumatica
        var loginRequest = new RestRequest("entity/auth/login", Method.Post);
        loginRequest.AddJsonBody(new
        {
            name = username,
            password = password
        });

        try
        {
            var loginResponse = await client.ExecuteAsync(loginRequest);
            if (loginResponse.IsSuccessful)
            {
                Console.WriteLine("Login Successful!");

                // Step 3: Fetch Payroll Records
                var payrollRequest = new RestRequest($"{endpoint}/PayrollDetails", Method.Get);
                var payrollResponse = await client.ExecuteAsync(payrollRequest);

                if (payrollResponse.IsSuccessful)
                {
                    var payrollData = JArray.Parse(payrollResponse.Content);
                    Console.WriteLine($"Payroll Records: {payrollData}");
                }
                else
                {
                    Console.WriteLine($"Error Fetching Payroll Data: {payrollResponse.Content}");
                }

                // Step 4: Logout
                var logoutRequest = new RestRequest("entity/auth/logout", Method.Post);
                await client.ExecuteAsync(logoutRequest);
                Console.WriteLine("Logged out successfully.");
            }
            else
            {
                Console.WriteLine($"Login Failed: {loginResponse.Content}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
