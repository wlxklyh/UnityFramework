require "base.Class"

Example2Log = Example2Log or {}

Example2Log = Class("Example2Log", Example2Log)

function Example2Log:Awake()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====Example2Log:Awake")
end

function Example2Log:Construct(csObj)
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====Example2Log:Construct")
end

return Example2Log
