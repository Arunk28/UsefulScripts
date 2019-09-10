 public class HttpProperties
    {
        public Dictionary<string, string> dictObject { get; set; }

        public string url { get; set; }

        public string jsonObjectString { get; set; }

        public string contentType { get; set; }

        public bool sync { get; set; }

        public string methodType { get; set; }

        public string token { get; set; }
    }

    public class Http  {
        public static object HttpRequest(HttpProperties http)
        {
            var result = new object();
            try
            {
                var httpWebRequest = WebRequest.Create(http.url) as HttpWebRequest;

                if (!string.IsNullOrEmpty(http.contentType))
                    httpWebRequest.ContentType = http.contentType;

                httpWebRequest.Method = http.methodType;

                if (http.token != string.Empty)
                    httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + http.token);

                if (http.dictObject != null)
                {
                    StringBuilder postData = new StringBuilder();
                    int i = 0;
                    foreach (KeyValuePair<string, string> kvpRequest
                        in http.dictObject)
                    {
                        postData.AppendFormat(((i == 0) ? string.Empty : "&") + "{0}={1}", kvpRequest.Key, HttpUtility.UrlEncode(kvpRequest.Value));
                        i++;
                    }

                    if (http.methodType != "GET")
                    {
                        byte[] byteArray = Encoding.UTF8.GetBytes(postData.ToString());
                        httpWebRequest.ContentLength = byteArray.Length;

                        using (Stream dataStream = httpWebRequest.GetRequestStream())
                        {
                            dataStream.Write(byteArray, 0, byteArray.Length);
                            dataStream.Close();
                        }
                    }

                }

                if (!string.IsNullOrEmpty(http.jsonObjectString))
                {
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(http.jsonObjectString);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }

                if (http.sync)
                {
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
