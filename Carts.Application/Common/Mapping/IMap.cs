using AutoMapper;

namespace Carts.Application.Common.Mapping
{
    public interface IMap<T>
    {
        //  ИНТЕРФЕЙС ДЛЯ ИНИЦИАЛИЗАЦИИ МАППИНГА
        void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(T), GetType());
        }
    }
}
