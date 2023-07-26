using System.Collections.Generic;
using UnityGameFramework.Runtime;
using XLua;

namespace Framework.UI
{
    [CSharpCallLua]
    public delegate void OnUIEventCallback();
    
    public class UIEventDispatcher
    {
        public Dictionary<int, OnUIEventCallback> EventIDCallbackMap = new Dictionary<int, OnUIEventCallback>();

        public void ResisterUIEvent(int eventID, OnUIEventCallback callback)
        {
            OnUIEventCallback old_callback = null;
            if (EventIDCallbackMap.TryGetValue(eventID, out old_callback) && old_callback != null)
            {
                Log.Error("Error!! ");
                return;
            }
            this.EventIDCallbackMap[eventID] = callback;
        }

        public void DispatchEvent(int eventID)
        {
            OnUIEventCallback callback = null;
            if (EventIDCallbackMap.TryGetValue(eventID, out callback) && callback != null)
            {
                callback();
            } 
        }
    }
}