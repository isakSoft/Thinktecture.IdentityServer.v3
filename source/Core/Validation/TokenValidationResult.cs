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

using System.Collections.Generic;
using System.Security.Claims;
using Thinktecture.IdentityServer.Core.Models;

namespace Thinktecture.IdentityServer.Core.Validation
{
    public class TokenValidationResult
    {
        public IEnumerable<Claim> Claims { get; set; }
        public string Jwt { get; set; }
        public Token ReferenceToken { get; set; }
        public string ReferenceTokenId { get; set; }
        public Client Client { get; set; }

        public string Error { get; set; }
        public bool IsError { get; set; }
    }
}