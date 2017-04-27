using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

public partial class test : System.Web.UI.Page
{
    private UserDAL userDAL;

    protected void Page_Load(object sender, EventArgs e)
    {
        userDAL = new UserDAL();
    }

    protected void regButton_Click(object sender, EventArgs e)
    {
        //Response.Write(Request.QueryString["username"]+ Request.QueryString["password"]);

        //todo check
        User u = new User();
        u.user_name = username.Value;
        u.user_account = useraccount.Value;
        u.user_password = password.Value;
        u.register_time = DateTime.Now.ToString();
        u.user_description = description.Value;
        u.user_type = 0;
        if (userDAL.Insert(u))
        {
            Response.Write("<script>alert('register success');window.location.href='login.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alert('register failed');</script>");
        }
    }
}