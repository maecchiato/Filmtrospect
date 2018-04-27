using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ForumInterface
{
    public partial class Movies : System.Web.UI.Page
    {
        int profileID;
        string movieCategory;
        List<int> movieList;

        TimelineReference.TimelineServiceClient tr = new TimelineReference.TimelineServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeQueryStrings();
            DisplayDynamicMovies();

            
           

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

        protected void btnReadMore_Click(object sender, EventArgs e)
        {
            Response.Redirect("Thread.aspx?id=" + profileID);
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

            if (!String.IsNullOrWhiteSpace(Request.QueryString["category"]))
            {
                movieCategory = Request.QueryString["category"];
                movieList = tr.getSortedMovies(movieCategory);
            }
            else
            {
                movieList = tr.getAllMovies();
            }
        }

        protected void DisplayDynamicMovies()
        {
            foreach (int m in movieList)
            {
                //Column, for each contains a movie
                System.Web.UI.HtmlControls.HtmlGenericControl divCol = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                divCol.Attributes.Add("class", "col-md-4");
                //Animation for the Column
                System.Web.UI.HtmlControls.HtmlGenericControl divAni = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                divAni.Attributes.Add("class", "fh5co-blog animate-box");
                //Panel for movie attributes
                Panel indvPanel = new Panel();
                //Picture
                System.Web.UI.HtmlControls.HtmlGenericControl divPic = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                divPic.Attributes.Add("class", "blog-bg");
                Image movPoster = new Image();
                movPoster.ImageUrl = "~/forum_img/movie_pic/" + tr.getMovieImage(m);
                movPoster.CssClass = "img";

                System.Web.UI.HtmlControls.HtmlGenericControl divText = new System.Web.UI.HtmlControls.HtmlGenericControl("div"); //add to panel
                divText.Attributes.Add("class", "blog-text");
                //Insert Picture to its Div
                divPic.Controls.Add(movPoster);
                //h1
                System.Web.UI.HtmlControls.HtmlGenericControl h1Title = new System.Web.UI.HtmlControls.HtmlGenericControl("h1"); //add to div text
                                                                                                                                 //Title
                LinkButton lnkTitle = new LinkButton();
                lnkTitle.Text = tr.getMovieTitle(m);
                lnkTitle.PostBackUrl = "Thread.aspx?id=" + profileID + "&movieID=" + m;
                //Set Title to H1
                h1Title.Controls.Add(lnkTitle);
                //Span for Year
                System.Web.UI.HtmlControls.HtmlGenericControl span = new System.Web.UI.HtmlControls.HtmlGenericControl("span"); //add to div text
                span.Attributes.Add("class", "posted_on");
                Label movieYear = new Label();
                //Set text for year
                movieYear.Text = Convert.ToString(tr.getMovieYear(m));
                span.Controls.Add(movieYear);
                //Set text for preview
                Label moviePreview = new Label();
                moviePreview.Text = "<p>" + tr.getMoviePreview(m) + "</p>";
                //Create UL and LI
                System.Web.UI.HtmlControls.HtmlGenericControl foot = new System.Web.UI.HtmlControls.HtmlGenericControl("ul");//add to div text
                foot.Attributes.Add("class", "stuff");

                //rating
                System.Web.UI.HtmlControls.HtmlGenericControl rateLI = new System.Web.UI.HtmlControls.HtmlGenericControl("li");//add to ul
                                                                                                                               //icon
                System.Web.UI.HtmlControls.HtmlGenericControl iconStar = new System.Web.UI.HtmlControls.HtmlGenericControl("i");
                iconStar.Attributes.Add("class", "icon-star");
                //Label for rating
                Label rate = new Label();
                rate.Text = Convert.ToString(tr.getRating(m));
                //add icon and label to rateLI
                rateLI.Controls.Add(iconStar);
                rateLI.Controls.Add(rate);

                //comment
                System.Web.UI.HtmlControls.HtmlGenericControl commentLI = new System.Web.UI.HtmlControls.HtmlGenericControl("li");//add to ul
                                                                                                                                  //icon
                System.Web.UI.HtmlControls.HtmlGenericControl iconPen = new System.Web.UI.HtmlControls.HtmlGenericControl("i");
                iconPen.Attributes.Add("class", "icon-pen");
                //Label for comment
                Label comment = new Label();
                comment.Text = Convert.ToString(tr.getComment(m));
                commentLI.Controls.Add(iconPen);
                commentLI.Controls.Add(comment);

                //Read More
                System.Web.UI.HtmlControls.HtmlGenericControl readLI = new System.Web.UI.HtmlControls.HtmlGenericControl("li"); // add to ul
                readLI.Attributes.Add("class", "selected");
                LinkButton readMore = new LinkButton();
                readMore.Text = "Read More";
                readMore.PostBackUrl = "Thread.aspx?id=" + profileID + "&movieID=" + m;
                readLI.Controls.Add(readMore);

                //fill UL
                foot.Controls.Add(rateLI);
                foot.Controls.Add(commentLI);
                foot.Controls.Add(readLI);
                //fill div text
                divText.Controls.Add(h1Title);
                divText.Controls.Add(span);
                divText.Controls.Add(moviePreview);
                divText.Controls.Add(foot);
                //fill panel
                indvPanel.Controls.Add(divPic);
                indvPanel.Controls.Add(divText);

                //fill divAni
                divAni.Controls.Add(indvPanel);
                //fill divColumn
                divCol.Controls.Add(divAni);
                //send this whole thing to main page
                rowDiv.Controls.Add(divCol);
            }
        }
    }
}