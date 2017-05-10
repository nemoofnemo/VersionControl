<%@ Page Language="C#" AutoEventWireup="true" CodeFile="warehouse_page.aspx.cs" Inherits="warehouse_page" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>LibraryPage</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Facebook and Twitter integration -->
    <meta property="og:title" content="" />
    <meta property="og:image" content="" />
    <meta property="og:url" content="" />
    <meta property="og:site_name" content="" />
    <meta property="og:description" content="" />
    <meta name="twitter:title" content="" />
    <meta name="twitter:image" content="" />
    <meta name="twitter:url" content="" />
    <meta name="twitter:card" content="" />

    <!-- <link href="https://fonts.googleapis.com/css?family=Droid+Sans" rel="stylesheet"> -->

    <!-- Animate.css -->
    <link rel="stylesheet" href="css/animate.css">
    <!-- Icomoon Icon Fonts-->
    <link rel="stylesheet" href="css/icomoon.css">
    <!-- Themify Icons-->
    <link rel="stylesheet" href="css/themify-icons.css">
    <!-- Bootstrap  -->
    <link rel="stylesheet" href="css/bootstrap.css">

    <!-- Magnific Popup -->
    <link rel="stylesheet" href="css/magnific-popup.css">

    <!-- Owl Carousel  -->
    <link rel="stylesheet" href="css/owl.carousel.min.css">
    <link rel="stylesheet" href="css/owl.theme.default.min.css">

    <!-- Theme style  -->
    <link rel="stylesheet" href="css/style.css">

    <!-- Modernizr JS -->
    <script src="js/modernizr-2.6.2.min.js"></script>
    <!-- FOR IE9 below -->
    <!--[if lt IE 9]>
	<script src="js/respond.min.js"></script>
	<![endif]-->
    <style>
        .nemobutton {
            background-color: rgba(29, 43, 83, 0.89); /* Green */
            border: none;
            color: white;
            padding: 8px 16px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 14px;
            margin: 4px 2px;
            cursor: pointer;
            border-radius: 8px;
        }

        .nemoborder{
            border-style: solid; 
            border-width: medium; 
            border-color: #ccc;
        }
    </style>

    <script src="js/sigma.core.js"></script>
    <script src="js/conrad.js"></script>
    <script src="js/utils/sigma.utils.js"></script>
    <script src="js/utils/sigma.polyfills.js"></script>
    <script src="js/sigma.settings.js"></script>
    <script src="js/classes/sigma.classes.dispatcher.js"></script>
    <script src="js/classes/sigma.classes.configurable.js"></script>
    <script src="js/classes/sigma.classes.graph.js"></script>
    <script src="js/classes/sigma.classes.camera.js"></script>
    <script src="js/classes/sigma.classes.quad.js"></script>
    <script src="js/classes/sigma.classes.edgequad.js"></script>
    <script src="js/captors/sigma.captors.mouse.js"></script>
    <script src="js/captors/sigma.captors.touch.js"></script>
    <script src="js/renderers/sigma.renderers.canvas.js"></script>
    <script src="js/renderers/sigma.renderers.webgl.js"></script>
    <script src="js/renderers/sigma.renderers.svg.js"></script>
    <script src="js/renderers/sigma.renderers.def.js"></script>
    <script src="js/renderers/webgl/sigma.webgl.nodes.def.js"></script>
    <script src="js/renderers/webgl/sigma.webgl.nodes.fast.js"></script>
    <script src="js/renderers/webgl/sigma.webgl.edges.def.js"></script>
    <script src="js/renderers/webgl/sigma.webgl.edges.fast.js"></script>
    <script src="js/renderers/webgl/sigma.webgl.edges.arrow.js"></script>
    <script src="js/renderers/canvas/sigma.canvas.labels.def.js"></script>
    <script src="js/renderers/canvas/sigma.canvas.hovers.def.js"></script>
    <script src="js/renderers/canvas/sigma.canvas.nodes.def.js"></script>
    <script src="js/renderers/canvas/sigma.canvas.edges.def.js"></script>
    <script src="js/renderers/canvas/sigma.canvas.edges.curve.js"></script>
    <script src="js/renderers/canvas/sigma.canvas.edges.arrow.js"></script>
    <script src="js/renderers/canvas/sigma.canvas.edges.curvedArrow.js"></script>
    <script src="js/renderers/canvas/sigma.canvas.edgehovers.def.js"></script>
    <script src="js/renderers/canvas/sigma.canvas.edgehovers.curve.js"></script>
    <script src="js/renderers/canvas/sigma.canvas.edgehovers.arrow.js"></script>
    <script src="js/renderers/canvas/sigma.canvas.edgehovers.curvedArrow.js"></script>
    <script src="js/renderers/canvas/sigma.canvas.extremities.def.js"></script>
    <script src="js/renderers/svg/sigma.svg.utils.js"></script>
    <script src="js/renderers/svg/sigma.svg.nodes.def.js"></script>
    <script src="js/renderers/svg/sigma.svg.edges.def.js"></script>
    <script src="js/renderers/svg/sigma.svg.edges.curve.js"></script>
    <script src="js/renderers/svg/sigma.svg.labels.def.js"></script>
    <script src="js/renderers/svg/sigma.svg.hovers.def.js"></script>
    <script src="js/middlewares/sigma.middlewares.rescale.js"></script>
    <script src="js/middlewares/sigma.middlewares.copy.js"></script>
    <script src="js/misc/sigma.misc.animation.js"></script>
    <script src="js/misc/sigma.misc.bindEvents.js"></script>
    <script src="js/misc/sigma.misc.bindDOMEvents.js"></script>
    <script src="js/misc/sigma.misc.drawHovers.js"></script>

</head>

<body>
    <div class="gtco-loader"></div>
    <div id="page">
        <nav class="gtco-nav" role="navigation">
            <div class="gtco-container">
                <div class="row">
                    <div class="col-sm-4 col-xs-12">
                        <div id="gtco-logo"><a href="index.html">仓库中心<em>.</em></a></div>
                    </div>
                    <div class="col-xs-8 text-right menu-1">
                        <ul>
                            <li><a href="index.html">Home</a></li>
                            <li class="active"><a href="about.html">About</a></li>
                            <li class="has-dropdown">
                                <a href="services.html">Services</a>
                                <ul class="dropdown">
                                    <li><a href="#">Web Design</a></li>
                                    <li><a href="#">eCommerce</a></li>
                                    <li><a href="#">Branding</a></li>
                                    <li><a href="#">API</a></li>
                                </ul>
                            </li>
                            <li class="has-dropdown">
                                <a href="#">Dropdown</a>
                                <ul class="dropdown">
                                    <li><a href="#">HTML5</a></li>
                                    <li><a href="#">CSS3</a></li>
                                    <li><a href="#">Sass</a></li>
                                    <li><a href="#">jQuery</a></li>
                                </ul>
                            </li>
                            <li><a href="portfolio.html">Portfolio</a></li>
                            <li><a href="contact.html">Contact</a></li>
                        </ul>
                    </div>
                </div>

            </div>
        </nav>

        <header id="gtco-header" class="gtco-cover gtco-cover-xs" role="banner" style="background-image: url(images/img_bg_1.jpg);">
            <div class="overlay"></div>
            <div class="gtco-container">
                <div class="row">
                    <div class="col-md-8 col-md-offset-2 text-center">
                        <div class="display-t">
                            <div class="display-tc">
                                <h1 id="headName" class="animate-box" data-animate-effect="fadeInUp" runat="server">warehouse name</h1>
                                <h2 class="headDesc" data-animate-effect="fadeInUp" runat="server">wrehouse desc</h2>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </header>

        <form id="form1" runat="server">
            <%-- sigma graph --%>
            <div style="background-color:#ccc"><a style="background-color: #ccc;">Graph:</a></div>
            <asp:HiddenField ID="hidValue1" runat="server"/>
            <div id="sigma_container">
                <style>
                    #graph-container {
                        top: 5px;
                        bottom: 5px;
                        left: 5px;
                        right: 5px;
                        position: absolute;
                        background: #fff;
                    }

                    #sigma_container {
                        position: relative;
                        top: 0;
                        left: 0;
                        right: 0;
                        height: 400px;
                        background: #ccc;
                    }
                </style>
                <div id="graph-container"></div>
                <div style="clear: both; height: 0; font-size: 1px; line-height: 0px;"></div>
            </div>
            <script>
                var i,
                    s,
                    N = 20,
                    E = 200,
                    g = {
                        nodes: [],
                        edges: []
                    };

                g.nodes.push({
                    id: 'a',
                    label: 'hello',
                    x: 0,
                    y: 0,
                    size: 10,
                    color: '#666'
                });

                g.nodes.push({
                    id: 'b',
                    label: 'world',
                    x: 10,
                    y: 10,
                    size: 10,
                    color: '#666'
                });

                g.edges.push({
                    id: 'e1',
                    source: 'a',
                    target: 'b',
                    size: 10,
                    type: 'curve',
                    color: '#ccc',
                    hover_color: '#000'
                });

                s = new sigma({
                    graph: g,
                    renderer: {
                        container: document.getElementById('graph-container'),
                        type: 'canvas'
                    },
                    settings: {
                        doubleClickEnabled: false,
                        minEdgeSize: 0.5,
                        maxEdgeSize: 4,
                        enableEdgeHovering: true,
                        edgeHoverColor: 'edge',
                        defaultEdgeHoverColor: '#000',
                        edgeHoverSizeRatio: 1,
                        edgeHoverExtremities: true,
                    }
                });

                s.bind('clickNode doubleClickNode rightClickNode', function (e) {
                    console.log(e.type, e.data.node.label, e.data.captor);
                    document.getElementById("hidValue1").value = e.data.node.label;
                });
            </script>

            <div style="border-style: solid; border-width: medium; border-color: #ccc;">
                <a style="color: #000000">当前分支：</a><a style="color: #000000">当前版本:</a>
                <br />
                <a style="color: #000000">当前版本描述：</a>
                <br />
                <asp:Button ID="pushNew" CssClass="nemobutton" Text="推送新版本" runat="server" />
                <input id="createBranch" class="nemobutton" type="button" value="创建分支" />                
                <input id="deleteBranch" class="nemobutton" type="button" value="删除分支" />
                <br />

                <a style="color: #000000">选中分支：</a><a style="color: #000000">选中版本:</a>
                <br />
                <input id="jumoVersion" class="nemobutton" type="button" value="查看选中版本" />
                <%-- jump to create page --%>
                
                <input id="redoVersion" class="nemobutton" type="button" value="回滚至选中版本" />

            </div>

            <%-- file list and file content --%>
            <div style="border-style: solid; border-width: medium; border-color: #ccc">
                <asp:ImageButton ID="backwardButton" runat="server" ImageUrl="~/images/backward.png" Height="32px" Width="32px" />
                <asp:ImageButton ID="forwardButton" runat="server" ImageUrl="~/images/forward.png" Height="32px" Width="32px" />
                <asp:ImageButton ID="rootButton" runat="server" ImageUrl="~/images/root.png" Height="32px" Width="32px" />
                <asp:ImageButton ID="createFileButton" runat="server" ImageUrl="~/images/file.png" Height="32px" Width="32px" />
                <asp:ImageButton ID="createFolderButton" runat="server" ImageUrl="~/images/folder.png" Height="32px" Width="32px" />
                &nbsp;
                <asp:Label ID="Label1" runat="server" Text="  Path:" Font-Size="34px"></asp:Label>
                <asp:Label ID="pathLabel" runat="server" Text="/" Font-Size="34px"></asp:Label>
            </div>
            
            <%-- list --%>
            <div style="border-style: solid; border-width: medium; border-color: #ccc">
                <div id="file_list" style="float: left; width: 30%" runat="server">
                    <p>ssss</p>
                    <p>ssss</p>
                    <p>ssss</p>
                    <p>ssss</p>
                    <p>ssss</p>
                </div>
                <div style="float: left; width:2%;border-style: solid; border-width: medium; border-color: #ccc;height:inherit"></div>
                <div id="file_content" style="float: right; width: 70%;" runat="server">
                    <dl>
                        <dt>Coffee</dt>
                        <dd>Black hot drinkddddddddddddddddddddddddddddddddddddddddddd</dd>
                        <dt>Milk</dt>
                        <dd>White cold drink</dd>
                    </dl>
                </div>
                <div style="clear: both; height: 0; font-size: 1px; line-height: 0px;"></div>
            </div>
        </form>

        <footer id="gtco-footer" role="contentinfo">
            <div class="gtco-container">
                <div class="row row-pb-md">

                    <div class="col-md-4">
                        <div class="gtco-widget">
                            <h3>About Us</h3>
                            <p>aaaaaaaaaaaaaaaaaaaaaaaaaaaa</p>
                        </div>
                    </div>

                    <div class="col-md-4 col-md-push-1">
                        <div class="gtco-widget">
                            <h3>Links</h3>
                            <ul class="gtco-footer-links">
                                <li><a href="#">Knowledge Base</a></li>
                                <li><a href="#">Career</a></li>
                                <li><a href="#">Press</a></li>
                                <li><a href="#">Terms of services</a></li>
                                <li><a href="#">Privacy Policy</a></li>
                            </ul>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="gtco-widget">
                            <h3>Get In Touch</h3>
                            <ul class="gtco-quick-contact">
                                <li><a href="#"><i class="icon-phone"></i>+1 234 567 890</a></li>
                                <li><a href="#"><i class="icon-mail2"></i>info@gettemplates.co</a></li>
                                <li><a href="#"><i class="icon-chat"></i>Live Chat</a></li>
                            </ul>
                        </div>
                    </div>

                </div>

                <div class="row copyright">
                    <div class="col-md-12">
                        <p class="pull-left">
                            <small class="block">&copy; 2016 Free HTML5. All Rights Reserved.</small>
                            <small class="block">More Templates <a href="http://www.cssmoban.com/" target="_blank" title="模板之家">模板之家</a> - Collect from <a href="http://www.cssmoban.com/" title="网页模板" target="_blank">网页模板</a> Demo Images: <a href="#" target="_blank">Unsplash</a></small>
                        </p>
                        <p class="pull-right">
                            <ul class="gtco-social-icons pull-right">
                                <li><a href="#"><i class="icon-twitter"></i></a></li>
                                <li><a href="#"><i class="icon-facebook"></i></a></li>
                                <li><a href="#"><i class="icon-linkedin"></i></a></li>
                                <li><a href="#"><i class="icon-dribbble"></i></a></li>
                            </ul>
                        </p>
                    </div>
                </div>

            </div>
        </footer>
    </div>

    <div class="gototop js-top">
        <a href="#" class="js-gotop"><i class="icon-arrow-up"></i></a>
    </div>

    <!-- jQuery -->
    <script src="js/jquery.min.js"></script>
    <!-- jQuery Easing -->
    <script src="js/jquery.easing.1.3.js"></script>
    <!-- Bootstrap -->
    <script src="js/bootstrap.min.js"></script>
    <!-- Waypoints -->
    <script src="js/jquery.waypoints.min.js"></script>
    <!-- Carousel -->
    <script src="js/owl.carousel.min.js"></script>
    <!-- countTo -->
    <script src="js/jquery.countTo.js"></script>
    <!-- Magnific Popup -->
    <script src="js/jquery.magnific-popup.min.js"></script>
    <script src="js/magnific-popup-options.js"></script>
    <!-- Main -->
    <script src="js/main.js"></script>

</body>
</html>

