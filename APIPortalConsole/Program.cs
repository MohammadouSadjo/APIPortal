using System;
using APIPortalLibrary;
using APIPortalLibrary.Models.Store;
using APIPortalLibrary.Models.Authentication;


namespace APIPortalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //** GET CLIENTID AND SECRET ID
            var taskClientIDSecret = Go.ClientIDSecret();

            ClientIDSecret clientIDSecret;
            clientIDSecret = taskClientIDSecret.Result;

            Console.WriteLine("ClientId : " + clientIDSecret.clientId);
            Console.WriteLine("ClientSecret : " + clientIDSecret.clientSecret);

            //** GET ACCESS TOKEN
            var taskAccessToken = Go.AccessToken("admin", "admin");

            AccessToken accessToken;
            accessToken = taskAccessToken.Result;

            Console.WriteLine("Access token : " + accessToken.access_token);

            //**  GET ALL APIS
            var limit = 25;
            var offset = 0;
            var query = "";
            var taskAllApis = Go.AllApis(limit,offset,query);

            AllApis allApis;

            allApis = taskAllApis.Result;

            Console.WriteLine("Get All Apis:");
            Console.WriteLine("List : " + allApis.list);
            Console.WriteLine("Count : " + allApis.count);
            Console.WriteLine("Next : " + allApis.next);
            Console.WriteLine("Previous : " + allApis.previous);
            Console.WriteLine("Pagination limit : " + allApis.pagination.limit);
            Console.WriteLine("Pagination offset : " + allApis.pagination.offset);
            Console.WriteLine("Pagination total : " + allApis.pagination.total);

            //** GET API DETAILS
            var apiId = "7d601720-3a59-467b-8595-afbbbce6d12a";
            var taskApiDetails = Go.APIDetails(apiId);

            APIDetails apiDetails;

            apiDetails = taskApiDetails.Result;

            Console.WriteLine("Get Apis details:");
            Console.WriteLine("id : " + apiDetails.id);
            Console.WriteLine("name : " + apiDetails.name);
            Console.WriteLine("description : " + apiDetails.description);
            Console.WriteLine("context : " + apiDetails.context);
            Console.WriteLine("version : " + apiDetails.version);
            Console.WriteLine("provider : " + apiDetails.provider);
            apiDetails.transport.ForEach(c => Console.WriteLine($"transport : {c}"));
            Console.WriteLine("isdefaultversion : " + apiDetails.isDefaultVersion);
            apiDetails.endpointURLs.ForEach(c => Console.WriteLine(
                "environment Name:" + c.environmentName +
                "environment Type:" + c.environmentType +
                "environment URLs:" + c.environmentURLs.http
                ));
            apiDetails.environmentList.ForEach(c => Console.WriteLine(c));
            Console.WriteLine(apiDetails.lastUpdatedTime);
            Console.WriteLine(apiDetails.createdTTime);
        }
    }
}
