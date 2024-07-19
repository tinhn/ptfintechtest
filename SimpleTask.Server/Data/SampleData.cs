using SimpleTask.Server.Models;
using System;

namespace SimpleTask.Server.Data
{
    public class SampleData
    {
        public static void Initialize(SimpleTaskDbContext context)
        {
            //Look for any account
            if (context.People.Any()) { return; }

            var account_lst = new Account[]
            {
                new Account{ Firstname="Administrator", Email="admin@local.net", Username="admin", Password="abc@123"},
                new Account{ Firstname="John Elliot",Lastname="Elliot", Email="john@local.net", Username="john", Password="abc@123"},
                new Account{ Firstname="Rachel",Lastname="Green", Email="rahel@local.net", Username="rachel", Password="abc@123"},
                new Account{ Firstname="Anan",Lastname="Catmire", Email="anan@local.net", Username="anan", Password="abc@123"},
                new Account{ Firstname="Laura",Lastname="Dagson", Email="laura@local.net", Username="laura", Password="abc@123"}
            };
            context.People.AddRange(account_lst);
            context.SaveChanges();

            var task_lst = new AccountTask[]
            {
                new AccountTask{ CreatedBy="john",Title="Create a User Registration", Description="Design and implement a user registration system with features like sign-up, login, and password reset", TaskStatus = "Complete", DueDate=DateOnly.FromDateTime(DateTime.Now.AddDays(7))},
                new AccountTask{ CreatedBy="john",Title="Build a RESTful API", Description="Develop an API using a framework like ReactJs and Asp.NET. Include endpoints for CRUD operations (Create, Read, Update, Delete)",TaskStatus="To-Do"},
                new AccountTask{ CreatedBy="john",Title="Implement Authentication and Authorization", Description="Add authentication (e.g., OAuth, JWT) and authorization (roles, permissions) to secure your application",TaskStatus = "Processing",StartDate=DateOnly.FromDateTime(DateTime.Now.AddDays(4))},
                new AccountTask{ CreatedBy="john",Title="Write Unit Tests", Description="Profile and optimize slow database queries by using indexes, caching, or query optimization techniques."},
                new AccountTask{ CreatedBy="john",Title="Integrate Third-Party APIs", Description="Integrate external services (e.g., payment gateways, social media APIs) into your application."},
                new AccountTask{ CreatedBy="john",Title="Implement Real-Time Features", Description="Build real-time features using technologies like WebSockets or SignalR.",TaskStatus="Processing", StartDate=DateOnly.FromDateTime(DateTime.Now.AddDays(2))},
                new AccountTask{ CreatedBy="john",Title="Refactor Legacy Code", Description="Identify and refactor legacy code to improve maintainability, readability, and performance.", TaskStatus = "Complete", DueDate=DateOnly.FromDateTime(DateTime.Now.AddDays(5))},
                new AccountTask{ CreatedBy="john",Title="Implement Deployment (CI/CD)", Description="Set up automated build, test, and deployment pipelines using tools like Jenkins, GitLab CI/CD, or GitHub Actions", TaskStatus = "Processing", StartDate=DateOnly.FromDateTime(DateTime.Now.AddDays(3))},
                new AccountTask{ CreatedBy="john",Title="Redesign Scalable Architecture", Description="Plan and design a scalable architecture that can handle increased traffic and data volume."},

                new AccountTask{ CreatedBy="anan",Title="Create a User Registration", Description="Design and implement a user registration system with features like sign-up, login, and password reset", TaskStatus = "Complete", DueDate=DateOnly.FromDateTime(DateTime.Now.AddDays(7))},
                new AccountTask{ CreatedBy="anan",Title="Build a RESTful API", Description="Develop an API using a framework like ReactJs and Asp.NET. Include endpoints for CRUD operations (Create, Read, Update, Delete)",TaskStatus="To-Do"},
                new AccountTask{ CreatedBy="anan",Title="Implement Authentication and Authorization", Description="Add authentication (e.g., OAuth, JWT) and authorization (roles, permissions) to secure your application",TaskStatus = "Processing",StartDate=DateOnly.FromDateTime(DateTime.Now.AddDays(4))},
                new AccountTask{ CreatedBy="anan",Title="Write Unit Tests", Description="Profile and optimize slow database queries by using indexes, caching, or query optimization techniques."},
                new AccountTask{ CreatedBy="anan",Title="Integrate Third-Party APIs", Description="Integrate external services (e.g., payment gateways, social media APIs) into your application."},
                new AccountTask{ CreatedBy="anan",Title="Implement Real-Time Features", Description="Build real-time features using technologies like WebSockets or SignalR.",TaskStatus="Processing", StartDate=DateOnly.FromDateTime(DateTime.Now.AddDays(2))},
                new AccountTask{ CreatedBy="anan",Title="Refactor Legacy Code", Description="Identify and refactor legacy code to improve maintainability, readability, and performance.", TaskStatus = "Complete", DueDate=DateOnly.FromDateTime(DateTime.Now.AddDays(5))},
                new AccountTask{ CreatedBy="anan",Title="Implement Deployment (CI/CD)", Description="Set up automated build, test, and deployment pipelines using tools like Jenkins, GitLab CI/CD, or GitHub Actions", TaskStatus = "Processing", StartDate=DateOnly.FromDateTime(DateTime.Now.AddDays(3))},
                new AccountTask{ CreatedBy="anan",Title="Redesign Scalable Architecture", Description="Plan and design a scalable architecture that can handle increased traffic and data volume."},

                new AccountTask{ CreatedBy="admin",Title="Create a User Registration", Description="Design and implement a user registration system with features like sign-up, login, and password reset", TaskStatus = "Complete", DueDate=DateOnly.FromDateTime(DateTime.Now.AddDays(7))},
                new AccountTask{ CreatedBy="admin",Title="Build a RESTful API", Description="Develop an API using a framework like ReactJs and Asp.NET. Include endpoints for CRUD operations (Create, Read, Update, Delete)",TaskStatus="To-Do"},
                new AccountTask{ CreatedBy="admin",Title="Implement Authentication and Authorization", Description="Add authentication (e.g., OAuth, JWT) and authorization (roles, permissions) to secure your application",TaskStatus = "Processing",StartDate=DateOnly.FromDateTime(DateTime.Now.AddDays(4))},
                new AccountTask{ CreatedBy="admin",Title="Write Unit Tests", Description="Profile and optimize slow database queries by using indexes, caching, or query optimization techniques."},
                new AccountTask{ CreatedBy="admin",Title="Integrate Third-Party APIs", Description="Integrate external services (e.g., payment gateways, social media APIs) into your application."},
                new AccountTask{ CreatedBy="admin",Title="Implement Real-Time Features", Description="Build real-time features using technologies like WebSockets or SignalR.",TaskStatus="Processing", StartDate=DateOnly.FromDateTime(DateTime.Now.AddDays(2))},
                new AccountTask{ CreatedBy="admin",Title="Refactor Legacy Code", Description="Identify and refactor legacy code to improve maintainability, readability, and performance.", TaskStatus = "Complete", DueDate=DateOnly.FromDateTime(DateTime.Now.AddDays(5))},
                new AccountTask{ CreatedBy="admin",Title="Implement Deployment (CI/CD)", Description="Set up automated build, test, and deployment pipelines using tools like Jenkins, GitLab CI/CD, or GitHub Actions", TaskStatus = "Processing", StartDate=DateOnly.FromDateTime(DateTime.Now.AddDays(3))},
                new AccountTask{ CreatedBy="admin",Title="Redesign Scalable Architecture", Description="Plan and design a scalable architecture that can handle increased traffic and data volume."},

                new AccountTask{ CreatedBy="laura",Title="Create a User Registration", Description="Design and implement a user registration system with features like sign-up, login, and password reset", TaskStatus = "Complete", DueDate=DateOnly.FromDateTime(DateTime.Now.AddDays(7))},
                new AccountTask{ CreatedBy="laura",Title="Build a RESTful API", Description="Develop an API using a framework like ReactJs and Asp.NET. Include endpoints for CRUD operations (Create, Read, Update, Delete)",TaskStatus="To-Do"},
                new AccountTask{ CreatedBy="laura",Title="Implement Authentication and Authorization", Description="Add authentication (e.g., OAuth, JWT) and authorization (roles, permissions) to secure your application",TaskStatus = "Processing",StartDate=DateOnly.FromDateTime(DateTime.Now.AddDays(4))},
                new AccountTask{ CreatedBy="laura",Title="Write Unit Tests", Description="Profile and optimize slow database queries by using indexes, caching, or query optimization techniques."},
                new AccountTask{ CreatedBy="laura",Title="Integrate Third-Party APIs", Description="Integrate external services (e.g., payment gateways, social media APIs) into your application."},
                new AccountTask{ CreatedBy="laura",Title="Implement Real-Time Features", Description="Build real-time features using technologies like WebSockets or SignalR.",TaskStatus="Processing", StartDate=DateOnly.FromDateTime(DateTime.Now.AddDays(2))},
                new AccountTask{ CreatedBy="laura",Title="Refactor Legacy Code", Description="Identify and refactor legacy code to improve maintainability, readability, and performance.", TaskStatus = "Complete", DueDate=DateOnly.FromDateTime(DateTime.Now.AddDays(5))},
                new AccountTask{ CreatedBy="laura",Title="Implement Deployment (CI/CD)", Description="Set up automated build, test, and deployment pipelines using tools like Jenkins, GitLab CI/CD, or GitHub Actions", TaskStatus = "Processing", StartDate=DateOnly.FromDateTime(DateTime.Now.AddDays(3))},
                new AccountTask{ CreatedBy="laura",Title="Redesign Scalable Architecture", Description="Plan and design a scalable architecture that can handle increased traffic and data volume."},
            };

            context.TaskInfos.AddRange(task_lst);
            context.SaveChanges();
        }
    }
}
