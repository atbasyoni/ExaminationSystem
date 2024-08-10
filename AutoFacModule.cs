using Autofac;
using AutoMapper;
using ExaminationSystem.Data;
using ExaminationSystem.Helpers;
using ExaminationSystem.Mediators.Accounts;
using ExaminationSystem.Mediators.Choices;
using ExaminationSystem.Mediators.Courses;
using ExaminationSystem.Mediators.Departments;
using ExaminationSystem.Mediators.Exams;
using ExaminationSystem.Mediators.Questions;
using ExaminationSystem.Models;
using ExaminationSystem.Profiles;
using ExaminationSystem.Repositories.Bases;
using ExaminationSystem.Repositories.Users;
using ExaminationSystem.Services.Accounts;
using ExaminationSystem.Services.Choices;
using ExaminationSystem.Services.CourseInstructors;
using ExaminationSystem.Services.Courses;
using ExaminationSystem.Services.CourseStudents;
using ExaminationSystem.Services.Departments;
using ExaminationSystem.Services.Exams;
using ExaminationSystem.Services.Instructors;
using ExaminationSystem.Services.Questions;
using ExaminationSystem.Services.Students;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ExaminationSystem
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(UserRepository<>)).As(typeof(IUserRepository<>)).InstancePerLifetimeScope();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return context.Resolve<IOptions<JWT>>().Value;
            }).As<JWT>().SingleInstance();

            builder.RegisterType<UserManager<User>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<RoleManager<IdentityRole<int>>>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerLifetimeScope();
            builder.RegisterType<ChoiceService>().As<IChoiceService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseService>().As<ICourseService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseInstructorService>().As<ICourseInstructorService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseStudentService>().As<ICourseStudentService>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>().InstancePerLifetimeScope();
            builder.RegisterType<ExamService>().As<IExamService>().InstancePerLifetimeScope();
            builder.RegisterType<ExamQuestionService>().As<IExamQuestionService>().InstancePerLifetimeScope();
            builder.RegisterType<InstructorService>().As<IInstructorService>().InstancePerLifetimeScope();
            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerLifetimeScope();
            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();

            builder.RegisterType<AuthMediator>().As<IAuthMediator>().InstancePerLifetimeScope();
            builder.RegisterType<ChoiceMediator>().As<IChoiceMediator>().InstancePerLifetimeScope();
            builder.RegisterType<CourseMediator>().As<ICourseMediator>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentMediator>().As<IDepartmentMediator>().InstancePerLifetimeScope();
            builder.RegisterType<ExamMediator>().As<IExamMediator>().InstancePerLifetimeScope();
            builder.RegisterType<QuestionMediator>().As<IQuestionMediator>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AccountProfile>();
                cfg.AddProfile<DepartmentProfile>();
                cfg.AddProfile<CourseProfile>();
                cfg.AddProfile<ExamProfile>();
                cfg.AddProfile<QuestionProfile>();
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
