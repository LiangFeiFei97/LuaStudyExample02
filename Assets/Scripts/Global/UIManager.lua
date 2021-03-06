---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by Dell.
--- DateTime: 2021/1/12 10:30
---

local UIManager = {}

UIManager.UI = {}

function UIManager.showPanel(name, callback)
    if not UIManager.UI[name] then
        local panel = Resource.load(name)
        if panel then
            UIManager.UI[name] = panel
        else
            return
        end
    end
    
    require(UIDefine.UI[name].script).show(UIManager.UI[name])
    if callback then
        callback()
    end
end

function UIManager.hidePanel(name, callback)
    if not UIManager.UI[name] then
        return
    end

    Resource.destroy(UIManager.UI[name])
    UIManager.UI[name] = nil
    if callback then
        callback()
    end
end

return UIManager