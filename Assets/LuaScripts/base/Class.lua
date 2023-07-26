--创建一个类
--clsname 类名
--... 需要继承的父类
function Class(clsname, ...)
    local args = {...}
    local cls = {clsname = clsname, __bases__ = args}
    if #args > 0 then
        setmetatable(cls, {
            __index = function(_, k)
                for i, v in ipairs(cls.__bases__) do
                    local ret = v[k]
                    if ret ~= nil then
                        return ret
                    end
                end
            end,
            --可以打印出所有函数的调用时间
            -- __newindex = function(t, k, v)
            --  if type(v) == "function" then
            --      rawset(t, k, function(...) 
            --          return Utils.DebugCallTime(v, k, nil, ...)
            --      end)
            --  else
            --      rawset(t, k, v)
            --  end
            -- end
    })
    end
    cls.New = function(...)
        local self = setmetatable({clstype=cls}, cls)
        if cls.Construct then --构造函数
            cls.Construct(self, ...)
        end
        
        return self
    end



    cls.__index = cls
    return cls
end