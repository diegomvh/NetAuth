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
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace NetAuthServer.Extensions
{
    public class CustomGrantValidator : IExtensionGrantValidator
    {
        Task IExtensionGrantValidator.ValidateAsync(ExtensionGrantValidationContext context)
        {
            System.Console.Write("Hola");
            var credential = context.Request.Raw.Get("custom_credential");
            if (credential != null)
            {
                // valid credential
                return Task.FromResult(new GrantValidationResult("818727", "custom"));
            }
            else
            {
                // custom error message
                return Task.FromResult(new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential"));
            }
        }

        public string GrantType
        {
            get { return "custom"; }
        }
    }
}