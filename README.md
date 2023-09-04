1. CameraController
   -> WebCam.js must be included
   -> Captures must be created to store the captured images

2. CaptchaController
   -> Visit -> https://www.google.com/recaptcha/about/
   -> Click V3 Admin Console
   -> Click on the + symbol(Create)
   -> Give a Label and choose Challenge(radiobutton)
   -> Add domain as localhost
   -> Submit -> You'll get the Key and Secret Key
   -> Create a Model ReCaptcha.cs
    public class RECaptcha
    {
        public string Key = "6LeeTesnAAAAAGllQtdAYuld_StcjTuQbbgvNrsT";

        public string Secret = "6LeeTesnAAAAAEABxStL8kQKOhvrE3Ymi5Uz_xLF";
        public string Response { get; set; }
    }
   -> Implement the rest of the logic in CaptchaController

3. jQueryController - Validation using jQuery-Validation-Engine
   -> Include the following plugins to work with jQueryController
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/jQuery-Validation-Engine/2.6.4/validationEngine.jquery.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jQuery-Validation-Engine/2.6.4/jquery.validationEngine.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jQuery-Validation-Engine/2.6.4/languages/jquery.validationEngine-en.min.js"></script>

4. JsonController - JSON to List<>
   -> Create CustomerModel.cs (Models)
   -> Create Customers.json (Files)
   -> Use JavaScriptSerializer for converting JSON to List<>

   ******* HAPPY CODING *******
   

