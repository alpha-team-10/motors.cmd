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
        protected MotorSystemContext()
            :base("MotorSystem")
        {

        }

        IDbSet<User> Users { get; set; } 
    }
}
