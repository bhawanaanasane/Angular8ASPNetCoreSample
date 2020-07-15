using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FLA.Core.Domain.BaseTable;
using FLA.Core.Domain.ChatDetail;
using FLA.Core.Domain.Clients;
using FLA.Core.Domain.Directory;
using FLA.Core.Domain.Drivers;
using FLA.Core.Domain.Mobile;
using FLA.Core.Domain.Orders;
using FLA.Core.Domain.Permissions;
using FLA.Core.Domain.Scheduling;
using FLA.Core.Domain.Security;
using FLA.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace FLA.Data
{
    public class DBContextFLA : DbContext
    {
        public DBContextFLA(DbContextOptions<DBContextFLA> option) : base(option)
        {

        }
        #region Permission
        public DbSet<FormName> FormNames { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionRoleMapping> PermissionRoleMappings { get; set; }
        public DbSet<Role> Roles { get; set; }
        #endregion
        #region User
        public DbSet<UserLogin> UserLogins { get; set; }
        #endregion
        #region Security
        public DbSet<TwilioCredential> TwilioCredentials { get; set; }
        #endregion
        #region Scheduling
        public DbSet<ContainerTracking> ContainerTrackings { get; set; }
        public DbSet<Dispatch> Dispatches { get; set; }
        public DbSet<DriverDispachDetail> DriverDispachDetails { get; set; }
        public DbSet<PayType> PayTypes { get; set; }
        public DbSet<SegmentType> SegmentTypes { get; set; }
        #endregion
        #region Orders
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Chassis> Chassis { get; set; }
        public DbSet<Containers> Containers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<RentalCompany> RentalCompanies { get; set; }
        public DbSet<Size> Sizes { get; set; }
        #endregion
        #region Mobile
        public DbSet<ProofOfDelivery> ProofOfDeliveries { get; set; }

        #endregion
        #region Drivers
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverLogin> DriverLogins { get; set; }
        public DbSet<DrugScreen> DrugScreens { get; set; }
        public DbSet<TruckInspection> TruckInspections { get; set; }
        #endregion
        #region Directory
        public DbSet<Country> Countries { get; set; }
        public DbSet<StateProvince> StateProvinces { get; set; }
        #endregion
        #region Clients
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientPermissions> ClientPermissions { get; set; }
        public DbSet<FactorCompany> FactorCompanies { get; set; }
        #endregion
        #region ChatDetail
        public DbSet<ChatMessages> ChatMessages { get; set; }
        public DbSet<Message> Messages { get; set; }
        #endregion
        #region BaseTable
        public DbSet<BillTo> BillTo { get; set; }
        public DbSet<BillToContacts> BillToContacts { get; set; }
        public DbSet<PickupDelivery> PickupDeliveries { get; set; }
        public DbSet<PickupDeliveryContacts> PickupDeliveryContacts { get; set; }
        public DbSet<PortLogin> PortLogins { get; set; }
        public DbSet<Ports> Ports { get; set; }
        public DbSet<SalesPerson> SalesPeople { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !string.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
