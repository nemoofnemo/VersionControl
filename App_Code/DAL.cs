using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

/// <summary>
/// DAL 的摘要说明
/// </summary>
public class DAL
{
    public DAL()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
}

public class UserDAL
{
    private SqlDatabase sqlServerDB;

    public UserDAL()
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        sqlServerDB = factory.CreateDefault() as SqlDatabase;
    }

    public bool LoginCheck(ref User u)
    {
        IDataReader reader;
        DbCommand cmd;
        cmd = sqlServerDB.GetSqlStringCommand("select * from user_table where user_account=@ACCOUNT and user_password=@PASSWORD");
        sqlServerDB.AddInParameter(cmd, "@ACCOUNT", DbType.String, u.user_account);
        sqlServerDB.AddInParameter(cmd, "@PASSWORD", DbType.String, u.user_password);
        reader = sqlServerDB.ExecuteReader(cmd);
        if (reader.Read())
        {
            u.user_id = reader.GetInt32(0);
            u.user_name = reader.GetString(1);
            u.user_account = reader.GetString(2);
            u.user_password = reader.GetString(3);
            u.register_time = reader.GetString(4);
            u.user_description = reader.GetString(5);
            u.user_type = reader.GetInt32(6);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool SelectByID(ref User u)
    {
        IDataReader reader;
        DbCommand cmd;
        cmd = sqlServerDB.GetSqlStringCommand("select * from user_table where user_id=@UID");
        sqlServerDB.AddInParameter(cmd, "@UID", DbType.Int32, u.user_id);
        reader = sqlServerDB.ExecuteReader(cmd);
        if (reader.Read())
        {
            //u.user_id = reader.GetInt32(0);
            u.user_name = reader.GetString(1);
            u.user_account = reader.GetString(2);
            u.user_password = reader.GetString(3);
            u.register_time = reader.GetString(4);
            u.user_description = reader.GetString(5);
            u.user_type = reader.GetInt32(6);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Insert(User u)
    {
        IDataReader reader;
        DbCommand cmd;

        //account check
        cmd = sqlServerDB.GetSqlStringCommand("select user_id from user_table where user_account=@ACCOUNT");
        sqlServerDB.AddInParameter(cmd, "@ACCOUNT", DbType.String, u.user_account);
        reader = sqlServerDB.ExecuteReader(cmd);
        if (reader.Read())
        {
            return false;
        }

        reader = sqlServerDB.ExecuteReader(CommandType.Text, "select max(user_id) from user_table");
        if (reader.Read())
        {
            if(reader[0] is System.DBNull)
            {
                return false;
            }
            else
            {
                u.user_id = (int)reader[0] + 1;
            }
        }
        else
        {
            return false;
        }

        //todo:data check

        cmd = sqlServerDB.GetSqlStringCommand("insert into user_table values(@USER_ID,@USER_NAME,@USER_ACCOUNT,@USER_PASSWORD,@REGISTER_TIME,@USER_DESCRIPTION,@USER_TYPE)");
        sqlServerDB.AddInParameter(cmd, "@USER_ID", DbType.Int32, u.user_id);
        sqlServerDB.AddInParameter(cmd, "@USER_NAME", DbType.String, u.user_name);
        sqlServerDB.AddInParameter(cmd, "@USER_ACCOUNT", DbType.String, u.user_account);
        sqlServerDB.AddInParameter(cmd, "@USER_PASSWORD", DbType.String, u.user_password);
        sqlServerDB.AddInParameter(cmd, "@REGISTER_TIME", DbType.String, u.register_time);
        sqlServerDB.AddInParameter(cmd, "@USER_DESCRIPTION", DbType.String, u.user_description);
        sqlServerDB.AddInParameter(cmd, "@USER_TYPE", DbType.Int32, u.user_type);

        if(sqlServerDB.ExecuteNonQuery(cmd) != 1)
        {
            return false;
        }

        return true;
    }
}