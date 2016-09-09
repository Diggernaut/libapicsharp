using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
namespace libapicsharp.Classes
{
    public class Digger
    {
        string _token { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int project { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public string config { get; set; }
        public string schedule_from { get; set; }
        public string schedule_to { get; set; }
        public double bandwidth { get; set; }
        public int calls { get; set; }
        public int requests { get; set; }
        public Session last_session { get; set; }


        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        public Digger Project(int p)
        {
            project = p;
            return this;
        }
        public Digger Name(string n)
        {
            name = n;
            return this;
        }
        public Digger Url(string u)
        {
            url = u;
            return this;
        }
        public Digger Config(string c)
        {
            config = c;
            return this;
        }
        public Digger ScheduleTo(DateTime d)
        {
            schedule_to = d.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ");
            return this;
        }
        public Digger ScheduleFrom(DateTime d)
        {
            schedule_from = d.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ");
            return this;
        }
        public DateTime ScheduleTo()
        {
            DateTime time;
            if (schedule_to == null)
            {
                return default (DateTime);
            }
            time = DateTime.Parse(schedule_to);
            return time;
        }
        public DateTime ScheduleFrom()
        {
            DateTime time;
            if (schedule_from == null)
            {
                return default(DateTime);
            }
            time = DateTime.Parse(schedule_from);
            return time;
        }
        public Digger(){
            }
        public Digger(string token)
        {
            Token = token;
        }
        public Digger Create()
        {
            if (_token == null)
            {
                throw new Exception("You must setup api key");
            }
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/diggers/", Method.POST);
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("name", name);
            request.AddParameter("project", project);
            request.AddParameter("url", url);
            if (config != null)
            {
                request.AddParameter("config", config);
            }
            if (schedule_from != null)
            {
                request.AddParameter("schedule_from", schedule_from);
            }
            if (schedule_to != null)
            {
                request.AddParameter("schedule_to", schedule_to);
            }
            if (status != null)
            {
                request.AddParameter("status", status);
            }
            IRestResponse<Digger> digger = client.Execute<Digger>(request);
            if (digger.ErrorException != null)
            {
                throw digger.ErrorException;
            }
            if ((int)digger.StatusCode != 201)
            {
                throw new Exception(digger.Content);
            }
            digger.Data.Token = _token;
            if (digger.Data.last_session == null)
            {
                digger.Data.last_session = new Session(_token);
            }
            else
            {
                digger.Data.last_session.Token = _token;
            }
            return digger.Data;
        }

        public Digger Put()
        {
            if (_token == null)
            {
                throw new Exception("You must setup api key");
            }
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/diggers/" + id, Method.PUT);
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("name", name);
            request.AddParameter("project", project);
            request.AddParameter("url", url);

            IRestResponse<Digger> digger = client.Execute<Digger>(request);
            if (digger.ErrorException != null)
            {
                throw digger.ErrorException;
            }
            if ((int)digger.StatusCode != 200)
            {
                throw new Exception(digger.Content);
            }
            digger.Data.Token = _token;
            if (digger.Data.last_session == null)
            {
                digger.Data.last_session = new Session(_token);
            }
            else
            {
                digger.Data.last_session.Token = _token;
            }
            return digger.Data;
        }
        public Digger Patch()
        {
            if (_token == null)
            {
                throw new Exception("You must setup api key");
            }
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/diggers/" + id, Method.PATCH);
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("name", name);
            request.AddParameter("project", project);
            request.AddParameter("url", url);
            if (config != null)
            {
                request.AddParameter("config", config);
            }
            if(schedule_from != null)
            {
                request.AddParameter("schedule_from", schedule_from);
            }
            if(schedule_to != null)
            {
                request.AddParameter("schedule_to", schedule_to);
            }
            if(status != null)
            {
                request.AddParameter("status", status);
            }
            IRestResponse<Digger> digger = client.Execute<Digger>(request);
            if (digger.ErrorException != null)
            {
                throw digger.ErrorException;
            }
            if ((int)digger.StatusCode != 200)
            {
                throw new Exception(digger.Content);
            }
            digger.Data.Token = _token;
            if (digger.Data.last_session == null)
            {
                digger.Data.last_session = new Session(_token);
            }
            else
            {
                digger.Data.last_session.Token = _token;
            }
            return digger.Data;
        }
        public Digger Delete()
        {
            if (_token == null)
            {
                throw new Exception("You must setup api key");
            }
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/diggers/" + id, Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse digger = client.Execute(request);
            if (digger.ErrorException != null)
            {
                throw digger.ErrorException;
            }
            if ((int)digger.StatusCode != 204)
            {
                throw new Exception(digger.Content);
            }
            return null;
        }
        
        public Digger GetConfig()
        {
            if (_token == null)
            {
                throw new Exception("You must setup api key");
            }
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/diggers/" + id + "/config", Method.GET);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");

            IRestResponse<Config> config = client.Execute<Config>(request);
            if (config.ErrorException != null)
            {
                throw config.ErrorException;
            }
            if ((int)config.StatusCode != 200)
            {
                throw new Exception(config.Content);
            }
            Config(config.Data.config);
            return this;
        }
        
        public Digger SetConfig(string conf)
        {
            if (_token == null)
            {
                throw new Exception("You must setup api key");
            }
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/diggers/" + id + "/config", Method.PATCH);

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("config", conf);
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");

            IRestResponse<Config> config = client.Execute<Config>(request);
            if (config.ErrorException != null)
            {
                throw config.ErrorException;
            }
            if ((int)config.StatusCode != 200)
            {
                throw new Exception(config.Content);
            }
            Config(config.Data.config);
            return this;
        }
    }
}
