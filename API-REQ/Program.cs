using Newtonsoft.Json.Linq;
using System.Net;

using System; // means that we can use classes from the System namespace.

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            string html = string.Empty;
            dynamic json;
            string url = @"https://reqres.in/api/users?page=2";

            System.Net.HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();

            }
         
            json = JObject.Parse(html);

            Console.WriteLine(json.data[0].email);
            // Console.WriteLine(json);

            JArray myArr = json.data;

             bool isContain= myArr.Contains(json.data[2]);

            Console.WriteLine(isContain);
        }
    }
}