using System;
using System.IO;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public class LuaInit : MonoBehaviour
{
    [SerializeField] private LuaStruct[] pages;

    private void Awake()
    {
        var luaEnv = LuaEnvManager.Instance.GetEnv();
        luaEnv.AddLoader(LuaCodeLoader);

        foreach (var item in pages)
        {
            luaEnv.Global.Set(item.Name, item.Value);
        }

        luaEnv.DoString("require('Scripts.Global.init')");
    }

    private static byte[] LuaCodeLoader(ref string filePath)
    {
        var relPath = filePath.Replace(".", "/");
        var s = File.ReadAllText(Application.dataPath + "/" + relPath + ".lua");
        return System.Text.Encoding.UTF8.GetBytes(s);
    }
}

[Serializable]
public class LuaStruct
{
    public string Name;
    public GameObject Value;
}