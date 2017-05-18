using System;
using System.Collections.Generic;
using System.Collections;
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

    private struct Node
    {
        public int vid;
        public string lable;
        public int x;
        public int y;
    }

    private struct Edge
    {
        public int edgeId;
        public int src;
        public int dest;
    }

    protected void DrawGraph()
    {
        List<Branch> branchList = new List<Branch>();
        ArrayList nodes = new ArrayList();
        ArrayList edges = new ArrayList();

        if (!bd.SelectByWarehouseID(wid, ref branchList))
        {

        }

        //find master
        int masterBranchID = -1;
        int masterStart = -1;
        foreach(Branch b in branchList)
        {
            if(b.branch_name == "master")
            {
                masterBranchID = b.branch_id;
                masterStart = b.start_id;
                break;
            }
        }

        if(masterBranchID == -1)
        {
            //error
            return;
        }

        int curX = 0;
        int curY = 0;
        int edgeID = 0;

        //draw master
        Version v = new Version();
        v.version_id = masterStart;
        bool isFirst = true;
        while (v.version_id != 0)
        {
            if(!vd.SelectByID(ref v))
            {
                //error
                return;
            }
            Node n = new Node();
            n.vid = v.version_id;
            n.lable = "master:" + n.vid.ToString();
            n.x = curX;
            n.y = curY;
            curX += 10;
            nodes.Add(n);
            if (!isFirst)
            {
                Edge e = new Edge();
                e.src = v.prev_id;
                e.dest = v.version_id;
                e.edgeId = edgeID;
                edgeID++;
                edges.Add(e);
            }
            else
            {
                isFirst = false;
            }
            v.version_id = v.next_id;
        }
        
        //draw branches
        foreach(Branch b in branchList)
        {
            if(b.branch_id == masterBranchID)
            {
                continue;
            }
            curX = 0;
            curY += 10;
            v.version_id = b.start_id;
            while (v.version_id != 0)
            {
                if (!vd.SelectByID(ref v))
                {
                    //error
                    return;
                }
                Node n = new Node();
                n.vid = v.version_id;
                n.lable = b.branch_name + n.vid.ToString();
                n.x = curX;
                n.y = curY;
                curX += 10;
                nodes.Add(n);

                Edge e = new Edge();
                e.src = v.prev_id;
                e.dest = v.version_id;
                e.edgeId = edgeID;
                edgeID++;
                edges.Add(e);

                v.version_id = v.next_id;
            }
        }

        //js

    }

    protected void createBranch_Click(object sender, EventArgs e)
    {
        Response.Redirect("create_branch.aspx?vid="+vid.ToString());
    }

    protected void pushNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("create_version.aspx?vid=" + vid.ToString());
    }
}