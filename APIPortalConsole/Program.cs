using System;
using APIPortalLibrary;
using APIPortalLibrary.Models;
using Refit;
using System.Collections.Generic;
using APIPortalLibrary.Services;
using Microsoft.Extensions.Http;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using APIPortalLibrary.Services.Applications;
using APIPortalLibrary.Services.Login;
using APIPortalLibrary.Services.APIs;
using APIPortalLibrary.Services.Documents;
using APIPortalLibrary.Services.Subscriptions;
using APIPortalLibrary.Services.Tags;

namespace APIPortalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //STORE SERVICE COLLECTION
            IServiceCollection services = new ServiceCollection();

            services.AddHttpClient<IClientIdAndSecretService, ClientIdAndSecretService>(c =>
            {
                c.BaseAddress = new Uri("https://localhost:9446");

            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            services.AddHttpClient<IAccessTokenService, AccessTokenService>(c =>
            {
                c.BaseAddress = new Uri("http://localhost:8283");

            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            services.AddHttpClient<IApplicationService, ApplicationService>(c =>
            {
                c.BaseAddress = new Uri("https://localhost:9443");

            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            services.AddHttpClient<IAPIService, APIService>(c =>
            {
                c.BaseAddress = new Uri("https://localhost:9446");

            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            services.AddHttpClient<IDocumentService, DocumentService>(c =>
            {
                c.BaseAddress = new Uri("https://localhost:9446");

            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            services.AddHttpClient<ISubscriptionService, SubscriptionService>(c =>
            {
                c.BaseAddress = new Uri("https://localhost:9446");

            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            services.AddHttpClient<ITagService, TagService>(c =>
            {
                c.BaseAddress = new Uri("https://localhost:9446");

            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var _serviceApplication = serviceProvider.GetRequiredService<IApplicationService>();
            var _serviceClientIdAndSecret = serviceProvider.GetRequiredService<IClientIdAndSecretService>();
            var _serviceAccessToken = serviceProvider.GetRequiredService<IAccessTokenService>();
            var _serviceAPI = serviceProvider.GetRequiredService<IAPIService>();
            var _serviceDocument = serviceProvider.GetRequiredService<IDocumentService>();
            var _serviceSubscription = serviceProvider.GetRequiredService<ISubscriptionService>();
            var _serviceTag = serviceProvider.GetRequiredService<ITagService>();

            //***LOGIN

            //GET CLIENTID AND SECRET ID
            ApiResponse<ClientIDAndSecret> ClientIDAndSecret()
            {
                string username = "admin";
                string password = "admin";
                string callbackUrl = "www.google.lk";
                string clientName = "rest_api_store";
                string owner = "admin";
                string grantType = "password refresh_token";
                bool saasApp = true;
                var taskClientIDSecret = _serviceClientIdAndSecret.ClientIDSecret(username, password, callbackUrl,clientName,owner,grantType,saasApp);

                ApiResponse<ClientIDAndSecret> clientIDSecret;
                clientIDSecret = taskClientIDSecret.Result;

                Console.WriteLine("ClientId : " + clientIDSecret.Content.clientId);
                Console.WriteLine("ClientSecret : " + clientIDSecret.Content.clientSecret);
                return clientIDSecret;
            }
            
            //GET ACCESS TOKEN
            ApiResponse<AccessToken> AccessToken(string clientId, string clientSecret)
            {
                var taskAccessToken = _serviceAccessToken.AccessToken("admin", "admin", clientId, clientSecret);

                ApiResponse<AccessToken> accessToken;
                accessToken = taskAccessToken.Result;

                Console.WriteLine("Access token : " + accessToken.Content.access_token);
                return accessToken;
            }

            var clientidsecret = ClientIDAndSecret();
            var accesstoken = AccessToken(clientidsecret.Content.clientId, clientidsecret.Content.clientSecret);

            //***APPLICATIONS
            //GetAllApplications(accesstoken);
            //GetApplicationDetails(accesstoken);
            //GetApplicationKeyDetailsOfAGivenType(accesstoken);
            //AddApplication(accesstoken);
            //UpdateApplication(accesstoken);
            //UpdateGrantTypesAndCallbackUrl(accesstoken);
            //DeleteApplication(accesstoken);
            //GenerateApplicationKeys(accesstoken);

            //***APIS
            //GetAllAPIs();
            //GetAPIDetails();
            //GetSwaggerDefinition();

            //***DOCUMENTS
            //GetAllDocuments();
            //GetDocument();
            //GetDocumentContent();

            //***SUBSCRIPTIONS
            //GetAllSubscriptions(accesstoken);
            //GetSubscriptionDetails(accesstoken);
            //AddSubscription(accesstoken);
            //AddSubscriptionMultiple(accesstoken);
            //DeleteSubscription(accesstoken);

            //***TAGS
            //GetAllTags();

            //GET ALL APPLICATIONS
            void GetAllApplications(ApiResponse<AccessToken> accessToken)
            {
                var query = "";
                var limit = 25;
                var offset = 0;
                
                var taskAllApplications = _serviceApplication.AllApplications(accesstoken.Content.access_token,accesstoken.Content.token_type, limit, offset, query);
                ApiResponse<AllApplications> allApplications = taskAllApplications.Result;

                Console.WriteLine("ALL APPLICATIONS");
                Console.WriteLine("Status code : " + allApplications.StatusCode);
                Console.WriteLine("count : " + allApplications.Content.count);
                Console.WriteLine("next : " + allApplications.Content.next);
                allApplications.Content.list.ForEach(c => {
                    Console.WriteLine("App Id : " + c.applicationId);
                    Console.WriteLine("App name : " + c.name);
                });
            }

            //GET APPLICATION DETAILS
            void GetApplicationDetails(ApiResponse<AccessToken> accessToken)
            {
                var taskApplicationDetails = _serviceApplication.ApplicationDetails(accesstoken.Content.access_token, accesstoken.Content.token_type, "cb76761d-4d45-4231-8578-6f5592571c11");
                ApiResponse<Application> applicationDetails = taskApplicationDetails.Result;

                Console.WriteLine("Status code: " + applicationDetails.StatusCode);
                Console.WriteLine("Application ID : " + applicationDetails.Content.applicationId);
                Console.WriteLine("Description : " + applicationDetails.Content.description);
            }


            //GET APPLICATION KEY DETAILS OF A GIVEN TYPE
            void GetApplicationKeyDetailsOfAGivenType(ApiResponse<AccessToken> accessToken)
            {
                var taskApplicationKeyDetailsOfGivenType = _serviceApplication.ApplicationKeyDetailsOfGivenType(accesstoken.Content.access_token, accesstoken.Content.token_type, "cb76761d-4d45-4231-8578-6f5592571c11", "PRODUCTION");

                ApiResponse<Key> applicationKeyDetailsOfGivenType;
                applicationKeyDetailsOfGivenType = taskApplicationKeyDetailsOfGivenType.Result;
                ;
                Console.WriteLine("Status code: " + applicationKeyDetailsOfGivenType.StatusCode);
                Console.WriteLine("Consumerkey : " + applicationKeyDetailsOfGivenType.Content.consumerKey);
                Console.WriteLine("consumersecret : " + applicationKeyDetailsOfGivenType.Content.consumerSecret);
                Console.WriteLine("keytype : " + applicationKeyDetailsOfGivenType.Content.keyType);
            }

            //ADD APPLICATION
            void AddApplication(ApiResponse<AccessToken> accessToken)
            {
                var throttlingTier = "Unlimited";
                var description = "sample app description";
                var name = "sampleapp";
                var callbackUrl = "";
                var groupId = "";
                var taskAddApplication = _serviceApplication.AddApplication(accesstoken.Content.access_token, accesstoken.Content.token_type, throttlingTier, description, name, callbackUrl, groupId);
                ApiResponse<Application> addApplication;
                addApplication = taskAddApplication.Result;

                Console.WriteLine("Add application");
                Console.WriteLine("Statuscode : " + addApplication.StatusCode);
                Console.WriteLine("app id : " + addApplication.Content.applicationId);
                Console.WriteLine("name : " + addApplication.Content.name);
                Console.WriteLine("subscriber : " + addApplication.Content.subscriber);
            }

            //UPDATE APPLICATION
            void UpdateApplication(ApiResponse<AccessToken> accessToken)
            {
                var throttlingTier = "Unlimited";
                var description = "sample app description";
                var name = "sampleappUpdated";
                var callbackUrl = "";
                var groupId = "";
                var taskAddApplication = _serviceApplication.UpdateApplication(accesstoken.Content.access_token, accesstoken.Content.token_type, "4da09cfb-c05c-400e-bc53-343f76727ad6", throttlingTier, description, name, callbackUrl, groupId);
                ApiResponse<Application> updateApplication;
                updateApplication = taskAddApplication.Result;

                Console.WriteLine("Update application");
                Console.WriteLine("Statuscode : " + updateApplication.StatusCode);
                Console.WriteLine("app id : " + updateApplication.Content.applicationId);
                Console.WriteLine("name : " + updateApplication.Content.name);
                Console.WriteLine("subscriber : " + updateApplication.Content.subscriber);
            }

            //UPDATE GRANTTYPES AND CALLBACK URL
            void UpdateGrantTypesAndCallbackUrl(ApiResponse<AccessToken> accessToken)
            {
                var refresh_token = "refresh_token";
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
                var taskUpdateGrantTypesAndCallbackUrl = _serviceApplication.UpdateGrantTypesAndCallbackUrl(accesstoken.Content.access_token, accesstoken.Content.token_type, "cb76761d-4d45-4231-8578-6f5592571c11", "SANDBOX", supportedGrantTypes, callbackUrl);
                ApiResponse<Key> updateGrantTypesAndUrl;
                updateGrantTypesAndUrl = taskUpdateGrantTypesAndCallbackUrl.Result;

                Console.WriteLine("Update grantTypes and CallbackUrl");
                Console.WriteLine("statuscode : " + updateGrantTypesAndUrl.StatusCode);
                Console.WriteLine("Consumerkey : " + updateGrantTypesAndUrl.Content.consumerKey);
                Console.WriteLine("ConsumerSecret : " + updateGrantTypesAndUrl.Content.consumerSecret);
            }
            
            //DELETE APPLICATION
            void DeleteApplication(ApiResponse<AccessToken> accessToken)
            {
                var taskDeleteApplication = _serviceApplication.DeleteApplication(accesstoken.Content.access_token, accesstoken.Content.token_type, "4da09cfb-c05c-400e-bc53-343f76727ad6");
                ApiResponse<Application> deleteApplication;
                deleteApplication = taskDeleteApplication.Result;

                Console.WriteLine("Delete application");
                Console.WriteLine("StatusCode: " + deleteApplication.StatusCode);
            }

            //GENERATE APPLICATION KEYS 
            void GenerateApplicationKeys(ApiResponse<AccessToken> accessToken)
            {
                var validityTime = 3600;
                var keyType = "PRODUCTION";
                var refresh_token = "refresh_token";
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
                var taskApplicationKeys = _serviceApplication.GenerateApplicationKeys(accesstoken.Content.access_token, accesstoken.Content.token_type, "a135e363-10b6-4171-8d18-0e8c89614692", validityTime, keyType, supportedGrantTypes);

                ApiResponse<GenerateApplicationKeys> applicationKeys;
                applicationKeys = taskApplicationKeys.Result;

                Console.WriteLine("Status code : " + applicationKeys.StatusCode);
                Console.WriteLine("Consumer Key : " + applicationKeys.Content.consumerKey);
                Console.WriteLine("Consumer Secret : " + applicationKeys.Content.consumerSecret);
                Console.WriteLine("Access Token : " + applicationKeys.Content.token.accessToken);
            }

            //GET ALL APIS
            void GetAllAPIs()
            {
                var limit = 25;
                var offset = 0;
                var query = "";
                var taskAllApis = _serviceAPI.AllApis(limit, offset, query);

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
                Console.WriteLine("Pagination total : " + allApis.Content.pagination.total);
            }

            //GET API DETAILS
            void GetAPIDetails()
            {
                var apiId = "7d601720-3a59-467b-8595-afbbbce6d12a";
                var taskApiDetails = _serviceAPI.APIDetails(apiId);

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
                Console.WriteLine(apiDetails.Content.createdTime);
            }

            //** GET SWAGGER DEFINITION
            void GetSwaggerDefinition()
            {
                var apiId = "7c4c14bf-a7fc-48b4-84b3-b0a8b76c0071";
                var taskSwaggerDefinition = _serviceAPI.SwaggerDefinition(apiId);

                ApiResponse<string> swaggerDefinition;

                swaggerDefinition = taskSwaggerDefinition.Result;

                Console.WriteLine("Get Swagger definition:");
                Console.WriteLine("Status code : " + swaggerDefinition.StatusCode);
                Console.WriteLine("Content : " + swaggerDefinition.Content);
            }

            //** GET ALL SUBSCRIPTIONS
            void GetAllSubscriptions(ApiResponse<AccessToken> accessToken)
            {
                var taskAllSubscriptions = _serviceSubscription.AllSubscriptions(accesstoken.Content.access_token, accesstoken.Content.token_type, "aa2a068c-a007-498a-93a9-036d73c04281", 25, 0);

                ApiResponse<AllSubscriptions> allSubscriptions;

                allSubscriptions = taskAllSubscriptions.Result;

                Console.WriteLine("Count : " + allSubscriptions.Content.count);
                Console.WriteLine("next : " + allSubscriptions.Content.next);
                Console.WriteLine("previous : " + allSubscriptions.Content.previous);
                allSubscriptions.Content.list.ForEach(c => Console.WriteLine(
                    "API Identifier : " + c.apiIdentifier +
                    "Application Id : " + c.applicationId +
                    "tier : " + c.tier +
                    "Status : " + c.status
                    ));
            }

            //** GET SUBSCRIPTION DETAILS 
            void GetSubscriptionDetails(ApiResponse<AccessToken> accessToken)
            {
                var taskSubscriptionDetails = _serviceSubscription.SubscriptionDetails(accesstoken.Content.access_token, accesstoken.Content.token_type, "a60d695c-0251-48dc-8417-710ab304fcdb");

                ApiResponse<Subscription> subscriptionDetails;

                subscriptionDetails = taskSubscriptionDetails.Result;
                Console.WriteLine("Subs Details : ");
                Console.WriteLine("Status code: " + subscriptionDetails.StatusCode);
                Console.WriteLine("API identifier : " + subscriptionDetails.Content.apiIdentifier);
                Console.WriteLine("App ID : " + subscriptionDetails.Content.applicationId);
                Console.WriteLine("SubscriptionId : " + subscriptionDetails.Content.subscriptionId);
                Console.WriteLine("tier : " + subscriptionDetails.Content.tier);
                Console.WriteLine("Status : " + subscriptionDetails.Content.status);
            }

            //** ADD SUBSCRIPTION
            void AddSubscription(ApiResponse<AccessToken> accessToken)
            {
                var tier = "Gold";
                var apiIdentifier = "7c4c14bf-a7fc-48b4-84b3-b0a8b76c0071";
                var applicationId = "aa2a068c-a007-498a-93a9-036d73c04281";
                var taskAddSubscription = _serviceSubscription.AddSubscription(accesstoken.Content.access_token, accesstoken.Content.token_type, tier, apiIdentifier, applicationId);

                ApiResponse<Subscription> addSubscription;
                addSubscription = taskAddSubscription.Result;
                Console.WriteLine("ADD SUBSCRIPTION");
                Console.WriteLine("Status code: " + addSubscription.StatusCode);
                Console.ReadLine();
                Console.WriteLine("Subscription ID : " + addSubscription.Content.subscriptionId);
                Console.WriteLine("application ID : " + addSubscription.Content.subscriptionId);
                Console.WriteLine("application identifier : " + addSubscription.Content.subscriptionId);
                Console.WriteLine("tier : " + addSubscription.Content.subscriptionId);
                Console.WriteLine("status : " + addSubscription.Content.subscriptionId);
            }
            /**/

            //** ADD SUBSCRIPTIONS MULTIPLE
            void AddSubscriptionMultiple(ApiResponse<AccessToken> accessToken)
            {
                Subscription sub = new Subscription();
                List<Subscription> listSub = new List<Subscription>();
                sub.apiIdentifier = "7c4c14bf-a7fc-48b4-84b3-b0a8b76c0071";
                sub.applicationId = "aa2a068c-a007-498a-93a9-036d73c04281";
                sub.tier = "Gold";
                listSub.Add(sub);

                var taskAddSubscriptionMultiple = _serviceSubscription.AddSubscriptionMultiple(accesstoken.Content.access_token, accesstoken.Content.token_type, listSub);

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
                );
            }

            //** DELETE SUBSCRIPTION
            void DeleteSubscription(ApiResponse<AccessToken> accessToken)
            {
                var taskDeleteSubscription = _serviceSubscription.DeleteSubscription(accesstoken.Content.access_token, accesstoken.Content.token_type, "fd28dc40-cb7c-4035-a44c-5b5cec8b49d3");

                ApiResponse<Subscription> deleteSubscription;
                deleteSubscription = taskDeleteSubscription.Result;
                Console.WriteLine("DELETE SUBS");
                Console.WriteLine(deleteSubscription.StatusCode);
            }

            //** GET ALL DOCUMENTS
            void GetAllDocuments()
            {
                var taskAllDocuments = _serviceDocument.AllDocuments("7c4c14bf-a7fc-48b4-84b3-b0a8b76c0071");

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
                );
            }

            //** GET A DOCUMENT FOR AN API
            void GetDocument()
            {
                var taskDocument = _serviceDocument.GetDocument("7c4c14bf-a7fc-48b4-84b3-b0a8b76c0071", "0582a0cf-e3e7-446f-a5fe-7b6774c9f16d");

                ApiResponse<Document> document;

                document = taskDocument.Result;

                Console.WriteLine("Get Document");
                Console.WriteLine("Status code : " + document.StatusCode);
                Console.WriteLine("documentId : " + document.Content.documentId);
                Console.WriteLine("name : " + document.Content.name);
                Console.WriteLine("type : " + document.Content.type);
                Console.WriteLine("summary : " + document.Content.summary);
            }

            //** GET A DOCUMENT Content FOR AN API
            void GetDocumentContent()
            {
                var taskDocumentContent = _serviceDocument.GetDocumentContent("7c4c14bf-a7fc-48b4-84b3-b0a8b76c0071", "0582a0cf-e3e7-446f-a5fe-7b6774c9f16d");

                ApiResponse<string> documentContent;

                documentContent = taskDocumentContent.Result;

                Console.WriteLine("Get Document Content");
                Console.WriteLine("Status code : " + documentContent.StatusCode);
                Console.WriteLine("Content : " + documentContent.Content);
            }

            //GET ALL TAGS
            void GetAllTags()
            {
                var limit = 25;
                var offset = 0;
                var taskAllTags = _serviceTag.Alltags(limit, offset);

                ApiResponse<AllTags> allTags;

                allTags = taskAllTags.Result;

                Console.WriteLine("Get All Apis:");
                Console.WriteLine("Status code : " + allTags.StatusCode);
                Console.WriteLine("List : " + allTags.Content.list);
                allTags.Content.list.ForEach(c => { Console.WriteLine(c.name); });
                Console.WriteLine("Count : " + allTags.Content.count);
                Console.WriteLine("Next : " + allTags.Content.next);
                Console.WriteLine("Previous : " + allTags.Content.previous);
               
            }
        }
    }
}
