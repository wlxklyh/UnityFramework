using Framework;
using Framework.UI;
using UnityGameFramework.Runtime;
using XLua;

namespace Lua
{
    public class LuaUIFormLogic: UIFormLogic
    {
        public LuaTableHandler luaTableHandler;
        private UIEvent[] uiEvents;
        public UIEventDispatcher uiEventDispatcher = new UIEventDispatcher();

        public void Close()
        {
            UIComponent uiComp = GameEntry.GetComponent<UIComponent>();
            uiComp.CloseUIForm(UIForm.SerialId);
        }
        
        public void ResisterUIEvent(int eventID,OnUIEventCallback callback)
        {
           uiEventDispatcher.ResisterUIEvent(eventID,callback);
        }

        public void DispatchEvent(int eventID)
        {
            uiEventDispatcher.DispatchEvent(eventID);
        }
        

        public LuaTable LuaScriptTable
        {
            get
            {
                return luaTableHandler.LuaScriptTable;
            }
        }
        
        public virtual void Awake()
        {
            luaTableHandler.OnInit(this);
            CallLuaMethod("Awake");
            
            uiEvents = this.GetComponentsInChildren<UIEvent>();
            foreach (var uiEvent in uiEvents)
            {
                uiEvent.luaUIFormLogic = this;
            }
        }
        public virtual void OnDestroy()
        {
            foreach (var uiEvent in uiEvents)
            {
                uiEvent.luaUIFormLogic = null;
            }
            CallLuaMethod("OnDestroy");
            luaTableHandler.OnDestroy();
        }

         /// <summary>
        /// 界面初始化。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnInit(object userData)
        {
           base.OnInit(userData);
           CallLuaMethod("OnInit",userData);
           
        }

        /// <summary>
        /// 界面回收。
        /// </summary>
        protected override void OnRecycle()
        {
            base.OnRecycle();
            CallLuaMethod("OnRecycle");
        }

        /// <summary>
        /// 界面打开。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            CallLuaMethod("OnOpen",userData);
        }

        /// <summary>
        /// 界面关闭。
        /// </summary>
        /// <param name="isShutdown">是否是关闭界面管理器时触发。</param>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown,userData);
            CallLuaMethod("OnClose",isShutdown,userData);
        }

        /// <summary>
        /// 界面暂停。
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
            CallLuaMethod("OnPause");
        }

        /// <summary>
        /// 界面暂停恢复。
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            CallLuaMethod("OnResume");
        }

        /// <summary>
        /// 界面遮挡。
        /// </summary>
        protected override void OnCover()
        {
            base.OnCover();
            CallLuaMethod("OnCover");
        }

        /// <summary>
        /// 界面遮挡恢复。
        /// </summary>
        protected override void OnReveal()
        {
            base.OnReveal();
            CallLuaMethod("OnReveal");
        }

        /// <summary>
        /// 界面激活。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnRefocus(object userData)
        {
            base.OnRefocus(userData);
            CallLuaMethod("OnRefocus",userData);
        }

        /// <summary>
        /// 界面轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds,realElapseSeconds);
            CallLuaMethod("OnUpdate",elapseSeconds,realElapseSeconds);
        }

        /// <summary>
        /// 界面深度改变。
        /// </summary>
        /// <param name="uiGroupDepth">界面组深度。</param>
        /// <param name="depthInUIGroup">界面在界面组中的深度。</param>
        protected override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            base.OnDepthChanged(uiGroupDepth,depthInUIGroup);
            CallLuaMethod("OnDepthChanged",uiGroupDepth,depthInUIGroup);
        }

        /// <summary>
        /// 设置界面的可见性。
        /// </summary>
        /// <param name="visible">界面的可见性。</param>
        protected virtual void InternalSetVisible(bool visible)
        {
            base.InternalSetVisible(visible);
            CallLuaMethod("InternalSetVisible",visible);
        }

        #region 调用Lua函数 无返回值
        public void CallLuaMethod(string funcName)
        {
            CSCallLuaHelper.CallLuaMethod(this.LuaScriptTable, funcName);
        }

        public void CallLuaMethod<T1>(string funcName, T1 para1)
        {
            CSCallLuaHelper.CallLuaMethod(this.LuaScriptTable, funcName, para1);
        }

        public void CallLuaMethod<T1, T2>(string funcName, T1 para1, T2 para2)
        {
            CSCallLuaHelper.CallLuaMethod(this.LuaScriptTable, funcName, para1, para2);
        }

        public void CallLuaMethod<T1, T2, T3>(string funcName, T1 para1, T2 para2, T3 para3)
        {
            CSCallLuaHelper.CallLuaMethod(this.LuaScriptTable, funcName, para1, para2, para3);
        }

        #endregion

        #region 调用Lua函数 有返回值 Ref和Out区别 ：找不到函数时候Out会在函数内部赋值默认值 Ref则保持外部调用的初始化值

        public void CallLuaMethodRef<TResult>(string funcName, ref TResult ret)
        {
            CSCallLuaHelper.CallLuaMethodRef(this.LuaScriptTable, funcName, ref ret);
        }

        public void CallLuaMethodOut<TResult>(string funcName, out TResult ret)
        {
            CSCallLuaHelper.CallLuaMethodOut(this.LuaScriptTable, funcName, out ret);
        }

        public void CallLuaMethodRef<TResult, T1>(string funcName, ref TResult ret, T1 para1)
        {
            CSCallLuaHelper.CallLuaMethodRef(this.LuaScriptTable, funcName, ref ret, para1);
        }

        public void CallLuaMethodOut<TResult, T1>(string funcName, out TResult ret, T1 para1)
        {
            CSCallLuaHelper.CallLuaMethodOut(this.LuaScriptTable, funcName, out ret, para1);
        }

        public void CallLuaMethodRef<TResult, T1, T2>(string funcName, ref TResult ret, T1 para1, T2 para2)
        {
            CSCallLuaHelper.CallLuaMethodRef(this.LuaScriptTable, funcName, ref ret, para1, para2);
        }

        public void CallLuaMethodOut<TResult, T1, T2>(string funcName, out TResult ret, T1 para1, T2 para2)
        {
            CSCallLuaHelper.CallLuaMethodOut(this.LuaScriptTable, funcName, out ret, para1, para2);
        }

        public void CallLuaMethodRef<TResult, T1, T2, T3>(string funcName, ref TResult ret, T1 para1, T2 para2,
            T3 para3)
        {
            CSCallLuaHelper.CallLuaMethodRef(this.LuaScriptTable, funcName, ref ret, para1, para2, para3);
        }

        public void CallLuaMethodOut<TResult, T1, T2, T3>(string funcName, out TResult ret, T1 para1, T2 para2,
            T3 para3)
        {
            CSCallLuaHelper.CallLuaMethodOut(this.LuaScriptTable, funcName, out ret, para1, para2, para3);
        }

        #endregion
    }
}