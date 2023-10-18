using AutoMapper;
using TemplateMicroservice.BLL.Infrastructure;
using TemplateMicroservice.Core.Infrastructure.AutoMapper;

namespace TemplateMicroservice.Tests.Infrastructure.AutoMapper
{
    public static class AutoMapperHelper
    {
        private static Mapper _mapper = null; 
        public static Mapper GetMapper()
        {

            if (_mapper == null)
            {
                var configuration = new MapperConfiguration(x =>
                {
                    x.AddProfile<AutoMapperBllProfile>();
                    x.AddProfile<AutoMapperCoreProfile>();
                });
                _mapper = new Mapper(configuration);
            }
            return _mapper;
        }
    }
}
