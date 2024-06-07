using Microsoft.AspNetCore.Http;
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
        var stream = await _convertAudioToStreamService.ConvertAudioToStreamAsync(file);

        var transcription = await _openAIAPI.Transcriptions.GetTextAsync(
            stream,
            file.FileName);

        return transcription;
    }
}
