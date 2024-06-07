using Microsoft.AspNetCore.Mvc;
using Services.AudioTranscriptions.TranscribeAudio;

namespace project_ai.Controllers;

[Route("audio-transcriptions")]
public class AudioTranscriptionsController : Controller
{
    [HttpPost("transcribe")]
    public async Task<IActionResult> TranscribeAudioAsync(
        [FromServices] TranscribeAudioService transcribeAudioService,
        IFormFile file)
    {
        var transcription = await transcribeAudioService.TranscribeAudioAsync(file);

        return Ok(transcription);
    }
}
