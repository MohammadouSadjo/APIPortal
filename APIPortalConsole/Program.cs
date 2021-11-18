using System;
using APIPortalLibrary;
using APIPortalLibrary.Models.Store;
using APIPortalLibrary.Models.Authentication;
using Refit;

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

            //** GET ALL APPLICATIONS
            var query = "";
            var limit = 25;
            var offset = 0;

            var taskAllApplications = Go.AllApplications(limit, offset, query);

            ApiResponse<AllApplications> allApplications;
            allApplications = taskAllApplications.Result;

            Console.WriteLine("ALL APPLICATIONS");
            Console.WriteLine("Status code : " + allApplications.StatusCode);
            Console.WriteLine("count : " + allApplications.Content.count);
            Console.WriteLine("next : " + allApplications.Content.next);
            allApplications.Content.list.ForEach(c => {
                Console.WriteLine("App Id : " + c.applicationId);
                Console.WriteLine("App name : " + c.name);
            });

            //**GET APPLICATION DETAILS
            /*var taskApplicationDetails = Go.ApplicationDetails("cb76761d-4d45-4231-8578-6f5592571c11");

            ApiResponse<Application> applicationDetails;
            applicationDetails = taskApplicationDetails.Result;
            ;
            Console.WriteLine("Status code: " + applicationDetails.StatusCode);
            Console.WriteLine("Application ID : " + applicationDetails.Content.applicationId);
            Console.WriteLine("Description : " + applicationDetails.Content.description);*/

            //** ADD APPLICATION
            /*var throttlingTier = "Unlimited";
            var description = "sample app description";
            var name = "sampleapp";
            var callbackUrl = "";
            var groupId = "";
            var taskAddApplication = Go.AddApplication(throttlingTier, description, name, callbackUrl, groupId);
            ApiResponse<Application> addApplication;
            addApplication = taskAddApplication.Result;

            Console.WriteLine("Add application");
            Console.WriteLine("Statuscode : " + addApplication.StatusCode);
            Console.WriteLine("app id : " + addApplication.Content.applicationId);
            Console.WriteLine("name : " + addApplication.Content.name);
            Console.WriteLine("subscriber : " + addApplication.Content.subscriber);*/

            //**UPDATE APPLICATION
            /*var throttlingTier = "Unlimited";
            var description = "sample app description";
            var name = "sampleappUpdated";
            var callbackUrl = "";
            var groupId = "";
            var taskAddApplication = Go.UpdateApplication("bea5e191-0a51-4bb0-a91f-bd8987f68268", throttlingTier, description, name, callbackUrl, groupId);
            ApiResponse<Application> updateApplication;
            updateApplication = taskAddApplication.Result;

            Console.WriteLine("Update application");
            Console.WriteLine("Statuscode : " + updateApplication.StatusCode);
            Console.WriteLine("app id : " + updateApplication.Content.applicationId);
            Console.WriteLine("name : " + updateApplication.Content.name);
            Console.WriteLine("subscriber : " + updateApplication.Content.subscriber);*/

            //DELETE APPLICATION
            /*var taskDeleteApplication = Go.DeleteApplication("e69f94f8-9bbe-42b4-a0c1-a9f36a150853");
            ApiResponse<Application> deleteApplication;
            deleteApplication = taskDeleteApplication.Result;

            Console.WriteLine("Delete application");
            Console.WriteLine("StatusCode: " + deleteApplication.StatusCode);*/

            //**GENERATE APPLICATION KEYS 
            /*var taskApplicationKeys = Go.GenerateApplicationKeys("cb76761d-4d45-4231-8578-6f5592571c11");

            ApiResponse<GenerateApplicationKeys> applicationKeys;
            applicationKeys = taskApplicationKeys.Result;

            Console.WriteLine("Status code : " + applicationKeys.StatusCode);
            Console.WriteLine("Consumer Key : " + applicationKeys.Content.consumerKey);
            Console.WriteLine("Consumer Secret : " + applicationKeys.Content.consumerSecret);
            Console.WriteLine("Access Token : " + applicationKeys.Content.token.accessToken);*/

            //**  GET ALL APIS
            /*var limit = 25;
            var offset = 0;
            var query = "";
            var taskAllApis = Go.AllApis(limit,offset,query);

            ApiResponse<AllApis> allApis;

            allApis = taskAllApis.Result;

            Console.WriteLine("Get All Apis:");
            Console.WriteLine("Status code : " + allApis.StatusCode);
            Console.WriteLine("List : " + allApis.Content.list);
            Console.WriteLine("Count : " + allApis.Content.count);
            Console.WriteLine("Next : " + allApis.Content.next);
            Console.WriteLine("Previous : " + allApis.Content.previous);
            Console.WriteLine("Pagination limit : " + allApis.Content.pagination.limit);
            Console.WriteLine("Pagination offset : " + allApis.Content.pagination.offset);
            Console.WriteLine("Pagination total : " + allApis.Content.pagination.total);*/

            //** GET API DETAILS
            /*var apiId = "7d601720-3a59-467b-8595-afbbbce6d12a";
            var taskApiDetails = Go.APIDetails(apiId);

            ApiResponse<API> apiDetails;

            apiDetails = taskApiDetails.Result;

            Console.WriteLine("Get Apis details:");
            Console.WriteLine("Status code : " + apiDetails.StatusCode);
            Console.WriteLine("id : " + apiDetails.Content.id);
            Console.WriteLine("name : " + apiDetails.Content.name);
            Console.WriteLine("description : " + apiDetails.Content.description);
            Console.WriteLine("context : " + apiDetails.Content.context);
            Console.WriteLine("version : " + apiDetails.Content.version);
            Console.WriteLine("provider : " + apiDetails.Content.provider);
            apiDetails.Content.transport.ForEach(c => Console.WriteLine($"transport : {c}"));
            Console.WriteLine("isdefaultversion : " + apiDetails.Content.isDefaultVersion);
            apiDetails.Content.endpointURLs.ForEach(c => Console.WriteLine(
                "environment Name:" + c.environmentName +
                "environment Type:" + c.environmentType +
                "environment URLs:" + c.environmentURLs.http
                ));
            apiDetails.Content.environmentList.ForEach(c => Console.WriteLine(c));
            Console.WriteLine(apiDetails.Content.lastUpdatedTime);
            Console.WriteLine(apiDetails.Content.createdTime);*/

            //** GET ALL SUBSCRIPTIONS

            /*var taskAllSubscriptions = Go.AllSubscriptions("aa2a068c-a007-498a-93a9-036d73c04281", 25,0);

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
                ));*/

            //** GET SUBSCRIPTION DETAILS 

            var taskSubscriptionDetails = Go.SubscriptionDetails("a60d695c-0251-48dc-8417-710ab304fcdb");

            ApiResponse<Subscription> subscriptionDetails;

            subscriptionDetails = taskSubscriptionDetails.Result;
            Console.WriteLine("Subs Details : ");
            Console.WriteLine("Status code: " + subscriptionDetails.StatusCode);
            Console.WriteLine("API identifier : " + subscriptionDetails.Content.apiIdentifier);
            Console.WriteLine("App ID : " + subscriptionDetails.Content.applicationId);
            Console.WriteLine("SubscriptionId : " + subscriptionDetails.Content.subscriptionId);
            Console.WriteLine("tier : " + subscriptionDetails.Content.tier);
            Console.WriteLine("Status : " + subscriptionDetails.Content.status);

            //** ADD SUBSCRIPTION

            /*var tier = "Gold";
            var apiIdentifier = "7c4c14bf-a7fc-48b4-84b3-b0a8b76c0071";
            var applicationId = "aa2a068c-a007-498a-93a9-036d73c04281";
            var taskAddSubscription = Go.AddSubscription(tier, apiIdentifier, applicationId);

            ApiResponse<Subscription> addSubscription;
            addSubscription = taskAddSubscription.Result;
            Console.WriteLine("ADD SUBSCRIPTION");
            Console.WriteLine("Status code: " + addSubscription.StatusCode);
            Console.ReadLine();
            Console.WriteLine("Subscription ID : " + addSubscription.Content.subscriptionId);
            Console.WriteLine("application ID : " + addSubscription.Content.subscriptionId);
            Console.WriteLine("application identifier : " + addSubscription.Content.subscriptionId);
            Console.WriteLine("tier : " + addSubscription.Content.subscriptionId);
            Console.WriteLine("status : " + addSubscription.Content.subscriptionId);*/

            //** DELETE SUBSCRIPTION

            /*var taskDeleteSubscription = Go.DeleteSubscription("fd28dc40-cb7c-4035-a44c-5b5cec8b49d3");
            
            ApiResponse<Subscription> deleteSubscription;
            deleteSubscription = taskDeleteSubscription.Result;
            Console.WriteLine("DELETE SUBS");
            Console.WriteLine(deleteSubscription.StatusCode);*/
        }
    }
}
