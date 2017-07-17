using NET.PersonalFinances.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NET.PersonalFinances.Data
{
    public class Context : DbContext
    {
        public Context() : base("name=PersonalFinancesConnectionstring")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new Initializer());
            (this as IObjectContextAdapter).ObjectContext.ContextOptions.UseCSharpNullComparisonBehavior = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Status> Status { get; set; }
        public DbSet<AccountNature> AccountNature { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<OperationType> OperationType { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountMovement> AccountMovement { get; set; }
    }

    public class Initializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            List<Status> status = new List<Status>()
            {
                new Status() { Initials = "A", Description = "Active" },
                new Status() { Initials = "I", Description = "Inactive" }
            };

            List<AccountType> accountType = new List<AccountType>()
            {
                new AccountType() { Initials = "A", Description = "Analytic" },
                new AccountType() { Initials = "S", Description = "Sintetic" }
            };

            List<AccountNature> accountNature = new List<AccountNature>()
            {
                new AccountNature() { Initials = "A", Description = "Active" },
                new AccountNature() { Initials = "P", Description = "Passive" },
                new AccountNature() { Initials = "R", Description = "Result" }
            };

            List<OperationType> operationType = new List<OperationType>()
            {
                new OperationType() { Initials = "D", Description = "Debit" },
                new OperationType() { Initials = "C", Description = "Credit" }
            };            

            List<Account> accounts = new List<Account>();

            accounts.Add(new Account() { AccountNature = accountNature[0], Description = "Active", Status = status[0], AccountType = accountType[1] });
            accounts.Add(new Account() { AccountNature = accountNature[1], Description = "Passive", Status = status[0], AccountType = accountType[1] });
            accounts.Add(new Account() { AccountNature = accountNature[2], Description = "Net Worth", Status = status[0], AccountType = accountType[1] });

            accounts.Add(new Account() { Account1 = accounts[0], AccountNature = accountNature[0], Description = "Income", Status = status[0], AccountType = accountType[1] });
            accounts.Add(new Account() { Account1 = accounts[1], AccountNature = accountNature[1], Description = "Expenses", Status = status[0], AccountType = accountType[1] });

            accounts.Add(new Account() { Account1 = accounts[3], AccountNature = accountNature[0], Description = "Payment", Status = status[0], AccountType = accountType[0] });
            accounts.Add(new Account() { Account1 = accounts[3], AccountNature = accountNature[0], Description = "Rent", Status = status[0], AccountType = accountType[0] });
            accounts.Add(new Account() { Account1 = accounts[3], AccountNature = accountNature[0], Description = "Heritage", Status = status[0], AccountType = accountType[0] });

            accounts.Add(new Account() { Account1 = accounts[4], AccountNature = accountNature[1], Description = "Rent", Status = status[0], AccountType = accountType[0] });
            accounts.Add(new Account() { Account1 = accounts[4], AccountNature = accountNature[1], Description = "Condominium", Status = status[0], AccountType = accountType[0] });
            accounts.Add(new Account() { Account1 = accounts[4], AccountNature = accountNature[1], Description = "Water", Status = status[0], AccountType = accountType[0] });
            accounts.Add(new Account() { Account1 = accounts[4], AccountNature = accountNature[1], Description = "Light", Status = status[0], AccountType = accountType[0] });
            accounts.Add(new Account() { Account1 = accounts[4], AccountNature = accountNature[1], Description = "Entertainment", Status = status[0], AccountType = accountType[0] });
            accounts.Add(new Account() { Account1 = accounts[4], AccountNature = accountNature[1], Description = "Gas", Status = status[0], AccountType = accountType[0] });
            accounts.Add(new Account() { Account1 = accounts[4], AccountNature = accountNature[1], Description = "Education", Status = status[0], AccountType = accountType[0] });
            accounts.Add(new Account() { Account1 = accounts[4], AccountNature = accountNature[1], Description = "Health", Status = status[0], AccountType = accountType[0] });
            accounts.Add(new Account() { Account1 = accounts[4], AccountNature = accountNature[1], Description = "Auto", Status = status[0], AccountType = accountType[0] });

            context.Status.AddRange(status);
            context.AccountType.AddRange(accountType);
            context.AccountNature.AddRange(accountNature);
            context.OperationType.AddRange(operationType);
            context.Account.AddRange(accounts);
            context.SaveChanges();
        }
    }
}
