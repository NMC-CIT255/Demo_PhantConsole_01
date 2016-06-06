using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;

namespace PhantConsole.D1
{
    public class PhantClient
    {
        private string ViewData_URL = PhantFeedConfiguration.BaseHost_URL + "/streams/" + PhantFeedConfiguration.PublicKey;
        private string AddData_BaseURL = PhantFeedConfiguration.BaseHost_URL + "/input/" + PhantFeedConfiguration.PublicKey + "?private_key=" + PhantFeedConfiguration.PrivateKey;
        private string ClearData_URL = PhantFeedConfiguration.BaseHost_URL + "/input/" + PhantFeedConfiguration.PublicKey + "/clear?private_key=" + PhantFeedConfiguration.PrivateKey;
        private string DeleteAccount_URL = PhantFeedConfiguration.BaseHost_URL + "/streams/" + PhantFeedConfiguration.PublicKey + "/delete/" + PhantFeedConfiguration.DeleteKey;
        private string GetFiledata_URL { get { return PhantFeedConfiguration.BaseHost_URL + "/output/" + PhantFeedConfiguration.PublicKey + "."; } }

        public PhantClient()
        {

        }

        public bool AddData(string tempValue, string lightValue)
        {
            //var data = new Dictionary<string, string>();
            //data.Add("temp", temp);
            //var content = new FormUrlEncodedContent(data);

            //using (var client = new HttpClient())
            //{
            //    try
            //    {
            //        var httpResponseMessage = client.PostAsync(AddData_BaseURL, content);

            //        if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            //        {
            //            Console.WriteLine("Posted!");
            //            Console.ReadLine();
            //        }
            //    }
            //    catch (OperationCanceledException) { }
            //}
            // Make sure we have enough parameters for each of our fields

            //if (Values.Length != FieldNames.Length) return false;

            // Build up our URL to store the data
            StringBuilder sb = new StringBuilder(AddData_BaseURL);
            sb.Append("&" + "temp" + "=" + tempValue);
            sb.Append("&" + "light" + "=" + lightValue);


            //for (int i = 0; i < FieldNames.Length; i++)
            //{
            //    sb.Append("&" + FieldNames[i] + "=" + Values[i]);
            //}

            // Run our URL
            return RunURL(sb.ToString()).Contains("1 success");
        }

        private string RunURL(string URL)
        {
            string RetVal = string.Empty;


            try //Catch all errors from the server if stuff is malformed
            {
                // Set up our web request for our URL
                WebRequest request = WebRequest.Create(URL);

                // Get the response
                WebResponse response = request.GetResponse();

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    // Check that we have a 1 success
                    RetVal = reader.ReadToEnd();
                }


                // Clean up
                response.Close();

            }
            catch
            {
            }

            return RetVal;
        }
    }
}
