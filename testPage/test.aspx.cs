using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testPage_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["ss"] == null)
        {
            Response.Write("111\r\n2222");
        }
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        div1.InnerHtml = "<script>alert('ssss');</script>";
    }
}