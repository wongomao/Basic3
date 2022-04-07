using static System.Console;

string address = "https://raw.githubusercontent.com/microsoft/Windows-universal-samples/main/Samples/HttpClient/cs/Scenario02_GetStream.xaml.cs";
//string address = "https://gist.githubusercontent.com/suellenstringer-hye/f2231b3383538bcb1a5b051c7908f5b7/raw/0f4e0733a434733cda8e749bbbf33a93c2b5bbde/test.csv";
WriteLine($"get from {address}");
Uri uri = new Uri(address);
HttpClient client = new HttpClient();
try
{
    var result = await client.GetAsync(uri);
    if (result.IsSuccessStatusCode)
    {

    }
    if (result is not null)
    {
        //var x = await result.Content.ReadAsStreamAsync();
        string? x = await result.Content.ReadAsStringAsync();
        WriteLine(x);
    }
}
catch (Exception ex)
{
    WriteLine(ex.Message);
}

//try
//{
//    HttpClient client = clientFactory.CreateClient(
//        name: "Minimal.WebApi");
//    HttpRequestMessage request = new(
//        method: HttpMethod.Get, requestUri: "api/weather");
//    HttpResponseMessage response = await client.SendAsync(request);
//    ViewData["weather"] = await response.Content
//        .ReadFromJsonAsync<WeatherForecast[]>();
//}
//catch (Exception ex)
//{
//    _logger.LogWarning($"The Minimal.WebApi service is not responding. Exception: {ex.Message}");
//    ViewData["weather"] = Enumerable.Empty<WeatherForecast>().ToArray();
//}


//// ===========================================================

//Uri resourceUri = Helpers.TryParseHttpUri(AddressField.Text);
//if (resourceUri == null)
//{
//    rootPage.NotifyUser("Invalid URI.", NotifyType.ErrorMessage);
//    return;
//}

//Helpers.ScenarioStarted(StartButton, CancelButton, OutputField);
//rootPage.NotifyUser("In progress", NotifyType.StatusMessage);

//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, resourceUri);

//// This sample uses a "try" in order to support TaskCanceledException.
//// If you don't need to support cancellation, then the "try" is not needed.
//try
//{
//    // Do not buffer the response.
//    HttpRequestResult result = await httpClient.TrySendRequestAsync(
//        request,
//        HttpCompletionOption.ResponseHeadersRead).AsTask(cts.Token);

//    if (result.Succeeded)
//    {
//        OutputField.Text += Helpers.SerializeHeaders(result.ResponseMessage);

//        StringBuilder responseBody = new StringBuilder();
//        using (Stream responseStream = (await result.ResponseMessage.Content.ReadAsInputStreamAsync()).AsStreamForRead())
//        {
//            int read = 0;
//            byte[] responseBytes = new byte[1000];
//            do
//            {
//                read = await responseStream.ReadAsync(responseBytes, 0, responseBytes.Length);

//                responseBody.AppendFormat("Bytes read from stream: {0}", read);
//                responseBody.AppendLine();

//                // Use the buffer contents for something. We can't safely display it as a string though, since encodings
//                // like UTF-8 and UTF-16 have a variable number of bytes per character and so the last bytes in the buffer
//                // may not contain a whole character. Instead, we'll convert the bytes to hex and display the result.
//                IBuffer responseBuffer = CryptographicBuffer.CreateFromByteArray(responseBytes);
//                responseBuffer.Length = (uint)read;
//                responseBody.AppendFormat(CryptographicBuffer.EncodeToHexString(responseBuffer));
//                responseBody.AppendLine();
//            } while (read != 0);
//        }
//        OutputField.Text += responseBody.ToString();

//        rootPage.NotifyUser("Completed", NotifyType.StatusMessage);
//    }
//    else
//    {
//        Helpers.DisplayWebError(rootPage, result.ExtendedError);
//    }
//}
//catch (TaskCanceledException)
//{
//    rootPage.NotifyUser("Request canceled.", NotifyType.ErrorMessage);
//}


