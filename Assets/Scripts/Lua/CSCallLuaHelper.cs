using System;
using System.Collections.Generic;
using Assets.Scripts.Lua;
using XLua;

namespace Framework
{
    public class CSCallLuaHelper
    {
        public static Dictionary<string,LuaTable> dictStr2Table = new Dictionary<string, LuaTable>();
        public static Dictionary<string,string> dictStr2TableName = new Dictionary<string, string>();
        public static Dictionary<string,string> dictStr2FunName = new Dictionary<string, string>();
        #region 调用Lua函数 无返回值
        public static LuaFunction GetLuaMethod(LuaTable LuaScriptTable ,string funcName)
        {
            LuaFunction func = null;
            
            if (LuaScriptTable == null)
            {
                return null;
            }
        
            try
            {
                func = LuaScriptTable.Get<LuaFunction>(funcName);
            }
            catch (Exception e)
            {
                return null;
            }
        
            return func;
        }

        public static bool ParserArg(ref string globalTableNameAndFuncName,out string globalTableName,out string functionName,out LuaTable LuaScriptTable)
        {
            globalTableName = null;
            functionName = null;
            LuaScriptTable = null;
            //字符串检查
            if (string.IsNullOrEmpty(globalTableNameAndFuncName))
            {
                return false;
            }
            
            if (dictStr2TableName.TryGetValue(globalTableNameAndFuncName, out globalTableName)==false || 
                dictStr2FunName.TryGetValue(globalTableNameAndFuncName, out functionName)==false)
            {
                //字符串格式检查
                string[] strspilt = globalTableNameAndFuncName.Split(':');
                if (strspilt == null || strspilt.Length != 2)
                {
                    return false;
                }
                //表名和函数名检查
                globalTableName = strspilt[0];
                functionName = strspilt[1];
                if (string.IsNullOrEmpty(globalTableName) || string.IsNullOrEmpty(functionName))
                {
                    return false;
                }
                
                dictStr2TableName[globalTableNameAndFuncName] = globalTableName;
                dictStr2FunName[globalTableNameAndFuncName] = functionName;
            }


            if (dictStr2Table.TryGetValue(globalTableNameAndFuncName, out LuaScriptTable) == false )
            {
                //找不到表
                LuaEnv luaEnv = LuaManager.GetInst().MainEnv;
                LuaScriptTable = luaEnv.Global.Get<LuaTable>(globalTableName);
                if (LuaScriptTable == null)
                {
                    return false;
                }
                dictStr2Table[globalTableNameAndFuncName] = LuaScriptTable;
            }

            
            
            return true;
        }
        
        public static void CallLuaMethod(string globalTableNameAndFuncName)
        {
            string globalTableName, functionName;
            LuaTable LuaScriptTable;
            if (false == ParserArg(ref globalTableNameAndFuncName, out globalTableName, out functionName,out LuaScriptTable))
            {
                return;
            }
            CallLuaMethod(LuaScriptTable,functionName);
        }

        public static void CallLuaMethod(LuaTable LuaScriptTable ,string funcName)
        {
            LuaFunction func = GetLuaMethod(LuaScriptTable ,funcName);
            if (func == null)
            {
                return;
            }

            func.Action(LuaScriptTable);
        }

        public static void CallLuaMethod<T1>(string globalTableNameAndFuncName,T1 para1)
        {
            string globalTableName, functionName;
            LuaTable LuaScriptTable;
            if (false == ParserArg(ref globalTableNameAndFuncName, out globalTableName, out functionName,out LuaScriptTable))
            {
                return;
            }
            CallLuaMethod(LuaScriptTable,functionName,para1);
        }
        
        public static void CallLuaMethod<T1>(LuaTable LuaScriptTable ,string funcName, T1 para1)
        {
            LuaFunction func = GetLuaMethod(LuaScriptTable ,funcName);
            if (func == null)
            {
                return;
            }

            func.Action(LuaScriptTable, para1);
        }

        public static void CallLuaMethod<T1, T2>(string globalTableNameAndFuncName, T1 para1, T2 para2)
        {
            string globalTableName, functionName;
            LuaTable LuaScriptTable;
            if (false == ParserArg(ref globalTableNameAndFuncName, out globalTableName, out functionName,out LuaScriptTable))
            {
                return;
            }
            CallLuaMethod(LuaScriptTable,functionName,para1,para2);
        }
        
        public static void CallLuaMethod<T1, T2>(LuaTable LuaScriptTable ,string funcName, T1 para1, T2 para2)
        {
            LuaFunction func = GetLuaMethod(LuaScriptTable ,funcName);
            if (func == null)
            {
                return;
            }

            func.Action(LuaScriptTable, para1, para2);
        }

        public static void CallLuaMethod<T1, T2, T3>(string globalTableNameAndFuncName, T1 para1, T2 para2, T3 para3)
        {
            string globalTableName, functionName;
            LuaTable LuaScriptTable;
            if (false == ParserArg(ref globalTableNameAndFuncName, out globalTableName, out functionName,out LuaScriptTable))
            {
                return;
            }
            CallLuaMethod(LuaScriptTable,functionName,para1,para2,para3);
        }
        
        public static void CallLuaMethod<T1, T2, T3>(LuaTable LuaScriptTable ,string funcName, T1 para1, T2 para2, T3 para3)
        {
            LuaFunction func = GetLuaMethod(LuaScriptTable ,funcName);
            if (func == null)
            {
                return;
            }

            func.Action(LuaScriptTable, para1, para2, para3);
        }
        
        public static void CallLuaMethod<T1, T2, T3, T4>(string globalTableNameAndFuncName, T1 para1, T2 para2, T3 para3, T4 para4)
        {
            string globalTableName, functionName;
            LuaTable LuaScriptTable;
            if (false == ParserArg(ref globalTableNameAndFuncName, out globalTableName, out functionName,out LuaScriptTable))
            {
                return;
            }
            CallLuaMethod(LuaScriptTable,functionName,para1,para2,para3,para4);
        }
        
        public static void CallLuaMethod<T1, T2, T3, T4>(LuaTable LuaScriptTable ,string funcName, T1 para1, T2 para2, T3 para3, T4 para4)
        {
            LuaFunction func = GetLuaMethod(LuaScriptTable ,funcName);
            if (func == null)
            {
                return;
            }

            func.Action(LuaScriptTable, para1, para2, para3, para4);
        }

        #endregion

        #region 调用Lua函数 有返回值 Ref和Out区别 ：找不到函数时候Out会在函数内部赋值默认值 Ref则保持外部调用的初始化值  建议Ref外部初始化！！！！！！！
    
        public static void CallLuaMethodRef<TResult>(string globalTableNameAndFuncName, ref TResult ret)
        {
            string globalTableName, functionName;
            LuaTable LuaScriptTable;
            if (false == ParserArg(ref globalTableNameAndFuncName, out globalTableName, out functionName,out LuaScriptTable))
            {
                return;
            }
            CallLuaMethodRef(LuaScriptTable,functionName,ref ret);
        }
        
        public static void CallLuaMethodRef<TResult>(LuaTable LuaScriptTable ,string funcName, ref TResult ret)
        {
            LuaFunction func = GetLuaMethod(LuaScriptTable ,funcName);
            if (func == null)
            {
                return;
            }

            ret = func.Func<LuaTable, TResult>(LuaScriptTable);
        }
    
        public static void CallLuaMethodOut<TResult>(LuaTable LuaScriptTable ,string funcName, out TResult ret)
        {
            LuaFunction func = GetLuaMethod(LuaScriptTable ,funcName);
            if (func == null)
            {
                ret = default(TResult);
                return;
            }

            ret = func.Func<LuaTable, TResult>(LuaScriptTable);
        }

        public static void CallLuaMethodRef<TResult,T1>(string globalTableNameAndFuncName, ref TResult ret, T1 para1)
        {
            string globalTableName, functionName;
            LuaTable LuaScriptTable;
            if (false == ParserArg(ref globalTableNameAndFuncName, out globalTableName, out functionName,out LuaScriptTable))
            {
                return;
            }
            CallLuaMethodRef(LuaScriptTable,functionName,ref ret,para1);
        }
        
        public static void CallLuaMethodRef<TResult, T1>(LuaTable LuaScriptTable ,string funcName, ref TResult ret, T1 para1)
        {
            LuaFunction func = GetLuaMethod(LuaScriptTable ,funcName);
            if (func == null)
            {
                return;
            }

            ret = func.Func<LuaTable, T1, TResult>(LuaScriptTable, para1);
        }
        
        public static void CallLuaStaticMethodRef<TResult, T1>(LuaTable LuaScriptTable ,string funcName, ref TResult ret, T1 para1)
        {
            LuaFunction func = GetLuaMethod(LuaScriptTable ,funcName);
            if (func == null)
            {
                return;
            }

            ret = func.Func< T1, TResult>(para1);
        }
    
        public static void CallLuaMethodOut<TResult, T1>(LuaTable LuaScriptTable ,string funcName, out TResult ret, T1 para1)
        {
            LuaFunction func = GetLuaMethod(LuaScriptTable ,funcName);
            if (func == null)
            {
                ret = default(TResult);
                return;
            }

            ret = func.Func<LuaTable, T1, TResult>(LuaScriptTable, para1);
        }

        public static void CallLuaMethodRef<TResult,T1,T2>(string globalTableNameAndFuncName, ref TResult ret, T1 para1, T2 para2)
        {
            string globalTableName, functionName;
            LuaTable LuaScriptTable;
            if (false == ParserArg(ref globalTableNameAndFuncName, out globalTableName, out functionName,out LuaScriptTable))
            {
                return;
            }
            CallLuaMethodRef(LuaScriptTable,functionName,ref ret,para1,para2);
        }
        
        public static void CallLuaMethodRef<TResult, T1, T2>(LuaTable LuaScriptTable ,string funcName, ref TResult ret, T1 para1, T2 para2)
        {
            LuaFunction func = GetLuaMethod(LuaScriptTable ,funcName);
            if (func == null)
            {
                return;
            }

            ret = func.Func<LuaTable, T1, T2, TResult>(LuaScriptTable, para1, para2);
        }

        public static void CallLuaMethodOut<TResult, T1, T2>(LuaTable LuaScriptTable ,string funcName, out TResult ret, T1 para1, T2 para2)
        {
            LuaFunction func = GetLuaMethod(LuaScriptTable ,funcName);
            if (func == null)
            {
                ret = default(TResult);
                return;
            }

            ret = func.Func<LuaTable, T1, T2, TResult>(LuaScriptTable, para1, para2);
        }

        public static void CallLuaMethodRef<TResult,T1,T2,T3>(string globalTableNameAndFuncName, ref TResult ret, T1 para1, T2 para2, T3 para3)
        {
            string globalTableName, functionName;
            LuaTable LuaScriptTable;
            if (false == ParserArg(ref globalTableNameAndFuncName, out globalTableName, out functionName,out LuaScriptTable))
            {
                return;
            }
            CallLuaMethodRef(LuaScriptTable,functionName,ref ret,para1,para2,para3);
        }
        
        public static void CallLuaMethodRef<TResult, T1, T2, T3>(LuaTable LuaScriptTable ,string funcName, ref TResult ret, T1 para1, T2 para2, T3 para3)
        {
            LuaFunction func = GetLuaMethod(LuaScriptTable ,funcName);
            if (func == null)
            {
                return;
            }

            ret = func.Func<LuaTable, T1, T2, T3, TResult>(LuaScriptTable, para1, para2, para3);
        }
    
        public static void CallLuaMethodOut<TResult, T1, T2, T3>(LuaTable LuaScriptTable ,string funcName, out TResult ret, T1 para1, T2 para2, T3 para3)
        {
            LuaFunction func = GetLuaMethod(LuaScriptTable ,funcName);
            if (func == null)
            {
                ret = default(TResult);
                return;
            }

            ret = func.Func<LuaTable, T1, T2, T3, TResult>(LuaScriptTable, para1, para2, para3);
        }

        #endregion

    }
}