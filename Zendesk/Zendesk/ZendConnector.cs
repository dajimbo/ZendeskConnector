using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization; 
using RestSharp;
using Newtonsoft.Json.Linq;
using System.ServiceModel.Web;
using RestSharp.Authenticators;

namespace Zendesk
{
    
    public class ZendConnector
    {
       public readonly string USER = "/api/v2/users";
       public readonly string SUSPEND = "{\"user\": {\"suspended\": \"true\"}}";
       public readonly string SETPASSWORD = "{\"password\": \""; 

        public string userName { get; set; }
        public string password { get; set; }
        public string subDomain { get; set; }
        public RestClient client { get; set; }
        public RestRequest request { get; set; }
        public IRestResponse response { get; set; }

        //Constructor
        public ZendConnector(string userName, string password, string subDomain)
        {
            client = authenticate(userName, password, subDomain);
            this.userName = userName;
            this.password = password;
            this.subDomain = subDomain;
        }

        //Authenticate User
        public RestClient authenticate(string userName, string password, string subDomain)
        {
            var client = new RestClient("https://"+ subDomain+".zendesk.com");
            client.Authenticator = new HttpBasicAuthenticator(userName, password);

            this.userName = userName;
            this.password = password;
            this.subDomain = subDomain;
            this.client = client;

            return client;
        }

        //Web CRUD Methods
        public RestRequest requestMethod(string resource, string method)
        {
            
            if(method.ToLower().Equals("get"))
            {
                request = new RestRequest(resource, Method.GET);
            }
            else if (method.ToLower().Equals("post"))
            {
                request = new RestRequest(resource, Method.POST);
            }
            else if (method.ToLower().Equals("put"))
            {
                request = new RestRequest(resource, Method.PUT);
            }
            else if (method.ToLower().Equals("delete"))
            {
                request = new RestRequest(resource, Method.DELETE);
            }
            else
            {
                Console.WriteLine("Not a valid Crud method");
            }
            
            request.RequestFormat = DataFormat.Json;

            return request;
            
        }

        //Action Method creates a user with minium of 3 fields
        public string createUser(string pname, string pemail, string prole)
        {
            request = requestMethod(USER + ".json", "post");
            var user = new NewUser
            {
                user =
                    new User
                    {
                        name = pname,
                        email = pemail,
                        role = prole
                    }
            };
            request.AddBody(user);
            response = client.Execute(request);

            return response.Content;
        }

        //Action Method Suspends a user by there unique id
        public string suspendUser(int id)
        {
            request = requestMethod(USER + "/" + id + ".json","put");
            request.AddParameter("Application/Json",SUSPEND, ParameterType.RequestBody);
            response = client.Execute(request);
            
            return response.Content;
        }

        //Action Method Resets a end-user
        public string setPassword(int id, string newPassword)
        {  //'{"password": "newpassword"}'
            request = requestMethod(USER + "/" + id + "/password.json", "post");
            request.AddParameter("Application/Json", SETPASSWORD + newPassword + "\"}", ParameterType.RequestBody);
            response = client.Execute(request);
           
            return response.Content;
        }   
    }
}
