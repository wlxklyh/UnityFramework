#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class FrameworkLuaTableHandlerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Framework.LuaTableHandler);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 6, 5);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDestroy", _m_OnDestroy);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CallLuaMethod", _m_CallLuaMethod);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaScriptTable", _g_get_LuaScriptTable);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaFilePath", _g_get_LuaFilePath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaRealPath", _g_get_LuaRealPath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Members", _g_get_Members);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ArrMembers", _g_get_ArrMembers);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MemberDatas", _g_get_MemberDatas);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaScriptTable", _s_set_LuaScriptTable);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaRealPath", _s_set_LuaRealPath);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Members", _s_set_Members);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ArrMembers", _s_set_ArrMembers);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "MemberDatas", _s_set_MemberDatas);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new Framework.LuaTableHandler();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Framework.LuaTableHandler constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDestroy(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Framework.LuaTableHandler gen_to_be_invoked = (Framework.LuaTableHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDestroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CallLuaMethod(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Framework.LuaTableHandler gen_to_be_invoked = (Framework.LuaTableHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _funcName = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.CallLuaMethod( _funcName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaScriptTable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Framework.LuaTableHandler gen_to_be_invoked = (Framework.LuaTableHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaScriptTable);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaFilePath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Framework.LuaTableHandler gen_to_be_invoked = (Framework.LuaTableHandler)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.LuaFilePath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaRealPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Framework.LuaTableHandler gen_to_be_invoked = (Framework.LuaTableHandler)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.LuaRealPath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Members(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Framework.LuaTableHandler gen_to_be_invoked = (Framework.LuaTableHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Members);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ArrMembers(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Framework.LuaTableHandler gen_to_be_invoked = (Framework.LuaTableHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ArrMembers);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MemberDatas(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Framework.LuaTableHandler gen_to_be_invoked = (Framework.LuaTableHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.MemberDatas);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaScriptTable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Framework.LuaTableHandler gen_to_be_invoked = (Framework.LuaTableHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaScriptTable = (XLua.LuaTable)translator.GetObject(L, 2, typeof(XLua.LuaTable));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaRealPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Framework.LuaTableHandler gen_to_be_invoked = (Framework.LuaTableHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaRealPath = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Members(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Framework.LuaTableHandler gen_to_be_invoked = (Framework.LuaTableHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Members = (Framework.Member[])translator.GetObject(L, 2, typeof(Framework.Member[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ArrMembers(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Framework.LuaTableHandler gen_to_be_invoked = (Framework.LuaTableHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ArrMembers = (Framework.ArrMember[])translator.GetObject(L, 2, typeof(Framework.ArrMember[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MemberDatas(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Framework.LuaTableHandler gen_to_be_invoked = (Framework.LuaTableHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.MemberDatas = (Framework.MemberDatas)translator.GetObject(L, 2, typeof(Framework.MemberDatas));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
