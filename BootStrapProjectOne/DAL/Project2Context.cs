using BootStrapProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BootStrapProjectOne.DAL
{
    public class Project2Context : DbContext
    {
        public Project2Context() : base("Project2Context")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}