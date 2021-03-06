﻿/*
 * Copyright 2014 Dominick Baier, Brock Allen
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace Thinktecture.IdentityServer.Core.Services.Default
{
    public class DefaultCache<T> : ICache<T>
        where T : class
    {
        readonly MemoryCache cache;
        readonly TimeSpan duration;

        public DefaultCache()
            : this(Constants.DefaultCacheDuration)
        {
        }

        public DefaultCache(TimeSpan duration)
        {
            if (duration <= TimeSpan.Zero) throw new ArgumentOutOfRangeException("duration", "Duration must be greater than zero");

            this.cache = new MemoryCache("cache");
            this.duration = duration;
        }
    
        public Task<T> GetAsync(string key)
        {
            return Task.FromResult((T)cache.Get(key));
        }

        public Task SetAsync(string key, T item)
        {
            var expiration = UtcNow.Add(this.duration);
            cache.Set(key, item, expiration);
            return Task.FromResult(0);
        }

        protected virtual DateTimeOffset UtcNow
        {
            get { return DateTimeOffset.UtcNow; }
        }
    }
}
