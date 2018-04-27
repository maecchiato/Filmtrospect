<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ForumInterface.Home" %>

<!DOCTYPE HTML>
<html>
	<head>
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<title>Filmtrospect.</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<link href="https://fonts.googleapis.com/css?family=Cormorant+Garamond:300,300i,400,400i,500,600i,700" rel="stylesheet">
	<link href="https://fonts.googleapis.com/css?family=Satisfy" rel="stylesheet">

	<link rel="stylesheet" href="css/animate.css">
	<link rel="stylesheet" href="css/icomoon.css">
	<link rel="stylesheet" href="content/bootstrap.css">
	<link rel="stylesheet" href="css/flexslider.css">
	<link rel="stylesheet" href="css/style.css">
	<script src="scripts/modernizr-2.6.2.min.js"></script>

	</head>
	<body>
        <form runat="server">
		
	<div class="fh5co-loader"></div>
	
	<div id="page">
	<nav class="fh5co-nav" role="navigation">
		<!-- <div class="top-menu"> -->
			<div class="container">
				<div class="row">
					<div class="col-xs-12 text-center logo-wrap">
						<div id="fh5co-logo"><a href="Home.aspx">FILMTROSPECT<span>.</span></a></div>
					</div>
					<div class="col-xs-12 text-center menu-1 menu-wrap">
						<ul>
							<li class="active"><asp:LinkButton ID="btnHome" OnClick="btnHome_Click" runat="server">Home</asp:LinkButton></li>
							<li class="has-dropdown">
								<asp:LinkButton ID="btnMovie" OnClick="btnMovie_Click" runat="server">Movies</asp:LinkButton>
								<ul class="dropdown">
                                    <li class="selected"><asp:LinkButton ID="action" OnClick="action_Click" runat="server">Action</asp:LinkButton></li>
                                    <li class="selected"><asp:LinkButton ID="animated" OnClick="animated_Click" runat="server">Animated</asp:LinkButton></li>
                                    <li class="selected"><asp:LinkButton ID="comedy" OnClick="comedy_Click" runat="server">Comedy</asp:LinkButton></li>
                                    <li class="selected"><asp:LinkButton ID="drama" OnClick="drama_Click" runat="server">Drama</asp:LinkButton></li>
                                    <li class="selected"><asp:LinkButton ID="fantasy" OnClick="fantasy_Click" runat="server">Fantasy</asp:LinkButton></li>
                                    <li class="selected"><asp:LinkButton ID="horror" OnClick="horror_Click" runat="server">Horror</asp:LinkButton></li>
                                    <li class="selected"><asp:LinkButton ID="mystery" OnClick="mystery_Click" runat="server">Mystery</asp:LinkButton></li>
                                    <li class="selected"><asp:LinkButton ID="romance" OnClick="romance_Click" runat="server">Romance</asp:LinkButton></li>
                                    <li class="selected"><asp:LinkButton ID="scifi" OnClick="scifi_Click" runat="server">Sci-Fi</asp:LinkButton></li>
								</ul>
							</li>
                            <li><asp:LinkButton ID="btnProfile" OnClick="btnProfile_Click" runat="server">Profile</asp:LinkButton></li>
							<li><asp:LinkButton ID="btnAdmin" OnClick="btnAdmin_Click" runat="server">Admin</asp:LinkButton></li>
                            <li><asp:LinkButton ID="linkLogout" data-toggle="modal" data-target="#logout" runat="server">Logout</asp:LinkButton></li>
						</ul>
					</div>
				</div>
				
			</div>
		<!-- </div> -->
	</nav>

<!-- Modal -->
<div id="logout" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
          <asp:Label ID="lblConfirm" ForeColor="Black" runat="server" Text="Are you sure you want to log out?"></asp:Label>
        <button type="button" class="close" data-dismiss="modal">&times;</button>
      </div>
      <div class="modal-footer">
          <asp:Button ID="btnOut" class="btn btn-default" OnClick="btnOut_Click" runat="server" Text="Log Out" />
      </div>
    </div>

  </div>
</div>
<%--End of Modal--%>

	<header id="fh5co-header" class="fh5co-cover js-fullheight" role="banner" style=" background-image: url('images/Product-Photography.png');" data-stellar-background-ratio="0.5">
		<div class="overlay"></div>
		<div class="container">
			<div class="row">
				<div class="col-md-12 text-center">
					<div class="display-t js-fullheight">
						<div class="display-tc js-fullheight animate-box" data-animate-effect="fadeIn">
							<h1>FILMTROSPECT</h1>
							<h2>Lights. Camera. Action.</h2>
						</div>
					</div>
				</div>
			</div>
		</div>
	</header>

	<div id="fh5co-blog" class="fh5co-section">
		<div class="container cont" style="margin-bottom: 0px">
			<div class="row animate-box">
				<div class="col-md-8 col-md-offset-2 text-center fh5co-heading animate-box">
					<h1>FEATURED</h1>
				</div>
			</div>
			<div class="row">
				<div class="col-md-4">
					<div class="fh5co-blog animate-box">
                        <div class="blog-bg"><asp:Image ID="fImg1" CssClass="img" runat="server"/></div>
						<div class="blog-text">
                           <h1><asp:LinkButton ID="lblFTitle1" OnClick="lblFTitle1_Click" runat="server"></asp:LinkButton></h1>
                            <span class="posted_on"><asp:Label ID="lblFYear1" runat="server"></asp:Label></span>
                            <asp:Label ID="lblFPrev1" runat="server"></asp:Label>
                            <ul class="stuff">
								<li><i class="icon-star"></i><asp:Label ID="lblFRate1" runat="server" Text="Label"></asp:Label></li>
								<li><i class="icon-pen"><asp:Label ID="lblFComment1" runat="server" Text="Label"></asp:Label></i></li>
								<li class="selected"><asp:LinkButton ID="lblFReadmore1" OnClick="lbFReadmore1_Click"  runat="server">Read More</asp:LinkButton></li>
							</ul>   
						</div> 
					</div>
				</div>

                <div class="col-md-4">
					<div class="fh5co-blog animate-box">
                        <div class="blog-bg"><asp:Image ID="fImg2" CssClass="img" runat="server" /></div>
						<div class="blog-text">
                           <h1><asp:LinkButton ID="lblFTitle2" OnClick="lblFTitle2_Click" runat="server"></asp:LinkButton></h1>
                            <span class="posted_on"><asp:Label ID="lblFYear2" runat="server"></asp:Label></span>
                            <asp:Label ID="lblFPrev2" runat="server"></asp:Label>
                            <ul class="stuff">
								<li><i class="icon-star"></i><asp:Label ID="lblFRate2" runat="server" ></asp:Label></li>
								<li><i class="icon-pen"><asp:Label ID="lblFComment2" runat="server"></asp:Label></i></li>
								<li class="selected"><asp:LinkButton ID="lblFReadmore2" OnClick="lbFReadmore2_Click"  runat="server">Read More</asp:LinkButton></li>
							</ul>     
						</div> 
					</div>
				</div>

				 <div class="col-md-4">
					<div class="fh5co-blog animate-box">
                        <div class="blog-bg"><asp:Image ID="fImg3" CssClass="img" runat="server" /></div>
						<div class="blog-text">
                           <h1><asp:LinkButton ID="lblFTitle3" OnClick="lblFTitle3_Click" runat="server">Title1</asp:LinkButton></h1>
                            <span class="posted_on"><asp:Label ID="lblFYear3" runat="server" Text="Jan 01, 2017"></asp:Label></span>
                            <asp:Label ID="lblFPrev3" runat="server" Text="<p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts.</p>"></asp:Label>
                            <ul class="stuff">
								<li><i class="icon-star"></i><asp:Label ID="lblFRate3" runat="server" Text="Label"></asp:Label></li>
								<li><i class="icon-pen"><asp:Label ID="lblFComment3" runat="server" Text="Label"></asp:Label></i></li>
								<li class="selected"><asp:LinkButton ID="lblFReadmore3" OnClick="lbFReadmore3_Click"  runat="server">Read More</asp:LinkButton></li>
							</ul>          
						</div> 
					</div>
				</div>
			</div>
		</div>
	</div>

	<div id="fh5co-blogg" class="fh5co-section">
		<div class="container cont" style="margin-bottom: 0px">
			<div class="row animate-box">
				<div class="col-md-8 col-md-offset-2 text-center fh5co-heading animate-box">
					<h1>TRENDING</h1>
				</div>
			</div>
			<div class="row">
				<div class="col-md-4">
					<div class="fh5co-blog animate-box">
                        <div class="blog-bg"><asp:Image ID="TImage1" CssClass="img" runat="server" /></div>
						<div class="blog-text">
                           <h1><asp:LinkButton ID="TTitle1" OnClick="TTitle1_Click" runat="server"></asp:LinkButton></h1>
                            <span class="posted_on"><asp:Label ID="TYear1" runat="server"></asp:Label></span>
                            <asp:Label ID="TPreview1" runat="server"></asp:Label>
                            <ul class="stuff">
								<li><i class="icon-star"></i><asp:Label ID="TRate1" runat="server" Text="Label"></asp:Label></li>
								<li><i class="icon-pen"><asp:Label ID="TComment1" runat="server" Text="Label"></asp:Label></i></li>
								<li class="selected"><asp:LinkButton ID="lbTReadMore1" OnClick="lbTReadMore1_Click" runat="server">Read More</asp:LinkButton></li>
							</ul>   
						</div> 
					</div>
				</div>

                <div class="col-md-4">
					<div class="fh5co-blog animate-box">
                        <div class="blog-bg"><asp:Image ID="TImage2" CssClass="img" runat="server" /></div>
						<div class="blog-text">
                           <h1><asp:LinkButton ID="TTitle2" OnClick="TTitle2_Click" runat="server"></asp:LinkButton></h1>
                            <span class="posted_on"><asp:Label ID="TYear2" runat="server"></asp:Label></span>
                            <asp:Label ID="TPreview2" runat="server"></asp:Label>
                            <ul class="stuff">
								<li><i class="icon-star"></i><asp:Label ID="TRate2" runat="server" Text="Label"></asp:Label></li>
								<li><i class="icon-pen"><asp:Label ID="TComment2" runat="server" Text="Label"></asp:Label></i></li>
								<li class="selected"><asp:LinkButton ID="lbTReadMore2" OnClick="lbTReadMore2_Click"  runat="server">Read More</asp:LinkButton></li>
							</ul>     
						</div> 
					</div>
				</div>

				 <div class="col-md-4">
					<div class="fh5co-blog animate-box">
                        <div class="blog-bg"><asp:Image ID="TImage3" CssClass="img" runat="server"/></div>
						<div class="blog-text">
                           <h1><asp:LinkButton ID="TTitle3" OnClick="TTitle3_Click" runat="server"></asp:LinkButton></h1>
                            <span class="posted_on"><asp:Label ID="TYear3" runat="server"></asp:Label></span>
                            <asp:Label ID="TPreview3" runat="server"></asp:Label>
                            <ul class="stuff">
								<li><i class="icon-star"></i><asp:Label ID="TRate3" runat="server" Text="Label"></asp:Label></li>
								<li><i class="icon-pen"><asp:Label ID="TComment3" runat="server" Text="Label"></asp:Label></i></li>
								<li class="selected"><asp:LinkButton ID="lbTReadMore3" OnClick="lbTReadMore3_Click"  runat="server">Read More</asp:LinkButton></li>
							</ul>      
						</div> 
					</div>
				</div>
			</div>
		</div>
	</div>
	
	<footer id="fh5co-footer" role="contentinfo" class="fh5co-section">
		<div class="container">
			<div class="row copyright">
				<div class="col-md-12 text-center">
					<p>
						<small class="block">&copy; 2017 Filmtrospect. All Rights Reserved.</small> 
						<small class="block">Designed by A. C. D. J.</small>
					</p>
				</div>
			</div>

		</div>
	</footer>
	</div>

	<div class="gototop js-top">
		<a href="#" class="js-gotop"><i class="icon-arrow-up22"></i></a>
	</div>
	
	<!-- jQuery -->
	<script src="scripts/jquery.min.js"></script>
	<!-- jQuery Easing -->
	<script src="scripts/jquery.easing.1.3.js"></script>
	<!-- Bootstrap -->
	<script src="scripts/bootstrap.min.js"></script>
	<!-- Waypoints -->
	<script src="scripts/jquery.waypoints.min.js"></script>
	<!-- Waypoints -->
	<script src="scripts/jquery.stellar.min.js"></script>
	<!-- Flexslider -->
	<script src="scripts/jquery.flexslider-min.js"></script>
	<!-- Main -->
	<script src="scripts/main.js"></script>
            </form>
	</body>
</html>


