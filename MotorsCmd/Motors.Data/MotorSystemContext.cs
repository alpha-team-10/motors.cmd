using Motors.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Data
{
    public class MotorSystemContext : DbContext
    {
        public MotorSystemContext()
            :base("MotorSystem")
        {

        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Model> Models { get; set; }

        public IDbSet<Offer> Offers { get; set; }

        public IDbSet<Comment> Commets { get; set; }

    }
}
