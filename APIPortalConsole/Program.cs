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

            ClientIDAndSecret clientIDSecret;
            clientIDSecret = taskClientIDSecret.Result;

            Console.WriteLine("ClientId : " + clientIDSecret.clientId);
            Console.WriteLine("ClientSecret : " + clientIDSecret.clientSecret);

            //** GET ACCESS TOKEN
            var taskAccessToken = Go.AccessToken("admin", "admin");

            AccessToken accessToken;
            accessToken = taskAccessToken.Result;

            Console.WriteLine("Access token : " + accessToken.access_token);

            //**GET APPLICATION DETAILS
            /*var taskApplicationDetails = Go.ApplicationDetails("cb76761d-4d45-4231-8578-6f5592571c11");

            Application applicationDetails;
            applicationDetails = taskApplicationDetails.Result;

            Console.WriteLine("Application ID : " + applicationDetails.applicationId);
            Console.WriteLine("Description : " + applicationDetails.description);*/

            //**GENERATE APPLICATION KEYS 
            /*var taskApplicationKeys = Go.GenerateApplicationKeys("cb76761d-4d45-4231-8578-6f5592571c11");

            GenerateApplicationKeys applicationKeys;
            applicationKeys = taskApplicationKeys.Result;

            Console.WriteLine("Consumer Key : " + applicationKeys.consumerKey);
            Console.WriteLine("Consumer Secret : " + applicationKeys.consumerSecret);
            Console.WriteLine("Access Token : " + applicationKeys.token.accessToken);*/

            //**  GET ALL APIS
            /*var limit = 25;
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
            Console.WriteLine("Pagination total : " + allApis.pagination.total);*/

            //** GET API DETAILS
            /*var apiId = "7d601720-3a59-467b-8595-afbbbce6d12a";
            var taskApiDetails = Go.APIDetails(apiId);

            API apiDetails;

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
            Console.WriteLine(apiDetails.createdTTime);*/

            //** GET ALL SUBSCRIPTIONS

            var taskAllSubscriptions = Go.AllSubscriptions("aa2a068c-a007-498a-93a9-036d73c04281", 25,0);

            AllSubscriptions allSubscriptions;

            allSubscriptions = taskAllSubscriptions.Result;

            Console.WriteLine("Count : " + allSubscriptions.count);
            Console.WriteLine("next : " + allSubscriptions.next);
            Console.WriteLine("previous : " + allSubscriptions.previous);
            allSubscriptions.list.ForEach(c => Console.WriteLine(
                "API Identifier : " + c.apiIdentifier +
                "Application Id : " + c.applicationId +
                "tier : " + c.tier +
                "Status : " + c.status
                ));
        }
    }
}
