using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zendesk;
using RestSharp;
using Newtonsoft.Json.Linq;
namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            
           
            string userName = "david.jimbo26@gmail.com";
            string password = "Damannlp1!";

            ZendConnector myConnector = new ZendConnector(userName, password, "djimbo");
           
            //Console.WriteLine(myConnector.createUser("VS Test0", "david.jimbo26+300@gmail.com", "end-user"));
            //Console.WriteLine(myConnector.createUser("VS Test1", "david.jimbo26+302@gmail.com", "end-user"));
            //Console.WriteLine(myConnector.createUser("VS Test2", "david.jimbo26+303@gmail.com", "end-user"));
            //Console.WriteLine(myConnector.createUser("VS Test3", "david.jimbo26+304@gmail.com", "end-user"));
            //Console.WriteLine(myConnector.suspendUser(1243360477));
            //Console.WriteLine(myConnector.suspendUser(1247957928));
            Console.WriteLine(myConnector.setPassword(1247957708, "david"));
            Console.WriteLine(myConnector.setPassword(1243361517, "david"));

        }
    }
     
}
   