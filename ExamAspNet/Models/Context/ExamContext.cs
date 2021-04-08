using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAspNet.Models.Context
{
    public class ExamContext : IdentityDbContext<User, Role, Guid>
    {
    }
}
