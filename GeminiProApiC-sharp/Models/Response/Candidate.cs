using GeminiProApiC_sharp.Models.Request;

namespace GeminiProApiC_sharp.Models.Response
{
    public class Candidate
    {
        public Content content { get; set; }
        public string finishReason { get; set; }
        public int index { get; set; }
        public List<SafetyRating> safetyRatings { get; set; }
    }
}