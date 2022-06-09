namespace ASPIntro.Models;

public class VideosView
{
        public List<string> YoutubeVideoIds { get; set; } = new List<string>()
        {
            "yT3_vLQ3jbM", "fbqHK8i-HdA", "CUe2ymg1RHs", "-rEIOkGCbo8", "KYgZPphIKQY", "GPdGeLAprdg", "eg9_ymCEAF8", "nHkUMkUFuBc", "QTwcvNdMFMI", "j6YK-qgt_TI", "Wvjsgb2nB4o", "GcKkiRl9_qE", "6avJHaC3C2U", "_mZBa3sqTrI", "i_HaMlLJ7Jk", "32I0Qso4sDg"
        };

        //Removing the following line to convert our List<string> from ViewBag to ViewModel
        // ViewBag.YoutubeVideoIds = youtubeVideoIds;
        public string Title { get; set; } = $"Here are my favorite videos!";
}