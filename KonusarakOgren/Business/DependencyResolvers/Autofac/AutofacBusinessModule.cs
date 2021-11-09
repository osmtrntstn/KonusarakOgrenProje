using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.EntityFrameWork.Contexts;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ExamDal>().As<IExamDal>();
            builder.RegisterType<ExamService>().As<IExamService>();

            builder.RegisterType<ExamQuestionDal>().As<IExamQuestionDal>();
            builder.RegisterType<ExamQuestionService>().As<IExamQuestionService>();

            builder.RegisterType<ExamQuestionOptionDal>().As<IExamQuestionOptionDal>();
            builder.RegisterType<ExamQuestionOptionService>().As<IExamQuestionOptionService>();

            builder.RegisterType<UserDal>().As<IUserDal>();
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<UserExamDal>().As<IUserExamDal>();
            builder.RegisterType<UserExamService>().As<IUserExamService>();

            builder.RegisterType<UserExamOptionDal>().As<IUserExamOptionDal>();
            builder.RegisterType<UserExamOptionService>().As<IUserExamOptionService>();

            builder.RegisterType<UserTypeDal>().As<IUserTypeDal>();
            builder.RegisterType<UserTypeService>().As<IUserTypeService>();

            builder.RegisterType<WiredTextDal>().As<IWiredTextDal>();
            builder.RegisterType<WiredTextService>().As<IWiredTextService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
