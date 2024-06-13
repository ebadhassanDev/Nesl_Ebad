using AutoMapper;
using Nesl_assessment.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_XUnitTesting
{
    public class MapperFixture : IDisposable
    {
        public IMapper mapper { get; set; }

        public MapperFixture()
        {
            this.mapper = new MapperConfiguration(config =>
            {
                config.AddMaps(typeof(CustomerDocument).Assembly.FullName);
            }).CreateMapper();
        }

        #region Override
        public void Dispose()
        {
        }
        #endregion
    }
}
