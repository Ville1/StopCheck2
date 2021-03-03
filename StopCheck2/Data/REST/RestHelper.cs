using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using System;
using StopCheck2.Utils;

namespace StopCheck2.Data.Rest
{
    public class RestHelper
    {
        public static string Post(string url, Dictionary<string, string> headers, string body)
        {
            try {
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";

                foreach (KeyValuePair<string, string> header in headers) {
                    if (header.Key.ToLower() == "content-type") {
                        request.ContentType = header.Value;
                        continue;
                    }
                }

                byte[] bytes = Encoding.UTF8.GetBytes(body);
                request.ContentLength = bytes.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);

                HttpWebResponse respone = request.GetResponse() as HttpWebResponse;
                Stream stream = respone.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string responseString = reader.ReadToEnd();

                reader.Close();
                stream.Close();
                respone.Close();

                return responseString;
            } catch (Exception exception) {
                Logger.LogException(exception);
                return null;
            }
        }
    }
}