---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by Dell.
--- DateTime: 2021/1/12 14:27
---

local Resource = {}

function Resource.load(name)
    local object = CS.UnityEngine.Resources.Load(UIDefine.UI[name].path, typeof(CS.UnityEngine.GameObject))
    local parent = CS.UnityEngine.GameObject.Find('Canvas').transform
    if UIDefine.UI[name].parent then
        parent = parent:Find(UIDefine.UI[name].parent)
    end
    local result = CS.UnityEngine.Object.Instantiate(object, parent);
    result.name = name
    return result.gameObject
end

function Resource.loadImage(name)
    return CS.UnityEngine.Resources.Load('Backpack/Images/' .. name, typeof(CS.UnityEngine.Sprite))
end

function Resource.destroy(object)
    CS.UnityEngine.Object.Destroy(object)
end

return Resource