using BepInEx;
using BepInEx.Logging;
using System.Collections.Generic;
using UnityEngine;

namespace Messed_Up_Settings
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger { get; private set; } = null!;
        public static Plugin Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            // Plugin startup logic
            Logger = base.Logger;
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
            gameObject.hideFlags = HideFlags.DontSaveInEditor;

            
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                InGameEffectManager.TranslateCommand(JsonUtility.ToJson(CreateCommand(CommandType.Spawn, new List<string>() { "Assets/Prefabs/Attacks and Projectiles/Explosions/Explosion Minos Prime.prefab" })));
            }
        }


        public static CommandClass CreateCommand(CommandType type, List<string> arguments)
        {
            return new CommandClass() { 
                Arguments = arguments,
                CommandT = (int)type,
            };
        }
    }
}
