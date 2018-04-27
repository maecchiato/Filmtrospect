using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ForumInterface
{
    public partial class SplashPage : System.Web.UI.Page
    {

        AccountReference.AccountServiceClient accountRef = new AccountReference.AccountServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Signup_Click(object sender, EventArgs e)
        {
            string fname, lname, uname, password, emailadd, pic;
            DateTime dob;


            try
            {

            fname = txtFname.Text;
            lname = txtLname.Text;
            uname = "@" + txtNewUsername.Text;
            password = txtNewPassword.Text;
            emailadd = txtEmail.Text;
            pic = "avatar.png";
            dob = Convert.ToDateTime(txtDob.Text);

                if (uname.Length >= 8)
                {
                    if (password.Length >= 8)
                    {
                        lblResult.Text = accountRef.createAccount(fname, lname, dob, uname, password, emailadd, pic);
                        txtFname.Text = "";
                        txtLname.Text = "";
                        txtNewUsername.Text = "";
                        txtEmail.Text = "";
                        txtDob.Text = "mm/dd/yyyy";

                    }
                    else
                    {
                        lblResult.Text = "Password must be atleast 8 characters!";
                    }
                }
                else
                {
                    lblResult.Text = "Username must be atleast 8 characters!";
                }

            }
            catch
            {
                lblResult.Text = "Required field is empty";
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string u, p;
            u = txtUsername.Text;
            p = txtPassword.Text;
            try
            {
                int accID = Convert.ToInt32(accountRef.verifyAccount(u, p));
                string aID = accID.ToString();
                Response.Redirect("Home.aspx?id=" + aID);
            }
            catch
            {
                lblErrorLogin.Text = accountRef.verifyAccount(u, p);
            }
            
            
        }
    }
}