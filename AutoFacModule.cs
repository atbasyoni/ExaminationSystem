using Autofac;
using AutoMapper;
using ExaminationSystem.Data;
using ExaminationSystem.Mediators;
using ExaminationSystem.Profiles;
using ExaminationSystem.Repositories.Bases;
using ExaminationSystem.Repositories.Users;
using ExaminationSystem.Services.Choices;
using ExaminationSystem.Services.CourseInstructors;
using ExaminationSystem.Services.Courses;
using ExaminationSystem.Services.CourseStudents;
using ExaminationSystem.Services.Departments;
using ExaminationSystem.Services.Exams;
using ExaminationSystem.Services.Instructors;
using ExaminationSystem.Services.Questions;

namespace ExaminationSystem
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(UserRepository<>)).As(typeof(IUserRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<ExamService>().As<IExamService>().InstancePerLifetimeScope();
            builder.RegisterType<ExamQuestionService>().As<IExamQuestionService>().InstancePerLifetimeScope();

            builder.RegisterType<DepartmentService>().As<IDepartmentService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseService>().As<ICourseService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseInstructorService>().As<ICourseInstructorService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseStudentService>().As<ICourseStudentService>().InstancePerLifetimeScope();
            builder.RegisterType<ChoiceService>().As<IChoiceService>().InstancePerLifetimeScope();
            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerLifetimeScope();
            builder.RegisterType<InstructorService>().As<IInstructorService>().InstancePerLifetimeScope();

            builder.RegisterType<CourseMediator>().As<ICourseMediator>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentMediator>().As<IDepartmentMediator>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DepartmentProfile>();
                cfg.AddProfile<CourseProfile>();
                cfg.AddProfile<ExamProfile>();
                cfg.AddProfile<QuestionProfile>();
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
