using AutoMapper;
using PotifolioASB.Domain.Entities;
using PotifolioASB.Service.ViewModels.Fluxo;

namespace PotifolioASB.Test.Configuration
{
    public static class AutoMapperConfiguration
    {


        public static IMapper GetConfiguration()
        {
            var autoMapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<Fluxo, CreateFluxoViewModel>().ReverseMap();
            });

        return autoMapperConfig.CreateMapper();
    }
        


    }
}
