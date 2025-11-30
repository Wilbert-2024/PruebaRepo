using MartinWilbert.Models;
using Microsoft.EntityFrameworkCore;

namespace MartinWilbert.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        // Nuevos DbSets
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<ReservaLaboratorio> ReservasLaboratorio { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        //    modelBuilder.Entity<Role>().HasMany(e => e.Users).WithOne(u => u.Role).HasForeignKey(u => u.RoleId).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Role>().HasData(

                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Usuario" }

            );



            modelBuilder.Entity<Laboratorio>().HasData(

                   // ===== Laboratorio #1 =====
                   new Laboratorio { Id = 1, Nombre = "Laboratorio #1", Capacidad = 24, dias_ocupado = "Lunes", horas_ocupado = "08:00-09:30" },
                   new Laboratorio { Id = 2, Nombre = "Laboratorio #1", Capacidad = 24, dias_ocupado = "Miércoles", horas_ocupado = "08:00-09:30" },
                   new Laboratorio { Id = 3, Nombre = "Laboratorio #1", Capacidad = 24, dias_ocupado = "Miércoles", horas_ocupado = "18:00-19:30" },
                   new Laboratorio { Id = 4, Nombre = "Laboratorio #1", Capacidad = 24, dias_ocupado = "Jueves", horas_ocupado = "14:45-16:15" },
                   new Laboratorio { Id = 5, Nombre = "Laboratorio #1", Capacidad = 24, dias_ocupado = "Domingo", horas_ocupado = "18:00-19:30" },

                   // ===== Laboratorio #2 =====
                   new Laboratorio { Id = 6, Nombre = "Laboratorio #2", Capacidad = 24, dias_ocupado = "Martes", horas_ocupado = "14:45-16:15" },
                   new Laboratorio { Id = 7, Nombre = "Laboratorio #2", Capacidad = 24, dias_ocupado = "Miércoles", horas_ocupado = "08:00-09:30" },
                   new Laboratorio { Id = 8, Nombre = "Laboratorio #2", Capacidad = 24, dias_ocupado = "Viernes", horas_ocupado = "09:45-11:15" },
                   new Laboratorio { Id = 9, Nombre = "Laboratorio #2", Capacidad = 24, dias_ocupado = "Sábado", horas_ocupado = "09:45-11:15" },

                   // ===== Laboratorio #3 =====
                   new Laboratorio { Id = 10, Nombre = "Laboratorio #3", Capacidad = 24, dias_ocupado = "Lunes", horas_ocupado = "09:45-11:15" },
                   new Laboratorio { Id = 11, Nombre = "Laboratorio #3", Capacidad = 24, dias_ocupado = "Martes", horas_ocupado = "13:00-14:30" },
                   new Laboratorio { Id = 12, Nombre = "Laboratorio #3", Capacidad = 24, dias_ocupado = "Jueves", horas_ocupado = "08:00-09:30" },
                   new Laboratorio { Id = 13, Nombre = "Laboratorio #3", Capacidad = 24, dias_ocupado = "Jueves", horas_ocupado = "19:45-21:15" },
                   new Laboratorio { Id = 14, Nombre = "Laboratorio #3", Capacidad = 24, dias_ocupado = "Viernes", horas_ocupado = "14:45-16:15" },

                   // ===== Laboratorio #4 =====
                   new Laboratorio { Id = 15, Nombre = "Laboratorio #4", Capacidad = 24, dias_ocupado = "Lunes", horas_ocupado = "09:45-11:15" },
                   new Laboratorio { Id = 16, Nombre = "Laboratorio #4", Capacidad = 24, dias_ocupado = "Martes", horas_ocupado = "13:00-14:30" },
                   new Laboratorio { Id = 17, Nombre = "Laboratorio #4", Capacidad = 24, dias_ocupado = "Miércoles", horas_ocupado = "14:45-16:15" },
                   new Laboratorio { Id = 18, Nombre = "Laboratorio #4", Capacidad = 24, dias_ocupado = "Jueves", horas_ocupado = "09:45-11:15" },
                   new Laboratorio { Id = 19, Nombre = "Laboratorio #4", Capacidad = 24, dias_ocupado = "Sábado", horas_ocupado = "09:45-11:15" }


            );


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ReservaLaboratorio>(entity =>
            {
                entity.HasKey(r => r.Id); 
                entity.HasOne(r => r.User).WithMany().HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(r => r.Laboratorio).WithMany(l => l.Reservas).HasForeignKey(r => r.LaboratorioId).OnDelete(DeleteBehavior.Cascade);
                entity.Property(r => r.Fecha_reservacion).HasColumnType("date");
               // entity.Property(r => r.HoraReserva).HasColumnType("string");
              



            }
            );

        }
    }
}
