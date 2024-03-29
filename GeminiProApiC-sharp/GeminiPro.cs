﻿using GeminiProApiC_sharp.Enums;
using GeminiProApiC_sharp.Models.Request;
using GeminiProApiC_sharp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeminiProApiC_sharp
{
    public class GeminiPro
    {
        private  string BASE_URL = "";

        private  string API_KEY = "";


        public void Configure(string apiKey)
        {
           API_KEY = apiKey;
           
        }

        public void GenerativeModel(GenerativeModel generativeModel)
        {
            switch (generativeModel) 
            {
                case Enums.GenerativeModel.Gemini_Pro:
                    BASE_URL = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key={API_KEY}";
                    break;
                case Enums.GenerativeModel.Gemini_pro_vision:
                    BASE_URL = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-pro-vision:generateContent?key=${API_KEY}";
                    break;
            }
        }

        public async Task<GeminiResponse> GenerateContentAsync(string prompt)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new Request
                {
                    contents = new List<Models.Request.Content> 
                    {
                       new Models.Request.Content
                       {
                           parts = new List<Part>
                           {
                               new Part
                               {
                                   text = prompt,
                               }
                           }
                       }
                    }
                };
                var json = JsonSerializer.Serialize(request);

                HttpContent content = new StringContent(json,Encoding.UTF8,"application/json");

                var result = await httpClient.PostAsync(BASE_URL, content);

                if (result.IsSuccessStatusCode)
                {
                    var jsonString = await result.Content.ReadAsStringAsync();

                    var response = JsonSerializer.Deserialize<GeminiResponse>(jsonString);
                    return response;
                }
                else
                {
                    return new GeminiResponse();
                }
            
            }
        }

        
    }
}
