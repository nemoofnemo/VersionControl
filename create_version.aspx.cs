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

    protected void Page_Load(object sender, EventArgs e)
    {
        ud = new UserDAL();
        vd = new VersionDAL();
        
        //debug
        //User u = new User();
        //u.user_id = 0;
        //ud.SelectByID(ref u);
        //Session["user"] = u;

        if (Session["user"] == null)
        {
            Response.Write("<script>alert('please login.');window.location.href='login.aspx';</script>");
            return;
        }

        string vid_str = Request.QueryString["vid"];
        //debug
        //vid_str = "0";
        //Response.Write("<script>alert('shit" +vid_str+"');</script>");
        if (vid_str == null)
        {
            //error
            Response.Write("<script>alert('invalid vid1 : vid is null.');window.opener=null;window.close();</script>");
            return;
        }

        int vid;
        if (int.TryParse(vid_str,out vid) == false)
        {
            //error
            Response.Write("<script>alert('invalid vid2.');window.opener=null;window.close();</script>");
            return;
        }

        v = new Version();
        v.version_id = vid;
        if(vd.SelectByID(ref v) == false)
        {
            Response.Write("<script>alert('invalid vid in url.');window.opener=null;window.close();</script>");
            return;
        }
    }

    protected void createButton_Click(object sender, EventArgs e)
    {
        User u = (User)Session["user"];

        if(u == null){
            Response.Write("<script>alert('invalid user 1.');window.opener=null;window.close();</script>");
            return;
        }

        if (v == null)
        {
            Response.Write("<script>alert('invalid vid in create.');window.opener=null;window.close();</script>");
            return;
        }

        if (u.user_id != v.user_id)
        {
            Response.Write("<script>alert('invalid user.');window.opener=null;window.close();</script>");
            return;
        }

        if(name.Value.Length == 0 || desc.Value.Length == 0)
        {
            //error
            Response.Write("<script>alert('invalid name or desc.');</script>");
            return;
        }

        Version v2 = new Version();
        v2.version_name = name.Value;
        v2.description = desc.Value;
        v2.prev_id = v.version_id;//!
        v2.next_id = v.next_id;//!
        v2.warehouse_id = v.warehouse_id;
        v2.user_id = v.user_id;
        v2.branch_id = v.branch_id;

        if(!vd.Insert(ref v2))
        {
            Response.Write("<script>alert('insert error 1.');</script>");
            return;
        }

        Version v3 = new Version();
        v3.branch_id = v.branch_id;
        v3.description = v.description;
        v3.next_id = v2.version_id;//warning
        v3.prev_id = v.prev_id;//warning
        v3.timestamp = v.timestamp;
        v3.user_id = v.user_id;
        v3.version_id = v.version_id;
        v3.version_name = v.version_name;
        v3.warehouse_id = v.warehouse_id;
        if(!vd.Update(ref v3))
        {
            Response.Write("<script>alert('error 3.');</script>");
            vd.Delete(ref v2);
            vd.Update(ref v);
            return;
        }

        //create files
        if (!FileSystem.CopyFolder(Server.MapPath("~/") +@"data\"+v.warehouse_id.ToString() + @"\"+v.version_id.ToString(), Server.MapPath("~/") + @"data\" + v.warehouse_id.ToString() + @"\" + v2.version_id.ToString()))
        {
            vd.Delete(ref v2);
            vd.Update(ref v);
            Response.Write("<script>alert('file error.');</script>");
            return;
        }

        //warnning ; bug here
        Branch b = new Branch();
        b.branch_id = v.branch_id;
        bd = new BranchDAL();
        bd.SelectByID(ref b);
        if (b.branch_name == "master")
        {
            Warehouse w = new Warehouse();
            w.warehouse_id = v.warehouse_id;
            wd = new WarehouseDAL();
            wd.SelectedByID(ref w);
            if(w.master_version_id == v.version_id)
            {
                w.master_version_id = v3.version_id;
                wd.Update(ref w);
            }
        }

        Response.Write("<script>alert('create success.');window.location.href='warehouse_page.aspx?wid=" +v.warehouse_id +"&vid=" +v3.version_id + "';</script>");
    }
}