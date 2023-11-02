﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using wpfData_Step_4.Model;
using wwpfData_Step_4.ViewModel;

namespace wpfData_Step_4.ViewModel
{
    public class UserDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new User() as BaseEntity;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = (User)entity;
            user.Id = (int)reader["PersonID"];
            user.FirstName = reader["FirstName"].ToString();
            user.LastName = reader["LastName"].ToString();
            user.Phone = reader["Phone"].ToString();
            user.UserName = reader["UserName"].ToString();
            user.Password = reader["Password"].ToString();
            user.IsAdmin = bool.Parse(reader["IsAdmin"].ToString());

            // השלמת הבאת נתוני עיר לפי קוד העיר
            int cityID = (int)reader["CityID"];
            CityDB cityDB = new CityDB();
            user.City = cityDB.SelectById(cityID);

            SnackDB snackDB = new SnackDB();
            user.Snacks = snackDB.SelectByUser(user);
            return user;
        }


        public UserList SelectAll()
        {
            this.command.CommandText = "SELECT * FROM TblUsers";
            UserList list = new UserList(base.ExecuteCommand());
            return list;
        }

        public User SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM TblUsers WHERE (ID = {id})";
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }

        public User Login(User user)
        {
            command.CommandText = $"SELECT * FROM TblUsers WHERE (UserName = '{user.UserName}') AND ([Password] = '{user.Password}')";
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }

        public UserList SelectBySnack(Snack snack)
        {
            this.command.CommandText = $"SELECT * FROM (TblUsersFavoriteSnacks INNER JOIN TblUsers ON TblUsersFavoriteSnacks.UserID = TblUsers.PersonID) WHERE (SnackID = {snack.Id})";
            UserList list = new UserList(base.ExecuteCommand());
            return list;
        }
    }
 }


