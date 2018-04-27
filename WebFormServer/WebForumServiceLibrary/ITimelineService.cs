using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebForumServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITimelineService" in both code and config file together.
    [ServiceContract]
    public interface ITimelineService
    {
        [OperationContract]
        List<int> getAllMovies();

        [OperationContract]
        List<int> getSortedMovies(string category);

        [OperationContract]
        string getMovieImage(int movieID);

        [OperationContract]
        string getMovieTitle(int movieID);

        [OperationContract]
        int getMovieYear(int movieID);

        [OperationContract]
        string getMoviePreview(int movieID);

        [OperationContract]
        string getMoviePlot(int movieID);

        [OperationContract]
        List<string> getMovieCategories(int movieID);

        [OperationContract]
        int getRating(int movieID);

        [OperationContract]
        int getComment(int movieID);

        [OperationContract]
        List<int> getFeaturedMovies();

        [OperationContract]
        List<int> getTrendingMovies();

        [OperationContract]
        List<int> getMovieComments(int movieID);

        [OperationContract]
        int getCommenter(int commentID);

        [OperationContract]
        int getCommentRate(int commentID);

        [OperationContract]
        string getCommentDesc(int commentID);

        [OperationContract]
        string getCommentTime(int commentID);
    }
}
