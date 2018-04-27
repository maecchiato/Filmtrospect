<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="ForumInterface.Movies" %>

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
							<li><asp:LinkButton ID="btnHome" OnClick="btnHome_Click" runat="server">Home</asp:LinkButton></li>
							<li class="has-dropdown active">
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

	<div id="fh5co-blog" class="fh5co-section" style="padding-bottom:10em">
		<div class="container cont" style="margin-bottom: 0px">
            <div class="space"></div>
            <asp:Panel ID="panelMovies" runat="server">
			<div id ="rowDiv" class="row" runat="server">
       
			</div>
        </asp:Panel>
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
