using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace SQClient.Model
{
    class AI
    {
        const string baseUrl = @"http://127.0.0.1:3000";

        /// <summary>
        /// 云端提取特征值（嘉楠提供云端提取接口，速度比本地端较快，可选用）
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public AI_Result Extract(string path)
        {
            string url = baseUrl + "/api/extract";
            return PostResult(url, path);
        }

        /// <summary>
        /// 本地提取特征值
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public AI_Result ExtractLocal(string path)
        {
            string url = baseUrl + "/api/extractLocal";
            return PostResult(url, path);
        }

        AI_Result PostResult(string url, string path)
        {
            string tmpPath = path.Replace("\\", "\\\\");
            string json = $"{{\"path\" : \"{tmpPath}\", \"type\" : \"1\"}}";   //type 1-人脸特征  2-口罩特征

            RestClient client = new RestClient(url);
            client.Timeout = -1;
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (!string.IsNullOrEmpty(response.Content))
            {
                AI_Result result = JsonConvert.DeserializeObject<AI_Result>(response.Content);
                return result;
            }

            return null;
        }
    }   
}
