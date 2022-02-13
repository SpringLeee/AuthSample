using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentitySample
{
    public class MyDBContext:IdentityDbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {

        } 
    }
}
