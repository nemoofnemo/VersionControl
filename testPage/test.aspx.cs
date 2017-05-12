using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class testPage_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(Server.MapPath("~/"));
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (file1.PostedFile.ContentLength > 0)
        {
            file1.PostedFile.SaveAs(Server.MapPath("~/") + System.IO.Path.GetFileName(file1.PostedFile.FileName));
        }
    }
}