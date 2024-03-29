﻿using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IT_Project.Auth
{
    public class AuthenticationRequirementsOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authAttributes = context.MethodInfo.DeclaringType!.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AuthorizeAttribute>();

            if (authAttributes.Any())
            {
                operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
                operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

                var oAuthScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                };

                operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement { [oAuthScheme] = new string [] {} }
                };
            }
        }
    }
}
