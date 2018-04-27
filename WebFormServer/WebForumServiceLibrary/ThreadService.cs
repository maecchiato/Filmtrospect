using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebForumServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ThreadService" in both code and config file together.
    public class ThreadService : IThreadService
    {
        webforumdbEntities1 wfDB = new webforumdbEntities1();

        //create movie
        public int createMovie(string plot, string title, int year, string poster, string preview)
        {

            movie newMovie = new movie();
            newMovie.plot = plot;
            newMovie.title = title;
            newMovie.year = year;
            newMovie.poster = poster;
            newMovie.preview = preview;

           return insertMovie(newMovie);
        }

        //insert movie
        public int insertMovie(movie newMovie)
        {
            try
            {
                wfDB.movies.Add(newMovie);
                wfDB.SaveChanges();
                return Convert.ToInt32(newMovie.ID);
            }
            catch
            {
                return 0;
            }
        }

        //assign category  (after button clicks, call createThread, save id into int x, call this for each cathegory)
        public string assignCategory(int movieID, string catgry)
        {
            movie_category newM = new movie_category();
            var catID = (from c in wfDB.categories where c.Description == catgry select c.ID);
            int cat = Convert.ToInt32(catID.First());

            newM.Movie_ID = movieID;
            newM.Category_ID = cat;
            
            try
            {
                wfDB.movie_category.Add(newM);
                wfDB.SaveChanges();
                return "MOVIE SUCCESSFULLY POSTED";
            } 
            catch
            {
                return "ERROR WHILE POSTING MOVIE";
            }
        }

        //get rating
        public int computeRating(int movieID)
        {
            var rates = (from c in wfDB.comments where c.Movie_ID == movieID select c.Movie_Rate).ToList();

            int ratecount = 0;
            int rating = 0;
            int average = 0;
            foreach(var c in rates)
            {
                rating += Convert.ToInt32(c);
                ratecount += 1;
            }

            average = rating / ratecount;

            return average;
        }

        //update movie rating
        public void updateMovieRate(int movieID)
        {
            movie mov = new movie();
            mov = wfDB.movies.Find(movieID);

            mov.rating = computeRating(movieID);

            wfDB.SaveChanges();
        }
 

       //movie by rating
       public List<int> adminMovByRating()
        {
            var movie = (from m in wfDB.movies
                         orderby m.rating descending
                         select m.ID).ToList();

            List<int> fmovie = new List<int>();
            foreach (int m in movie)
            {
                fmovie.Add(m);
            }
            return fmovie;
        }

        //movie by rating and category
        public List<int> adminMovByRatingCat(string cat)
        {
            var movies = (from c in wfDB.categories
                          where c.Description == cat
                          join mc in wfDB.movie_category
                          on c.ID equals mc.Category_ID
                          join m in wfDB.movies
                          on mc.Movie_ID equals m.ID
                          orderby m.rating descending
                          select m.ID).ToList();

            List<int> fmovie = new List<int>();
            foreach (int m in movies)
            {
               fmovie.Add(m);
            }
            return fmovie;
        }

        //movie by comment count
        public List<int> adminMovByComment()
        {
            var movie = (from c in wfDB.comments
                         group c
                         by c.Movie_ID into grp
                         orderby grp.Count() descending
                         select grp.Key).ToList();

            List<int> fmovie = new List<int>();
            foreach (int m in movie)
            {
                fmovie.Add(m);
            }
            return fmovie;
        }

        //movie by comment count
        public List<int> adminMovByCommentCat(string category)
        {
            var movie = (from c in wfDB.comments
                         group c
                         by c.Movie_ID into grp
                         orderby grp.Count() descending
                         select grp.Key).ToList();

            List<int> fmovie = new List<int>();
            foreach (int m in movie)
            {
                List<string> categories = (from mov in wfDB.movies
                                           where mov.ID == m
                                           join mc in wfDB.movie_category
                                           on mov.ID equals mc.Movie_ID
                                           join c in wfDB.categories
                                           on mc.Category_ID equals c.ID
                                           select c.Description).ToList();
                foreach (string c in categories)
                {
                    if (c.Equals(category))
                    {
                        fmovie.Add(m);
                    }
                }
            }
            return fmovie;
        }
    }
}
