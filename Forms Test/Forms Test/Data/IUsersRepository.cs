using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsTest.Data
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetUsersAsync();

        Task<IEnumerable<Users>> GetUserByIdAsync(string username);

        Task<bool> AddUser(Users users);

        Task<bool> UpdateUserAsync(Users users);

        Task<bool> RemoveUserAsync(int id);

        Task<IEnumerable<Users>> QueryUserAsync(Func<Users, bool> predicate);
    }
}
