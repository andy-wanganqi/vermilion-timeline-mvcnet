using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VermilionTimeline.MainDataAccess.Entities;

namespace VermilionTimeline.MainDataAccess.Repositories
{
    public class AccountRepository
    {
        private readonly MainDbContext mainDbContext;

        public AccountRepository(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public async Task<DataAccessResult> CreateAsync(Account account, AccountClaim[] accountClaims)
        {
            await mainDbContext.Account.AddAsync(account);
            await mainDbContext.AccountClaim.AddRangeAsync(accountClaims);
            await mainDbContext.SaveChangesAsync();
            return DataAccessResult.Success;
        }

        public async Task<Account?> FindAsync(string fullname)
        {
            var account = await mainDbContext.Account.FirstOrDefaultAsync(a => a.FullName == fullname);
            return account;
        }
    }
}
