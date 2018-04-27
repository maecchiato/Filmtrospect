using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ForumInterface
{
    public partial class Home : System.Web.UI.Page
    {
        int profileID;
        List<int> x = new List<int>();
        List<int> y = new List<int>();

        TimelineReference.TimelineServiceClient thread = new TimelineReference.TimelineServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeQueryStrings();
            getFeatured();
            FDisplay1();
            FDisplay2();
            FDisplay3();
            getTrending();
            TDisplay1();
            TDisplay2();
            TDisplay3();

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

        protected void lbFReadmore1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thread.aspx?id=" + profileID + "&movieID=" + x[0]);
        }

        protected void lbFReadmore2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thread.aspx?id=" + profileID + "&movieID=" + x[1]);
        }

        protected void lbFReadmore3_Click(object sender, EventArgs e)
        {
           Response.Redirect("Thread.aspx?id=" + profileID+"&movieID=" + x[2]);
        }

        protected void lbReadmore1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thread.aspx?id=" + profileID+"&movieID=" + x[2]);
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx?id=" + profileID);
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx?id=" + profileID);
        }

        protected void btnMovie_Click(object sender, EventArgs e)
        {
            Response.Redirect("Movies.aspx?id=" + profileID);
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx?id=" + profileID);
        }

        protected void btnOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("SplashPage.aspx");
        }

        //Rank 1 in Feature
        protected void FDisplay1()
        {
            fImg1.ImageUrl = "~/forum_img/movie_pic/" + thread.getMovieImage(x[0]);
            lblFTitle1.Text = thread.getMovieTitle(x[0]);
            lblFYear1.Text = ""+thread.getMovieYear(x[0]);
            lblFPrev1.Text = "<p>" + thread.getMoviePreview(x[0])+ "</p>";
            lblFRate1.Text = ""+thread.getRating(x[0]);
            lblFComment1.Text = "" + thread.getComment(x[0]);
        }
        //Rank 2 in Feature
        protected void FDisplay2()
        {
            fImg2.ImageUrl = "~/forum_img/movie_pic/" + thread.getMovieImage(x[1]);
            lblFTitle2.Text = thread.getMovieTitle(x[1]);
            lblFYear2.Text = "" + thread.getMovieYear(x[1]);
            lblFPrev2.Text = "<p>" + thread.getMoviePreview(x[1]) + "</p>";
            lblFRate2.Text = "" + thread.getRating(x[1]);
            lblFComment2.Text = "" + thread.getComment(x[1]);
        }

        //Rank 3 in Feature
        protected void FDisplay3()
        {
            fImg3.ImageUrl = "~/forum_img/movie_pic/" + thread.getMovieImage(x[2]);
            lblFTitle3.Text = thread.getMovieTitle(x[2]);
            lblFYear3.Text = "" + thread.getMovieYear(x[2]);
            lblFPrev3.Text = "<p>" + thread.getMoviePreview(x[2]) + "</p>";
            lblFRate3.Text = "" + thread.getRating(x[2]);
            lblFComment3.Text = "" + thread.getComment(x[2]);
        }

        protected void getFeatured()
        {
            x = thread.getFeaturedMovies();
        }

        protected void getTrending()
        {
            y = thread.getTrendingMovies();
        }
        //Rank1 in Trending
        protected void TDisplay1()
        {
            TImage1.ImageUrl = "~/forum_img/movie_pic/" + thread.getMovieImage(y[0]);
            TTitle1.Text = thread.getMovieTitle(y[0]);
            TYear1.Text = "" + thread.getMovieYear(y[0]);
            TPreview1.Text = "<p>" + thread.getMoviePreview(y[0]) + "</p>";
            TRate1.Text = "" + thread.getRating(y[0]);
            TComment1.Text = "" + thread.getComment(y[0]);
        }
        //Rank2 in Trending
        protected void TDisplay2()
        {
            TImage2.ImageUrl = "~/forum_img/movie_pic/" + thread.getMovieImage(y[1]);
            TTitle2.Text = thread.getMovieTitle(y[1]);
            TYear2.Text = "" + thread.getMovieYear(y[1]);
            TPreview2.Text = "<p>" + thread.getMoviePreview(y[1]) + "</p>";
            TRate2.Text = "" + thread.getRating(y[1]);
            TComment2.Text = "" + thread.getComment(y[1]);
        }
        //Rank3 in Trending
        protected void TDisplay3()
        {
            TImage3.ImageUrl = "~/forum_img/movie_pic/" + thread.getMovieImage(y[2]);
            TTitle3.Text = thread.getMovieTitle(y[2]);
            TYear3.Text = "" + thread.getMovieYear(y[2]);
            TPreview3.Text = "<p>" + thread.getMoviePreview(y[2]) + "</p>";
            TRate3.Text = "" + thread.getRating(y[2]);
            TComment3.Text = "" + thread.getComment(y[2]);
        }
        protected void InitializeQueryStrings()
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                profileID = Convert.ToInt32(Request.QueryString["id"]);
            }

            if (profileID != 1)
            {
                btnAdmin.Visible = false;
            }
            else
            {
                btnProfile.Visible = false;
            }
        }

        protected void lbTReadMore1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thread.aspx?id=" + profileID + "&movieID=" + y[0]);
        }

        protected void lbTReadMore2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thread.aspx?id=" + profileID + "&movieID=" + y[1]);
        }

        protected void lbTReadMore3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thread.aspx?id=" + profileID + "&movieID=" + y[2]);
        }

        protected void lblFTitle1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thread.aspx?id=" + profileID + "&movieID=" + x[0]);
        }

        protected void lblFTitle2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thread.aspx?id=" + profileID + "&movieID=" + x[1]);
        }

        protected void lblFTitle3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thread.aspx?id=" + profileID + "&movieID=" + x[2]);
        }

        protected void TTitle1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thread.aspx?id=" + profileID + "&movieID=" + y[0]);
        }

        protected void TTitle2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thread.aspx?id=" + profileID + "&movieID=" + y[1]);
        }

        protected void TTitle3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thread.aspx?id=" + profileID + "&movieID=" + y[2]);
        }
    }
}