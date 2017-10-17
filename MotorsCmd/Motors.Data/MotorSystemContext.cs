using Motors.Models;
using System.Data.Entity;

namespace Motors.Data
{
    public class MotorSystemContext : DbContext, IMotorSystemContext
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

        public IDbSet<Motorcycle> Motorcycles { get; set; }

    }
}
