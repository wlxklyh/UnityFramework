using System;
using System.IO;
using UnityGameFramework.Runtime;

namespace Assets.Scripts.Common
{
    public class HFileHelper
    {
        public static bool IsFileExist(string filePath)
        {
            return File.Exists(filePath);
        }
        
        public static string LuaFileNameWithoutExtension(string luaFile)
        {
            if (String.IsNullOrEmpty(luaFile))
            {
                return "";
            }

            int lastDot = luaFile.LastIndexOf(".");
            if (lastDot >= 0)
            {
                return luaFile.Substring(lastDot + 1);
            }
            return luaFile;
        }
        
        public static byte[] ReadFile(string filePath)
        {
            if (!IsFileExist(filePath))
            {
                return null;
            }

            byte[] data = null;
            int tryCount = 0;

            while (true)
            {
                try
                {
                    data = File.ReadAllBytes(filePath);
                }
                catch (Exception ex)
                {
                    Log.Debug("Read File " + filePath + " Error! Exception = " + ex.ToString() + ", TryCount = " + tryCount);
                    data = null;
                }

                if (data == null || data.Length <= 0)
                {
                    tryCount++;

                    if (tryCount >= 3)
                    {
                        Log.Debug("Read File " + filePath + " Fail!, TryCount = " + tryCount);
                        return null;
                    }
                }
                else
                {
                    return data;
                }
            }
        }
    }
}