using System;
using System.Collections.Generic;
using RestSharp;
using System.Text;

namespace libapicsharp.Classes
{
    public class API
    {
        string _token { get; set; }
        public API(string token)
        {
            _token = token;
        }
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        public override string ToString()
        {
            return _token;
        }
        public List<Project> GetProjects()
        { 
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/projects/", Method.GET);
            request.AddHeader("Authorization", "Token "+_token);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse<List<Project>> projects = client.Execute<List<Project>>(request);
            foreach(var p in projects.Data)
            {
                p.Token = _token;
            }
            return projects.Data;
        }
        public List<Digger> GetDiggers()
        {
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/diggers/", Method.GET);
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse<List<Digger>> diggers = client.Execute<List<Digger>>(request);
            foreach(var d in diggers.Data)
            {
                d.Token = _token;
                if(d.last_session == null)
                {
                    d.last_session.Token = _token;
                }
                else
                {
                    d.last_session = new Session(_token);
                }
            }
            return diggers.Data;
        }
        public List<Session> GetSessions()
        {
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/sessions/", Method.GET);
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse<List<Session>> sessions = client.Execute<List<Session>>(request);
            foreach (var s in sessions.Data)
            {
                s.Token = _token;
            }
            return sessions.Data;
        }
        public Project GetProject(int id)
        {
            if (_token == null)
            {
                throw new Exception("You must setup api key");
            }
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/projects/" + id, Method.GET);
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse<Project> project = client.Execute<Project>(request);
            if (project.ErrorException != null)
            {
                throw project.ErrorException;
            }
            if ((int)project.StatusCode != 200)
            {
                throw new Exception(project.Content);
            }
            project.Data.Token = _token;

            return project.Data;
        }
        public Digger GetDigger(int id)
        {
            if (_token == null)
            {
                throw new Exception("You must setup api key");
            }
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/diggers/" + id, Method.GET);
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");
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
        public string SetConfig(int id, string conf)
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
            return config.Data.config;
        }
        public string GetConfig(int id)
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
            return config.Data.config;
        }
        public string GetData(int id)
        {
            if (_token == null)
            {
                throw new Exception("You must setup api key");
            }
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/sessions/" + id + "/data", Method.GET);

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
