using Core.Utilities.Security.Encryption;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork.Contexts
{
    public class Context : DbContext
    {
        public IConfiguration _configuration;
        private static string ConnectionString { get; set; } 
        public static void SetConnectionString(string connectionString)
        {
            if (ConnectionString == null)
            {
                ConnectionString = connectionString;
            }
        }
        public Context(DbContextOptions<Context> options) : base(options) 
        {
            
        }

       
        public Context()
        {
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                
            optionsBuilder.UseSqlite("DataSource = " + ConnectionString);
            optionsBuilder.EnableSensitiveDataLogging();

        }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<ExamQuestionOption> ExamQuestionOptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserExam> UserExams { get; set; }
        public DbSet<UserExamOption> UserExamOptions { get; set; }
        public DbSet<WiredText> WiredTexts { get; set; }


       
    }


}
