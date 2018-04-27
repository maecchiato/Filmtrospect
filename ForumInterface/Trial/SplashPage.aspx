<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SplashPage.aspx.cs" Inherits="ForumInterface.SplashPage" %>

<!DOCTYPE html>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"> 
<head runat="server">

        <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
        <title>Filmtrospect.</title>

        <!-- CSS -->
        <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500"/>
        <link rel="stylesheet" href="content/bootstrap.min.css"/>
        <link rel="stylesheet" href="fonts/font-awesome/css/font-awesome.min.css"/>
		<link rel="stylesheet" href="css/form-elements.css"/>
        <link rel="stylesheet" href="css/spstyle.css"/>

</head>

<body>
    <form runat="server">
		<!-- Top menu -->
		<nav class="navbar navbar-inverse navbar-no-bg" role="navigation">
			<div class="container">
				<div class="navbar-header">
					<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#top-navbar-1">
						<span class="sr-only">Toggle navigation</span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					</button>
					<a class="navbar-brand" href="SplashPage.aspx"></a>
				</div>
				<!-- Collect the nav links, forms, and other content for toggling -->
				<div class="collapse navbar-collapse" id="top-navbar-1">
					<ul class="nav navbar-nav navbar-right">
						<li>
                           <div class="input-group row">
  <div class="col-xs-4">
    <label for="ex1"></label>
      <asp:TextBox ID="txtUsername" Height="25" Width="200px" placeholder="Username" runat="server"></asp:TextBox>
  </div>
  <div class="col-xs-4">
    <label for="ex2"></label>
      <asp:TextBox ID="txtPassword" TextMode="Password" ForeColor="Black" Height="26" Width="200px" placeholder="     Password" runat="server"></asp:TextBox>
  </div>
<div class="col-xs-4" style="text-align:left;">
    <asp:Button ID="btnLogin" CssClass="btn" runat="server" OnClick="btnLogin_Click" Text="Log in" /><br />
    <asp:Label ID="lblErrorLogin" runat="server"></asp:Label>
    </div>
</div> 
						</li>
					</ul>
				</div>
            </div>
		</nav>

        <!-- Top content -->
        <div class="top-content">
        	
            <div class="inner-bg">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-6 text">
                            <h1><strong>Film</strong>trospect</h1>
                            <div class="description">
                            	<p>
	                            	Read reviews on the lastest and featured movies 
                            	</p>
                            </div>
                        </div>
                        <div class="col-sm-6 form-box">
                        	<div class="form-top">
                        		<div class="form-top-left">
                        			<h3>Sign up now</h3>
                            		<p>Fill in the form below to get instant access:</p>
                        		</div>
                        		<div class="form-top-right">
                        			<i class="fa fa-pencil"></i>
                        		</div>
                        		<div class="form-top-divider"></div>
                            </div>
                            <div class="form-bottom">
			                    	<div class="form-group">
			                    		<label class="sr-only" for="form-first-name">First name</label>
                                        <asp:TextBox ID="txtFname"  placeholder="First name" class="form-first-name form-control" runat="server"></asp:TextBox>
                                    </div>
			                        <div class="form-group">
			                        	<label class="sr-only" for="form-last-name">Last name</label>
                                         <asp:TextBox ID="txtLname"  placeholder="Last name" class="form-last-name form-control" runat="server"></asp:TextBox>
			                        </div>
                                    <div class="form-group">
			                        	<label class="sr-only" for="form-dob">Date of Birth</label>
                                         <asp:TextBox ID="txtDob" Height="50px" TextMode="Date" placeholder="Date of Birth" class="form-dob form-control" runat="server"></asp:TextBox>
			                        </div>
                                     <div class="form-group">
			                        	<label class="sr-only" for="form-username">Username</label>
                                         <asp:TextBox ID="txtNewUsername" Height="50px" placeholder="Username" class="form-username form-control" runat="server"></asp:TextBox>
			                        </div>
                                    <div class="form-group">
			                        	<label class="sr-only" for="form-password">Password</label>
                                         <asp:TextBox ID="txtNewPassword" TextMode="Password" Height="50px" placeholder="New Password" class="form-password form-control" runat="server"></asp:TextBox>
			                        </div>
			                        <div class="form-group">
			                        	<label class="sr-only" for="form-email">Email</label>
                                         <asp:TextBox ID="txtEmail" TextMode="Email" Height="50px" placeholder="Email Address" class="form-email form-control" runat="server"></asp:TextBox>
			                        </div>
                                    <asp:Button ID="Signup" runat="server" Text="Sign up" Cssclass="btn" OnClick="Signup_Click"/>
                                    <asp:Label ID="lblResult" runat="server" Text="" ForeColor="White" BackColor="#2d1b11"></asp:Label>
                                    
                                 
		                    </div>
                        </div>
                    </div>
                </div>
            </div>
            
        </div>

</form>
        <!-- Javascript -->
        <script src="scripts/jquery-1.11.1.min.js"></script>
        <script src="scripts/bootstrap.min.js"></script>
        <script src="scripts/jquery.backstretch.min.js"></script>
        <script src="scripts/retina-1.1.0.min.js"></script>
        <script src="scripts/scripts.js"></script>

</body>
</html>

