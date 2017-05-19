using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        //Response.Write(Request.QueryString["username"]+ Request.QueryString["password"]);
        User u = new User();
        UserDAL userDAL = new UserDAL();
        u.user_account = useraccount.Value;
        u.user_password = password.Value;
        if (userDAL.LoginCheck(ref u))
        {
            Session["user"] = u;
            Response.Redirect("user_page.aspx?uid="+u.user_id.ToString());
        }
        else
        {
            Response.Write("<script>alert('login failed');</script>");
        }
    }
}