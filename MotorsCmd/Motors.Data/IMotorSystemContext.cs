﻿using Motors.Models;
using System.Data.Entity;
 
namespace Motors.Data
{
    public interface IMotorSystemContext
    {
        IDbSet<User> Users { get; set; }
        IDbSet<Manufacturer> Manufacturers { get; set; }
        IDbSet<Model> Models { get; set; }
        IDbSet<Offer> Offers { get; set; }
        IDbSet<Comment> Comments { get; set; }
        IDbSet<Motorcycle> Motorcycles { get; set; }

        int SaveChanges();
    }
}
