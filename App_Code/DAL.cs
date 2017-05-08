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

public class WarehouseDAL
{
    private SqlDatabase sqlServerDB;

    public WarehouseDAL()
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        sqlServerDB = factory.CreateDefault() as SqlDatabase;
    }

    public bool SelectedByID(ref Warehouse w)
    {
        DbCommand cmd;
        IDataReader reader;
        cmd = sqlServerDB.GetSqlStringCommand("select * from warehouse_table where warehouse_id=@a1");
        sqlServerDB.AddInParameter(cmd, "@a1", DbType.Int32, w.warehouse_id);
        reader = sqlServerDB.ExecuteReader(cmd);
        if (reader.Read())
        {
            w.warehouse_id = reader.GetInt32(0);
            w.user_id = reader.GetInt32(1);
            w.organization_id = w.warehouse_id = reader.GetInt32(2);
            w.warehouse_type = reader.GetInt32(3);
            w.create_time = reader.GetString(4);
            w.warehouse_description = reader.GetString(5);
            w.master_version_id = reader.GetInt32(6);
            w.warehouse_name = reader.GetString(7);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Insert(ref Warehouse w)
    {
        DbCommand cmd;
        IDataReader reader;

        //todo:check user id

        //todo:get last version id
        reader = sqlServerDB.ExecuteReader(CommandType.Text, "select max(warehouse_id) from warehouse_table");
        if (reader.Read())
        {
            if (reader[0] is System.DBNull)
            {
                return false;
            }
            else
            {
                w.warehouse_id = reader.GetInt32(0) + 1;
            }
        }
        else
        {
            return false;
        }

        //insert
        cmd = sqlServerDB.GetSqlStringCommand("insert into warehouse_table values(@a0,@a1,@a2,@a3,@a4,@a5,@a6,@a7)");
        sqlServerDB.AddInParameter(cmd, "@a0", DbType.Int32, w.warehouse_id);
        sqlServerDB.AddInParameter(cmd, "@a1", DbType.Int32, w.user_id);
        sqlServerDB.AddInParameter(cmd, "@a2", DbType.Int32, w.organization_id);
        sqlServerDB.AddInParameter(cmd, "@a3", DbType.Int32, w.warehouse_type);
        w.create_time = DateTime.Now.ToString();
        sqlServerDB.AddInParameter(cmd, "@a4", DbType.String, w.create_time);
        sqlServerDB.AddInParameter(cmd, "@a5", DbType.String, w.warehouse_description);
        sqlServerDB.AddInParameter(cmd, "@a6", DbType.Int32, w.master_version_id);
        sqlServerDB.AddInParameter(cmd, "@a7", DbType.String, w.warehouse_name);

        if (sqlServerDB.ExecuteNonQuery(cmd) != 1)
        {
            return false;
        }

        return true;
    }

    public bool Update(ref Warehouse w)
    {
        DbCommand cmd;
        cmd = sqlServerDB.GetSqlStringCommand("update warehouse_table set warehouse_id=@a0,user_id=@a1,organization_id=@a2,warehouse_type=@a3,create_time=@a4,warehouse_description=@a5,master_version_id=@a6,warehouse_name=@a7 where warehouse_id=@a0");
        sqlServerDB.AddInParameter(cmd, "@a0", DbType.Int32, w.warehouse_id);
        sqlServerDB.AddInParameter(cmd, "@a1", DbType.Int32, w.user_id);
        sqlServerDB.AddInParameter(cmd, "@a2", DbType.Int32, w.organization_id);
        sqlServerDB.AddInParameter(cmd, "@a3", DbType.Int32, w.warehouse_type);
        sqlServerDB.AddInParameter(cmd, "@a4", DbType.String, w.create_time);
        sqlServerDB.AddInParameter(cmd, "@a5", DbType.String, w.warehouse_description);
        sqlServerDB.AddInParameter(cmd, "@a6", DbType.Int32, w.master_version_id);
        sqlServerDB.AddInParameter(cmd, "@a7", DbType.String, w.warehouse_name);

        if (sqlServerDB.ExecuteNonQuery(cmd) != 1)
        {
            return false;
        }

        return true;
    }

    public bool Delete(ref Warehouse w)
    {
        DbCommand cmd;
        cmd = sqlServerDB.GetSqlStringCommand("delete from warehouse_table where warehouse_id=@a0");
        sqlServerDB.AddInParameter(cmd, "@a0", DbType.Int32, w.warehouse_id);
        if (sqlServerDB.ExecuteNonQuery(cmd) != 1)
        {
            return false;
        }
        return true;
    }

    public bool SelectByUserID(int uid, ref List<Warehouse> l)
    {
        DbCommand cmd;
        IDataReader reader;
        //todo:check user id

        cmd = sqlServerDB.GetSqlStringCommand("select * from warehouse_table where user_id=@a0");
        sqlServerDB.AddInParameter(cmd, "@a0", DbType.Int32, uid);
        reader = sqlServerDB.ExecuteReader(cmd);

        while (reader.Read())
        {
            Warehouse w = new Warehouse();
            w.warehouse_id = reader.GetInt32(0);
            w.user_id = reader.GetInt32(1);
            w.organization_id = reader.GetInt32(2);
            w.warehouse_type = reader.GetInt32(3);
            w.create_time = reader.GetString(4);
            w.warehouse_description = reader.GetString(5);
            w.master_version_id = reader.GetInt32(6);
            w.warehouse_name = reader.GetString(7);
            l.Add(w);
        }

        return true;
    }
    
}

public class VersionDAL
{
    private SqlDatabase sqlServerDB;

    public VersionDAL()
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        sqlServerDB = factory.CreateDefault() as SqlDatabase;
    }

    public bool Insert(ref Version v)
    {
        IDataReader reader;
        DbCommand cmd;

        //get new id
        reader = sqlServerDB.ExecuteReader(CommandType.Text, "select max(version_id) from version_table");
        if (reader.Read())
        {
            if (reader[0] is System.DBNull)
            {
                return false;
            }
            else
            {
                v.version_id = reader.GetInt32(0) + 1;
            }
        }
        else
        {
            return false;
        }

        //insert
        cmd = sqlServerDB.GetSqlStringCommand("insert into version_table values(@a0,@a1,@a2,@a3,@a4,@a5,@a6,@a7)");
        sqlServerDB.AddInParameter(cmd, "@a0", DbType.Int32, v.version_id);
        sqlServerDB.AddInParameter(cmd, "@a1", DbType.Int32, v.warehouse_id);
        sqlServerDB.AddInParameter(cmd, "@a2", DbType.Int32, v.user_id);
        sqlServerDB.AddInParameter(cmd, "@a3", DbType.Int32, v.prev_id);
        sqlServerDB.AddInParameter(cmd, "@a4", DbType.Int32, v.next_id);
        v.timestamp = DateTime.Now.ToString();
        sqlServerDB.AddInParameter(cmd, "@a5", DbType.String, v.timestamp);
        sqlServerDB.AddInParameter(cmd, "@a6", DbType.String, v.version_name);
        sqlServerDB.AddInParameter(cmd, "@a7", DbType.String, v.description);

        if (sqlServerDB.ExecuteNonQuery(cmd) != 1)
        {
            return false;
        }

        return true;
    }

    public bool Delete(ref Version v)
    {
        DbCommand cmd;
        cmd = sqlServerDB.GetSqlStringCommand("delete from version_table where version_id=@a0");
        sqlServerDB.AddInParameter(cmd, "@a0", DbType.Int32, v.version_id);
        if (sqlServerDB.ExecuteNonQuery(cmd) != 1)
        {
            return false;
        }
        return true;
    }
}

public class BranchDAL
{
    private SqlDatabase sqlServerDB;

    public BranchDAL()
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        sqlServerDB = factory.CreateDefault() as SqlDatabase;
    }

    public bool Insert(ref Branch b)
    {
        IDataReader reader;
        DbCommand cmd;

        //get new id
        reader = sqlServerDB.ExecuteReader(CommandType.Text, "select max(branch_id) from branch_table");
        if (reader.Read())
        {
            if (reader[0] is System.DBNull)
            {
                return false;
            }
            else
            {
                b.branch_id = reader.GetInt32(0) + 1;
            }
        }
        else
        {
            return false;
        }

        //insert
        cmd = sqlServerDB.GetSqlStringCommand("insert into branch_table values(@a0,@a1,@a2,@a3,@a4,@a5,@a6,@a7)");
        sqlServerDB.AddInParameter(cmd, "@a0", DbType.Int32, b.branch_id);
        sqlServerDB.AddInParameter(cmd, "@a1", DbType.Int32, b.warehouse_id);
        sqlServerDB.AddInParameter(cmd, "@a2", DbType.Int32, b.user_id);
        sqlServerDB.AddInParameter(cmd, "@a3", DbType.Int32, b.start_id);
        sqlServerDB.AddInParameter(cmd, "@a4", DbType.Int32, b.end_id);
        b.timestamp = DateTime.Now.ToString();
        sqlServerDB.AddInParameter(cmd, "@a5", DbType.String, b.timestamp);
        sqlServerDB.AddInParameter(cmd, "@a6", DbType.String, b.branch_name);
        sqlServerDB.AddInParameter(cmd, "@a7", DbType.String, b.description);

        if (sqlServerDB.ExecuteNonQuery(cmd) != 1)
        {
            return false;
        }

        return true;
    }
}