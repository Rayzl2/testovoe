using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Carts.Application.Common.Behaviors;
using Carts.Application.Carts.Commands.DeletingCart;

namespace Carts.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

            services.AddValidatorsFromAssemblies(new[] { assembly });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            return services;
        }
    }
}
