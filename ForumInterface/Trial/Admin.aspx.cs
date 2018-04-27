using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ForumInterface
{
    public partial class Admin : System.Web.UI.Page
    {
        int profileID;

        string title, plot, preview, pic;
        int year, movieID;

        ThreadReference.ThreadServiceClient thread = new ThreadReference.ThreadServiceClient();
        TimelineReference.TimelineServiceClient timeline = new TimelineReference.TimelineServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            AutomaticMovieDisplay();
            InitializeQueryStrings();


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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            InitializeVariables();
            if (uploadPoster.HasFile)
            {
                CreateMovie();
                AssignCategories();
            }
            else
            {
                lblResult.Text = "PLEASE UPLOAD A PICTURE";
            }
            RefreshPage();
        }

        protected void RefreshPage()
        {
            txtAddTitle.Text = "";
            txtAddYear.Text = "";
            cbCategory.ClearSelection();
            txtAddPreview.Value = "";
            txtAddPlot.Value = "";

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlFilterCat.Text.Equals(""))
            {
                //If not filtered nor in order 
                if (ddlOrderby.Text.Equals(""))
                {
                    AutomaticMovieDisplay();
                }
                else
                {
                    //Not Filtered, Order by Rating
                    if (ddlOrderby.Text.Equals("Rating"))
                    {
                        OrderByRating();
                    }
                    //Not Filtered, Order by Comment Count
                    if (ddlOrderby.Text.Equals("Comment"))
                    {
                        OrderByComment();
                    }
                }
            }
            else
            {
                //If filtered but not in order 
                if (ddlOrderby.Text.Equals(""))
                {
                    FilteredMovie();
                }
                else
                {
                    //Filtered, Order by Rating
                    if (ddlOrderby.Text.Equals("Rating"))
                    {
                        FilteredOrderByRating();
                    }
                    //Filtered, Order by Comment Count
                    if (ddlOrderby.Text.Equals("Comment"))
                    {
                        FilteredOrderByComment();
                    }
                }

            }
        }



        //Default movie list display
        protected void AutomaticMovieDisplay()
        {
            const string strF = "{0,-27} {1,-7} {2,-9}";
            string header = String.Format(strF, "Title", "Rating", "Comments");
            string list = "";
            foreach (int m in timeline.getAllMovies())
            {
                string movieEntry;
                string movie = timeline.getMovieTitle(m);
                string rate = timeline.getRating(m) + "/5";
                string comment = "" + timeline.getComment(m);
                movieEntry = String.Format(strF, movie, rate, comment);
                list += movieEntry + "\n";
            }
            txtDisplay.Text = header + "\n" + list;
            //txtDisplay.Text = header;
        }
        //Filtered not in order
        protected void FilteredMovie()
        {
            const string strF = "{0,-50}{1,-10}{2,-10}";
            string header = String.Format(strF, "Title", "Rating", "Comments");
            string list = "";

            foreach (int m in timeline.getSortedMovies(ddlFilterCat.Text))
            {
                string movieEntry;
                movieEntry = String.Format(strF, timeline.getMovieTitle(m), timeline.getRating(m) + "/5", timeline.getComment(m));
                list += movieEntry + "\n";
            }
            txtDisplay.Text = header + "\n" + list;
        }

        //Order By Rating
        protected void OrderByRating()
        {
            const string strF = "{0,-50}{1,-10}{2,-10}";
            string header = String.Format(strF, "Title", "Rating", "Comments");
            string list = "";

            foreach (int m in thread.adminMovByRating())
            {
                string movieEntry;
                const string mfrmt = "{0,-50}{1,-10}{2,-10}";
                movieEntry = string.Format(mfrmt, timeline.getMovieTitle(m), timeline.getRating(m) + "/5", timeline.getComment(m));
                header += movieEntry + "\n";
            }
            txtDisplay.Text= header + "\n" + list;
        }
        //Filtered order by rating
        protected void FilteredOrderByRating()
        {
            const string strF = "{0,-50}{1,-10}{2,-10}";
            string header = String.Format(strF, "Title", "Rating", "Comments");
            string list = "";
            foreach (int m in thread.adminMovByRatingCat(ddlFilterCat.Text))
            {
                string movieEntry;
                movieEntry = String.Format(strF, timeline.getMovieTitle(m), timeline.getRating(m) + "/5", timeline.getComment(m));
                list += movieEntry + "\n";
            }
            txtDisplay.Text = header + "\n" + list;
        }

        //Order By Comment
        protected void OrderByComment()
        {
            const string strF = "{0,-50}{1,-10}{2,-10}";
            string header = String.Format(strF, "Title", "Rating", "Comments");
            string list = "";
            foreach (int m in thread.adminMovByComment())
            {
                string movieEntry;
                movieEntry = String.Format(strF, timeline.getMovieTitle(m), timeline.getRating(m) + "/5", timeline.getComment(m));
                list += movieEntry + "\n";
            }
            txtDisplay.Text = header + "\n" + list;
        }
       
        //Filtered Order By Comment
        protected void FilteredOrderByComment()
        {
            const string strF = "{0,50}{1,-10}{2,-10}";
            string header = String.Format(strF, "Title", "Rating", "Comments");
            string list = "";
            foreach (int m in thread.adminMovByCommentCat(ddlFilterCat.Text))
            {
                string movieEntry;
                movieEntry = String.Format(strF, timeline.getMovieTitle(m), timeline.getRating(m) + "/5", timeline.getComment(m));
                list += movieEntry + "\n";
            }
            txtDisplay.Text = header + "\n" + list;
        }

        //Query Strings 
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

        //Create Movie
        protected void CreateMovie()
        {
            pic = uploadPoster.FileName;
            movieID = thread.createMovie(plot, title, year, pic, preview);
        }

        //Initialize Categories 
        public List<string> categories()
        {
            List<string> c = new List<string>();
            foreach (ListItem l in cbCategory.Items)
            {
                if (l.Selected)
                {
                    c.Add(l.ToString());
                }
            }
            return c;

        }

        //Assign Categories
        protected void AssignCategories()
        {
            if (movieID != 0)
            {
                string result = "";
                foreach (string c in categories())
                {
                    result = thread.assignCategory(movieID, c);
                }
                lblResult.Text = result;
            }
            else
            {
                lblResult.Text = "ERROR! PLEASE COMPLETE REQUIRED FIELDS";
            }
        }

        //Initialize Variables
        protected void InitializeVariables()
        {
            title = txtAddTitle.Text;
            plot = txtAddPlot.Value;
            preview = txtAddPreview.Value;
            year = Convert.ToInt32(txtAddYear.Text);
        }
    }
}