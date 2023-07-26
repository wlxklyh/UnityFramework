require "base.Class"
require "base.BaseForm"


MailForm = MailForm or {}

MailForm = Class("MailForm", MailForm,BaseForm)



function MailForm:OnDestroy()
end

function MailForm:OnInit(userData)
end

function MailForm:OnRecycle()
end

function MailForm:OnOpen(userData)
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====MailForm:OnOpen")
    self:ResisterUIEvent(104,self.OnClickBack)
end

function MailForm:OnClickBack()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====MailForm:OnClickBack")
    self:Close()
end

function MailForm:OnClose(isShutdown,userData)
end

function MailForm:OnPause()
end

function MailForm:OnResume()
end

function MailForm:OnCover()
end

function MailForm:OnReveal()
end

function MailForm:OnRefocus(userData)
end

function MailForm:OnUpdate(elapseSeconds,realElapseSeconds)
--
end

function MailForm:OnDepthChanged()
end

function MailForm:InternalSetVisible()
end


return MailForm
