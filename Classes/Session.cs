using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libapicsharp.Classes
{
    public class Session
    {
        string _token { get; set; }
        public int? id { get; set; }
        public int digger { get; set; }
        public string started_at { get; set; }
        public string finished_at { get; set; }
        public string state { get; set; }
        public int runtime { get; set; }
        public double bandwidth { get; set; }
        public int requests { get; set; }
        public int errors { get; set; }
        public object items { get; set; }
        public double data_size { get; set; }
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        public Session()
        {

        }
        public Session(string token)
        {
            _token = token;
        }
        public DateTime StartedAt() {
            DateTime time;
            if (started_at == null)
            {
                return default(DateTime);
            }
            time = DateTime.Parse(started_at);
            return time;
        }
        public Session StartedAt(DateTime d)
        {
            started_at = d.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ");
            return this;
        }
        public DateTime FinishedAt() {
            DateTime time;
            if (finished_at == null)
            {
                return default(DateTime);
            }
            time = DateTime.Parse(finished_at);
            return time;
        }
        public Session FinishedAt(DateTime d) {
            finished_at = d.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ");
            return this;
        }
        public Session Get(int id)
        {
            if (_token == null)
            {
                throw new Exception("You must setup api key");
            }
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/sessions/" +id, Method.GET);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");

            IRestResponse<Session> session = client.Execute<Session>(request);
            if (session.ErrorException != null)
            {
                throw session.ErrorException;
            }
            if ((int)session.StatusCode != 200)
            {
                throw new Exception(session.Content);
            }

            return session.Data;

        }
        public string GetData()
        {
            if (_token == null)
            {
                throw new Exception("You must setup api key");
            }
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/sessions/" + id +"/data", Method.GET);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");

            IRestResponse data = client.Execute(request);
            if (data.ErrorException != null)
            {
                throw data.ErrorException;
            }
            if ((int)data.StatusCode != 200)
            {
                throw new Exception(data.Content);
            }

            return data.Content;
        }
    }
}
