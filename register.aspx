<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="test" %>

<!DOCTYPE HTML>

<html>
	<head>
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<title>注册</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<meta property="og:title" content=""/>
	<meta property="og:image" content=""/>
	<meta property="og:url" content=""/>
	<meta property="og:site_name" content=""/>
	<meta property="og:description" content=""/>
	
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

	</head>

	<body>
	<div class="gtco-loader"></div>
	<div id="gtco-subscribe">
		<div class="gtco-container">
			<div class="row animate-box">
				<div class="col-md-8 col-md-offset-2 text-center gtco-heading">
					<h2>注册</h2>
					<p>Be the first to know about the new update.</p>
				</div>
			</div>
			<div class="row animate-box">
				<div class="col-md-12">

                    <div style="width: 50%; margin-left: auto; margin-right: auto;">
                        <form id="form1" runat="server" method="get">
                            <label for="name" class="sr-only">Name</label>
                            <p>
                                <input type="text" runat="server" class="form-control" id="useraccount" placeholder="账号"></p>
                            <p>
                                <input type="text" runat="server" class="form-control" id="username" placeholder="用户名"></p>
                            <p>
                                <input type="password" runat="server" class="form-control" id="password" placeholder="密码"></p>
                            <p>
                                <input type="text" runat="server" class="form-control" id="description" placeholder="用户描述"></p>
                            <asp:Button ID="regButton" runat="server" Class="btn btn-default btn-block" Style="color: white" OnClick="regButton_Click" Text="提交" />
                        </form>
                    </div>

                </div>
			</div>
		</div>
	</div>

        <p class="pull-left">
            <small class="block">&copy; 2016 Nemo. All Rights Reserved.</small>
        </p>

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

