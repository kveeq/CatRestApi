﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CatRestApi.Model;

namespace CatRestApi.Services
{
    public class RestService : IRestService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;
        public List<Cat> TodoItems { get; set; }

        public RestService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            client = new HttpClient(httpClientHandler);

            serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task DeleteTodoItemAsync(Cat item)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, item.id));
            try
            {
                HttpResponseMessage httpResponseMessage = await client.DeleteAsync(uri);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("@@@Success");
                    App.Current.MainPage.DisplayAlert("Error", "@@@Success", "Ok");
                }

                App.Current.MainPage.DisplayAlert("Error", "@@@Succes11s", "Ok");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"@@@@@@@@@@//// {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error",$"@@@@@@@@@@//// {ex.Message}","Ok");
            }
        }

        public async Task<List<Cat>> GetTodoItemAsync()
        {
            TodoItems = new List<Cat>();

            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    TodoItems = JsonSerializer.Deserialize<List<Cat>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return TodoItems;
        }

        public async Task SaveTodoItemAsync(Cat item, bool isNewItem)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            try
            {
                string json = JsonSerializer.Serialize(item, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("@@@Success");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
    }
}