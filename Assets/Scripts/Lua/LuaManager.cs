#define USE_GWGO_NATIVE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Common;
using Framework;
using UnityEngine;
using UnityEngine.UIElements;
using UnityGameFramework.Runtime;
using XLua;



namespace Assets.Scripts.Lua
{
    using UnityEngine;
    using XLua;

#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
    using LuaAPI = XLua.LuaDLL.Lua;
    using RealStatePtr = System.IntPtr;
    using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

    public class LuaManager : HSingletonObject<LuaManager>
    {
        private LuaEnv mainLuaEnv = null;
        
        private LuaTable gameMainTable = null;
        
        private LuaFuncTableDoubleDoubleReturnVoid funcMainUpdate = null;
        public LuaEnv MainEnv
        {
            get
            {
                return this.mainLuaEnv;
            }
            set
            {
                // editor测试
                this.mainLuaEnv = value;
            }
        }

      
        public void InitLuaCore()
        {
            this.mainLuaEnv = new LuaEnv();
            this.mainLuaEnv.AddLoader(LoadLuaFile);
            InitLuaMacro(this.mainLuaEnv);
            InitMain();
        }
        
        public static LuaEnv GetNewEditorLuaEvn()
        {
            LuaEnv EditorLuaEvn = new LuaEnv();
            EditorLuaEvn.AddLoader(LoadLuaFile);
            return EditorLuaEvn;
        }

        private void InitMain()
        {
            try
            {
                this.mainLuaEnv.DoString("require 'main'");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            this.gameMainTable = this.mainLuaEnv.Global.Get<LuaTable>("GameMain");
            
            this.funcMainUpdate = this.mainLuaEnv.Global.GetInPath<LuaFuncTableDoubleDoubleReturnVoid>("GameMain.Update");

            LuaFuncTableReturnVoid initFunc = this.gameMainTable.GetInPath<LuaFuncTableReturnVoid>("Init");
            if (initFunc != null)
            {
                try
                {
                    initFunc(this.gameMainTable);
                }
                catch (Exception exception)
                {
                    Log.Error("Lua", exception);
                }
            }
        }





        public void Start()
        {
            if (this.gameMainTable != null)
            {
                this.mainLuaEnv.DoString("GameMain:Start()");
            }
        }

        public static void InitLuaMacro(LuaEnv luaEnv)
        {
            // 设置Lua中的环境变量
#if THREAD_SAFE
            luaEnv.Global.Set("THREAD_SAFE", 1);
#endif

#if HOTFIX_ENABLE
            luaEnv.Global.Set("HOTFIX_ENABLE", 1);
#endif

#if UNITY_EDITOR
            luaEnv.Global.Set("UNITY_EDITOR", 1);
#endif

#if UNITY_EDITOR_WIN
            luaEnv.Global.Set("UNITY_EDITOR_WIN", 1);
#endif

#if UNITY_EDITOR_OSX
            luaEnv.Global.Set("UNITY_EDITOR_OSX", 1);
#endif

#if UNITY_STANDALONE_OSX
            luaEnv.Global.Set("UNITY_STANDALONE_OSX", 1);
#endif

#if UNITY_STANDALONE_WIN
            luaEnv.Global.Set("UNITY_STANDALONE_WIN", 1);
#endif

#if UNITY_STANDALONE_LINUX
            luaEnv.Global.Set("UNITY_STANDALONE_LINUX", 1);
#endif

#if UNITY_STANDALONE
            luaEnv.Global.Set("UNITY_STANDALONE", 1);
#endif

#if UNITY_IOS
            luaEnv.Global.Set("UNITY_IOS", 1);
#endif

#if UNITY_IPHONE
            luaEnv.Global.Set("UNITY_IPHONE", 1);
#endif

#if UNITY_ANDROID
            luaEnv.Global.Set("UNITY_ANDROID", 1);
#endif

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            luaEnv.Global.Set("UNITY_WIN", 1);
#endif

#if PUBLISH_BUILD
            luaEnv.Global.Set("PUBLISH_BUILD", 1);
#endif

#if PERFORMANCE_BUILD
            luaEnv.Global.Set("PERFORMANCE_BUILD", 1);
#endif

#if PROFILE_TICKER
            luaEnv.Global.Set("PROFILE_TICKER", 1);
#endif

#if NO_CMD_FORM
             luaEnv.Global.Set("NO_CMD_FORM", 1);
#endif
        }

 
        public static byte[] LoadLuaFile(ref string fileName)
        {
            byte[] byData = LoadLuaFileInternal(ref fileName);
            return byData;
        }

        private static byte[] LoadLuaFileInternal(ref string fileName)
        {
            string strFmtFileName = fileName.Replace('.', '/');
#if LOAD_FROM_ASSET_BUNDLE || UNITY_EDITOR_DEBUG_BUNDLE || SIMPLE_GAME_BUILD
            // simple build   resource/luabytes
            // 如果从bundle中读取，不能是.lua后缀，.lua后缀的文件无法打进bundle内
            strFmtFileName = "LuaBytes/" + strFmtFileName + ".lua.bytes";
#else
            strFmtFileName =  strFmtFileName + ".lua";
#endif

            string localFilePath = Application.dataPath + HPathDef.LuaFolderPath + strFmtFileName;
            if (HFileHelper.IsFileExist(localFilePath))
            {
                return HFileHelper.ReadFile(localFilePath);
            }

            return null;
        }

        public void DoUpdate()
        {
            if (this.funcMainUpdate != null)
            {
                this.funcMainUpdate(this.gameMainTable, (double)Time.time, (double)Time.deltaTime);
            }
        }
		
        
        public static void InitLuaFile<T>(string luaFile, T csObj, out LuaTable luaScriptTable)
        {
            try
            {
                luaScriptTable = null;
                if (String.IsNullOrEmpty(luaFile))
                {
                    return;
                }

                string luaFileTrimmed = luaFile.Trim();
                if (String.IsNullOrEmpty(luaFileTrimmed))
                {
                    return;
                }

                // lua table
                luaScriptTable = LuaManager.CreateLuaTable( luaFileTrimmed, csObj);
                if (luaScriptTable == null)
                {
                    return;
                }
            }
            finally
            {
                
            }
        }
        
        public static LuaTable CreateLuaTable<T>(string luaTableFile,T csObj)
        {
            LuaEnv luaEnv = LuaManager.GetInstance().MainEnv;
            if (luaEnv == null)
            {
                return null;
            }
            try
            {
                // 表作为meta表 
                using (LuaTable metaTable = GetLuaFileTable(luaEnv,luaTableFile))
                {
                    if (metaTable == null)
                    {
                
                        return null;
                    }

                    LuaTable retLuaTable = null;
                    CSCallLuaHelper.CallLuaStaticMethodRef(metaTable, "New", ref retLuaTable,csObj);
                    return retLuaTable;
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
       
            return null;
        }
        
        
        public static LuaTable GetLuaFileTable(LuaEnv luaEnv, string luaFile)
        {
            LuaTable luaTable = null;
            try
            {
                LuaTable metatable = null;
                object[] ret = luaEnv.DoString(string.Format("return require \"{0}\"", luaFile));
                if (null != ret && ret.Length > 0)
                {
                    metatable = ret[0] as LuaTable;
                    return metatable;
                }
            }
            catch (Exception e)
            {
                
            }
            
            return luaTable;
        }
    }
}
