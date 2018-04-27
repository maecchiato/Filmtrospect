using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ForumInterface
{
    public partial class Profile : System.Web.UI.Page
    {
        int profileID;

        AccountReference.AccountServiceClient accountRef = new AccountReference.AccountServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayProfile();

            
            if (profileID != 1)
            {
                btnAdmin.Visible = false;
            }
            
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string pic = FileUpload.FileName;
           
            if(pic != null)
            {
                imgPic.ImageUrl = "~/forum_img/profile_pic/" + accountRef.changeProfilePic(pic, profileID);
            }         
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx?id=" + profileID);
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx?id=" + profileID);
        }

        protected void btnMovie_Click(object sender, EventArgs e)
        {
            Response.Redirect("Movies.aspx?id=" + profileID);
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx?id=" + profileID);
        }

        protected void action_Click(object sender, EventArgs e)
        {
            Response.Redirect("Movies.aspx?id=" + profileID + "&category=Action");
        }

        protected void animated_Click(object sender, EventArgs e)
        {
            Response.Redirect("Movies.aspx?id=" + profileID + "&category=Animated");
        }

        protected void comedy_Click(object sender, EventArgs e)
        {
            Response.Redirect("Movies.aspx?id=" + profileID + "&category=Comedy");
        }

        protected void drama_Click(object sender, EventArgs e)
        {
            Response.Redirect("Movies.aspx?id=" + profileID + "&category=Drama");
        }

        protected void fantasy_Click(object sender, EventArgs e)
        {
            Response.Redirect("Movies.aspx?id=" + profileID + "&category=Fantasy");
        }

        protected void horror_Click(object sender, EventArgs e)
        {
            Response.Redirect("Movies.aspx?id=" + profileID + "&category=Horror");
        }

        protected void mystery_Click(object sender, EventArgs e)
        {
            Response.Redirect("Movies.aspx?id=" + profileID + "&category=Mystery");
        }

        protected void romance_Click(object sender, EventArgs e)
        {
            Response.Redirect("Movies.aspx?id=" + profileID + "&category=Romance");
        }

        protected void scifi_Click(object sender, EventArgs e)
        {
            Response.Redirect("Movies.aspx?id=" + profileID + "&category=Sci-Fi");
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            lblProfBio.Text = accountRef.changeBio(txtBio.Text, profileID);
        }

        protected void btnOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("SplashPage.aspx");
        }
        
        protected void DisplayProfile()
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                profileID = Convert.ToInt32(Request.QueryString["id"]);
                imgPic.ImageUrl = "~/forum_img/profile_pic/" + accountRef.getProfilePicture(profileID);
                lblProfBio.Text = accountRef.getBio(profileID);
                lblProfUsername.Text = accountRef.getUserName(profileID);
                lblName.Text = accountRef.getName(profileID);
                lblDob.Text = accountRef.getDob(profileID);
                lblEmail.Text = accountRef.getEmail(profileID);
                foreach (string a in accountRef.activityList(profileID))
                {
                    lblActivity.Text += a + "<br/>";
                }
            }

        }
    }
}