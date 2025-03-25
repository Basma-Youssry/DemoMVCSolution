using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Data.DbContexts;

namespace Demo.DataAccess.Repositories
{
    public class DepartmentReprository(ApplicationDbContext dbContext) : IDepartmentReprository
    {


        //******************************Way04 DependancyInjection way

        private readonly ApplicationDbContext _dbContext;
        //public DepartmentReprository(ApplicationDbContext dbContext)  //1.Injection
        //{
        //    this._dbContext = dbContext;
        //}

        //******************************Way03 WithoutDBContext
        //public ApplicationDbContext Dbcontext { get; }
        //public DepartmentReprository(ApplicationDbContext dbContext)
        //{
        //    Dbcontext = dbContext;
        //}
        //******************************Way02 WithoutDBContext
        //ApplicationDbContext dbContext = new ApplicationDbContext();

        //*****************************Way01 WithoutDBContext
        ////CRUD Operations
        ////Get All
        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            if (withTracking)
                return _dbContext.Departments.ToList();
            else
                return _dbContext.Departments.AsNoTracking().ToList();
        }
        ////Get By Id

        public Department GetById(int id) => _dbContext.Departments.Find(id);

        //Update

        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }
        //Delete
        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }

        //Insert
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }


    }
}
