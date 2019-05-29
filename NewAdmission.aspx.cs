using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Data;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        static string GetConneectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ToString();
            return connectionString;
        }
        static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConneectionString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
            {
                FillState();
                AffiliatedBoard();
                zonal();
            }
            
            
        }

        void FillState()
        {
            using (SqlConnection con = new SqlConnection("data source=LAPTOP-FBF5J7NV;initial catalog=gic; integrated security=true"))
            {
                using (SqlCommand com = new SqlCommand("Select * from state", con))
                {
                    con.Open();
                    SqlDataReader read = com.ExecuteReader();
                    DropDownList1.DataSource = read;
                    DropDownList1.DataTextField = "StateName";
                    DropDownList1.DataValueField = "Sid";
                    DropDownList1.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SendMail();
            insertdetails();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCity();
        }
        void FillCity()
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand com = new SqlCommand("Select * from city where sid=@sid", con))
                {

                    com.Parameters.AddWithValue("@sid", DropDownList1.SelectedValue);

                    con.Open();
                    SqlDataReader read = com.ExecuteReader();
                    DropDownList2.DataSource = read;
                    DropDownList2.DataTextField = "CityName";
                    DropDownList2.DataValueField = "CityId";
                    DropDownList2.DataBind();
                    con.Close();


                }
            }
        }
        void AffiliatedBoard()
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand com = new SqlCommand("Select * from AffiliatedBoard", con))
                {


                    con.Open();
                    SqlDataReader read = com.ExecuteReader();
                    DropDownList3.DataSource = read;
                    DropDownList3.DataTextField = "BoardName";
                    DropDownList3.DataValueField = "AffiliatedId";
                    DropDownList3.DataBind();
                    con.Close();


                }
            }
        }

        void zonal()
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand com = new SqlCommand("Select * from Zonal", con))
                {

                    //com.Parameters.AddWithValue("@ZonalId", DropDownList4.SelectedValue);

                    con.Open();
                    SqlDataReader read = com.ExecuteReader();
                    DropDownList4.DataSource = read;
                    DropDownList4.DataTextField = "ZoneName";
                    DropDownList4.DataValueField = "ZonalId";
                    DropDownList4.DataBind();
                    con.Close();


                }
            }
        }

        void insertdetails()
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand com = new SqlCommand())
                {
                    string sqlQuery = "insert into School(SchoolName,Address,CityId,StateName,AffiliatedBoard,PinCode,ContactNumber,DateOfRegistration,ZonalId) values(@SchoolName,@Address,@CityId,@StateName,@AffiliatedBoard,@PinCode,@ContactNumber,@DateOfResignation,@ZonalId)";
                    com.Connection = con;
                    com.CommandText = sqlQuery;
                    com.Parameters.AddWithValue("@SchoolName", (TextBox1.Text));
                    com.Parameters.AddWithValue("@Address", TextBox2.Text);
                    com.Parameters.AddWithValue("@CityId", DropDownList2.SelectedValue);
                    com.Parameters.AddWithValue("@stateName", DropDownList1.SelectedValue);
                    com.Parameters.AddWithValue("@AffiliatedBoard", DropDownList3.SelectedValue);
                    com.Parameters.AddWithValue("@PinCode", Convert.ToInt32(TextBox6.Text));
                    com.Parameters.AddWithValue("@ContactNumber", TextBox7.Text);
                    com.Parameters.AddWithValue("@DateOfResignation", TextBox8.Text);
                    com.Parameters.AddWithValue("@ZonalId", DropDownList4.SelectedValue);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    Response.Write("Record Inserted");
                }
            }
        }
        

        void SendMail()
        {
            string HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
            string FromEmailid = ConfigurationManager.AppSettings["FromMail"].ToString();
            string Pass = ConfigurationManager.AppSettings["Password"].ToString();
            //creating the object of MailMessage  
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmailid); //From Email Id  
            mailMessage.Subject = "School Address"; //Subject of Email  
            mailMessage.Body = "School Name: " + TextBox1.Text + "\n" + "Address: " + TextBox2.Text + "\n" + "State" + DropDownList1.SelectedItem.Text + "\n" + " city: " + DropDownList2.SelectedItem.Text + "\n" + "Board: " + DropDownList3.SelectedItem.Text + " \n" + "Pin Code: " + TextBox6.Text + "\n" + "Contact Number: " +  TextBox7.Text + "\n" + "Date Of Registration: " + TextBox8.Text+ "\n" + "Zone: " + DropDownList4.SelectedItem.Text; 
                                    //body or message of Email

            mailMessage.To.Add(new MailAddress("harish.sharma@gridinfocom.com"));

            SmtpClient smtp = new SmtpClient();  // creating object of smptpclient  
            smtp.Host = HostAdd;              //host of emailaddress for example smtp.gmail.com etc  

            //network and security related credentials  

            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = mailMessage.From.Address;
            //            Console.WriteLine(NetworkCred.UserName);
            NetworkCred.Password = Pass;
            //          smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mailMessage); //sending Email

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            delete();
        }

        void delete()
        {
             using (SqlConnection con = GetConnection())
            {
                using (SqlCommand com = new SqlCommand())
                {
                    string sqlQuery = "delete from school where SchoolName=@SchoolName";
                    com.Connection = con;
                    com.CommandText = sqlQuery;
                    com.Parameters.AddWithValue("@SchoolName", (TextBox1.Text));
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    Response.Write("Record Deleted");
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            search();
        }

       /* void search()
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand com = new SqlCommand())
                {
                    string sqlQuery = "select * school where SchoolName=@SchoolName";
                    com.Connection = con;
                    com.CommandText = sqlQuery;
                    com.Parameters.AddWithValue("@SchoolName", (TextBox1.Text));
                    con.Open();
                    DataTable dt = new DataTable();

                    com.ExecuteNonQuery();
                    con.Close();
                    Response.Write();
                }
            }

        }
        */

        void search()
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection con = new SqlConnection(mainconn);
            con.Open();
            SqlCommand com = new SqlCommand();
            string sqlQuery = "select * from School where SchoolName =@SchoolName";
            com.CommandText = sqlQuery;
            com.Connection = con;
            com.Parameters.AddWithValue("@SchoolName",TextBox1.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter ada = new SqlDataAdapter(com);
            ada.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();


        }
        

    }
}

    