using Microsoft.EntityFrameworkCore;

namespace APIGrandstream.Data
{
    public class GrandstreamContext : DbContext
    {

        public GrandstreamContext(DbContextOptions<GrandstreamContext> option) : base (option){}

      
    }
}
