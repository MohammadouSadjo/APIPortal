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

namespace APIPortalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //STORE
            IServiceCollection services = new ServiceCollection();
            services.AddHttpClient<IApplicationService, ApplicationService>(c =>
            {
                c.BaseAddress = new Uri("https://localhost:9443");

            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            services.AddHttpClient<IClientIdAndSecretService, ClientIdAndSecretService>(c =>
            {
                c.BaseAddress = new Uri("https://localhost:9443");

            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            services.AddHttpClient<IAccessTokenService, AccessTokenService>(c =>
            {
                c.BaseAddress = new Uri("https://localhost:9443");

            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            services.AddHttpClient<IAPIService, APIService>(c =>
            {
                c.BaseAddress = new Uri("https://localhost:9443");

            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            services.AddHttpClient<IDocumentService, DocumentService>(c =>
            {
                c.BaseAddress = new Uri("https://localhost:9443");

            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            });

            services.AddHttpClient<ISubscriptionService, SubscriptionService>(c =>
            {
                c.BaseAddress = new Uri("https://localhost:9443");

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

            //***LOGIN

            //GET CLIENTID AND SECRET ID
            ApiResponse<ClientIDAndSecret> ClientIDAndSecret()
            {
                string username = "admin";
                string password = "admin";
                string callbackUrl = "www.google.lk";
                string clientName = "rest_api_devportal";
                string owner = "admin";
                string grantType = "client_credentials password refresh_token";
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
            DeleteSubscription(accesstoken);


            //GET ALL APPLICATIONS
            void GetAllApplications(ApiResponse<AccessToken> accessToken)
            {
                var query ="";
                var limit = 25;
                var offset = 0;
                
                var taskAllApplications = _serviceApplication.AllApplications(accesstoken.Content.access_token,accesstoken.Content.token_type, limit, offset, query);
                ApiResponse<AllApplications> allApplications = taskAllApplications.Result;

                Console.WriteLine("ALL APPLICATIONS");
                Console.WriteLine("Status code : " + allApplications.StatusCode);
                Console.WriteLine("count : " + allApplications.Content.count);
                Console.WriteLine("next : " + allApplications.Content.pagination.next);
                allApplications.Content.list.ForEach(c => {
                    Console.WriteLine("App Id : " + c.applicationId);
                    /*Console.WriteLine("Description : " + c.description);
                    Console.WriteLine("Status : " + c.status);
                    Console.WriteLine("SubscriptionCount : " + c.subscriptionCount);
                    Console.WriteLine("Owner : " + c.owner);
                    Console.WriteLine("App name : " + c.name);
                    Console.WriteLine("Token Type : " + c.tokenType);
                    Console.WriteLine("HashEnabled : " + c.hashEnabled);*/
                    
                });
            }

            //GET APPLICATION DETAILS
            void GetApplicationDetails(ApiResponse<AccessToken> accessToken)
            {
                var taskApplicationDetails = _serviceApplication.ApplicationDetails(accesstoken.Content.access_token, accesstoken.Content.token_type, "f8756046-dd42-4406-8b4d-bef8721baf6b");
                ApiResponse<Application> applicationDetails = taskApplicationDetails.Result;

                Console.WriteLine("Status code: " + applicationDetails.StatusCode);
                Console.WriteLine("Application ID : " + applicationDetails.Content.applicationId);
                Console.WriteLine("Description : " + applicationDetails.Content.description);
            }


            //GET APPLICATION KEY DETAILS OF A GIVEN TYPE
            void GetApplicationKeyDetailsOfAGivenType(ApiResponse<AccessToken> accessToken)
            {
                var taskApplicationKeyDetailsOfGivenType = _serviceApplication.ApplicationKeyDetailsOfGivenType(accesstoken.Content.access_token, accesstoken.Content.token_type, "6dee7791-02e9-415c-907d-882839e38537", "411597d6-da15-446e-96a9-d179313e2c8c");

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
                var throttlingPolicy = "Unlimited";
                var description = "sample app description";
                var name = "sampleapp";
                var tokenType = "JWT";
                var taskAddApplication = _serviceApplication.AddApplication(accesstoken.Content.access_token, accesstoken.Content.token_type, tokenType, throttlingPolicy, description, name);
                ApiResponse<Application> addApplication;
                addApplication = taskAddApplication.Result;

                Console.WriteLine("Add application");
                Console.WriteLine("Statuscode : " + addApplication.StatusCode);
                Console.WriteLine("app id : " + addApplication.Content.applicationId);
                //Console.WriteLine("name : " + addApplication.Content.name);
            }

            //UPDATE APPLICATION
            void UpdateApplication(ApiResponse<AccessToken> accessToken)
            {
                var applicationId = "f8756046-dd42-4406-8b4d-bef8721baf6b";
                var throttlingPolicy = "Unlimited";
                var description = "sample app description";
                var name = "sampleapp";
                var tokenType = "JWT";
                var taskAddApplication = _serviceApplication.UpdateApplication(accesstoken.Content.access_token, accesstoken.Content.token_type, applicationId, tokenType, throttlingPolicy, description, name);
                ApiResponse<Application> updateApplication;
                updateApplication = taskAddApplication.Result;

                Console.WriteLine("Update application");
                Console.WriteLine("Statuscode : " + updateApplication.StatusCode);
                Console.WriteLine("app id : " + updateApplication.Content.applicationId);
                //Console.WriteLine("name : " + updateApplication.Content.name);
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
                var keyManager = "Resident Key Manager";
                var keyState = "APPROVED";
                var keyType = "PRODUCTION";
                var mode = "CREATED";
                AToken aToken = new AToken();
                aToken.accessToken = "1.2345678901234568e+30";
                aToken.validityTime = 3600;
                List<string> list = new List<string>();
                list.Add("default");
                list.Add("read_api");
                list.Add("write_api");

                aToken.tokenScopes = list;
                
                var taskUpdateGrantTypesAndCallbackUrl = _serviceApplication.UpdateGrantTypesAndCallbackUrl(accesstoken.Content.access_token, accesstoken.Content.token_type, "6dee7791-02e9-415c-907d-882839e38537", "411597d6-da15-446e-96a9-d179313e2c8c", supportedGrantTypes, callbackUrl, keyManager, keyState, keyType, mode, aToken);
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
                var taskDeleteApplication = _serviceApplication.DeleteApplication(accesstoken.Content.access_token, accesstoken.Content.token_type, "de1c0da0-a26a-47e1-bca5-b0f849be997f");
                ApiResponse<Application> deleteApplication;
                deleteApplication = taskDeleteApplication.Result;

                Console.WriteLine("Delete application");
                Console.WriteLine("StatusCode: " + deleteApplication.StatusCode);
            }

            //GENERATE APPLICATION KEYS 
            void GenerateApplicationKeys(ApiResponse<AccessToken> accessToken)
            {
                var keyType = "PRODUCTION";
                var keyManager = "Resident Key Manager";
                List<string> grantTypesToBeSupported = new List<string>();
                grantTypesToBeSupported.Add("password");
                grantTypesToBeSupported.Add("client_credentials");
                var callbackUrl = "http://sample.com/callback/url";
                List<string> scopes = new List<string>();
                scopes.Add("am_application_scope");
                scopes.Add("default");
                var validityTime = "3600";
                
                var taskApplicationKeys = _serviceApplication.GenerateApplicationKeys(accesstoken.Content.access_token, accesstoken.Content.token_type, "c4b3c60c-9e0c-4b75-8337-19074c734bcc", keyType, keyManager, grantTypesToBeSupported, callbackUrl, scopes, validityTime);

                ApiResponse<GenerateApplicationKeys> applicationKeys;
                applicationKeys = taskApplicationKeys.Result;

                Console.WriteLine("Status code : " + applicationKeys.StatusCode);
                Console.WriteLine("Consumer Key : " + applicationKeys.Content.consumerSecret);
                //Console.WriteLine("Consumer Secret : " + applicationKeys.Content.consumerSecret);
                //Console.WriteLine("Access Token : " + applicationKeys.Content.token.accessToken);
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
                Console.WriteLine("Next : " + allApis.Content.pagination.next);
                Console.WriteLine("Previous : " + allApis.Content.pagination.previous);
                Console.WriteLine("Pagination limit : " + allApis.Content.pagination.limit);
                Console.WriteLine("Pagination offset : " + allApis.Content.pagination.offset);
                Console.WriteLine("Pagination total : " + allApis.Content.pagination.total);
            }

            //GET API DETAILS
            void GetAPIDetails()
            {
                var apiId = "471a098b-fa90-416e-b194-51c5855e04f7";
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
                    "environment Type:" + c.environmentType 
                    ));
                apiDetails.Content.environmentList.ForEach(c => Console.WriteLine(c));
                Console.WriteLine(apiDetails.Content.lastUpdatedTime);
                Console.WriteLine(apiDetails.Content.createdTime);
            }

            //** GET SWAGGER DEFINITION
            void GetSwaggerDefinition()
            {
                var apiId = "471a098b-fa90-416e-b194-51c5855e04f7";
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
                var taskAllSubscriptions = _serviceSubscription.AllSubscriptions(accesstoken.Content.access_token, accesstoken.Content.token_type, "6dee7791-02e9-415c-907d-882839e38537", 25, 0);

                ApiResponse<AllSubscriptions> allSubscriptions;

                allSubscriptions = taskAllSubscriptions.Result;

                Console.WriteLine("Status code : " + allSubscriptions.StatusCode);
                Console.WriteLine("Count : " + allSubscriptions.Content.count);
                allSubscriptions.Content.list.ForEach(c => Console.WriteLine(
                    "API Identifier : " + c.subscriptionId +
                    "Application Id : " + c.applicationId +
                    "tier : " + c.apiId +
                    "Status : " + c.status
                    ));
            }

            //** GET SUBSCRIPTION DETAILS 
            void GetSubscriptionDetails(ApiResponse<AccessToken> accessToken)
            {
                var taskSubscriptionDetails = _serviceSubscription.SubscriptionDetails(accesstoken.Content.access_token, accesstoken.Content.token_type, "11332a11-8b90-4dbf-a5da-704da67578ea");

                ApiResponse<Subscription> subscriptionDetails;

                subscriptionDetails = taskSubscriptionDetails.Result;
                Console.WriteLine("Subs Details : ");
                Console.WriteLine("Status code: " + subscriptionDetails.StatusCode);
                Console.WriteLine("API identifier : " + subscriptionDetails.Content.apiId);
                Console.WriteLine("App ID : " + subscriptionDetails.Content.applicationId);
                Console.WriteLine("SubscriptionId : " + subscriptionDetails.Content.subscriptionId);
                Console.WriteLine("tier : " + subscriptionDetails.Content.throttlingPolicy);
                Console.WriteLine("Status : " + subscriptionDetails.Content.status);
            }

            //** ADD SUBSCRIPTION
            void AddSubscription(ApiResponse<AccessToken> accessToken)
            {
                var throttlingPolicy = "Unlimited";
                var apiId = "471a098b-fa90-416e-b194-51c5855e04f7";
                var applicationId = "6dee7791-02e9-415c-907d-882839e38537";
                var taskAddSubscription = _serviceSubscription.AddSubscription(accesstoken.Content.access_token, accesstoken.Content.token_type, throttlingPolicy, apiId, applicationId);

                ApiResponse<Subscription> addSubscription;
                addSubscription = taskAddSubscription.Result;
                Console.WriteLine("ADD SUBSCRIPTION");
                Console.WriteLine("Status code: " + addSubscription.StatusCode);Console.ReadLine();
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
                sub.apiId = "471a098b-fa90-416e-b194-51c5855e04f7";
                sub.applicationId = "6dee7791-02e9-415c-907d-882839e38537";
                sub.throttlingPolicy = "Unlimited";
                listSub.Add(sub);

                var taskAddSubscriptionMultiple = _serviceSubscription.AddSubscriptionMultiple(accesstoken.Content.access_token, accesstoken.Content.token_type, listSub);

                ApiResponse<List<Subscription>> addSubscriptionMultiple;
                addSubscriptionMultiple = taskAddSubscriptionMultiple.Result;
                Console.WriteLine("Addsubscription Multiple");
                Console.WriteLine("StatusCode : " + addSubscriptionMultiple.StatusCode);
                addSubscriptionMultiple.Content.ForEach(c =>
                {
                    Console.WriteLine("subsId : " + c.apiId);
                    Console.WriteLine("appId : " + c.applicationId);
                    Console.WriteLine("appIden : " + c.throttlingPolicy);
                }
                );
            }

            //** DELETE SUBSCRIPTION
            void DeleteSubscription(ApiResponse<AccessToken> accessToken)
            {
                var taskDeleteSubscription = _serviceSubscription.DeleteSubscription(accesstoken.Content.access_token, accesstoken.Content.token_type, "11332a11-8b90-4dbf-a5da-704da67578ea");

                ApiResponse<Subscription> deleteSubscription;
                deleteSubscription = taskDeleteSubscription.Result;
                Console.WriteLine("DELETE SUBS");
                Console.WriteLine(deleteSubscription.StatusCode);
            }

            //** GET ALL DOCUMENTS
            void GetAllDocuments()
            {
                var taskAllDocuments = _serviceDocument.AllDocuments("471a098b-fa90-416e-b194-51c5855e04f7");

                ApiResponse<AllDocuments> allDocuments;

                allDocuments = taskAllDocuments.Result;

                Console.WriteLine("Get All Documents:");
                Console.WriteLine("Status code : " + allDocuments.StatusCode);
                Console.WriteLine("count : " + allDocuments.Content.count);
                Console.WriteLine("next : " + allDocuments.Content.pagination.next);
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
                var taskDocument = _serviceDocument.GetDocument("471a098b-fa90-416e-b194-51c5855e04f7", "72f3b526-5cf2-497e-9b40-17b1b52533b9");

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
                var taskDocumentContent = _serviceDocument.GetDocumentContent("471a098b-fa90-416e-b194-51c5855e04f7", "72f3b526-5cf2-497e-9b40-17b1b52533b9");

                ApiResponse<string> documentContent;

                documentContent = taskDocumentContent.Result;

                Console.WriteLine("Get Document Content");
                Console.WriteLine("Status code : " + documentContent.StatusCode);
                Console.WriteLine("Content : " + documentContent.Content);
            }

        }
    }
}
