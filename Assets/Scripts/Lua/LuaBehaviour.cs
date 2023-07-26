/*
 * Tencent is pleased to support the open source community by making xLua available.
 * Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
 * Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XLua;
using System;
using Assets.Scripts.Lua;
using Framework;
using Sirenix.OdinInspector;

namespace Assets.Scripts.Common.Lua
{
        
   

    [LuaCallCSharp]
    public class LuaBehaviour : MonoBehaviour
    {
        public LuaTableHandler luaTableHandler;

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
        }

        public void Start()
        {
            CallLuaMethod("Start");
        }

        public virtual void OnDestroy()
        {
            CallLuaMethod("OnDestroy");
            luaTableHandler.OnDestroy();
        }

        public void Update()
        {
            CallLuaMethod("Update");
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
