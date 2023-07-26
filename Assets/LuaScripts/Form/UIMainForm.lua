require "base.Class"
require "base.BaseForm"
require "Form.UIEventID"

UIMainForm = UIMainForm or {}

UIMainForm = Class("UIMainForm", UIMainForm,BaseForm)



function UIMainForm:OnDestroy()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:OnDestroy")
end

function UIMainForm:OnInit(userData)
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:OnInit")
end

function UIMainForm:OnRecycle()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:OnRecycle")
end

function UIMainForm:OnOpen(userData)
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:OnOpen")
    self:ResisterUIEvent(UIEventID.UIMainForm_ClickMail,self.OnClickMail)
    self:ResisterUIEvent(UIEventID.UIMainForm_ClickFriend,self.OnClickFriend)
    self:ResisterUIEvent(UIEventID.UIMainForm_ClickItem,self.OnClickItem)
    
end

function UIMainForm:OnClickMail()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:OnClickMail")
    local uicomp = CS.UnityGameFramework.Runtime.GameEntry.GetComponent("UIComponent");
    uicomp:OpenUIForm("Assets/UI/Form/MailForm.prefab","DefaultGroup");
end

function UIMainForm:OnClickFriend()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:OnClickFriend")
    local uicomp = CS.UnityGameFramework.Runtime.GameEntry.GetComponent("UIComponent");
    uicomp:OpenUIForm("Assets/UI/Form/FriendForm.prefab","DefaultGroup");
end

function UIMainForm:OnClickItem()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:OnClickItem")
    local uicomp = CS.UnityGameFramework.Runtime.GameEntry.GetComponent("UIComponent");
    uicomp:OpenUIForm("Assets/UI/Form/ItemForm.prefab","DefaultGroup");
    self:Close()
end

function UIMainForm:OnClose(isShutdown,userData)
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:OnClose")
end

function UIMainForm:OnPause()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:OnPause")
end

function UIMainForm:OnResume()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:OnResume")
end

function UIMainForm:OnCover()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:OnCover")
end

function UIMainForm:OnReveal()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:OnReveal")
end

function UIMainForm:OnRefocus(userData)
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:OnRefocus")
end

function UIMainForm:OnUpdate(elapseSeconds,realElapseSeconds)
--     CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:OnUpdate")
end

function UIMainForm:OnDepthChanged()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:OnDepthChanged")
end

function UIMainForm:InternalSetVisible()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====UIMainForm:InternalSetVisible")
end


return UIMainForm
