﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Restier.AspNet;
using Microsoft.Restier.AspNet.Model;
using Microsoft.Restier.EntityFramework;

namespace Microsoft.Restier.Tests.Shared.Scenarios.Library
{
    class LibraryApi : EntityFrameworkApi<LibraryContext>
    {
        //// Need to register publisher services as MapRestierRoute is not called
        //public static new IServiceCollection ConfigureApi(Type apiType, IServiceCollection services)
        //{
        //    EntityFrameworkApi<LibraryContext>.ConfigureApi(apiType, services);
        //    services.AddODataServices<LibraryApi>();
        //    return services;
        //}

        public LibraryApi(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [Operation(HasSideEffects = false)]
        public Book PublishBook(bool IsActive)
        {
            Console.WriteLine($"IsActive = {IsActive}");
            return new Book
            {
                Id = Guid.NewGuid(),
                Title = "The Cat in the Hat"
            };
        }

        [Operation(HasSideEffects = false)]
        public Book PublishBooks(int Count)
        {
            Console.WriteLine($"Count = {Count}");
            return new Book
            {
                Id = Guid.NewGuid(),
                Title = "The Cat in the Hat Comes Back"
            };
        }

        [Operation(HasSideEffects = false)]
        public Book SubmitTransaction(Guid Id)
        {
            Console.WriteLine($"Id = {Id}");
            return new Book
            {
                Id = Id,
                Title = "Atlas Shrugged"
            };
        }

    }
}
