using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class create_page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDAL userDAL = new UserDAL();
        User u = new User();
        u.user_id = 0;
        userDAL.SelectByID(ref u);
        Session["user"] = u;

        if(Session["user"] == null){

        }
        else
        {

        }

    }

    protected void createButton_Click(object sender, EventArgs e)
    {
        if(Session["user"] == null)
        {
            Response.Write("<script>alert('please login.');</script>");
        }

        //create warehouse
        User u = Session["user"] as User;
        Warehouse w = new Warehouse();
        WarehouseDAL wd = new WarehouseDAL();
        w.user_id = u.user_id;
        w.warehouse_name = name.Value;
        w.warehouse_description = desc.Value;
        if (wd.Insert(ref w))
        {

        }
        else
        {
            Response.Write("<script>alert('error: warehouse insert');</script>");
            return;
        }

        //create first version
        Version v = new Version();
        VersionDAL vd = new VersionDAL();
        v.user_id = u.user_id;
        v.warehouse_id = w.warehouse_id;
        v.version_name = "master";
        v.description = "master";
        if (vd.Insert(ref v))
        {
            
        }
        else
        {
            //delete warehouse
            Response.Write("<script>alert('error: warehouse insert');</script>");
            return;
        }

    }
}