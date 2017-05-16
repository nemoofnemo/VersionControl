using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class create_branch : System.Web.UI.Page
{
    UserDAL ud;
    Version v;
    VersionDAL vd;
    WarehouseDAL wd;
    BranchDAL bd;


    /// <summary>
    /// url arg: user, warehouse id, version id
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        ud = new UserDAL();
        vd = new VersionDAL();
        
        //debug
        User u = new User();
        u.user_id = 0;
        ud.SelectByID(ref u);

        if (Session["user"] == null)
        {
            //Response.Write("<script>alert('please login.');window.location.href='login.aspx';</script>");
            //return;
        }

        string vid_str = Request.QueryString["vid"];
        //debug
        vid_str = "0";
        if (vid_str == null)
        {
            //error
        }

        int vid;
        if (int.TryParse(vid_str,out vid) == false)
        {
            //error
            Response.Write("<script>alert('invalid vid.');</script>");
            return;
        }

        v = new Version();
        v.version_id = vid;
        if(vd.SelectByID(ref v) == false)
        {
            Response.Write("<script>alert('invalid vid.');</script>");
            return;
        }
    }

    protected void createButton_Click(object sender, EventArgs e)
    {
        if(name.Value.Length == 0 || desc.Value.Length == 0)
        {
            //error
            Response.Write("<script>alert('invalid name or desc.');</script>");
            return;
        }
        if (name.Value == "master")
        {
            Response.Write("<script>alert('invalid name.');</script>");
            return;
        }

        Version v2 = new Version();
        v2.version_name = name.Value;
        v2.description = desc.Value;
        v2.prev_id = v.version_id;
        v2.next_id = 0;
        v2.warehouse_id = v.warehouse_id;
        v2.user_id = v.user_id;
        v2.branch_id = 0;//warning

        if(!vd.Insert(ref v2))
        {
            Response.Write("<script>alert('insert error 1.');</script>");
            return;
        }

        Branch b = new Branch();
        b.branch_name = name.Value;
        b.description = desc.Value;
        b.warehouse_id = v.warehouse_id;
        b.user_id = v.user_id;
        b.start_id = v2.version_id;
        b.end_id = 0;

        bd = new BranchDAL();

        if(!bd.Insert(ref b))
        {
            Response.Write("<script>alert('insert error 2.');</script>");
            vd.Delete(ref v2);
            return;
        }

        v2.branch_id = b.branch_id;
        if(!vd.Update( ref v2))
        {
            Response.Write("<script>alert('update error.');</script>");
            vd.Delete(ref v2);
            bd.Delete(b.branch_id);
            return;
        }

        //create files

        Response.Write("<script>alert('create success.');</script>");
    }
}