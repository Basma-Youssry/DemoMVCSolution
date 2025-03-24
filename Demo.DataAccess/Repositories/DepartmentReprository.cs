using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Data.DbContexts;

namespace Demo.DataAccess.Repositories
{
    internal class DepartmentReprository(ApplicationDbContext dbContext)
    {


        //******************************Way04 DependancyInjection way

        //private readonly ApplicationDbContext _dbContext;
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
        //CRUD Operations
        //Get All
        //Get By Id

        //public Department GetById(int id)
        //{
        //    var department = dbContext.Departments.Find(id);

        //    return department;
        //}



        //Update
        //Delete
        //Insert



    }
}
