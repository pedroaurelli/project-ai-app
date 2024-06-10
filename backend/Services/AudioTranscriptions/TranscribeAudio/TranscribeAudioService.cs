using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using OpenAI_API;
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

        var modelDetails = await _openAIAPI.Models.RetrieveModelDetailsAsync("ft:davinci-002:personal:project-ai-model:9XXzUFOa");
        _openAIAPI.Completions.DefaultCompletionRequestArgs.Model = modelDetails.ModelID;
        _openAIAPI.Completions.DefaultCompletionRequestArgs.MaxTokens = 100;
        _openAIAPI.Completions.DefaultCompletionRequestArgs.Temperature = 0;

        var completion = await _openAIAPI.Completions.CreateCompletionAsync(transcription);

        var response = completion.Completions[0].ToString();
        var json = JObject.Parse(response);

        await DbContext.SaveChangesAsync();

        return json.ToString(Newtonsoft.Json.Formatting.None);
    }
}
