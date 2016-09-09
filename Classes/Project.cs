using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libapicsharp.Classes
{
    

        public class Project
        {
        string _token { get; set; }
        string _baseUrl { get; }
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public Project(string token)
        {
            _token = token;
        }
        public Project()
        {

        }
        public Project Create()
        {
            if (_token == null)
            {
                throw new Exception("You must setup api key");
            }
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/projects/", Method.POST);
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("name", name);
            if(description != null)
            {
                request.AddParameter("description", description);
            }
            IRestResponse<Project> project = client.Execute<Project>(request);
            if (project.ErrorException != null)
            {
                throw project.ErrorException;
            }
            if ((int)project.StatusCode != 201)
            {
                throw new Exception(project.Content);
            }
            project.Data.Token = _token;
            return project.Data;
        }
        public Project Put()
        {
            if (_token == null)
            {
                throw new Exception("You must setup api key");
            }
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/projects/" + id, Method.PUT);
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("name", name);
            if (description != null)
            {
                request.AddParameter("description", description);
            }
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
        public Project Patch()
        {
            if (_token == null)
            {
                throw new Exception("You must setup api key");
            }
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/projects/" + id, Method.PATCH);
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("name", name);
            if (description != null)
            {
                request.AddParameter("description", description);
            }
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
        public Project Delete()
        {
            if (_token == null)
            {
                throw new Exception("You must setup api key");
            }
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/projects/" + id, Method.DELETE);
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            IRestResponse project = client.Execute(request);
            if (project.ErrorException != null)
            {
                throw project.ErrorException;
            }
            if ((int)project.StatusCode != 204)
            {
                throw new Exception(project.Content);
            }
            return null;
        }
        public List<Digger> GetDiggers()
        {
            var client = new RestClient("https://www.diggernaut.com");
            var request = new RestRequest("api/v1/projects/"+id+"/diggers", Method.GET);
            request.AddHeader("Authorization", "Token " + _token);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse<List<Digger>> diggers = client.Execute<List<Digger>>(request);
            foreach (var d in diggers.Data)
            {
                d.Token = _token;
                if (d.last_session == null)
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

    }
        

    }

