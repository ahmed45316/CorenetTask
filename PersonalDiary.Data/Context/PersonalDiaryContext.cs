using Microsoft.EntityFrameworkCore;
using PersonalDiary.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalDiary.Data.Context
{
    public class PersonalDiaryContext : DbContext
    {
        public PersonalDiaryContext(DbContextOptions<PersonalDiaryContext> options) : base(options)
        {

        }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Entities.PersonalDiary> PersonalDiaries { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new[] { new Person { Id = 1, Name = "Admin" } });
        }
    }
}
