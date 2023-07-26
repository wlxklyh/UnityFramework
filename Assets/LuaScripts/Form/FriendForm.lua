require "base.Class"
require "base.BaseForm"

FriendForm = FriendForm or {}

FriendForm = Class("FriendForm", FriendForm, BaseForm)



function FriendForm:OnDestroy()
end

function FriendForm:OnInit(userData)
end

function FriendForm:OnRecycle()
end

function FriendForm:OnOpen(userData)
    self:ResisterUIEvent(104,self.OnClickBack)
end

function FriendForm:OnClickBack()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====FriendForm:OnClickBack")
    self:Close()
end
function FriendForm:OnClose(isShutdown,userData)
end

function FriendForm:OnPause()
end

function FriendForm:OnResume()
end

function FriendForm:OnCover()
end

function FriendForm:OnReveal()
end

function FriendForm:OnRefocus(userData)
end

function FriendForm:OnUpdate(elapseSeconds,realElapseSeconds)
--
end

function FriendForm:OnDepthChanged()
end

function FriendForm:InternalSetVisible()
end


return FriendForm
