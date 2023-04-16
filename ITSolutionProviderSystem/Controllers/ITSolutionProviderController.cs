using ITSolutionProviderSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ITSolutionProviderSystem.Controllers
{
    [Authorize]
    public class ITSolutionProviderController : Controller
    {
        string Connection = "server=localhost;uid=root;" + "database=DB_IT_SOLUTION_PROVIDER; SslMode = none";
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login obj)
        {
            DataSet ds = new DataSet();
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(Connection))
            {
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter("select * from TBL_USER_REGISTRATION o where o.Email= @Email and o.Password= @Password", conn);
                da.SelectCommand.Parameters.AddWithValue("@Email", obj.Email);
                da.SelectCommand.Parameters.AddWithValue("@Password", obj.password);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    FormsAuthentication.SetAuthCookie(ds.Tables[0].Rows[0]["UserRoles"].ToString(), false);
                    Session["UserID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                    Session["UserRoles"] = ds.Tables[0].Rows[0]["UserRoles"].ToString();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateUser(RegistrationDetails obj)
        {
            int count = 0;
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(Connection))
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select Count(*) from TBL_USER_REGISTRATION o where o.Email = @Email and o.Password = @Password", conn);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Password", obj.Password);
                conn.Open();
                count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if (count > 0)
                {
                    ViewBag.Message = "User Already Exist.";
                }
                else
                {
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("insert into TBL_USER_REGISTRATION(FirstName,LastName,Email,PhoneNO,Password,UserRoles) values(@FirstName,@LastName,@Email,@PhoneNO,@Password,@UserRoles)", conn);
                    //cmd1.Parameters.AddWithValue("@UserName", obj.Name);
                    cmd1.Parameters.AddWithValue("@FirstName", obj.FirstName);
                    cmd1.Parameters.AddWithValue("@LastName", obj.LastName);
                    cmd1.Parameters.AddWithValue("@Email", obj.Email);
                    cmd1.Parameters.AddWithValue("@PhoneNO", obj.Phone);
                    cmd1.Parameters.AddWithValue("@Password", obj.Password); 
                    cmd1.Parameters.AddWithValue("@UserRoles", obj.Roles);
                    conn.Open();
                    count = cmd1.ExecuteNonQuery();
                    conn.Close();
                    if (count == 0)
                    {
                        ViewBag.Message = "Error While inserting Data.";
                    }
                    else
                    {
                        return RedirectToAction("Login", "ITSolutionProvider");
                    }
                }
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}