using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace WebForumServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountService" in both code and config file together.
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        string createAccount(string fname, string lname, DateTime dob,
                                    string uName, string password, string emailAdd, string pic);
        [OperationContract]
        string insertAccount(account newAccount);

        [OperationContract]
        string verifyAccount(string uName, string password);

        [OperationContract]
        List<activitylog> activites(int accID);

        [OperationContract]
        List<string> activityList(int accID);

        [OperationContract]
        string changeProfilePic(string image, int accID);

        [OperationContract]
        string getProfilePicture(int accID);

        [OperationContract]
        string changeBio(string bio, int accID);

        [OperationContract]
        string getBio(int accID);

        [OperationContract]
        string getUserName(int accID);

        [OperationContract]
        string getName(int accID);

        [OperationContract]
        string getDob(int accID);

        [OperationContract]
        string getEmail(int accID);

    }
}
