using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CarBook.Persistence.Context
{
    public class CarBookContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-VM4NR9R\\SQLEXPRESS;database=DbCarBookProject;integrated security=true;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //migration hatası almıştım RentACarProcess tablosunu okumuyordu 
            //kaldırılmış zannediyordu oyuzden bu yöntemi kullanıyorum
            modelBuilder.Entity<RentACarProcess>().ToTable("rentACarProcesses");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            //çoka çok ilişki tanımla 
            //Rezervasyonda Aracın alınacak kısmı
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.PickUpLocation)
                .WithMany(y => y.PickUpReservation)
                .HasForeignKey(z=>z.PickUpLocationId)
                //silinme sırasında sorun yaşamamak adına
                .OnDelete(DeleteBehavior.ClientSetNull);
            //Rezervasyonda Aracın verilecek kısmı
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.DropOffLocation)
                .WithMany(y => y.DropOffReservation)
                .HasForeignKey(z=>z.DropOffLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners{ get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RentACar> RentACars { get; set; }
        public DbSet<RentACarProcess> RentACarProcesses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
    }
}

