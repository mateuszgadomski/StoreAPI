using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Mappings;
using Store.Application.Store;
using Store.Application.Store.Commands.CreateStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateStoreCommand));

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new StoreMappingProfile());
            }).CreateMapper()
            );

            services.AddValidatorsFromAssemblyContaining<CreateStoreCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}