// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                // 如果要请求 OIDC 预设的 scope 就必须要加上 OpenId(),
                // 加上他表示这个是一个 OIDC 协议的请求
                // Profile Address Phone Email 全部是属于 OIDC 预设的 scope
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Phone(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("api1", "My API #1")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "spa",
                    ClientName = "SPA Client",
                    ClientUri = "http://localhost:5001",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    
                    // AccessToken 是否可以通过浏览器返回
                    AllowAccessTokensViaBrowser = true,
                    // 是否需要用户点击同意（待测试）
                    RequireConsent = true,
                    // AccessToken 的有效期
                    AccessTokenLifetime = 60 * 5,
                    
                    RedirectUris =
                    {
                        // 指定登录成功跳转回来的 uri
                        "http://localhost:5001/signin-oidc",
                        // AccessToken 有效期比较短，刷新 AccessToken 的页面
                        "http://localhost:5001/redirect-silentrenew",
                        "http://localhost:5001/silent.html",
                        "http://localhost:5001/popup.html",
                    },
                    
                    // 登出 以后跳转的页面
                    PostLogoutRedirectUris = { "http://localhost:5001/" },
                    // 指定跨域
                    AllowedCorsOrigins = { "http://localhost:5001", "http://127.0.0.1:5001","http://10.1.140.2:5001" },
                    AllowedScopes = { "api1", "openid", "profile", "address", "phone", "email" }
                }
            };
        }
    }
}