using Autofac;
using SharpAngular.BussinessLogic.Abstract.IUserBLL;
using SharpAngular.BussinessLogic.SharpService.UserService;
using SharpAngular.DataAccess.Abstract;
using SharpAngular.DataAccess.Concrete;
using Module = Autofac.Module;
namespace SharpAngular.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //BLL
            builder.RegisterType<UserBLL>().As<IUserBLL>().InstancePerLifetimeScope();

            //DAL
            builder.RegisterType<UserDAL>().As<IUserDAL>().InstancePerLifetimeScope();
        }
    }
}
