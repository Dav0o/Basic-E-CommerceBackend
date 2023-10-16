using Domain.Data;
using Domain.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class DetailsRepository : GenericRepository<Details>, IDetailsRepository
    {
        private readonly MyDbContext _context;

        public DetailsRepository(MyDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
