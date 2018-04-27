using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebForumServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TimelineService" in both code and config file together.
    public class TimelineService : ITimelineService
    {
        webforumdbEntities1 wfDB = new webforumdbEntities1();

        //retrieve all movies
        public List<int> getAllMovies()
        {
            var movies = (from t in wfDB.movies select t.ID).ToList();
            List<int> movieList = new List<int>();

            foreach (int m in movies)
            {
                movieList.Add(Convert.ToInt32(m));
            }

            return movieList;
        }

        //retrieve movies by category
        public List<int> getSortedMovies(string category)
        {

            var movies = (from c in wfDB.categories
                               where c.Description == category
                               join mc in wfDB.movie_category
                               on c.ID equals mc.Category_ID                             
                               join m in wfDB.movies
                               on mc.Movie_ID equals m.ID select m.ID).ToList();
            List<int> movieList = new List<int>();

            foreach (int m in movies)
            {
                movieList.Add(Convert.ToInt32(m));
            }

            return movieList;
        }

        //retrieve movie poster
        public string getMovieImage(int movieID)
        {
            movie m = new movie();
            m = wfDB.movies.Find(movieID);
            return m.poster;
        }

        //retrieve movie title
        public string getMovieTitle(int movieID)
        {
            movie m = new movie();
            m = wfDB.movies.Find(movieID);
            return m.title;
        }

        //retrieve movie year
        public int getMovieYear(int movieID)
        {
            movie m = new movie();
            m = wfDB.movies.Find(movieID);
            return Convert.ToInt32(m.year);
        }

        //retrieve preview 
        public string getMoviePreview(int movieID)
        {
            movie m = new movie();
            m = wfDB.movies.Find(movieID);
            return m.preview;
        }

        //retrieve plot
        public string getMoviePlot(int movieID)
        {
            movie m = new movie();
            m = wfDB.movies.Find(movieID);
            return m.plot;
        }

        //retrieve category 
        public List<string> getMovieCategories(int movieID)
        {

            List<string> categories = (from m in wfDB.movies
                                   where m.ID == movieID
                                   join mc in wfDB.movie_category
                                   on m.ID equals mc.Movie_ID
                                   join c in wfDB.categories
                                   on mc.Category_ID equals c.ID
                                   select c.Description).ToList();
            return categories;
        }

        //retrieve rating
        public int getRating(int movieID)
        {
            movie m = new movie();
            m = wfDB.movies.Find(movieID);
            return Convert.ToInt32(m.rating);
        }

        //retrieve comment counts
        public int getComment(int movieID)
        {
            var comments = (from c in wfDB.comments where c.Movie_ID == movieID select c).ToList();
            return comments.Count();
        }

        //retrieve comment details 
        public List<int> getMovieComments(int movieID)
        {
            var comments = (from c in wfDB.comments where c.Movie_ID == movieID select c.ID).ToList();
            List<int> l = new List<int>();
            
            foreach(int x in comments)
            {
                l.Add(x);
            }
            return l;
        }
        
        //retrieve commenters on comment
        public int getCommenter(int commentID)
        {
            comment c = new comment();
            c = wfDB.comments.Find(commentID);
            return Convert.ToInt32(c.UserID);
        }

        //retrieve comment rate
        public int getCommentRate(int commentID)
        {
            comment c = new comment();
            c = wfDB.comments.Find(commentID);
            return Convert.ToInt32(c.Movie_Rate);
        }
        //retrieve comment text
        public string getCommentDesc(int commentID)
        {
            comment c = new comment();
            c = wfDB.comments.Find(commentID);
            return c.Comment_Text;
        }

        //retrieve comment time
        public string getCommentTime(int commentID)
        {
            comment c = new comment();
            c = wfDB.comments.Find(commentID);
            return Convert.ToString(c.Timestamp);
        }

        //top 3 highest rating movies
        public List<int> getFeaturedMovies()
        {
           var movie = (from m in wfDB.movies orderby m.rating descending
                        select m.ID).ToList().Take(3);
            List<int> fmovie = new List<int>();
            foreach (int m in movie)
            {
                fmovie.Add(m);
            }
           return fmovie;
        }

        //top 3 most commented movies
        public List<int> getTrendingMovies()
        {
            var movie = (from c in wfDB.comments group c
                         by c.Movie_ID into grp
                         orderby grp.Count() descending
                         select grp.Key).ToList().Take(3);

            List<int> fmovie = new List<int>();
            foreach (int m in movie)
            {
                fmovie.Add(m);
            }
            return fmovie;

        }
    }
}
