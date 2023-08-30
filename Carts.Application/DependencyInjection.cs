using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Carts.Application.Common.Behaviors;

namespace Carts.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services) {
            var assembly = Assembly.GetExecutingAssembly();
            // ОПРЕДЕЛЕНИЕ ВСЕХ МЕТОДОВ ВАЗИМОДЕЙСТВИЯ 
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

            // ДОБАВЛЕНИЕ ВАЛИДАТОРОВ ДАННЫХ ДЛЯ ПРОВЕРКИ ПОСТУПАЮЩИЙ ДАННЫХ
            services.AddValidatorsFromAssemblies(new[] { assembly });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            return services;
        }
    }
}
