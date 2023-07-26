using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Lua
{
    using System.Runtime.InteropServices;
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




    [CSharpCallLua]
    public delegate void LuaFuncReturnVoid();     // no param

    [CSharpCallLua]
    public delegate void LuaFuncObjectReturnVoid(object obj);     // no param return void

    [CSharpCallLua]
    public delegate void LuaFuncGameObjectReturnVoid(GameObject gameObject);     // gameobject param; returen void

    [CSharpCallLua]
    public delegate bool LuaFuncLuaTableGameObjectReturnBool(LuaTable t, GameObject gameObject);   

    [CSharpCallLua]
	public delegate void LuaFuncBoolReturnVoid(bool boolParam);   

    [CSharpCallLua]
    public delegate void LuaFuncIntReturnVoid(int param1);     // int param

    [CSharpCallLua]
    public delegate void LuaFuncStringReturnVoid(string param1);     // string param

    [CSharpCallLua]
    public delegate void LuaFuncDoubleReturnVoid(double param1);     // double param

    [CSharpCallLua]
    public delegate void LuaFuncFloatReturnVoid(float param1);     // float param

    [CSharpCallLua]
    public delegate void LuaFuncTableReturnVoid(LuaTable t);     // Table return void

    [CSharpCallLua]
    public delegate void LuaFuncTableFloatReturnVoid(LuaTable t, float para1);     // Table return void

    [CSharpCallLua]
    public delegate void LuaFuncTableFloatFloatBoolReturnVoid(LuaTable t, float para1, float para2, bool para3);     // Table return void


    [CSharpCallLua]
    public delegate void LuaFuncMoreObjectReturnVoid(params object[] para1);     // Objects return void

    [CSharpCallLua]
    public delegate void LuaFuncTableMoreObjectReturnVoid(LuaTable t,params object[] para1);     // Table Objects return void

    [CSharpCallLua]
    public delegate void LuaFuncTableObjectReturnVoid(LuaTable t, object para1);     // Table Object return void

    [CSharpCallLua]
    public delegate void LuaFuncTableIntReturnVoid(LuaTable t, int para1);     // Table Int return void
    
    [CSharpCallLua]
    public delegate int LuaFuncTableIntStrReturnInt(LuaTable t, int para1,string para2);     // Table Int string return int

    [CSharpCallLua]
    public delegate void LuaFuncTableStringReturnVoid(LuaTable t, string para1);     // Table string return void

    [CSharpCallLua]
    public delegate void LuaFuncTableUlongReturnVoid(LuaTable t, ulong para1);     // Table ulong return void


    [CSharpCallLua]
    public delegate void LuaFuncTableDoubleReturnVoid(LuaTable t, double param);    // Table, double return void

    [CSharpCallLua]
    public delegate void LuaFuncTableDoubleDoubleReturnVoid(LuaTable t, double param, double param2);    // Table, double return void

    [CSharpCallLua]
    public delegate void LuaFuncTableBoolReturnVoid(LuaTable t, bool para);    // Table, bool return void
    
    [CSharpCallLua]
    public delegate void LuaFuncTableStringIntIntReturnVoid(LuaTable t, string param1, int param2, int param3);    // Table, bool return void

    [CSharpCallLua]
    public delegate void LuaFuncTable2ObjectReturnVoid(LuaTable t, object para1, object para2);
    
    [CSharpCallLua]
    public delegate void LuaFuncTable3ObjectReturnVoid(LuaTable t, object param1, object param2, object param3);
    
    #region return bool

    // cs call lua function delegate declare
    [CSharpCallLua]
    public delegate bool LuaFuncReturnBool();     // no param

    // cs call lua function delegate declare
    [CSharpCallLua]
    public delegate object LuaFuncReturnObject();     // no param
    [CSharpCallLua]
    public delegate object LuaFuncTableMoreObjectReturnObject(LuaTable t,params object[] para1); 
    [CSharpCallLua]
    public delegate object LuaFuncMoreObjectReturnObject(params object[] para1); 

    [CSharpCallLua]
    public delegate bool LuaFuncIntReturnBool(LuaTable t, int para); // param int return bool
    [CSharpCallLua]
    public delegate bool LuaFuncTableUlongReturnBool(LuaTable t, ulong para1);     //table ulong return bool

    [CSharpCallLua]
    public delegate bool LuaFuncTableStringReturnBool(LuaTable t, string para1);     //table string return bool

    [CSharpCallLua]
    public delegate bool LuaFuncTableReturnBool(LuaTable t);     // Table return  bool

    [CSharpCallLua]
    public delegate bool LuaFuncTableObjectReturnBool(LuaTable t, object para1);     // Table Object return bool     
    
    [CSharpCallLua]
    public delegate LuaTable LuaFuncTableObjectReturnTable(LuaTable t, object para1);     // Table Object return LuaTable

    [CSharpCallLua]
    public delegate bool LuaFuncTableDoubleReturnBool(LuaTable t, double param);    // Table, double

    [CSharpCallLua]
    public delegate bool LuaFuncTableUintReturnBool(LuaTable t, uint param);    // Table, uint, return bool

    [CSharpCallLua]
    public delegate bool LuaFuncTableStringBoolReturnBool(LuaTable t, string para1, bool para2);     // Table, string, bool return bool

    [CSharpCallLua]
    public delegate bool LuaFuncStringReturnBool(string para1);

    [CSharpCallLua]
    public delegate bool LuaFuncIntStringReturnBool(LuaTable t, int param1, string param2);
    
    [CSharpCallLua]
    public delegate bool LuaFuncMoreObjectReturnBool(params object[] para1);     // Objects return bool

    [CSharpCallLua]
    public delegate bool LuaFuncTableMoreObjectReturnBool(LuaTable t, params object[] para1);     // Table Objects return bool
    
    [CSharpCallLua]
    public delegate List<Int64> LuaFuncReturnListUlong(LuaTable t); // param none return List<ulong>
    #endregion

    #region return int
    [CSharpCallLua]
    public delegate bool LuaFuncReturnInt();     // no param
    
    [CSharpCallLua]
    public delegate int LuaFuncTableObjectReturnInt(LuaTable t, object para);
    
    [CSharpCallLua]
    public delegate int LuaFuncTable2ObjectReturnInt(LuaTable t, object para1, object para2);
    
    [CSharpCallLua]
    public delegate int LuaFuncLuaTableReturnInt(LuaTable t);
    
    [CSharpCallLua]
    public delegate int LuaFuncMoreObjectReturnInt(params object[] para1);     // Objects return int

    [CSharpCallLua]
    public delegate int LuaFuncTableMoreObjectReturnInt(LuaTable t,params object[] para1);     // Table Objects return int

    [CSharpCallLua]
    public delegate long LuaFuncMoreObjectReturnLong(params object[] para1);     // Objects return long
    [CSharpCallLua]
    public delegate long LuaFuncTableMoreObjectReturnLong(LuaTable t,params object[] para1);     // Table Objects return long
    #endregion

    #region return string
    [CSharpCallLua]
    public delegate string LuaFuncReturnString();     // no param
    
    [CSharpCallLua]
    public delegate string LuaFuncTableObjectReturnString(LuaTable t, object para1);
    
    [CSharpCallLua]
    public delegate string LuaFuncMoreObjectReturnString(params object[] para1);     // Objects return string

    [CSharpCallLua]
    public delegate string LuaFuncTableMoreObjectReturnString(LuaTable t,params object[] para1);     // Table Objects return string
    
    #endregion
    
    [CSharpCallLua]
    public delegate LuaTable LuaFuncTableReturnTable(LuaTable t);


    [CSharpCallLua]
    public delegate void LuaPushErrorCodeMsgFunc(LuaTable t, uint msgId, uint errorCode);

    [CSharpCallLua]
    public delegate int LuaFuncProtocolHandle(LuaTable t, byte[] param1, int param2, int param3, int param4);

    [CSharpCallLua]
    public delegate bool LuaFuncTableObjectObjectObjectReturnBool(LuaTable t, object para1, object para2, object para3);     
    
    [CSharpCallLua]
    public delegate void LuaFunBoolStrReturnBool(bool arg1, string arg2);

}
