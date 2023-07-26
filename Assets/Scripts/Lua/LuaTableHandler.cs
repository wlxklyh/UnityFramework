using System;
using Assets.Scripts.Lua;
using Sirenix.OdinInspector;
using XLua;


namespace Framework
{
    [System.Serializable]
    public class Member
    {
        public string name;
        public UnityEngine.Object value;
    }
    
    [System.Serializable]
    public class ArrMember
    {
        public string name;
        public UnityEngine.Object[] value;
    }
    
    [System.Serializable]
    public class MemberStringData
    {
        public string  Name;
        public string Value;
    }

    [System.Serializable]
    public class MemberIntData
    {
        public string Name;
        public int Value;
    }


    [System.Serializable]
    public class MemberFloatData
    {
        public string Name;
        public float Value;
    }

    [System.Serializable]
    public class MemberDatas
    {
        public MemberStringData [] StringDatas;
        public MemberIntData [] IntDatas;
        public MemberFloatData [] FloatDatas;
    }

    [LuaCallCSharp]
    [Serializable]
    public class LuaTableHandler
    {
    
        public LuaTable LuaScriptTable 
        {
            get
            {
                return this.luaTable;
            }
            set
            {
                this.luaTable = value;
            }
        }
        private LuaTable luaTable;


        [FilePath(ParentFolder = "Assets/LuaScripts")]
        public string LuaRealPath;
        
        public string LuaFilePath
        {
            get
            {
                if (LuaRealPath != null)
                {
                    string strPath = LuaRealPath.Replace('/', '.');
                    strPath = strPath.Replace('\\', '.');
                    strPath = strPath.Replace(".lua", "");
                    return strPath;
                }
                return null;
            }
        }
        
        public Member[] Members;
        public ArrMember[] ArrMembers;
        public MemberDatas MemberDatas;
        
        private static void ExportArrMembers(ArrMember[] arrMembers, LuaTable luaScriptTable)
        {
            if (arrMembers != null && luaScriptTable != null)
            {
                foreach (var member in arrMembers)
                {                    
                    var value = member.value;
                    if (value != null && value.Length > 0)
                    {
                        luaScriptTable.Set(member.name, value);
                    } 
                }
            }
        }

        private static void ExportMembers(Member[] members, LuaTable luaScriptTable)
        {
            if (members != null && luaScriptTable != null)
            {
                foreach (var member in members)
                {
                    var value = member.value;
                    luaScriptTable.Set(member.name, value);
                }
            }
        }
        private static void ExportMemberDatas(MemberDatas datas, LuaTable luaScriptTable)
        {
            if (luaScriptTable == null || datas == null)
            {
                return;
            }

            var memberStringDatas = datas.StringDatas;
            if (memberStringDatas != null)
            {
                foreach (var member in memberStringDatas)
                {
                    var value = member.Value;
                    if (value != null)
                    {
                        luaScriptTable.Set(member.Name, value);
                    }
                }
            }

            var memberIntData = datas.IntDatas;
            if (memberIntData != null)
            {
                foreach (var member in memberIntData)
                {
                    luaScriptTable.Set(member.Name, member.Value);
                }
            }

            var memberFloatData = datas.FloatDatas;
            if (memberFloatData != null)
            {
                foreach (var member in memberFloatData)
                {
                    luaScriptTable.Set(member.Name, member.Value);
                }
            }
        }


       
        
        // ReSharper disable Unity.PerformanceAnalysis
        public void OnInit<T>( T csObj)
        {
            LuaManager.InitLuaFile(LuaFilePath, csObj,out this.luaTable);
            ExportArrMembers(ArrMembers, luaTable);
            ExportMembers(Members, luaTable);
            ExportMemberDatas(MemberDatas, luaTable);
        }
        
        // 用了析构可能不够及时
        ~LuaTableHandler()
        {
            OnDestroy();
        }
        
        
        
        public void OnDestroy()
        {
            this.DisposeLuaRes();
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


        protected virtual void DisposeLuaRes()
        {
            if (this.LuaScriptTable != null)
            {
                this.LuaScriptTable.Dispose();
                this.LuaScriptTable = null;
            }
        }
        
       
    }
}
