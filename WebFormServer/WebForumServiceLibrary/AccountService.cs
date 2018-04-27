using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace WebForumServiceLibrary
{
  
    public class AccountService : IAccountService
    {
        webforumdbEntities1 wfDB = new webforumdbEntities1();
      
        //Create Account
        public string createAccount(string fname, string lname, DateTime dob,
                                    string uName, string password, string emailAdd, string pic)

        {
            account newAccount = new account();
            newAccount.firstName = fname;
            newAccount.lastName = lname;
            newAccount.dateOfBirth = dob.Date;
            newAccount.username = uName;
            newAccount.password = password;
            newAccount.emailAdd = emailAdd;
            newAccount.profile_picture = pic;
            newAccount.bio = "Say something about yourself";
            return insertAccount(newAccount);

        }
        //Insert Acount
        public string insertAccount(account newAccount)
        {
            string result = "";
            var username = (from a in wfDB.accounts
                            where a.username == newAccount.username
                            select a.username).ToList();
            if (username.Count() ==0 )
            {
                try
                {
                    wfDB.accounts.Add(newAccount);
                    wfDB.SaveChanges();
                    result = "ACCOUNT SUCCESSFULLY CREATED";
                }
                catch
                {
                    result = "ACCOUNT NOT CREATED!";
                }

            }
            else
            {
                result = "USERNAME ALREADY EXISTS!";
            }
            return result;
        }
        
        //Verify Account
        public string verifyAccount(string uName, string password)
        {
            var acc = (from a in wfDB.accounts where uName == a.username select a).ToList();
            string output;
            if (acc.Count() == 0)
            {
                output = "USERNAME DOES NOT EXIST!";
            }
            else
            {
                if (acc.First().password.Equals(password))
                {
                    output = Convert.ToString(acc.First().acc_ID);
                }
                else
                {
                    output = "INCORRECT PASSWORD!";
                }
            }
            return output;
        }

        //Change Image
        public string changeProfilePic(string image, int accID)
        {
            account acc = new account();
            acc = wfDB.accounts.Find(accID);
            acc.profile_picture = image;
            wfDB.SaveChanges();
            return image;

        }

        //Default image display
        public string getProfilePicture(int accID)
        {
            account profile = new account();
            profile = wfDB.accounts.Find(accID);

            return profile.profile_picture;
        }

        //Change Bio
        public string changeBio(string bio, int accID)
        {
            account acc = new account();
            acc = wfDB.accounts.Find(accID);
            acc.bio = bio;
            wfDB.SaveChanges();
            return bio;
        }

        //Default bio display
        public string getBio(int accID) 
        {
            account acc = new account();
            acc = wfDB.accounts.Find(accID);

            return acc.bio;
        }

        //Retrieve activity log
        public List<activitylog> activites(int accID)
        {
            var acts = (from a in wfDB.activitylogs where a.Account_ID == accID select a).ToList();
            return acts;
        }
        
        //Compile Activity log
        public List<string> activityList(int accID)
        {
            List<string> actlist = new List<string>();

            foreach(activitylog a in activites(accID))
            {
                actlist.Add(a.Description);
            }
            return actlist;
        }

        //retrieve username
        public string getUserName(int accID)
        {
            account acc = new account();
            acc = wfDB.accounts.Find(accID);
            return acc.username;
        }

        //retrieve gen info
        public string getName(int accID)
        {
            account acc = new account();
            acc = wfDB.accounts.Find(accID);
            return acc.firstName + " " + acc.lastName;
        }

        //retrieve dob
        public string getDob(int accID)
        {
            account acc = new account();
            acc = wfDB.accounts.Find(accID);
            return "" + acc.dateOfBirth;
        }

        //retrieve email
        public string getEmail(int accID)
        {
            account acc = new account();
            acc = wfDB.accounts.Find(accID);
            return acc.emailAdd;
        }
    }
}
