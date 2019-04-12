using System;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace AutoRegger.Utils
{
    public class AntiCapthaUtils
    {
        // TODO: Move clientKey to config
        private const string createTaskPattern = @"{
            ""clientKey"":""40341c38c408ec7f8387dd21659dadcf"",
            ""task"":
            {
                ""type"":""ImageToTextTask"",
                ""body"":""{body}"",
                ""phrase"":false,
                ""case"":false,
                ""numeric"":false,
                ""math"":0,
                ""minLength"":0,
                ""maxLength"":0
            }
        }";

        private const string getTaskResultPattern = @"{
            ""clientKey"":""40341c38c408ec7f8387dd21659dadcf"",
            ""taskId"": {taskId}
        }";

        public static string GetCapthaAnswer(string base64Image)
        {
            WebRequest request = WebRequest.Create("https://api.anti-captcha.com/createTask");
            request.Method = "POST";
            string data = createTaskPattern.Replace("{body}", base64Image);
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            WebResponse webResponse = request.GetResponse();
            using (Stream stream = webResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string response = reader.ReadToEnd();
                    var rObj = JObject.Parse(response);
                    var errorId = rObj["errorId"].ToObject<int>();
                    if (errorId != 0)
                    {
                        Console.WriteLine(
                            $"[AntiCaptha] [CreateTask] ErrorID = {errorId} FullResponse:\n{response}");
                        Thread.Sleep(10000);
                        return GetCapthaAnswer(base64Image);
                    }

                    var taskID = rObj["taskId"].ToObject<int>();

                    return GetTaskResult(taskID);
                }
            }
        }

        private static string GetTaskResult(int taskId)
        {
            WebRequest request = WebRequest.Create("https://api.anti-captcha.com/getTaskResult");
            request.Method = "POST";
            string data = getTaskResultPattern.Replace("{taskId}", taskId.ToString());
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            WebResponse webResponse = request.GetResponse();
            using (Stream stream = webResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string response = reader.ReadToEnd();
                    var rObj = JObject.Parse(response);
                    var errorId = rObj["errorId"].ToObject<int>();
                    if (errorId != 0)
                    {
                        Console.WriteLine(
                            $"[AntiCaptha] [GetTaskResult] ErrorID = {errorId} FullResponse:\n{response}");
                        return string.Empty;
                    }

                    var status = rObj["status"].ToObject<string>();
                    if (status == "processing")
                    {
                        Thread.Sleep(2000);
                        return GetTaskResult(taskId);
                    }

                    var answer = rObj["solution"]["text"].ToObject<string>();
                    return answer;
                }
            }
        }
    }
}