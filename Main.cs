using BetterMasks;
using BetterMasks.Utils;
using SDG.Framework.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BetterMasks
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

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            ConfigHelper.EnsureConfig($"{path}{Path.DirectorySeparatorChar}config.json");

            Config = ConfigHelper.ReadConfig($"{path}{Path.DirectorySeparatorChar}config.json");

            BetterMasksObject.AddComponent<MasksManager>();
        }


        public void shutdown()
        {
            Instance = null;
        }
    }
}