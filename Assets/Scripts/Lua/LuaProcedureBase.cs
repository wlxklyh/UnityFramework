using Framework;
using GameFramework.Procedure;
using XLua;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;


namespace Lua
{
    public class LuaProcedureBase
    {
        public LuaTableHandler luaTableHandler;
        public LuaTable LuaScriptTable
        {
            get
            {
                return luaTableHandler.LuaScriptTable;
            }
        }
        // /// <summary>
        // /// 状态初始化时调用。
        // /// </summary>
        // /// <param name="procedureOwner">流程持有者。</param>
        // protected override void OnInit(ProcedureOwner procedureOwner)
        // {
        //     base.OnInit(procedureOwner);
        //     CSCallLuaHelper.CallLuaMethod(this.LuaScriptTable, "OnInit",procedureOwner);
        // }
        //
        // /// <summary>
        // /// 进入状态时调用。
        // /// </summary>
        // /// <param name="procedureOwner">流程持有者。</param>
        // protected override void OnEnter(ProcedureOwner procedureOwner)
        // {
        //     CSCallLuaHelper.CallLuaMethod(this.LuaScriptTable, "OnEnter",procedureOwner);
        // }
        //
        // /// <summary>
        // /// 状态轮询时调用。
        // /// </summary>
        // /// <param name="procedureOwner">流程持有者。</param>
        // /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        // /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        // protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        // {
        //     base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        //     CSCallLuaHelper.CallLuaMethod(this.LuaScriptTable, "OnUpdate",procedureOwner,elapseSeconds,realElapseSeconds);
        // }
        //
        // /// <summary>
        // /// 离开状态时调用。
        // /// </summary>
        // /// <param name="procedureOwner">流程持有者。</param>
        // /// <param name="isShutdown">是否是关闭状态机时触发。</param>
        // protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        // {
        //     base.OnLeave(procedureOwner, isShutdown);
        //     CSCallLuaHelper.CallLuaMethod(this.LuaScriptTable, "OnLeave",procedureOwner,isShutdown);
        // }
        //
        // /// <summary>
        // /// 状态销毁时调用。
        // /// </summary>
        // /// <param name="procedureOwner">流程持有者。</param>
        // protected override void OnDestroy(ProcedureOwner procedureOwner)
        // {
        //     base.OnDestroy(procedureOwner);
        //     CSCallLuaHelper.CallLuaMethod(this.LuaScriptTable, "OnDestroy",procedureOwner);
        // }
    }
}