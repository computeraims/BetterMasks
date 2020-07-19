using BetterMasks;
using BetterMasks.Utils;
using SDG.Framework.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Announcer
{
    public class Main : MonoBehaviour, IModuleNexus
    {
        private static GameObject BetterMasksObject;

        public static Main Instance;

        public static Config Config;

        public void initialize()
        {
            Instance = this;
            Console.WriteLine("BetterMasks by Corbyn loaded");

            BetterMasksObject = new GameObject("BetterMasks");
            DontDestroyOnLoad(BetterMasksObject);

            string path = Directory.GetCurrentDirectory();

            ConfigHelper.EnsureConfig($"{path}\\Modules\\BetterMasks\\config.json");

            Config = ConfigHelper.ReadConfig($"{path}\\Modules\\BetterMasks\\config.json");

            BetterMasksObject.AddComponent<MasksManager>();
        }


        public void shutdown()
        {
            Instance = null;
        }
    }
}