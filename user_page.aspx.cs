using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_page : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        UserDAL userDAL = new UserDAL();
        User u = new User();
        int uid;

        if (Request.QueryString["uid"] != null)
        {
            if (int.TryParse(Request.QueryString["uid"],out uid))
            {
                u.user_id = uid;
            }
            else
            {
                //invalid uid
            }

            //debug
            //u.user_id = 0;

            if (userDAL.SelectByID(ref u))
            {
                username.InnerHtml = u.user_name;
                description.InnerHtml = u.user_description;
            }
            else
            {
                //invalid
            }

            //debug
            //Session["user"] = u;

            //print lib list
            if (printLibList(u.user_id) == false)
            {
                //fail
                Response.Write("<script>alert('printlist error');</script>");
            }
        }
        else
        {
            //no uid
            Response.Write("<script>alert('invalid uid');</script>");
        }

    }

    private bool printLibList(int uid)
    {
        List<Warehouse> list = new List<Warehouse>();
        WarehouseDAL wd = new WarehouseDAL();
        if(wd.SelectByUserID(uid, ref list) == false)
        {
            return false;
        }
        string str = "";
        foreach(Warehouse w in list)
        {
            str += "<div class=\"lib_border\"><p>项目名称：<a href=\"warehouse_page.aspx?wid=" +w.warehouse_id.ToString() +"&mid=" + w.master_version_id.ToString() +"\">" + w.warehouse_name + "</a></p>";
            str += "<p>创建时间：" + w.create_time +"</p>";
            str += "<p>项目说明：" + w.warehouse_description +"</p></div></br>";
        }
        lib_list.InnerHtml = str;
        return true;
    }
}