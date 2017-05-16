using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class warehouse_page : System.Web.UI.Page
{
    Warehouse w;
    WarehouseDAL wd;
    Version v;
    VersionDAL vd;
    Branch b;
    BranchDAL bd;
    int wid;
    int vid;

    protected void Page_Load(object sender, EventArgs e)
    {
        wd = new WarehouseDAL();
        vd = new VersionDAL();
        bd = new BranchDAL();
        
        if(int.TryParse(Request.QueryString["wid"], out wid) == false)
        {
            //error
        }
        
        if (int.TryParse(Request.QueryString["vid"], out vid) == false)
        {
            //error
        }

        if(wid ==0 || vid == 0)
        {
            //error
        }

        //debug!!!!!!!!!!!!!!!!!!!!!!!
        wid = 0;
        vid = 0;

        w = new Warehouse();
        w.warehouse_id = wid;
        if (!wd.SelectedByID(ref w))
        {
            //error
        }

        v = new Version();
        v.version_id = vid;
        if(!vd.SelectByID(ref v))
        {
            //error
        }

        b = new Branch();
        b.branch_id = v.branch_id;
        if(!bd.SelectByID(ref b))
        {
            //error
        }

        //head
        headName.InnerText = w.warehouse_name;
        headDesc.InnerText = w.warehouse_description;

        //current version
        curBran.InnerText = "当前分支：" + b.branch_name;
        curVer.InnerText = "当前版本：" + v.version_id.ToString();
        curTime.InnerText = "修改时间：" + v.timestamp;
        curDesc.InnerText = "当前版本描述：" + v.description;

    }

    protected void DrawGraph()
    {

    }

    protected void createBranch_Click(object sender, EventArgs e)
    {
        Response.Redirect("create_branch.aspx?vid="+vid.ToString());
    }
}