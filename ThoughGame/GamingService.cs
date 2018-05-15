using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ThoughGame
{
    public class GamingService
    {
        private readonly string HostUrl = "http://tw-http-hunt-api-1062625224.us-east-2.elb.amazonaws.com/challenge";

        public GameModel gameModelInfo { get; set; }
        public GamingService()
        {
            this.gameModelInfo = new GameModel();
        }

        public GameModel InvokeService(string request)
        {
            string serviceResponse = string.Empty;
            switch (request)
            {
                case "Challenge":
                    request = "";
                    serviceResponse = GameGetCall(request);
                    gameModelInfo = new JavaScriptSerializer().Deserialize<GameModel>(serviceResponse);
                    gameModelInfo.jsonResponse = serviceResponse;
                    break;
                case "Input":
                    serviceResponse = GameGetCall(request);
                    gameModelInfo.sampleInput.input = new JavaScriptSerializer().Deserialize<List<Input>>(serviceResponse);
                    gameModelInfo.jsonResponse = serviceResponse;
                    break;
                case "output":
                    //this.GameModelInfo.sampleOutput.output.count = this.GameModelInfo.sampleInput.input.Count;

                    //this.gameModelInfo.sampleOutput.output.count = CalculateCountBasedOnEndDate();
                    //Dictionary<string, int> activeProductByCatagory = CalculateProductByCatagory();
                    //serviceResponse = GamePOSTCall(request, activeProductByCatagory);  //Challenge3

                    int totalValue = CalculatePriceofActiveProducts();
                    Dictionary<string, int> price = new Dictionary<string, int>();
                    price.Add("totalValue", totalValue);
                    serviceResponse = GamePOSTCall(request, price);  //Challenge4

                    gameModelInfo.jsonResponse = serviceResponse;
                    break;

            }

            return gameModelInfo;

        }

        private int CalculateCountBasedOnEndDate()
        {
            int count = 0;
            foreach (Input input in gameModelInfo.sampleInput.input)
            {
                DateTime today = DateTime.Now;
                DateTime inputStartDate = Convert.ToDateTime(input.startDate);
                DateTime? inputEndDate = null;
                if (!string.IsNullOrEmpty(input.endDate))
                {
                    inputEndDate = Convert.ToDateTime(input.endDate);
                }

                if (inputEndDate == null)
                {
                    if (inputStartDate <= today)
                    {
                        count++;
                    }
                }
                else
                {
                    if (inputStartDate <= today && inputEndDate >= today)
                    {
                        count++;
                    }
                }

            }

            return count;
        }
        private Dictionary<string, int> CalculateProductByCatagory()
        {
            int count = 0;
            Dictionary<string, int> dictProductByCatagory = new Dictionary<string, int>();
            foreach (Input input in gameModelInfo.sampleInput.input)
            {
                DateTime today = DateTime.Now;
                DateTime inputStartDate = Convert.ToDateTime(input.startDate);
                DateTime? inputEndDate = null;
                if (!string.IsNullOrEmpty(input.endDate))
                {
                    inputEndDate = Convert.ToDateTime(input.endDate);
                }

                if (inputEndDate == null)
                {
                    if (inputStartDate <= today)
                    {
                        count++;

                        AddProduct(dictProductByCatagory, input);
                    }
                }
                else
                {
                    if (inputStartDate <= today && inputEndDate >= today)
                    {
                        count++;
                        AddProduct(dictProductByCatagory, input);
                    }
                }

            }

            return dictProductByCatagory;
        }

        private void AddProduct(Dictionary<string, int> dictProductByCatagory, Input input)
        {
            if (dictProductByCatagory.ContainsKey(input.category))
            {
                int value = dictProductByCatagory[input.category];
                dictProductByCatagory[input.category] = ++value; ;
            }
            else
            {
                dictProductByCatagory.Add(input.category, 1);
            }
        }

        private int CalculatePriceofActiveProducts()
        {
            int count = 0;
            int price = 0;
            foreach (Input input in gameModelInfo.sampleInput.input)
            {
                DateTime today = DateTime.Now;
                DateTime inputStartDate = Convert.ToDateTime(input.startDate);
                DateTime? inputEndDate = null;
                if (!string.IsNullOrEmpty(input.endDate))
                {
                    inputEndDate = Convert.ToDateTime(input.endDate);
                }

                if (inputEndDate == null)
                {
                    if (inputStartDate <= today)
                    {
                        count++;
                        price += input.price;
                    }
                }
                else
                {
                    if (inputStartDate <= today && inputEndDate >= today)
                    {
                        count++;
                        price += input.price;
                    }
                }

            }

            return price;
        }
        private string GameGetCall(string apitoCall)
        {
            try
            {
                string requestUrl = HostUrl + "/" + apitoCall;
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("userId", "B1v-B8XHG");
                    using (HttpResponseMessage response = client.GetAsync(requestUrl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            string responseReceived = content.ReadAsStringAsync().Result;
                            return responseReceived;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return "error Occured " + ex.Message;
            }
        }

        private string GamePOSTCall(string apitoCall, Dictionary<string, int> prodCatagories)
        {
            try
            {
                string requestUrl = HostUrl + "/" + apitoCall;
                //var jsonParams = new JavaScriptSerializer().Serialize(this.gameModelInfo.sampleOutput);
                var jsonParams = new JavaScriptSerializer().Serialize(prodCatagories);
                var jsonContent = new StringContent(jsonParams);
                jsonContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("userId", "B1v-B8XHG");
                    using (HttpResponseMessage response = client.PostAsync(requestUrl, jsonContent).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            string responseReceived = content.ReadAsStringAsync().Result;
                            return responseReceived;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return "error Occured " + ex.Message;
            }
        }
    }
}
