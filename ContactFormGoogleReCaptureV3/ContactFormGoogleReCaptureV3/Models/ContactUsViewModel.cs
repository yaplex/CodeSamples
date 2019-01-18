namespace ContactFormGoogleReCaptureV3.Models
{
    public class ContactUsViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string GoogleCaptchaToken { get; set; }
    }
}