using Autofac;
using ExaminationSystem.Data;
using ExaminationSystem.Repositories;
using ExaminationSystem.Services.Exams;

namespace ExaminationSystem
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IExamService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IExamQuestionService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
