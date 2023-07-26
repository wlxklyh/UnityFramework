using System;
using XLua;

[LuaCallCSharp]
public class HSingletonObject<T> where T : class
{
    private static T m_Singleton;
    private static object lockHelper = new object();

    protected HSingletonObject()
    {
    }

    public static T GetInstance()
    {
        if (m_Singleton == null)
        {
            lock (lockHelper)
            {
                if (m_Singleton == null)
                {
                    m_Singleton = (T)Activator.CreateInstance(typeof(T));
                }
            }
        }
        return m_Singleton;
    }
    public static T GetInst()
    {
        return GetInstance();
    }

    public static void DeleteInst()
    {
        m_Singleton = null;
    }
}