using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

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
    string root;

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
        //wid = 1;
        //vid = 1;
        //User u = new User();
        //u.user_id = 1;
        //UserDAL ud = new UserDAL();
        //ud.SelectByID(ref u);
        //Session["user"] = u;

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

        //draw
        if (!DrawGraph())
        {

        }

        //file
        fileInit();
    }

    void fileInit()
    {
        root = Server.MapPath("~/") + @"data\" + wid + @"\" + vid;

        foreach (ListItem item in listBox.Items)
        {
            if (item.Selected)
            {
                if (FileSystem.IsFile(root + @"\" + pathLabel.Text + item.Text))
                {
                    byte[] data = FileSystem.ReadFile(root + @"\" + item.Text);
                    file_content.InnerText = Encoding.Default.GetString(data);
                    //pathLabel.Text += item.Text;
                }
                else if (FileSystem.IsFolder(root + @"\" + pathLabel.Text + item.Text))
                {
                    pathLabel.Text += item.Text;
                    file_content.InnerHtml = "";
                }
                else
                {
                    file_content.InnerHtml = "Invalid Data.";
                    pathLabel.Text = "";
                }
                break;
            }
        }
        listBox.Items.Clear();

        if (FileSystem.IsFolder(root + @"\" + pathLabel.Text))
        {
            string[] folderList = FileSystem.GetFolderList(root + @"\" + pathLabel.Text);
            if (folderList != null)
            {
                foreach (string s in folderList)
                {
                    listBox.Items.Add(s + @"\");
                }
            }
            string[] fileList = FileSystem.GetFileList(root + @"\" + pathLabel.Text);
            if (fileList != null)
            {
                foreach (string s in fileList)
                {
                    listBox.Items.Add(s);
                }
            }
            listBox.AutoPostBack = true;
        }
    }

    //=============================graph========================================
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

    protected bool DrawGraph()
    {
        List<Branch> branchList = new List<Branch>();
        ArrayList nodes = new ArrayList();
        ArrayList edges = new ArrayList();

        if (!bd.SelectByWarehouseID(wid, ref branchList))
        {
            //error
            return false;
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
            return false;
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
                break;
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
            for(int i = 0; i < nodes.Count; ++i)
            {
                
            }
            curX = 0;
            curY += 10;
            isFirst = true;
            v.version_id = b.start_id;
            while (v.version_id != 0)
            {
                if (!vd.SelectByID(ref v))
                {
                    break;
                }
                if (isFirst)
                {
                    int i = 0;
                    for(;i < nodes.Count; ++i)
                    {
                        if(v.prev_id == ((Node)nodes[i]).vid)
                        {
                            curX = 10 * i;
                        }
                    }
                    isFirst = false;
                }

                Node n = new Node();
                n.vid = v.version_id;
                n.lable = b.branch_name +":" + n.vid.ToString();
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
        string js = "<script>var g = {nodes: [],edges: []};";
        foreach(Node n in nodes)
        {
            js += "g.nodes.push({id:'" + n.vid.ToString() + "',label:'" + n.lable + "',x:" + n.x.ToString() + ",y:"+n.y.ToString() + ",size:10,color:'#666'});";
        }

        foreach(Edge e in edges)
        {
            js += "g.edges.push({id:'" + e.edgeId.ToString() + "',source:'" + e.src.ToString() + "',target:'" + e.dest.ToString() + "',size:10,color: '#ccc',hover_color:'#000'}); ";
        }

        js += "s = new sigma({graph: g,renderer:{container: document.getElementById('graph-container'),type: 'canvas'},settings:{doubleClickEnabled: false,minEdgeSize: 0.5,maxEdgeSize: 4,enableEdgeHovering: true,edgeHoverColor: 'edge',defaultEdgeHoverColor: '#000',edgeHoverSizeRatio: 1,edgeHoverExtremities: true,}});";

        js += "s.bind('clickNode doubleClickNode rightClickNode', function (e) {var str = '' + e.data.node.label;var arr = str.split(':', 2);document.getElementById('selectedBranch').innerText = '选中分支:' + arr[0];document.getElementById('selectedVersion').innerText= arr[1];document.getElementById('hidValue').value = arr[1];});</script>";

        graph_script.InnerHtml = js;
        return true;
    }

    protected void createBranch_Click(object sender, EventArgs e)
    {
        Response.Redirect("create_branch.aspx?vid="+vid.ToString());
    }

    protected void pushNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("create_version.aspx?vid=" + vid.ToString());
    }

    protected void jumpVersion_Click(object sender, EventArgs e)
    {
        //Response.Write("<script>alert('"+ hidValue.Value+ "')</script>");
        if(hidValue.Value.Length > 0)
            Response.Redirect("warehouse_page.aspx?wid=" + wid.ToString() + "&vid=" + hidValue.Value,false);
        else
            Response.Write("<script>alert('invalid vid')</script>");
    }

    //---------------------------------------
    bool checkUser()
    {
        if(Session["user"] == null)
        {
            return false;
        }
        User u = (User)Session["user"];
        if(u.user_id != w.user_id)
        {
            return false;
        }
        return true;
    }

    bool deleteFrom(int id)
    {
        Version v2 = new Version();
        v2.version_id = id;
        bool isFirst = true;
        while (true)
        {
            if(v2.version_id == 0)
            {
                break;
            }
            if(!vd.SelectByID(ref v2))
            {
                return false;
            }

            if (!isFirst)
            {
                //warnning
                vd.Delete(ref v2);
                //remove files
                FileSystem.RemoveFolder(Server.MapPath("~/") + @"data\" + v2.warehouse_id.ToString() + @"\" + v2.version_id.ToString());
            }
            else
            {
                isFirst = false;
            }

            v2.version_id = v2.next_id;
        }

        v2.version_id = id;
        vd.SelectByID(ref v2);
        v2.next_id = 0;
        vd.Update(ref v2);

        return true;
    }
    

    protected void redoVersion_Click(object sender, EventArgs e)
    {
        if (!checkUser())
        {
            Response.Write("<script>alert('please login.');window.location.href='login.aspx';</script>");
            return;
        }

        Version v2 = new Version();
        v2.version_id = int.Parse(hidValue.Value);
        vd.SelectByID(ref v2);

        Branch b2 = new Branch();
        b2.branch_id = v2.branch_id;
        if (!bd.SelectByID(ref b2))
        {
            Response.Write("<script>alert('invalid argument.')</script>");
            return;
        }

        Warehouse w2 = new Warehouse();
        w2.warehouse_id = v2.warehouse_id;
        if (!wd.SelectedByID(ref w2))
        {
            Response.Write("<script>alert('invalid argument.')</script>");
            return;
        }

        if (b2.branch_name == "master")
        {
            deleteFrom(v2.version_id);
            w2.master_version_id = v2.version_id;
            wd.Update(ref w2);
        }
        else
        {
            deleteFrom(v2.version_id);
        }
        Response.Write("<script>alert('success.');window.location.href='warehouse_page.aspx?wid="+w2.warehouse_id.ToString()+"&vid="+w2.master_version_id.ToString()+"';</script>");
    }

    void deleteBranchEx() {
        Version v2 = new Version();
        v2.version_id = b.start_id;
        if (!vd.SelectByID(ref v2))
        {
            Response.Write("<script>alert('invalid argument.')</script>");
            return;
        }
        
        while (true)
        {
            if (v2.version_id == 0)
            {
                break;
            }
            if (!vd.SelectByID(ref v2))
            {
                break;//warnning
            }

            //warnning
            vd.Delete(ref v2);
            //remove files
            FileSystem.RemoveFolder(Server.MapPath("~/") + @"data\" + v2.warehouse_id.ToString() + @"\" + v2.version_id.ToString());

            v2.version_id = v2.next_id;
        }

        bd.Delete(v2.branch_id);
    }

    protected void deleteBranch_Click(object sender, EventArgs e)
    {
        if (!checkUser())
        {
            Response.Write("<script>alert('please login.');window.location.href='login.aspx';</script>");
            return;
        }

        if (b.branch_name == "master")
        {
            Response.Write("<script>alert('cannot delete branch master')</script>");
        }
        else
        {
            deleteBranchEx();
            Response.Write("<script>alert('delete success');</script>");
        }
        Warehouse w2 = new Warehouse();
        w2.warehouse_id = w.warehouse_id;
        wd.SelectedByID(ref w2);
        Response.Write("<script>window.location.href='warehouse_page.aspx?wid=" + w2.warehouse_id.ToString() + "&vid=" + w2.master_version_id.ToString() + "';</script>");
    }

    protected void listBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        //foreach (ListItem item in listBox.Items)
        //{
        //    if (item.Selected)
        //    {
        //        //file_content.InnerHtml = item.Text;
        //        root = Server.MapPath("~/") + @"data\" + wid + @"\" + vid;
        //        if (FileSystem.IsFile(root + @"\" + item.Text)) {
        //            pathLabel.Text += item.Text;
        //        }
        //        else if (FileSystem.IsFolder(root + @"\" + item.Text))
        //        {
        //            pathLabel.Text += item.Text + @"\";
        //        }
        //        else
        //        {
        //            file_content.InnerHtml = "Invalid Data.";
        //        }
        //        break;
        //    }
        //}
    }

    protected void rootButton_Click(object sender, ImageClickEventArgs e)
    {
        pathLabel.Text = "";
        file_content.InnerHtml = "";
        root = Server.MapPath("~/") + @"data\" + wid + @"\" + vid;
        listBox.Items.Clear();
        if (FileSystem.IsFolder(root + @"\" + pathLabel.Text))
        {
            string[] folderList = FileSystem.GetFolderList(root + @"\" + pathLabel.Text);
            if (folderList != null)
            {
                foreach (string s in folderList)
                {
                    listBox.Items.Add(s + @"\");
                }
            }
            string[] fileList = FileSystem.GetFileList(root + @"\" + pathLabel.Text);
            if (fileList != null)
            {
                foreach (string s in fileList)
                {
                    listBox.Items.Add(s);
                }
            }
            listBox.AutoPostBack = true;
        }
    }

    protected void createFileButton_Click(object sender, ImageClickEventArgs e)
    {
        if (checkUser())
        {
            Response.Redirect("UploadFile.aspx?wid=" + wid.ToString() + "&vid=" + vid.ToString() + "&path=" + pathLabel.Text);
            pathLabel .Text= "";
            listBox.Items.Clear();
        }

    }

    protected void createFolderButton_Click(object sender, ImageClickEventArgs e)
    {
        if (checkUser())
        {
            Response.Redirect("CreateFolder.aspx?wid=" + wid.ToString() + "&vid=" + vid.ToString() + "&path=" + pathLabel.Text);
            pathLabel.Text = "";
            listBox.Items.Clear();
        }
    }

    protected void backwardButton_Click(object sender, ImageClickEventArgs e)
    {
        rootButton_Click(sender, e);
    }
}