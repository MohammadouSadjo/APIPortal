﻿using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPortalLibrary.Models.Store;

namespace APIPortalLibrary.Interfaces.Store
{
    interface IApplication
    {
        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/applications")]
        Task<ApiResponse<AllApplications>> GetAllApplications(
            [Header("Authorization")] string authorization,
            [AliasAs("query")] string query = "",
            [AliasAs("limit")] int limit = 25,
            [AliasAs("offset")] int offset = 0
            );

        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/applications/{applicationId}")]
        Task<ApiResponse<Application>> GetApplicationDetails(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization
            );

        [Headers("Accept:application/json")]
        [Get("/api/am/store/v0.14/applications/{applicationId}/keys/{keyType}")]
        Task<ApiResponse<Key>> GetApplicationKeyDetailsOfGivenType(
            [AliasAs("applicationId")] string applicationId,
            [AliasAs("keyType")] string keyType,
            [Header("Authorization")] string authorization,
            [AliasAs("groupId")] string group_id = ""
            );

        [Headers("Content-Type: application/json")]
        [Post("/api/am/store/v0.14/applications")]
        Task<ApiResponse<Application>> AddApplication(
            [Header("Authorization")] string authorization,
            [Body] string body
            );

        [Headers("Content-Type: application/json")]
        [Put("/api/am/store/v0.14/applications/{applicationId}")]
        Task<ApiResponse<Application>> UpdateApplication(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization,
            [Body] string body
            );

        [Delete("/api/am/store/v0.14/applications/{applicationId}")]
        Task<ApiResponse<Application>> DeleteApplication(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization
            );

        [Headers("Content-Type: application/json")]
        [Post("/api/am/store/v0.14/applications/generate-keys")]
        Task<ApiResponse<GenerateApplicationKeys>> GenerateApplicationKeys(
            [AliasAs("applicationId")] string applicationId,
            [Header("Authorization")] string authorization,
            [Body] string body
            );

        [Headers("Content-Type: application/json")]
        [Put("/api/am/store/v0.14/applications/{applicationId}/keys/{keyType}")]
        Task<ApiResponse<Key>> UpdateGrantTypesAndCallbackUrl(
            [AliasAs("applicationId")] string applicationId,
            [AliasAs("keyType")] string keyType,
            [Body] string body,
            [Header("Authorization")] string authorization
            );
    }
}
