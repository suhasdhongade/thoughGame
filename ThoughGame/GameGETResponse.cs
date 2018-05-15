using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThoughGame
{

    public class GameModel
    {
        public string stage { get; set; }
        public string statement { get; set; }
        public string instructions { get; set; }
        public SampleInput sampleInput { get; set; }
        public SampleOutput sampleOutput { get; set; }

        public string jsonResponse;
        //public string textInputResponse { get; set; }
        public GameModel()
        {
            sampleInput = new SampleInput();
            this.sampleOutput = new SampleOutput();
        }

    }


    public class Input
    {
        //public int price { get; set; }
        //public string name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string category { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int price { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string startDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string endDate { get; set; }
               
    }

    public class SampleInput
    {
        public SampleInput()
        {
            this.input = new List<Input>();
        }
        public IList<Input> input { get; set; }
    }

    public class Output
    {
        public int count { get; set; }
    }

    public class SampleOutput
    {
        public Output output { get; set; }
        public SampleOutput()
        {
            this.output = new Output();
        }
    }

}
