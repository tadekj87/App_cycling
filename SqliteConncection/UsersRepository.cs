using FormsTest.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SqliteConncection
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UsersRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<bool> AddUser(Users users)
        {
            try
            {
                var tracking = await _databaseContext.Users.AddAsync(users);

                await _databaseContext.SaveChangesAsync();

                var isAdded = tracking.State == EntityState.Added;
                return isAdded;
            }
            catch (Exception e)
            { 
                return false;
            }
        }
        public async Task<IEnumerable<Users>> GetUsersAsync()
        {
            try
            {
                var users = await _databaseContext.Users.ToListAsync();

                return users;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Users>> GetUserByIdAsync(string username)
        {
            try
            {
                var users1 = await _databaseContext.Users.Where(x => x.Name == username).ToListAsync();   
                
               
                return users1;
                
            }
            catch (Exception e)
            {
                return null;
            }
        }



        public async Task<bool> UpdateUserAsync(Users users)
        {
            try
            {
                var tracking = _databaseContext.Update(users);

                await _databaseContext.SaveChangesAsync();

                var isModified = tracking.State == EntityState.Modified;

                return isModified;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> RemoveUserAsync(int id)
        {
            try
            {
                var user = await _databaseContext.Users.FindAsync(id);

                var tracking = _databaseContext.Remove(user);

                await _databaseContext.SaveChangesAsync();

                var isDeleted = tracking.State == EntityState.Deleted;

                return isDeleted;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Users>> QueryUserAsync(Func<Users, bool> predicate)
        {
            try
            {
                var users = _databaseContext.Users.Where(predicate); ///LINQ

                return users.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }




    }
}
