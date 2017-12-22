﻿using System;
using Controllers;
using Gui;
using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class Installer : MonoInstaller
    {
        public Settings GameSettings;
        
        public override void InstallBindings()
        {
            InstallServices(Container, GameSettings.GameSparksRtUnity);
            InstallGui(Container, GameSettings.GuiSettings);
            InstallPacketController(Container, GameSettings.PacketServiceSettings);
            InstallApp(Container);
        }

        private static void InstallServices(DiContainer container, GameSparksRTUnity gs)
        {
            container.Bind<PrefabBuilder>().AsSingle();
            container.Bind<SparkRtService>().AsSingle();
            container.Bind<GameSparksRTUnity>().FromInstance(gs).AsSingle();
        }

        private static void InstallGui(DiContainer container, Settings.Gui gui)
        {
            container.Bind<AuthGui>().FromInstance(gui.AuthGui).AsSingle();
            container.Bind<MatchGui>().FromInstance(gui.MatchGui).AsSingle();
            container.Bind<SessionGui>().FromInstance(gui.SessionGui).AsSingle();
            container.Bind<ConnectionGui>().FromInstance(gui.ConnectionGui).AsSingle();
            container.Bind<GuiController>().AsSingle();
        }

        private static void InstallPacketController(DiContainer container, PacketService.Settings settings)
        {
            container.Bind<PacketService.Settings>().FromInstance(settings).AsSingle();
            container.Bind<PacketService>().AsSingle();
        }

        private static void InstallApp(DiContainer container)
        {
            container.Bind<IInitializable>().To<App>().AsSingle();
            container.Bind<App>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public Gui GuiSettings;
            public GameSparksRTUnity GameSparksRtUnity;
            public PacketService.Settings PacketServiceSettings;

            [Serializable]
            public class Gui
            {
                public AuthGui AuthGui;
                public MatchGui MatchGui;
                public SessionGui SessionGui;
                public ConnectionGui ConnectionGui;
            }
        }
    }
}