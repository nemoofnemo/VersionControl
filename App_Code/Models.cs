using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Class1 的摘要说明
/// </summary>
public class Models
{
    public Models()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
}

public class User
{
    public int user_id;
    public string user_name;
    public string user_account;
    public string user_password;
    public string register_time;
    public string user_description;
    public int user_type;
}

public class Warehouse
{
    public int warehouse_id;
    public int user_id;
    public int organization_id;
    public int warehouse_type;
    public string create_time;
    public string warehouse_description;
    public int master_version_id;
    public string warehouse_name;
}

public class Version
{
    public int version_id;
    public int warehouse_id;
    public int user_id;
    public int prev_id;
    public int next_id;
    public string timestamp;
    public string version_name;
    public string description;
}

public class Branch
{
    public int branch_id;
    public int warehouse_id;
    public int user_id;
    public int start_id;
    public int end_id;
    public string timestamp;
    public string branch_name;
    public string description;
}