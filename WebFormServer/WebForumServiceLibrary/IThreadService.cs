using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebForumServiceLibrary
{
   
    [ServiceContract]
    public interface IThreadService
    {
        [OperationContract]
        int createMovie(string plot, string title, int year, string poster, string preview);

        [OperationContract]
        int insertMovie(movie newMovie);

        [OperationContract]
        string assignCategory(int movieID, string catgry);

        [OperationContract]
        int computeRating(int movieID);

        [OperationContract]
        void updateMovieRate(int movieID);

        [OperationContract]
        List<int> adminMovByRating();

        [OperationContract]
        List<int> adminMovByRatingCat(string cat);

        [OperationContract]
        List<int> adminMovByComment();

        [OperationContract]
        List<int> adminMovByCommentCat(string category);

    }
}
