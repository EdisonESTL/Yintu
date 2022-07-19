using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Yintu.Models;

namespace Yintu.DataBase
{
    public class UserDb
    {
        static SQLiteAsyncConnection _dataBase;

        public static readonly AsyncLazy<UserDb> Instance = new AsyncLazy<UserDb>(async () =>
        {
            var instance = new UserDb();
            await _dataBase.CreateTableAsync<UserModel>();
            return instance;
        });
        
        public UserDb()
        {
            _dataBase = new SQLiteAsyncConnection(DataBase.DbPath, DataBase.flags);
        }

        public string AddUser(UserModel User)
        {
            var data = _dataBase.Table<UserModel>();
            var d1 = data.Where(x => x.NameUser == User.NameUser && x.MailUser == User.MailUser).FirstOrDefaultAsync();
            if(d1 == null)
            {
                _dataBase.InsertAsync(User);
                return "Siiiiiiii";
            }
            else
            {
                return "nooooo";
            }
        }
                
        public bool ValidarUsuario(string ci, string contrasenia)
        {
            //var gf = _dataBase.QueryAsync<UserModel>("SELECT NameUser FROM UserModel WHERE CiUser = ? AND PasswordUser = ?", ci, contrasenia);

            var data = _dataBase.Table<UserModel>().FirstOrDefaultAsync(t => t.CiUser == ci && t.PasswordUser == contrasenia);
            data.Wait();
            var result = data.Result;
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<List<UserModel>> Ver(string ci, string contrasenia)
        {
            var gf = _dataBase.QueryAsync<UserModel>("SELECT NameUser FROM UserModel WHERE CiUser = ? AND PasswordUser = ?", ci, contrasenia);
            
            if (gf != null)
            {
                return _dataBase.QueryAsync<UserModel>("SELECT NameUser, PhoneUser FROM UserModel WHERE CiUser = ? AND PasswordUser = ?", ci, contrasenia);
            }
            else
            {
                return _dataBase.QueryAsync<UserModel>("SELECT PhoneUser FROM UserModel WHERE CiUser = ? AND PasswordUser = ?", ci, contrasenia);
            }
        }
        public Task<List<UserModel>> listar()
        {
            return _dataBase.Table<UserModel>().ToListAsync();
            
        }

        public Task<int> SaveUser(UserModel us)
        {
            return _dataBase.InsertAsync(us);
        }

        public Task<int> UpdateUser(UserModel us)
        {
            return _dataBase.UpdateAsync(us);
        }

        public bool Delete()
        {
            var f = _dataBase.QueryAsync<UserModel>("DELETE * FROM UserModel");
            f.Wait();
            var tg = f.Result;
            if(tg != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
