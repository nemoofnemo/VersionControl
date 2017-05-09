using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// FileSystem 的摘要说明
/// </summary>
public class FileSystem
{
    public FileSystem()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static bool CreateFolder(string path)
    {

        return true;
    }

    public static bool Remove(string path)
    {

        return true;
    }

    public static bool CreateFile(string path)
    {

        return true;
    }

    public static bool IsFolder(string path)
    {

        return true;
    }

    public static bool IsFile(string path)
    {

        return true;
    }

    public static bool GetFileList(string path, ref List<string> list)
    {

        return true;
    }

    public static bool ReadFile(string path, out byte[] arr)
    {
        arr = new byte[10];
        return true;
    }

    public static bool Copy(string src, string dest)
    {

        return true;
    }
}