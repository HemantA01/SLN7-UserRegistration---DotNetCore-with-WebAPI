using Microsoft.EntityFrameworkCore;
using SLN7.DATA.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.DATA.DBContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public virtual DbSet<TblUserLogin> tblUserLogin { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<TblLeadSource> tblLeadSource { get; set; }
        public virtual DbSet<TblCountryMaster> tblCountryMaster { get; set; }
        public virtual DbSet<TblStateMaster> tblStateMaster { get; set; }
        public virtual DbSet<TblUserRegistration> tblUserRegistration { get; set; }
        public virtual DbSet<TblUploadFile> tblUploadFile { get; set; }
    }
}
