using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JWQuantum.MobileAppService.DbModels
{
    public class JWQuantumContext: DbContext
    {

        public JWQuantumContext(DbContextOptions<JWQuantumContext> options)
            : base(options)
        { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Address> Addresses { get; set; }


        public class Person
        {
            [Key]
            public int PersonId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool? IsPublisher { get; set; }
            public bool? IsElder { get; set; }
            public bool? IsMinisterialServant { get; set; }
            public bool? IsRegularPioneer { get; set; }
            public bool? IsAuxilaryPioneer { get; set; }
            public bool? IsSpecialPioneer { get; set; }

            public int AddressId { get; set; }

            [ForeignKey("AddressId")]
            public Address Address { get; set; }

            public ICollection<Action> Actions { get; set; }
        }

        public class Address
        {
            [Key]
            public int AddressId { get; set; }
            public decimal XCoord { get; set; }
            public decimal  YCoord { get; set; }
        }

        public class Action
        {
            [Key]
            public int ActionId { get; set; }
            public string ActionName { get; set; }

            public int PersonId { get; set; }
            [ForeignKey("PersonId")]
            public Person Person { get; set; }
        }
    }
}
