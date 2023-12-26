namespace LAOZ.CQRS.Configuration
{
    public sealed class ServiceLocator
    {
        //private static ICommandBus _commandBus;
        //private static IReportDatabase _reportDatabase;
        //private static bool _isInitialized;
        //private static readonly object _lockThis = new object();

        //static ServiceLocator()
        //{
        //    if (!_isInitialized)
        //    {
        //        lock (_lockThis)
        //        {
        //            ContainerBootstrapper.BootstrapStructureMap();
        //            _commandBus = ObjectFactory.GetInstance<ICommandBus>();
        //            _reportDatabase = ObjectFactory.GetInstance<IReportDatabase>();
        //            _isInitialized = true;
        //        }
        //    }
        //}

        //public static ICommandBus CommandBus
        //{
        //    get { return _commandBus; }
        //}

        //public static IReportDatabase ReportDatabase
        //{
        //    get { return _reportDatabase; }
        //}
    }
}