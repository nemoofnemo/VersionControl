﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_page.aspx.cs" Inherits="user_page" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>用户工作空间</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <meta property="og:title" content="" />
    <meta property="og:image" content="" />
    <meta property="og:url" content="" />
    <meta property="og:site_name" content="" />
    <meta property="og:description" content="" />

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
    <div id="page">
        <nav class="gtco-nav" role="navigation">
            <div class="gtco-container">
                <div class="row">
                    <div class="col-sm-4 col-xs-12">
                        <div id="gtco-logo">工作空间<em>.</em></div>
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
                                <h1 class="animate-box" data-animate-effect="fadeInUp" id="username" runat="server">name</h1>
                                <h2 class="animate-box" data-animate-effect="fadeInUp" id="description" runat="server">desc</h2>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </header>

        <div id="gtco-history" class="gtco-section border-bottom animate-box">
            <div class="gtco-container">

                <div class="row">
                    <div class="col-md-8 col-md-offset-2 text-center gtco-heading">
                        <h2>代码仓库列表</h2>
                        <div style="width: 60%; margin-left: auto; margin-right: auto;">
                            <input id="createButton" type="button" class="btn btn-default btn-block" value="创建代码仓库!" onclick="window.location.href = 'create_page.aspx'" />
                        </div>
                    </div>
                </div>

                <div class="row row-pb-md">
                    <div style="width: 60%; margin-left: auto; margin-right: auto;">
                        <style type="text/css">
                            .lib_border {
                                border-style: solid;
                                border-width: medium;
                                border-color: silver;
                            }
                        </style>
                        <div id="lib_list" runat="server">
                            <div class="lib_border">
                                <p>项目名称：<a href="#">null</a></p>
                                <p>创建时间：null</p>
                                <p>项目说明：null</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-12">
            <small class="block">&copy; 2016 nemo. All Rights Reserved.</small>
        </div>
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
