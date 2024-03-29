﻿using System;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Prism.Ioc;
using Shiny;
using Shiny.BluetoothLE;

namespace XamarinHelloBle.Client
{
  public class Startup : ShinyStartup
  {
    public override void ConfigureServices(IServiceCollection services, IPlatform platform)
    {
      // Inject our db so we can use it for Shiny Background events
      // services.AddSingleton<SampleSqliteConnection>();

      // As BLE Client:
      //// services.UseBleClient();
      //// services.UseBleClient<Shiny.BluetoothLE.IBleDelegate>();
      //// services.UseBleClient<BleClientDelegate>();
      // As BLE Host:
      //// services.UseBleHosting();

      services.UseBleClient();
      ////services.UseBleHosting();
      services.UseNotifications();
      services.UseJobs();
    }

    public override IServiceProvider CreateServiceProvider(IServiceCollection services)
    {
      // This registers and initializes the Container with Prism ensuring
      // that both Shiny & Prism use the same container
      // .
      ContainerLocator.SetContainerExtension(() => new DryIocContainerExtension());

      var container = ContainerLocator.Container.GetContainer();
      DryIocAdapter.Populate(container, services);

      return container.GetServiceProvider();
    }
  }
}
