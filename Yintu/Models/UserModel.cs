using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions;
using Yintu.Auxiliars;

namespace Yintu.Models
{
    [Table("UserModel")]
    public class UserModel : NotifyProperty
    {
        [PrimaryKey]
        [Column("CiUser")]
        public string CiUser
        { 
            get { return _ciUSer; }
            set { _ciUSer = value; OnPropertyChanged(); } 
        }
        private string _ciUSer;

        [Column("NameUSer")]
        public string NameUser 
        {
            get { return _nameUser; }
            set { _nameUser = value; OnPropertyChanged(); }
        }
        private string _nameUser;


        [Column("MailUser")]
        public string MailUser
        {
            get { return _mailUser; }
            set { _mailUser = value; OnPropertyChanged(); }
        }
        private string _mailUser;


        [Column("PhoneUSer"), MaxLength(10)]
        public string PhoneUser 
        {
            get { return _phoneUser; }
            set { _phoneUser = value; OnPropertyChanged(); }
        }
        private string _phoneUser;


        [Column("PasswordUSer"), MaxLength(12)]
        public string PasswordUser 
        {
            get { return _passwordUser; }
            set { _passwordUser = value; OnPropertyChanged(); }
        }
        private string _passwordUser;

        [Column("TypeUser")]
        public string TypeUser
        {
            get { return _typeUSer; }
            set { _typeUSer = value; OnPropertyChanged(); }
        }
        private string _typeUSer;
    }
}
