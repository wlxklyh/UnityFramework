require "base.Class"
--这个不是UIMainForm 这个是一个behaviour ！！！！！  UI请看UIMainForm.lua
Example3UI = Example3UI or {}

Example3UI = Class("Example3UI", Example3UI)

function Example3UI:Awake()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====[GF log]====Example3UI:Awake")
    local uicomp = CS.UnityGameFramework.Runtime.GameEntry.GetComponent("UIComponent");
    uicomp:OpenUIForm("Assets/UI/Form/UIMainForm.prefab","DefaultGroup");
end

function Example3UI:Construct(csObj)
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====[GF log]====Example3UI:Construct" )
end


return Example3UI
