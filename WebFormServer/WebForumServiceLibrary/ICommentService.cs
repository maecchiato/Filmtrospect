using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebForumServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommentService" in both code and config file together.
    [ServiceContract]
    public interface ICommentService
    {
        [OperationContract]
        string createComment(int userID, string comment_text, DateTime timestamp, int thread_ID, int rate);

        [OperationContract]
        string insertComment(comment newComment);

        [OperationContract]
        void activity(int userID, int movieID, DateTime time);

        [OperationContract]
        void insertActivity(activitylog act);
        
    }
}
