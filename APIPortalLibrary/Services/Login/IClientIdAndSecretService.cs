﻿using APIPortalLibrary.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPortalLibrary.Services.Login
{
    public interface IClientIdAndSecretService
    {
        Task<ApiResponse<ClientIDAndSecret>> ClientIDSecret();
    }
}