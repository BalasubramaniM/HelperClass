using Microsoft.Phone.Controls;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;

namespace ReadJSONData
{
    public partial class ReadJSON : PhoneApplicationPage
    {
        WebClient client; // Used to retrieve data from URL
        Uri uri;  // Proper way to assign URL using Uri Class

        public ReadJSON()
        {
            InitializeComponent();
            client = new WebClient();
            uri = new Uri("http://date.jsontest.com/"); // Sample JSON link
            ReadJSONData();
        }

        private void ReadJSONData()
        {
            client.DownloadStringAsync(uri); // Asynchronously download string from Uri
            client.DownloadStringCompleted += client_DownloadStringCompleted; // Invokes when string download completes
        }

        private void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string data = e.Result; // Get result from link
            var obj = JsonConvert.DeserializeObject<ModelClass>(data); // Deserialize objects in ModelClass
            
            Debug.WriteLine("Time : {0}", obj.time);
            Debug.WriteLine("Milliseconds : {0}", obj.milliseconds_since_epoch);
            Debug.WriteLine("Date : {0}", obj.date);
        }
    }

    class ModelClass
    {
        public string time { get; set; }
        public long milliseconds_since_epoch { get; set; }
        public string date { get; set; }
    }
}
