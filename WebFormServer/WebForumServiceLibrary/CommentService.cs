using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WebForumServiceLibrary
{
  
    public class CommentService : ICommentService
    {
        webforumdbEntities1 wfDB = new webforumdbEntities1();
       

        //create comment
        public string createComment(int userID, string comment_text, DateTime timestamp, int movie_ID, int rate)
        {
            comment newComment = new comment();

            newComment.UserID = userID;
            newComment.Comment_Text = comment_text;
            newComment.Timestamp = timestamp;
            newComment.Movie_ID = movie_ID;
            newComment.Movie_Rate = rate;

            return insertComment(newComment);
        }

        //insert comment
        public string insertComment(comment newComment)
        {
            try
            {
                wfDB.comments.Add(newComment);
                wfDB.SaveChanges();

                //for every comment, there is a rating
                ThreadService ts = new ThreadService();
                ts.updateMovieRate(Convert.ToInt32(newComment.Movie_ID));

                //every activity is recorded
                activity(Convert.ToInt32(newComment.UserID), 
                    Convert.ToInt32(newComment.Movie_ID),newComment.Timestamp);
                return "Comment Added";
            }
            catch
            {
                return "Comment Not Added";
            }
        }

        //create activity log 
        public void activity(int accID, int movieID, DateTime time)
        {
            activitylog al = new activitylog();
            movie mov = new movie();
            mov = wfDB.movies.Find(movieID);

            al.Account_ID = accID;
            al.Description = "You commented on " + mov.title + " at " + time;

            insertActivity(al);         
        }
        
        //insert activity log
        public void insertActivity(activitylog act)
        {
            wfDB.activitylogs.Add(act);
            wfDB.SaveChanges();
        }


    }
}
