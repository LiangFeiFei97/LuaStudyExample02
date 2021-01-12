using System.IO;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public class LuaInit : MonoBehaviour
{
    private void Awake()
    {
        var luaEnv = LuaEnvManager.Instance.GetEnv();
        luaEnv.AddLoader(LuaCodeLoader);
        luaEnv.DoString("require('Scripts.Global.init')");
    }

    private static byte[] LuaCodeLoader(ref string filePath)
    {
        var relPath = filePath.Replace(".", "/");
        var s = File.ReadAllText(Application.dataPath + "/" + relPath + ".lua");
        return System.Text.Encoding.UTF8.GetBytes(s);
    }
}