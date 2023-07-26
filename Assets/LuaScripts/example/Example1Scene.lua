require "base.Class"

Example1Scene = Example1Scene or {}

Example1Scene = Class("Example1Scene", Example1Scene)

function Example1Scene:Awake()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====Example1Scene:Awake")
    CS.UnityEngine.GameObject.DontDestroyOnLoad(self.csObj.gameObject)
end

function Example1Scene:Start()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====Example1Scene:Start")
    local sceneComp = CS.UnityGameFramework.Runtime.GameEntry.GetComponent("SceneComponent");
    sceneComp:LoadScene("Assets/Scene/Demo.unity", this);
end

function Example1Scene:Construct(csObj)
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====Example1Scene:Construct")
    self.csObj = csObj
end

return Example1Scene
