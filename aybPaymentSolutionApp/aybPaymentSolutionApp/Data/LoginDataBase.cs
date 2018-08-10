using aybPaymentSolutionApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aybPaymentSolutionApp.Data
{
    public class LoginDataBase
    {
        private readonly SQLiteAsyncConnection database;
        public LoginDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<InfoUser>().Wait();
        }

        public Task<InfoUser> getItemAsync(string pincode, string deviceid)
        {
            return database.Table<InfoUser>()
                .Where(i => i.pinCode == pincode)
                .Where(i => i.deviceID == deviceid)
                .FirstOrDefaultAsync();
        }

        public Task<InfoUser> getItembyId(int userid)
        {
            return database.Table<InfoUser>()
                .Where(i => i.userID == userid)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync (InfoUser user, bool exist)
        {
            if (exist == true)
            {
                return database.UpdateAsync(user);
            } else
            {
                return database.InsertAsync(user);
            }
        }

        public async Task<List<InfoUser>> GetItemsAsync()
        {
            return await database.Table<InfoUser>().ToListAsync();
        }
    }
}
