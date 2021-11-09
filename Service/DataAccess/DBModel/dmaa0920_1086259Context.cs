using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess.Model
{
    public partial class dmaa0920_1086259Context : DbContext
    {
        public dmaa0920_1086259Context()
        {
        }

        public dmaa0920_1086259Context(DbContextOptions<dmaa0920_1086259Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<RegisteredGuest> RegisteredGuests { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Wardrobe> Wardrobes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Persist Security Info=False;User ID=dmaa0920_1086259;Password=Password1!;Initial Catalog=dmaa0920_1086259;Server=hildur.ucn.dk");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>(entity =>
            {
                entity.ToTable("Guest");

                entity.Property(e => e.GuestId).HasColumnName("guestID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.ItemId).HasColumnName("itemID");

                entity.Property(e => e.TypeIdFk).HasColumnName("typeID_FK");

                entity.Property(e => e.WardrobeIdFk)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("wardrobeID_FK");

                entity.HasOne(d => d.TypeIdFkNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.TypeIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__typeID_FK__778AC167");

                entity.HasOne(d => d.WardrobeIdFkNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.WardrobeIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__wardrobeID__76969D2E");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.CheckInTime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("checkInTime");

                entity.Property(e => e.GuestIdFk).HasColumnName("guestID_FK");

                entity.Property(e => e.ItemIdFk).HasColumnName("itemID_FK");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("link");

                entity.Property(e => e.Paid).HasColumnName("paid");

                entity.Property(e => e.PickUpTime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("pickUpTime");

                entity.Property(e => e.TicketNumber).HasColumnName("ticketNumber");

                entity.HasOne(d => d.GuestIdFkNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.GuestIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__guestID_F__7B5B524B");

                entity.HasOne(d => d.ItemIdFkNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ItemIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__itemID_FK__7A672E12");
            });

            modelBuilder.Entity<RegisteredGuest>(entity =>
            {
                entity.HasKey(e => e.GuestId)
                    .HasName("PK__Register__8D59CD7C9BFC2C4E");

                entity.ToTable("RegisteredGuest");

                entity.Property(e => e.GuestId)
                    .ValueGeneratedNever()
                    .HasColumnName("guestID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("passwordHash");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("phoneNumber")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Guest)
                    .WithOne(p => p.RegisteredGuest)
                    .HasForeignKey<RegisteredGuest>(d => d.GuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registere__guest__6D0D32F4");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.ReservationId).HasColumnName("reservationID");

                entity.Property(e => e.AmountOfBags).HasColumnName("amountOfBags");

                entity.Property(e => e.AmountOfJackets).HasColumnName("amountOfJackets");

                entity.Property(e => e.ArrivalTime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("arrivalTime");

                entity.Property(e => e.GuestIdFk).HasColumnName("guestID_FK");

                entity.Property(e => e.OrderTime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("orderTime");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");

                entity.HasOne(d => d.GuestIdFkNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.GuestIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reservati__guest__6FE99F9F");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type");

                entity.Property(e => e.TypeId).HasColumnName("typeID");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("typeName");
            });

            modelBuilder.Entity<Wardrobe>(entity =>
            {
                entity.ToTable("Wardrobe");

                entity.Property(e => e.WardrobeId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("wardrobeID");

                entity.Property(e => e.MaxAmountOfItems).HasColumnName("maxAmountOfItems");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
