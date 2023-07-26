using System;
using Assets.Scripts.Lua;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Lua
{
    public class LuaGFComponent:GameFrameworkComponent
    {
        protected override void Awake()
        {
            LuaManager.GetInst().InitLuaCore();
        }

        public void Update()
        {
            LuaManager.GetInst().DoUpdate();
        }
    }
}