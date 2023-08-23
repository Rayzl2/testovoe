using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                    .Any(any => any.IsGenericType && any.GetGenericTypeDefinition() == typeof(IMap<>)))
                .ToList();

            foreach (var item in types)
            {
                var instance = Activator.CreateInstance(item);

                var methodInfo = item.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
