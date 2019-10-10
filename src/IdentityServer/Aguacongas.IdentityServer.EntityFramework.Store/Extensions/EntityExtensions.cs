﻿using IdentityServer4.Models;
using System;
using System.Linq;
using System.Security.Claims;

namespace Aguacongas.IdentityServer.Store
{
    public static class EntityExtensions
    {
		public static Client ToClient(this Entity.Client client)
        {
            if (client == null)
            {
                return null;
            }

            return new Client
            {
                AbsoluteRefreshTokenLifetime = client.AbsoluteRefreshTokenLifetime,
                AccessTokenLifetime = client.AccessTokenLifetime,
                AccessTokenType = (AccessTokenType)client.AccessTokenType,
                AllowAccessTokensViaBrowser = client.AllowAccessTokensViaBrowser,
                AllowedCorsOrigins = client.AllowedCorsOrigins.Select(c => c.Origin).ToList(),
                AllowedGrantTypes = client.AllowedGrantTypes.Select(g => g.GrantType).ToList(),
                AllowedScopes = client.AllowedScopes.Select(s => s.Scope).ToList(),
                AllowOfflineAccess = client.AllowOfflineAccess,
                AllowPlainTextPkce = client.AllowPlainTextPkce,
                AllowRememberConsent = client.AllowRememberConsent,
                AlwaysIncludeUserClaimsInIdToken = client.AlwaysIncludeUserClaimsInIdToken,
                AlwaysSendClientClaims = client.AlwaysSendClientClaims,
                AuthorizationCodeLifetime = client.AuthorizationCodeLifetime,
                BackChannelLogoutSessionRequired = client.BackChannelLogoutSessionRequired,
                BackChannelLogoutUri = client.BackChannelLogoutUri,
                Claims = client.ClientClaims.Select(c => new Claim(c.Type, c.Value)).ToList(),
                ClientClaimsPrefix = client.ClientClaimsPrefix,
                ClientId = client.Id,
                ClientName = client.ClientName,
                ClientSecrets = client.ClientSecrets.Select(s => new Secret(s.Value, s.Expiration)).ToList(),
                ClientUri = client.ClientUri,
                ConsentLifetime = client.ConsentLifetime,
                Description = client.Description,
                DeviceCodeLifetime = client.DeviceCodeLifetime,
                Enabled = client.Enabled,
                EnableLocalLogin = client.EnableLocalLogin,
                FrontChannelLogoutSessionRequired = client.FrontChannelLogoutSessionRequired,
                FrontChannelLogoutUri = client.FrontChannelLogoutUri,
                IdentityProviderRestrictions = client.IdentityProviderRestrictions.Select(r => r.Provider).ToList(),
                IdentityTokenLifetime = client.IdentityTokenLifetime,
                IncludeJwtId = client.IncludeJwtId,
                LogoUri = client.LogoUri,
                PairWiseSubjectSalt = client.PairWiseSubjectSalt,
                PostLogoutRedirectUris = client.PostLogoutRedirectUris.Select(u => u.Uri).ToList(),
                Properties = client.Properties.ToDictionary(p => p.Key, p => p.Value),
                ProtocolType = client.ProtocolType,
                RefreshTokenExpiration = (TokenExpiration)client.RefreshTokenExpiration,
                RedirectUris = client.RedirectUris.Select(u => u.Uri).ToList(),
                RefreshTokenUsage = (TokenUsage) client.RefreshTokenUsage,
                RequireClientSecret = client.RequireClientSecret,
                RequireConsent = client.RequireConsent,
                RequirePkce = client.RequirePkce,
                SlidingRefreshTokenLifetime = client.SlidingRefreshTokenLifetime,
                UpdateAccessTokenClaimsOnRefresh = client.UpdateAccessTokenClaimsOnRefresh,
                UserCodeType = client.UserCodeType,
                UserSsoLifetime = client.UserSsoLifetime
            };
        }

        public static ApiResource ToApi(this Entity.Api api)
        {
            if (api == null)
            {
                return null;
            }

            return new ApiResource
            {
                ApiSecrets = api.Secrets.Select(s => new Secret { Value = s.Value, Expiration = s.Expiration }).ToList(),
                Description = api.Description,
                DisplayName = api.DisplayName,
                Enabled = api.Enabled,
                Name = api.Id,
                Properties = api.Properties.ToDictionary(p => p.Key, p => p.Value),
                Scopes = api.Scopes.Select(s => new Scope 
                { 
                    Description = s.Description, 
                    DisplayName = s.DisplayName, 
                    Emphasize = s.Emphasize, 
                    Name = s.Id, 
                    Required = s.Required, 
                    ShowInDiscoveryDocument = s.ShowInDiscoveryDocument, 
                    UserClaims = s.ApiScopeClaims.Select( c => c.Type).ToList() 
                }).ToList(),
                UserClaims = api.ApiClaims.Select(c => c.Type).ToList()
            };
        }

        public static IdentityResource ToIdentity(this Entity.Identity identity)
        {
            if (identity == null)
            {
                return null;
            }

            return new IdentityResource
            {
                Description = identity.Description,
                DisplayName = identity.DisplayName,
                Emphasize = identity.Emphasize,
                Enabled = identity.Enabled,
                Name = identity.Id,
                Properties = identity.Properties.ToDictionary(p => p.Key, p => p.Value),
                Required = identity.Required,
                ShowInDiscoveryDocument = identity.ShowInDiscoveryDocument,
                UserClaims = identity.IdentityClaims.Select(c => c.Type).ToList()
            };
        }

        public static Entity.Client ToEntity(this Client client)
        {
            if(client == null)
            {
                return null;
            }

            return new Entity.Client
            {
                Id = client.ClientName,
                AbsoluteRefreshTokenLifetime = client.AbsoluteRefreshTokenLifetime,
                AccessTokenLifetime = client.AccessTokenLifetime,
                AccessTokenType = (int)client.AccessTokenType,
                AllowAccessTokensViaBrowser = client.AllowAccessTokensViaBrowser,
                AllowedCorsOrigins = client.AllowedCorsOrigins.Select(o => new Entity.ClientCorsOrigin
                {
                    Id = Guid.NewGuid().ToString(),
                    Origin = o
                }).ToList(),
                AllowedGrantTypes = client.AllowedGrantTypes.Select(t => new Entity.ClientGrantType
                {
                    Id = Guid.NewGuid().ToString(),
                    GrantType = t
                }).ToList(),
                AllowedScopes = client.AllowedScopes.Select(s => new Entity.ClientScope
                {
                    Id = Guid.NewGuid().ToString(),
                    Scope = s
                }).ToList(),
                AllowOfflineAccess = client.AllowOfflineAccess,
                AllowPlainTextPkce = client.AllowPlainTextPkce,
                AllowRememberConsent = client.AllowRememberConsent,
                AlwaysIncludeUserClaimsInIdToken = client.AlwaysIncludeUserClaimsInIdToken,
                AlwaysSendClientClaims = client.AlwaysSendClientClaims,
                AuthorizationCodeLifetime = client.AuthorizationCodeLifetime,
                BackChannelLogoutSessionRequired = client.BackChannelLogoutSessionRequired,
                BackChannelLogoutUri = client.BackChannelLogoutUri,
                ClientClaims = client.Claims.Select(c => new Entity.ClientClaim
                {
                    Id = Guid.NewGuid().ToString(),
                    Type = c.Type,
                    Value = c.Value
                }).ToList(),
                ClientClaimsPrefix = client.ClientClaimsPrefix,
                ClientName = client.ClientName,
                ClientSecrets = client.ClientSecrets.Select(s => new Entity.ClientSecret
                {
                    Id = Guid.NewGuid().ToString(),
                    Description = s.Description,
                    Expiration = s.Expiration,
                    Type = s.Type,
                    Value = s.Value
                }).ToList(),
                ClientUri = client.ClientUri,
                ConsentLifetime = client.ConsentLifetime,
                Description = client.Description,
                DeviceCodeLifetime = client.DeviceCodeLifetime,
                Enabled = client.Enabled,
                EnableLocalLogin = client.EnableLocalLogin,
                FrontChannelLogoutSessionRequired = client.FrontChannelLogoutSessionRequired,
                FrontChannelLogoutUri = client.FrontChannelLogoutUri,
                IdentityProviderRestrictions = client.IdentityProviderRestrictions.Select(r => new Entity.ClientIdPRestriction
                {
                    Id = Guid.NewGuid().ToString(),
                    Provider = r
                }).ToList(),
                IdentityTokenLifetime = client.IdentityTokenLifetime,
                IncludeJwtId = client.IncludeJwtId,
                LogoUri = client.LogoUri,
                PairWiseSubjectSalt = client.PairWiseSubjectSalt,
                PostLogoutRedirectUris = client.PostLogoutRedirectUris.Select(u => new Entity.ClientPostLogoutRedirectUri
                {
                    Id = Guid.NewGuid().ToString(),
                    Uri = u
                }).ToList(),
                Properties = client.Properties.Select(p => new Entity.ClientProperty
                {
                    Id = Guid.NewGuid().ToString(),
                    Key = p.Key,
                    Value = p.Value
                }).ToList(),
                ProtocolType = client.ProtocolType,
                RedirectUris = client.RedirectUris.Select(u => new Entity.ClientRedirectUri
                {
                    Id = Guid.NewGuid().ToString(),
                    Uri = u
                }).ToList(),
                RefreshTokenExpiration = (int)client.RefreshTokenExpiration,
                RefreshTokenUsage = (int)client.RefreshTokenUsage,
                RequireClientSecret = client.RequireClientSecret,
                RequireConsent = client.RequireConsent,
                RequirePkce = client.RequirePkce,
                SlidingRefreshTokenLifetime = client.SlidingRefreshTokenLifetime,
                UpdateAccessTokenClaimsOnRefresh = client.UpdateAccessTokenClaimsOnRefresh,
                UserCodeType = client.UserCodeType,
                UserSsoLifetime = client.UserSsoLifetime
            };
        }

        public static Entity.Api ToEntity(this ApiResource api)
        {
            if (api == null)
            {
                return null;
            };

            return new Entity.Api
            {
                Id = api.Name,
                ApiClaims = api.UserClaims.Select(c => new Entity.ApiClaim
                {
                    Id = Guid.NewGuid().ToString(),
                    Type = c
                }).ToList(),
                Description = api.Description,
                DisplayName = api.DisplayName,
                Enabled = api.Enabled,
                Properties = api.Properties.Select(p => new Entity.ApiProperty
                {
                    Id = Guid.NewGuid().ToString(),
                    Key = p.Key,
                    Value = p.Value
                }).ToList(),
                Scopes = api.Scopes.Select(s => new Entity.ApiScope
                {
                    Id = Guid.NewGuid().ToString(),
                    ApiScopeClaims = s.UserClaims.Select(c => new Entity.ApiScopeClaim
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = c
                    }).ToList(),
                    Description = s.Description,
                    DisplayName = s.DisplayName,
                    Emphasize = s.Emphasize,
                    Required = s.Required,
                    ShowInDiscoveryDocument = s.ShowInDiscoveryDocument
                }).ToList(),
                Secrets = api.ApiSecrets.Select(s => new Entity.ApiSecret
                {
                    Id = Guid.NewGuid().ToString(),
                    Description = s.Description,
                    Expiration = s.Expiration,
                    Type = s.Type,
                    Value = s.Value
                }).ToList()                
            };
        }

        public static Entity.Identity ToEntity(this IdentityResource identity)
        {
            if (identity == null)
            {
                return null;
            }

            return new Entity.Identity
            {
                Id = identity.Name,
                Description = identity.Description,
                DisplayName = identity.DisplayName,
                Emphasize = identity.Emphasize,
                Enabled = identity.Enabled,
                IdentityClaims = identity.UserClaims.Select(c => new Entity.IdentityClaim
                {
                    Id = Guid.NewGuid().ToString(),
                    Type = c
                }).ToList(),
                Properties = identity.Properties.Select(p => new Entity.IdentityProperty
                {
                    Id = Guid.NewGuid().ToString(),
                    Key = p.Key,
                    Value = p.Value
                }).ToList(),
                Required = identity.Required,
                ShowInDiscoveryDocument = identity.ShowInDiscoveryDocument
            };
        }
    }
}