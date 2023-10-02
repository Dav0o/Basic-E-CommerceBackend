﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class MyDbContext : DbContext
    { 
        public MyDbContext(DbContextOptions <MyDbContext> options)
            :base(options)
        { 
        
        }
    }
}
