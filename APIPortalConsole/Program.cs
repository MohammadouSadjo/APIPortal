using System;
using APIPortalLibrary;
using APIPortalLibrary.Models.Store;
using Refit;
using System.Collections.Generic;
using APIPortalLibrary.Controllers;
using System.Net.Http;

namespace APIPortalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //** GET CLIENTID AND SECRET ID
            var taskClientIDSecret = LoginController.ClientIDSecret();

            ApiResponse<ClientIDAndSecret> clientIDSecret;
            clientIDSecret = taskClientIDSecret.Result;

            Console.WriteLine("ClientId : " + clientIDSecret.Content.clientId);
            Console.WriteLine("ClientSecret : " + clientIDSecret.Content.clientSecret);

            //** GET ACCESS TOKEN
            var taskAccessToken = LoginController.AccessToken("admin", "admin");

            ApiResponse<AccessToken> accessToken;
            accessToken = taskAccessToken.Result;

            Console.WriteLine("Access token : " + accessToken.Content.access_token);

            //** GET ALL APPLICATIONS
            var query = "";
            var limit = 25;
            var offset = 0;

            var taskAllApplications = ApplicationController.AllApplications(limit, offset, query);

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
            var taskApplicationDetails = ApplicationController.ApplicationDetails("cb76761d-4d45-4231-8578-6f5592571c11");

            ApiResponse<Application> applicationDetails;
            applicationDetails = taskApplicationDetails.Result;
            ;
            Console.WriteLine("Status code: " + applicationDetails.StatusCode);
            Console.WriteLine("Application ID : " + applicationDetails.Content.applicationId);
            Console.WriteLine("Description : " + applicationDetails.Content.description);

            //**GET APPLICATION KEY DETAILS OF A GIVEN TYPE
            /*var taskApplicationKeyDetailsOfGivenType = ApplicationController.ApplicationKeyDetailsOfGivenType("cb76761d-4d45-4231-8578-6f5592571c11", "PRODUCTION");

            ApiResponse<Key> applicationKeyDetailsOfGivenType;
            applicationKeyDetailsOfGivenType = taskApplicationKeyDetailsOfGivenType.Result;
            ;
            Console.WriteLine("Status code: " + applicationKeyDetailsOfGivenType.StatusCode);
            Console.WriteLine("Consumerkey : " + applicationKeyDetailsOfGivenType.Content.consumerKey);
            Console.WriteLine("consumersecret : " + applicationKeyDetailsOfGivenType.Content.consumerSecret);
            Console.WriteLine("keytype : " + applicationKeyDetailsOfGivenType.Content.keyType);*/

            //** ADD APPLICATION
            /*var throttlingTier = "Unlimited";
            var description = "sample app description";
            var name = "sampleapp";
            var callbackUrl = "";
            var groupId = "";
            var taskAddApplication = ApplicationController.AddApplication(throttlingTier, description, name, callbackUrl, groupId);
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
            var taskAddApplication = ApplicationController.UpdateApplication("bea5e191-0a51-4bb0-a91f-bd8987f68268", throttlingTier, description, name, callbackUrl, groupId);
            ApiResponse<Application> updateApplication;
            updateApplication = taskAddApplication.Result;

            Console.WriteLine("Update application");
            Console.WriteLine("Statuscode : " + updateApplication.StatusCode);
            Console.WriteLine("app id : " + updateApplication.Content.applicationId);
            Console.WriteLine("name : " + updateApplication.Content.name);
            Console.WriteLine("subscriber : " + updateApplication.Content.subscriber);*/

            //** UPDATE GRANTTYPES AND CALLBACK URL
            /*var refresh_token = "refresh_token";
            var oauth = "urn:ietf:params:oauth:grant-type:saml2-bearer";
            var password = "password";
            var client_credentials = "client_credentials";
            var iwa = "iwa:ntlm";
            List<string> supportedGrantTypes = new List<string>();
            supportedGrantTypes.Add(refresh_token);
            supportedGrantTypes.Add(oauth);
            supportedGrantTypes.Add(password);
            supportedGrantTypes.Add(client_credentials);
            supportedGrantTypes.Add(iwa);
            var callbackUrl = "http://sample/com/callback";
            var taskUpdateGrantTypesAndCallbackUrl = ApplicationController.UpdateGrantTypesAndCallbackUrl("cb76761d-4d45-4231-8578-6f5592571c11", "SANDBOX", supportedGrantTypes, callbackUrl);
            ApiResponse<Key> updateGrantTypesAndUrl;
            updateGrantTypesAndUrl = taskUpdateGrantTypesAndCallbackUrl.Result;

            Console.WriteLine("Update grantTypes and CallbackUrl");
            Console.WriteLine("statuscode : " + updateGrantTypesAndUrl.StatusCode);
            Console.WriteLine("Consumerkey : " + updateGrantTypesAndUrl.Content.consumerKey);
            Console.WriteLine("ConsumerSecret : " + updateGrantTypesAndUrl.Content.consumerSecret);*/
            //DELETE APPLICATION
            /*var taskDeleteApplication = ApplicationController.DeleteApplication("e69f94f8-9bbe-42b4-a0c1-a9f36a150853");
            ApiResponse<Application> deleteApplication;
            deleteApplication = taskDeleteApplication.Result;

            Console.WriteLine("Delete application");
            Console.WriteLine("StatusCode: " + deleteApplication.StatusCode);*/

            //**GENERATE APPLICATION KEYS 
            /*var taskApplicationKeys = ApplicationController.GenerateApplicationKeys("cb76761d-4d45-4231-8578-6f5592571c11");

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
            var taskAllApis = APIController.AllApis(limit,offset,query);

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
            var taskApiDetails = APIController.APIDetails(apiId);

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

            //** GET SWAGGER DEFINITION
            /**var apiId = "7c4c14bf-a7fc-48b4-84b3-b0a8b76c0071";
            var taskSwaggerDefinition = APIController.SwaggerDefinition(apiId);

            ApiResponse<string> swaggerDefinition;

            swaggerDefinition = taskSwaggerDefinition.Result;

            Console.WriteLine("Get Swagger definition:");
            Console.WriteLine("Status code : " + swaggerDefinition.StatusCode);
            Console.WriteLine("Content : " + swaggerDefinition.Content);*/

            //** GET ALL SUBSCRIPTIONS

            /*var taskAllSubscriptions = SubscriptionController.AllSubscriptions("aa2a068c-a007-498a-93a9-036d73c04281", 25,0);

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

            /*var taskSubscriptionDetails = SubscriptionController.SubscriptionDetails("a60d695c-0251-48dc-8417-710ab304fcdb");

            ApiResponse<Subscription> subscriptionDetails;

            subscriptionDetails = taskSubscriptionDetails.Result;
            Console.WriteLine("Subs Details : ");
            Console.WriteLine("Status code: " + subscriptionDetails.StatusCode);
            Console.WriteLine("API identifier : " + subscriptionDetails.Content.apiIdentifier);
            Console.WriteLine("App ID : " + subscriptionDetails.Content.applicationId);
            Console.WriteLine("SubscriptionId : " + subscriptionDetails.Content.subscriptionId);
            Console.WriteLine("tier : " + subscriptionDetails.Content.tier);
            Console.WriteLine("Status : " + subscriptionDetails.Content.status);*/

            //** ADD SUBSCRIPTION

            /*var tier = "Gold";
            var apiIdentifier = "7c4c14bf-a7fc-48b4-84b3-b0a8b76c0071";
            var applicationId = "aa2a068c-a007-498a-93a9-036d73c04281";
            var taskAddSubscription = SubscriptionController.AddSubscription(tier, apiIdentifier, applicationId);

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

            //** ADD SUBSCRIPTIONS MULTIPLE
            /*Subscription sub = new Subscription();
            List<Subscription> listSub = new List<Subscription>();
            sub.apiIdentifier = "7c4c14bf-a7fc-48b4-84b3-b0a8b76c0071";
            sub.applicationId = "aa2a068c-a007-498a-93a9-036d73c04281";
            sub.tier = "Gold";
            listSub.Add(sub);
            
            var taskAddSubscriptionMultiple = SubscriptionController.AddSubscriptionMultiple(listSub);

            ApiResponse<List<Subscription>> addSubscriptionMultiple;
            addSubscriptionMultiple = taskAddSubscriptionMultiple.Result;
            Console.WriteLine("Addsubscription Multiple");
            Console.WriteLine("StatusCode : " + addSubscriptionMultiple.StatusCode);
            addSubscriptionMultiple.Content.ForEach(c =>
            {
                Console.WriteLine("subsId : " + c.apiIdentifier);
                Console.WriteLine("appId : " + c.applicationId);
                Console.WriteLine("appIden : " + c.apiIdentifier);
            }
            );*/
            //** DELETE SUBSCRIPTION

            /*var taskDeleteSubscription = SubscriptionController.DeleteSubscription("fd28dc40-cb7c-4035-a44c-5b5cec8b49d3");
            
            ApiResponse<Subscription> deleteSubscription;
            deleteSubscription = taskDeleteSubscription.Result;
            Console.WriteLine("DELETE SUBS");
            Console.WriteLine(deleteSubscription.StatusCode);*/

            //** ALL DOCUMENTS
            /*var taskAllDocuments = DocumentController.AllDocuments("7c4c14bf-a7fc-48b4-84b3-b0a8b76c0071");

            ApiResponse<AllDocuments> allDocuments;

            allDocuments = taskAllDocuments.Result;

            Console.WriteLine("Get All Documents:");
            Console.WriteLine("Status code : " + allDocuments.StatusCode);
            Console.WriteLine("count : " + allDocuments.Content.count);
            Console.WriteLine("next : " + allDocuments.Content.next);
            allDocuments.Content.list.ForEach(c =>
            {
                Console.WriteLine("documentId : " + c.documentId);
                Console.WriteLine("name : " + c.name);
                Console.WriteLine("type : " + c.type);
                Console.WriteLine("summary : " + c.summary);
            }
            );*/

            //** GET A DOCUMENT FOR AN API
            /*var taskDocument = DocumentController.GetDocument("7c4c14bf-a7fc-48b4-84b3-b0a8b76c0071", "ea2b5ca8-c601-4377-9d79-e8d42b314743");

            ApiResponse<Document> document;

            document = taskDocument.Result;

            Console.WriteLine("Get Document");
            Console.WriteLine("Status code : " + document.StatusCode);
            Console.WriteLine("documentId : " + document.Content.documentId);
            Console.WriteLine("name : " + document.Content.name);
            Console.WriteLine("type : " + document.Content.type);
            Console.WriteLine("summary : " + document.Content.summary);*/

            //** GET A DOCUMENT Content FOR AN API
            /*var taskDocumentContent = DocumentController.GetDocumentContent("7c4c14bf-a7fc-48b4-84b3-b0a8b76c0071", "ea2b5ca8-c601-4377-9d79-e8d42b314743");

            ApiResponse<string> documentContent;

            documentContent = taskDocumentContent.Result;

            Console.WriteLine("Get Document Content");
            Console.WriteLine("Status code : " + documentContent.StatusCode);
            Console.WriteLine("Content : " + documentContent.Content);*/
        }
    }
}
