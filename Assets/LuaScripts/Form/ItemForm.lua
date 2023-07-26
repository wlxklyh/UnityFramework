require "base.Class"
require "base.BaseForm"

ItemForm = ItemForm or {}

ItemForm = Class("ItemForm", ItemForm, BaseForm)



function ItemForm:OnDestroy()
end

function ItemForm:OnInit(userData)
end

function ItemForm:OnRecycle()
end

function ItemForm:OnOpen(userData)
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====MailForm:OnOpen")
    self:ResisterUIEvent(104,self.OnClickBack)
    
    self:ResisterUIEvent(201,self.OnClick1)
    self:ResisterUIEvent(202,self.OnClick2)
    self:ResisterUIEvent(203,self.OnClick3)
    
end

function ItemForm:OnClick1()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====ItemForm:OnClick1 ")
    local resComp = CS.UnityGameFramework.Runtime.GameEntry.GetComponent("ResourceComponent");
    local handleFunc = function(assetName, asset, duration, userData)  self.LoadPrefabCallBack(self, assetName, asset, duration, userData) end
    resComp:LoadAsset("Assets/Prefab/Charactor.prefab",CS.GameFramework.Resource.LoadAssetCallbacks(handleFunc));
end

function ItemForm:LoadPrefabCallBack(assetName, asset, duration, userData)
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====ItemForm:LoadPrefabCallBack " .. assetName)
    go = CS.UnityEngine.GameObject.Instantiate(asset)
    posX = math.random(5);
    posY = math.random(10);
    go.transform.position = CS.UnityEngine.Vector3(posX , posY , 0)
        
end


function ItemForm:OnClick2()

end

function ItemForm:OnClick3()

end

function ItemForm:OnClickBack()
    CS.GameFramework.GameFrameworkLog.Info("[GF log]====ItemForm:OnClickBack")
    self:Close()
end
function ItemForm:OnClose(isShutdown,userData)
end

function ItemForm:OnPause()
end

function ItemForm:OnResume()
end

function ItemForm:OnCover()
end

function ItemForm:OnReveal()
end

function ItemForm:OnRefocus(userData)
end

function ItemForm:OnUpdate(elapseSeconds,realElapseSeconds)
--
end

function ItemForm:OnDepthChanged()
end

function ItemForm:InternalSetVisible()
end


return ItemForm
