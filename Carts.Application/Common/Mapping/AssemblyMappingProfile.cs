using System.Reflection;
using AutoMapper;

namespace Carts.Application.Common.Mapping
{
    public class AssemblyMappingProfile : Profile
    {

        public AssemblyMappingProfile(Assembly assembly) {
            ApplyMappingsFromAssembly(assembly);
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            // СООТНОШЕНИЕ ТИПОВ ДАННЫХ МЕЖДУ ПОСТУПАЮЩИМИ ДАННЫМИ
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                    .Any(any => any.IsGenericType && any.GetGenericTypeDefinition() == typeof(IMap<>)))
                .ToList();

            foreach (var item in types)
            {
                var instance = Activator.CreateInstance(item);
                var methodInfo = item.GetMethod("Mapping"); // НАЗВАНИЕ МЕТОДА ИНТЕРФЕЙСА
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
