using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Messed_Up_Settings
{
    public class InGameEffectManager
    {
        public static void TranslateCommand(string command)
        {
            LogMan.Info($"Received command {command}");

            CommandClass c = JsonUtility.FromJson<CommandClass>(command);

            switch ((CommandType)c.CommandT)
            {
                case CommandType.Spawn:
                    Spawn(c.Arguments[0]);
                    break;

            }
        }

        static void Spawn(string Argument)
        {
            GameObject prefab = Addressables.LoadAssetAsync<GameObject>(Argument).WaitForCompletion();
            if(prefab == null)
            {
                LogMan.Error($"Tried spawning {Argument} but it doesn't exist!");
                return;
            }

            Object.Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }


    }

    [System.Serializable]
    public class CommandClass
    {
        public int CommandT;
        public List<string> Arguments;
    }

    public enum CommandType
    {
        Spawn
    }
}
