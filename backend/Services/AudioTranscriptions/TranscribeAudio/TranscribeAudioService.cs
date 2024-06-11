using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using Services.Audios.ConvertAudioToStream;

namespace Services.AudioTranscriptions.TranscribeAudio;

public class TranscribeAudioService : Service
{
    private readonly OpenAIAPI _openAIAPI;
    private readonly ConvertAudioToStreamService _convertAudioToStreamService;

    public TranscribeAudioService(
        OpenAIAPI openAIAPI,
        ConvertAudioToStreamService convertAudioToStreamService)
    {
        _openAIAPI = openAIAPI;
        _convertAudioToStreamService = convertAudioToStreamService;
    }

    public async Task<string> TranscribeAudioAsync(
        IFormFile file)
    {
        var audioToStream = await _convertAudioToStreamService.ConvertAudioToStreamAsync(file);

        var transcription = await _openAIAPI.Transcriptions.GetTextAsync(
            audioToStream.Stream,
            file.FileName);

        if (transcription == null)
        {
            throw new Exception("Failed to transcribe audio.");
        }

        var audioTranscription = new AudioTranscription
        {
            AudioId = audioToStream.AudioId,
            Text = transcription
        };
        DbContext.Add(audioTranscription);

        var systemMessage = new ChatMessage
        {
            Name = "System",
            Role = ChatMessageRole.System,
            TextContent = "You are a helpful assistant designed to output JSON."
        };

        var userMessage = new ChatMessage
        {
            Name = "User",
            Role = ChatMessageRole.User,
            TextContent = $"{transcription}, return JSON with property results, wich is a array of object with three properties, action: stric between values (eat, jump, run). value: a int value by inputed text. kind: the substantive of input"
        };

        var chatRequest = new ChatRequest()
        {
            Model = Model.GPT4_Turbo,
            Temperature = 0.0,
            MaxTokens = 100,
            ResponseFormat = ChatRequest.ResponseFormats.JsonObject,
            Messages = new List<ChatMessage> { systemMessage, userMessage }
        };


        var result = await _openAIAPI.Chat.CreateChatCompletionAsync(chatRequest);

        await DbContext.SaveChangesAsync();

        return result.Choices[0].Message.TextContent;
    }
}
