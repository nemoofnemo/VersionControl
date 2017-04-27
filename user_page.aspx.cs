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
            u.user_id = 0;

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
            Session["user"] = u;


        }
        else
        {
            //no uid
        }
    }
}