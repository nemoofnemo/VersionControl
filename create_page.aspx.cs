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
            Response.Write("<script>alert('please login.');window.location.href='login_page.aspx';</script>");
            return;
        }
        else
        {

        }

    }

    protected void createButton_Click(object sender, EventArgs e)
    {
        if(Session["user"] == null)
        {
            Response.Write("<script>alert('please login.');window.location.href='login_page.aspx';</script>");
            return;
        }

        if(name.Value.Length == 0 || desc.Value.Length == 0)
        {
            Response.Write("<script>alert('emoty data');</script>");
            return;
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
            w.master_version_id = v.version_id;
        }
        else
        {
            //delete warehouse
            wd.Delete(ref w);
            Response.Write("<script>alert('error: version insert');</script>");
            return;
        }

        if (wd.Update(ref w))
        {

        }
        else
        {
            //delete warehouse and version
            wd.Delete(ref w);
            vd.Delete(ref v);
            Response.Write("<script>alert('error: warehouse update');</script>");
            return;
        }

        //insert branch
        Branch b = new Branch();
        BranchDAL bd = new BranchDAL();
        b.warehouse_id = w.warehouse_id;
        b.user_id = u.user_id;
        b.start_id = v.version_id;
        b.end_id = v.version_id;
        b.branch_name = "master";
        b.description = "master";
        if (bd.Insert(ref b))
        {

        }
        else
        {
            wd.Delete(ref w);
            vd.Delete(ref v);
            Response.Write("<script>alert('error: branch insert');</script>");
            return;
        }

        //create success
        Response.Write("<script>alert('create success.');window.location.href='user_page.aspx';</script>");
    }
}