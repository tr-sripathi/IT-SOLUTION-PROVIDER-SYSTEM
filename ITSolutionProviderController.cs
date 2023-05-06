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
            if (ModelState.IsValid)
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

        public ActionResult AddIssue()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddIssue(Issue IssueDetail)
        {
            int count = 0;
            string Out = "";

            string UserID = "";
            if (Session["UserID"] != null)
            {
                UserID = Session["UserID"].ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            if (ModelState.IsValid)
            {

            
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(Connection))
            {
                MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("insert into tbl_issue_detail(Issue_Category,Issue_Date,Priority,Description,Status,UserId) Values(@Issue_Category,@Issue_Date,@Priority,@Description,@Status,@UserId)", conn);
                cmd1.Parameters.AddWithValue("@Issue_Category", IssueDetail.Issue_Category);
                cmd1.Parameters.AddWithValue("@Issue_Date", IssueDetail.Issue_Date);
                cmd1.Parameters.AddWithValue("@Priority", IssueDetail.Priority);
                cmd1.Parameters.AddWithValue("@Description", IssueDetail.Description);
                cmd1.Parameters.AddWithValue("@Status", "Pending");
                cmd1.Parameters.AddWithValue("@UserId", UserID);
                conn.Open();
                count = cmd1.ExecuteNonQuery();
                conn.Close();
                if (count == 0)
                {
                    Out = "Error While inserting Data.";
                }
                else
                {
                    Out = "Y";
                }
            }
            return View("Index");
            }
            return View();
        }

        public ActionResult IssueDetails()
        {
            string UserID = "";
            string Query = "";
            if (Session["UserID"] != null)
            {
                UserID = Session["UserID"].ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            List<IssueDetail> lstIssueDetail = new List<IssueDetail>();
            DataSet ds = new DataSet();
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(Connection))
            {
                if (Session["UserRoles"].ToString() == "Customers")
                {
                    Query = "SELECT I.*,(Select U.FirstName from tbl_user_registration U Where U.UserID=I.UserID) As UserName,R.FirstName AS EngineerName FROM tbl_issue_detail I Left Join tbl_user_registration R ON I.Engin_Id = R.UserID where I.UserID IN (Select UserID FROM tbl_user_registration WHERE UserRoles='Customers') AND I.UserID ="+ UserID + " Order By I.Issue_Date";
                }
                else
                {
                    Query = "SELECT I.*,(Select U.FirstName from tbl_user_registration U Where U.UserID=I.UserID) As UserName,R.FirstName AS EngineerName FROM tbl_issue_detail I Left Join tbl_user_registration R ON I.Engin_Id = R.UserID where I.UserID IN (Select UserID FROM tbl_user_registration WHERE UserRoles='Customers') Order By I.Issue_Date";
                }
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(Query, conn);
                da.Fill(ds);
                
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    IssueDetail IssueDetail = new IssueDetail();
                    IssueDetail.ID = dr["ID"].ToString();
                    IssueDetail.Issue_Category = dr["Issue_Category"].ToString();
                    IssueDetail.Issue_Date = Convert.ToDateTime(dr["Issue_Date"].ToString());
                    IssueDetail.Priority = dr["Priority"].ToString();
                    IssueDetail.Description = dr["Description"].ToString();
                    IssueDetail.Status = dr["Status"].ToString();
                    IssueDetail.Solution = dr["Solution"].ToString();
                    IssueDetail.Engineer = dr["EngineerName"].ToString();
                    IssueDetail.Feedback = dr["Feedback"].ToString();
                    IssueDetail.UserName = dr["UserName"].ToString();
                    lstIssueDetail.Add(IssueDetail);
                }
            }
            return View(lstIssueDetail);
        }

        public ActionResult Cancle(string ID)
        {
            int count = 0;
            string Out = "";
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(Connection))
            {
                MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("Update tbl_issue_detail set Status = 'Cancel' Where ID=@ID", conn);
                //cmd1.Parameters.AddWithValue("@Status", "Cancel");
                cmd1.Parameters.AddWithValue("@ID", ID);
                conn.Open();
                count = cmd1.ExecuteNonQuery();
                conn.Close();
                if (count == 0)
                {
                    Out = "Error While inserting Data.";
                }
                else
                {
                    Out = "Y";
                }
            }
            return View("Index");
        }
        public ActionResult Solution(string ID)
        {
            if (ID != null && ID != "")
            {
                Session["ID"] = ID;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Solution(SolutionDetail obj)
        {
            //string status = "";
            string ID = "";
            int count = 0;
            string UserID = "";
            if (Session["UserID"] != null)
            {
                ID = Session["ID"].ToString();
                UserID = Session["UserID"].ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            if (ModelState.IsValid)
            {

           
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(Connection))
            {
                //MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select Status from tbl_issue_detail o where o.ID = @ID", conn);
                //cmd.Parameters.AddWithValue("@ID", ID); 
                //conn.Open();
                //status = Convert.ToString(cmd.ExecuteScalar());
                //conn.Close();
                //if (status == "Pending")
                //{
                //    ViewBag.Message = "Status Should be Pending.";
                //}
                //else
                //{
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("Update tbl_issue_detail set Solution = @Solution, Status = @Status, Engin_Id = @UserID Where ID=@ID", conn);
                    //cmd1.Parameters.AddWithValue("@UserName", obj.Name);
                    cmd1.Parameters.AddWithValue("@Status", obj.Status);
                    cmd1.Parameters.AddWithValue("@Solution", obj.Solution);
                    cmd1.Parameters.AddWithValue("@UserID", UserID);    
                    cmd1.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    count = cmd1.ExecuteNonQuery();
                    conn.Close();
                    if (count == 0)
                    {
                        ViewBag.Message = "Error While Updating Data.";
                    }
                    else
                    {
                        return RedirectToAction("Index", "ITSolutionProvider");
                    }
                //}
            }
            }
            return View();

        }

        public ActionResult Feedback(string ID)
        {
            if (ID!=null && ID !="")
            {
            Session["ID"] = ID;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Feedback(FeedbackDetail IssueDetail)
        {
            int count = 0;
            string Out = "";
            string ID = "";
            if (Session["ID"] != null)
            {
                ID = Session["ID"].ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }


            if (ModelState.IsValid)
            {

            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(Connection))
            {
                MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("Update tbl_issue_detail set Feedback = @Feedback Where ID=@ID", conn);
                //cmd1.Parameters.AddWithValue("@Status", "Cancle");
                cmd1.Parameters.AddWithValue("@Feedback", IssueDetail.Feedback);
                cmd1.Parameters.AddWithValue("@ID", ID);
                conn.Open();
                count = cmd1.ExecuteNonQuery();
                conn.Close();
                if (count == 0)
                {
                    Out = "Error While inserting Data.";
                }
                else
                {
                    Out = "Y";
                }
            }
            return View("Index"); 
            }
            return View();
        }

    }
}