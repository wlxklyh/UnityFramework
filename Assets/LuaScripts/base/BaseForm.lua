BaseForm = BaseForm or{ }
BaseForm = Class("BaseForm", BaseForm, LogicBase)

function BaseForm:Construct(csObj)
    self.csObj = csObj
end

function BaseForm:ResisterUIEvent(eventId, handleFun)
    local handleFunc = function(uiEventData)  handleFun(self, uiEventData) end
    self.csObj:ResisterUIEvent(eventId, handleFunc)
end

function BaseForm:Close()
    self.csObj:Close()
end

function BaseForm:Init()
    
end
