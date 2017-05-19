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
        Warehouse w = new Warehouse();
        WarehouseDAL wd = new WarehouseDAL();
        w.warehouse_id = 1;
        wd = new WarehouseDAL();
        wd.SelectedByID(ref w);
        w.master_version_id = 1000;
        wd.Update(ref w);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (file1.PostedFile.ContentLength > 0)
        {
            file1.PostedFile.SaveAs(Server.MapPath("~/") + System.IO.Path.GetFileName(file1.PostedFile.FileName));
        }
    }
}