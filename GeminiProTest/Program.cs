// See https://aka.ms/new-console-template for more information
using GeminiProApiC_sharp;

var apiKey = "";

var gemini = new GeminiPro();


gemini.Configure(apiKey);

gemini.GenerativeModel(GeminiProApiC_sharp.Enums.GenerativeModel.Gemini_Pro);

var response = await gemini.GenerateContentAsync(prompt: "Write a story about a magic backpack");


Console.WriteLine(response.candidates[0].content.parts[0].text);
