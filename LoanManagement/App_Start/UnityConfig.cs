using LoanManagement.Data.Repository;
using LoanManagement.Data.Repository.Interface;
using System;

using Unity;

namespace LoanManagement
{

    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              UnityContainer container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        public static IUnityContainer Container => container.Value;

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ILoanRepository, LoanRepository>();
        }
    }
}