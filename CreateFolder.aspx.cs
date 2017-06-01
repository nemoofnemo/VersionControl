using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateFolder : System.Web.UI.Page
{
    int wid;
    int vid;
    string path;
    Warehouse w;
    WarehouseDAL wd;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            //error
            Response.Write("<script>alert('invalid argument 1.')</script>");
        }
        if (int.TryParse(Request.QueryString["wid"], out wid) == false)
        {
            //error
            Response.Write("<script>alert('invalid argument 2.')</script>");
        }
        if (int.TryParse(Request.QueryString["vid"], out vid) == false)
        {
            //error
            Response.Write("<script>alert('invalid argument 2.1 .')</script>");
        }

        if (Request.QueryString["path"] == null)
        {
            //error
            Response.Write("<script>alert('invalid argument 3.')</script>");
        }
        else
        {
            path = Request.QueryString["path"];
        }
    }

    bool checkUser()
    {
        if (Session["user"] == null)
        {
            return false;
        }
        User u = (User)Session["user"];
        if (u.user_id != w.user_id)
        {
            return false;
        }
        return true;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        wd = new WarehouseDAL();
        w = new Warehouse();
        w.warehouse_id = wid;

        if (!wd.SelectedByID(ref w))
        {
            //error
            Response.Write("<script>alert('invalid argument 4.')</script>");
        }
        else
        {
            if (checkUser())
            {
                string root = Server.MapPath("~/") + @"data\" + wid + @"\" + vid + @"\";
                if (FileSystem.CreateFolder(root + path + TextBox1.Text))
                {
                    Response.Redirect("warehouse_page.aspx?vid=" + vid.ToString() + "&wid=" + wid.ToString());
                }
                else
                {
                    Response.Write("<script>alert('invalid argument 5')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('invalid argument 6.')</script>");
            }

        }

    }
}