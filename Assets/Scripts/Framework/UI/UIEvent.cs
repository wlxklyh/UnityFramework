using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Lua;
using Lua;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using XLua;


namespace Framework.UI
{
    public class UIEvent : MonoBehaviour,IPointerDownHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerUpHandler
    {
        [HideInInspector]
        public int EventID;
#if UNITY_EDITOR
        [ValueDropdown("GetAllUIEventID", IsUniqueList = true)]
        [OnValueChanged("OnValueChanged")]
        public string StrEventID;
        
        public void OnValueChanged()
        {
            LuaTable table = LuaManager.GetLuaFileTable(LuaManager.GetNewEditorLuaEvn(),"Form/UIEventID");
            var stringKeysEnum = table.GetKeys();
            int eventId = -1;
            table.Get(StrEventID, out eventId);
            EventID = eventId;
        }
        
        
        private static IEnumerable GetAllUIEventID()
        {
            LuaTable table = LuaManager.GetLuaFileTable(LuaManager.GetNewEditorLuaEvn(),"Form/UIEventID");
            var stringKeysEnum = table.GetKeys();
            return stringKeysEnum;
        }
#endif
    
        [NonSerialized]
        public LuaUIFormLogic luaUIFormLogic;
        public void OnPointerDown(PointerEventData eventData)
        {
            
        }

        public void OnPointerUp(PointerEventData eventData)
        {
           
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            luaUIFormLogic.DispatchEvent(EventID);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {

        }

        public void OnDrag(PointerEventData eventData)
        {
            
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            
        }

        public void OnDrop(PointerEventData eventData)
        {
            
        }

    }
}