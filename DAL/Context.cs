using FronToBack.Models;
using FrontToBack.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.DAL
{
    public class Context:IdentityDbContext<AppUser>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Slider> Sliders { get; set; }

        public DbSet<SliderTitle> SliderTitles { get; set; }

        public DbSet<About> Abouts { get; set; }

        public DbSet<FlowerExperts> Flowers { get; set; }

        public DbSet<Join> Joins{ get; set; }

        public DbSet<Blogs> blogs { get; set; }

        public DbSet<SliderMain2> sliderMain2s{ get; set; }

        public DbSet<CATEGORY1> cATEGORies { get; set; }

        public DbSet<PRODUCTS1> pRODUCTS1s{ get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<Bio> Bios { get; set; }

        public DbSet<Footer> Footers { get; set; }



    }
}
