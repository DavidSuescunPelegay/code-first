using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }
        public Author Author { get; set; }
        public IList<Tag> Tags { get; set; }//Este metodo crea una relacion M-N con la tabla Tag
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }//Este metodo crea una relacion M-N con la tabla Tag
    }

    public enum CourseLevel
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3
    }

    public class PlutoContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public PlutoContext() : base("name=DefaultConnection")
        {
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

//Package Manager Console
/*
PM> install-package EntityFramework
Attempting to gather dependency information for package 'EntityFramework.6.1.3' with respect to project 'CodeFirst', targeting '.NETFramework,Version=v4.5.2'
Attempting to resolve dependencies for package 'EntityFramework.6.1.3' with DependencyBehavior 'Lowest'
Resolving actions to install package 'EntityFramework.6.1.3'
Resolved actions to install package 'EntityFramework.6.1.3'
Adding package 'EntityFramework.6.1.3' to folder 'F:\VisualStudioProjects\CodeFirst\packages'
Added package 'EntityFramework.6.1.3' to folder 'F:\VisualStudioProjects\CodeFirst\packages'
Added package 'EntityFramework.6.1.3' to 'packages.config'
Executing script file 'F:\VisualStudioProjects\CodeFirst\packages\EntityFramework.6.1.3\tools\init.ps1'
Executing script file 'F:\VisualStudioProjects\CodeFirst\packages\EntityFramework.6.1.3\tools\install.ps1'

Type 'get-help EntityFramework' to see all available Entity Framework commands.
Successfully installed 'EntityFramework 6.1.3' to CodeFirst

PM> enable-migrations
Checking if the context targets an existing database...
Code First Migrations enabled for project CodeFirst.
PM> add-migration InitialModel
Scaffolding migration 'InitialModel'.
The Designer Code for this migration file includes a snapshot of your current Code First model. This snapshot is used to calculate the changes to your model when you scaffold the next migration. If you make additional changes to your model that you want to include in this migration, then you can re-scaffold it by running 'Add-Migration InitialModel' again.
PM> 
*/