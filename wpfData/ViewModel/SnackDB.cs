using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfData_Step_4.Model;
using wpfData_Step_4.ViewModel;

namespace wwpfData_Step_4.ViewModel
{
    public class SnackDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Snack() as BaseEntity;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Snack snack = (Snack)entity;
            snack.Id = (int)reader["SnackID"];
            snack.Name = reader["Name"].ToString();
            snack.Calories = int.Parse(reader["Calories"].ToString());

            return snack;
        }

        public SnackList SelectAll()
        {
            this.command.CommandText = "SELECT * FROM TblSnacks";
            SnackList list = new SnackList(base.ExecuteCommand());
            return list;
        }

        public Snack SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM TblSnacks WHERE (SnackID = {id})";
            SnackList list = new SnackList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }

        public SnackList SelectByUser(User user)
        {
            this.command.CommandText = $"SELECT TblSnacks.SnackID, TblSnacks.Name, TblSnacks.Calories FROM (TblSnacks INNER JOIN TblUsersFavoriteSnacks ON TblSnacks.SnackID = TblUsersFavoriteSnacks.SnackID) WHERE (TblUsersFavoriteSnacks.UserID = {user.Id})";
            SnackList list = new SnackList(base.ExecuteCommand());
            return list;
        }
    }
}
