using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Access
{
    //public class UserRepository : IRepository<User>
    //{
    //    ReminderSystemContext context;
    //    public UserRepository()
    //    {
    //        context = new ReminderSystemContext();
    //    }
    //    public bool Add(User entity)
    //    {
    //        var user = context.Add(entity) != null;
    //        context.SaveChanges();
    //        if (user)
    //        {
    //            return true;
    //        }
    //        return false;
    //    }

    //    public bool Delete(User entity)
    //    {
    //        return context.User.Remove(entity) != null;
    //    }

    //    public bool Edit(User entity)
    //    {
    //        return context.User.Add(entity) != null;
    //    }

    //    //public List<User> FindById(int id)
    //    //{
    //    //    return context.User.Where(user => user.Id == id).ToList();
    //    //}

    //    public List<User> GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
