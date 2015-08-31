using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
namespace Zendesk
{
    /*
    class ZendRequests:RestRequest
    {
        public RestRequest request { get; set; }
        public IRestResponse response { get; set; }
        public string resource { get; set; }
        public string method { get; set; }

        public ZendRequests(string resource, string method)
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
            //this.response = ZendConnector.client.Execute(request);
            this.resource = resource;
            this.method = method;  
        }
    }
     */
}
