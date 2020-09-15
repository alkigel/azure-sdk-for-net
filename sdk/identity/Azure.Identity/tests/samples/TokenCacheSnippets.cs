﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Azure;

namespace Azure.Identity.Samples
{
    public class TokenCacheSnippets
    {
        public void Identity_TokenCache_PersistentDefault()
        {
            #region Snippet:Identity_TokenCache_PersistentDefault
            var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenCache = new PersistentTokenCache() });
            #endregion
        }

        public void Identity_TokenCache_PersistentNamed()
        {
            #region Snippet:Identity_TokenCache_PersistentNamed
            var tokenCache = new PersistentTokenCache(new PersistentTokenCacheOptions { Name = "my_application_name" });

            var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenCache = tokenCache });
            #endregion
        }

        public void Identity_TokenCache_PersistentUnencrypted()
        {
            #region Snippet:Identity_TokenCache_PersistentUnencrypted
            var tokenCache = new PersistentTokenCache(new PersistentTokenCacheOptions { AllowUnencryptedStorage = true });

            var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenCache =  tokenCache});
            #endregion
        }

        public async Task Identity_TokenCache_CustomPersistence_Read()
        {
            #region Snippet:Identity_TokenCache_CustomPersistence_Read
            using var cacheStream = new FileStream(TokenCachePath, FileMode.OpenOrCreate, FileAccess.Read);

            var tokenCache = await TokenCache.DeserializeAsync(cacheStream);
            #endregion
        }

        public async Task Identity_TokenCache_CustomPersistence_Write()
        {
            var tokenCache = new TokenCache();

            #region Snippet:Identity_TokenCache_CustomPersistence_Write
            using var cacheStream = new FileStream(TokenCachePath, FileMode.Create, FileAccess.Write);

            await tokenCache.SerializeAsync(cacheStream);
            #endregion
        }

        private const string TokenCachePath = "./tokencache.bin";

        #region Snippet:Identity_TokenCache_CustomPersistence_Usage
        public static async Task<TokenCache> ReadTokenCacheAsync()
        {
            using var cacheStream = new FileStream(TokenCachePath, FileMode.OpenOrCreate, FileAccess.Read);

            var tokenCache = await TokenCache.DeserializeAsync(cacheStream);

            tokenCache.Updated += WriteCacheOnUpdateAsync;

            return tokenCache;
        }

        public static async Task WriteCacheOnUpdateAsync(TokenCacheUpdatedArgs args)
        {
            using var cacheStream = new FileStream(TokenCachePath, FileMode.Create, FileAccess.Write);

            await args.Cache.SerializeAsync(cacheStream);
        }

        public static async Task Main()
        {
            var tokenCache = await ReadTokenCacheAsync();

            var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TokenCache = tokenCache });
        }
        #endregion
    }
}