﻿using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPortalLibrary.Models;

namespace APIPortalLibrary.Interfaces
{
    interface IApplication
    {
        //Get all applications
        [Headers("Accept:application/json")]
        [Get("/api/am/devportal/v2/applications")]
        Task<ApiResponse<AllApplications>> GetAllApplications(
            [Header("Authorization")] string authorization,
            [AliasAs("query")] string query,
            [AliasAs("limit")] int limit,
            [AliasAs("offset")] int offset
            );

        //Get details of an application
        [Headers("Accept:application/json")]
        [Get("/api/am/devportal/v2/applications/{applicationId}")]
        Task<ApiResponse<Application>> GetApplicationDetails(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization
            );

        //Get application key details of a given type(key type)
        [Headers("Accept:application/json")]
        [Get("/api/am/devportal/v2/applications/{applicationId}/oauth-keys/{keyMappingId}")]
        Task<ApiResponse<Key>> GetApplicationKeyDetailsOfGivenType(
            [AliasAs("applicationId")] string applicationId,
            [AliasAs("keyMappingId")] string keyMappingId,
            [Header("Authorization")] string authorization,
            [AliasAs("groupId")] string group_id = ""
            );

        //Add a new application
        [Headers("Content-Type: application/json")]
        [Post("/api/am/devportal/v2/applications")]
        Task<ApiResponse<Application>> AddApplication(
            [Header("Authorization")] string authorization,
            [Body] string body
            );

        //Update an application
        [Headers("Content-Type: application/json")]
        [Put("/api/am/devportal/v2/applications/{applicationId}")]
        Task<ApiResponse<Application>> UpdateApplication(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization,
            [Body] string body
            );

        //Delete an application
        [Delete("/api/am/devportal/v2/applications/{applicationId}")]
        Task<ApiResponse<Application>> DeleteApplication(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization
            );

        //Generate application keys
        [Headers("Content-Type: application/json")]
        [Post("/api/am/devportal/v2/applications/{applicationId}/generate-keys")]
        Task<ApiResponse<GenerateApplicationKeys>> GenerateApplicationKeys(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization,
            [Body] string body
            );

        //Update grantTypes and call back url of an application
        [Headers("Content-Type: application/json")]
        [Put("/api/am/devportal/v2/applications/{applicationId}/oauth-keys/{keyMappingId}")]
        Task<ApiResponse<Key>> UpdateGrantTypesAndCallbackUrl(
            [AliasAs("applicationId")] string applicationId,
            [AliasAs("keyMappingId")] string keyMappingId,
            [Body] string body,
            [Header("Authorization")] string authorization
            );
    }
}
