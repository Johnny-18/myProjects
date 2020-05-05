using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF.UnitOfWork;
using DAL.EF.Interfaces;
using AutoMapper;
using BLL.Mapper;
using DAL.EF.Context;

namespace BLL
{
    public class MyConfiguration
    {
        private static IUnitOfWork unitOfWork;
        private static IMapper mapper;
        private static CompanyContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }

        public IMapper Mapper
        {
            get
            {
                return mapper;
            }
        }

        public CompanyContext Context
        {
            get
            {
                return _context;
            }
        }

        public MyConfiguration() { }

        static MyConfiguration()
        {
            _context = new CompanyContext();//CompanyContext.GetContext();
            unitOfWork = new UnitOfWork(_context);
            mapper = MappingConfiguration.ConfigurationMapper().CreateMapper();
        }
    }
}
