using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ForumInterface
{
    public partial class Thread : System.Web.UI.Page
    {
        int profileID;
        int movieID;
        DateTime time;
        string comment;
        int rate;
        TimelineReference.TimelineServiceClient tr = new TimelineReference.TimelineServiceClient();
        CommentReference.CommentServiceClient com = new CommentReference.CommentServiceClient();
        AccountReference.AccountServiceClient ar = new AccountReference.AccountServiceClient();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (profileID != 1)
            {
                btnAdmin.Visible = false;
            }
            else
            {
                btnProfile.Visible = false;
            }

            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                profileID = Convert.ToInt32(Request.QueryString["id"]);
            }


            if (!String.IsNullOrWhiteSpace(Request.QueryString["movieID"]))
            {
                movieID = Convert.ToInt32(Request.QueryString["movieID"]);
                //display movie details
                DisplayMovieDetails();

                //for each categories
                DisplayCategories();
                //dynamic stars for the win!!!!
                RateStars();
                DisplayComments();
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx?id=" + profileID);
        }

        protected void btnMovie_Click(object sender, EventArgs e)
        {
            Response.Redirect("Movies.aspx?id=" + profileID);
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

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx?id=" + profileID);
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx?id=" + profileID);
        }

        protected void btnOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("SplashPage.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

             AddComment();
            Response.Redirect("Thread.aspx?id=" + profileID + "&movieID=" +movieID);


        }
       
       protected void AddComment()
        {
            try
            {
                rate = Convert.ToInt32(ddlRatings.Text);
                time = DateTime.Now;
                comment = txtComment.Value;
                txtError.Text = com.createComment(profileID, comment, time, movieID, rate);
                txtComment.Value = "";
                ddlRatings.ClearSelection();
            }
            catch
            {
                txtError.Text = "COMMENT AND RATING REQUIRED.";
            }
        }

        //display movie details
        protected void DisplayMovieDetails()
        {
          
            imgMovie.ImageUrl = "~/forum_img/movie_pic/" + tr.getMovieImage(movieID);
            lblMovieTitle.Text = tr.getMovieTitle(movieID);
            lblMovieYear.Text = "" + tr.getMovieYear(movieID);
            lblMoviePlot.Text = tr.getMoviePlot(movieID);
            lblCommentCount.Text = "" + tr.getComment(movieID);

        }
        //for each category 
        protected void DisplayCategories()
        {
            foreach (string c in tr.getMovieCategories(movieID))
            {
                System.Web.UI.HtmlControls.HtmlGenericControl catspan = new System.Web.UI.HtmlControls.HtmlGenericControl("span");
                catspan.Attributes.Add("class", "label label-success");
                catspan.InnerText = c;
                catID.Controls.Add(catspan);
                catID.Controls.Add(new LiteralControl("   "));

            }

        }
        //Stars rating
        protected void RateStars()
        {
            int x = tr.getRating(movieID);
            int y = 5 - x;

            while (x > 0)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl spanStar = new System.Web.UI.HtmlControls.HtmlGenericControl("span");
                spanStar.Attributes.Add("class", "glyphicon glyphicon-star");
                h5.Controls.Add(spanStar);
                x -= 1;
            }
            while (y > 0)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl spanStarEmpty = new System.Web.UI.HtmlControls.HtmlGenericControl("span");
                spanStarEmpty.Attributes.Add("class", "glyphicon glyphicon-star-empty");
                h5.Controls.Add(spanStarEmpty);
                y -= 1;
            }
        
         }

        protected void DisplayComments()
        {
            //display comments
            foreach (int cID in tr.getMovieComments(movieID))
            {
                int commenterID = tr.getCommenter(cID);

                //div for image
                System.Web.UI.HtmlControls.HtmlGenericControl divImage = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                divImage.Attributes.Add("class", "col-sm-2 text-center");
                Image userImg = new Image();
                userImg.ImageUrl = "~/forum_img/profile_pic/" + ar.getProfilePicture(commenterID);
                userImg.Attributes.Add("class", "img-circle");
                userImg.Width = 65;
                userImg.Height = 65;
                divImage.Controls.Add(userImg);
                //div for texts
                System.Web.UI.HtmlControls.HtmlGenericControl divTexts = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                divTexts.Attributes.Add("class", "col-sm-10");
                System.Web.UI.HtmlControls.HtmlGenericControl name = new System.Web.UI.HtmlControls.HtmlGenericControl("h4");
                System.Web.UI.HtmlControls.HtmlGenericControl time = new System.Web.UI.HtmlControls.HtmlGenericControl("small");
                Label lblName = new Label();
                Label lblTime = new Label();
                lblName.Text = ar.getName(commenterID) + "      ";
                lblTime.Text = tr.getCommentTime(cID);
                time.Controls.Add(lblTime);

                name.Controls.Add(lblName);
                name.Controls.Add(time);

                // for dynamic comment rates
                int x = tr.getCommentRate(cID);
                int y = 5 - x;
                System.Web.UI.HtmlControls.HtmlGenericControl stars = new System.Web.UI.HtmlControls.HtmlGenericControl("h5");
                while (x > 0)
                {
                    System.Web.UI.HtmlControls.HtmlGenericControl spanStar = new System.Web.UI.HtmlControls.HtmlGenericControl("span");
                    spanStar.Attributes.Add("class", "glyphicon glyphicon-star");
                    stars.Controls.Add(spanStar);
                    x -= 1;
                }
                while (y > 0)
                {
                    System.Web.UI.HtmlControls.HtmlGenericControl spanStarEmpty = new System.Web.UI.HtmlControls.HtmlGenericControl("span");
                    spanStarEmpty.Attributes.Add("class", "glyphicon glyphicon-star-empty");
                    stars.Controls.Add(spanStarEmpty);
                    y -= 1;
                }
                Label lblIndvComment = new Label();
                lblIndvComment.Text = "<p>" + tr.getCommentDesc(cID) + "</p> <br/>";

                //fill divTexts
                divTexts.Controls.Add(name);
                divTexts.Controls.Add(stars);
                divTexts.Controls.Add(lblIndvComment);

                //user Rows
                commentRow.Controls.Add(divImage);
                commentRow.Controls.Add(divTexts);
                foot.Controls.Add(new LiteralControl("<br/>"));
                foot.Controls.Add(new LiteralControl("<br/>"));
                foot.Controls.Add(new LiteralControl("<br/>"));
                foot.Controls.Add(new LiteralControl("<br/>"));
                foot.Controls.Add(new LiteralControl("<br/>"));
                foot.Controls.Add(new LiteralControl("<br/>"));
            }
        }
    }
}