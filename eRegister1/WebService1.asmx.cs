using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using AjaxControlToolkit;
using System.Data;

namespace eRegister1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public CascadingDropDownNameValue[] GetSubj(string knownCategoryValues, string category)
        {

            eRegisterData.DAL oDal = new eRegisterData.DAL();
            SqlConnection conn = oDal.getSubject();
            conn.Open(); 
            SqlCommand comm = new SqlCommand(
              "SELECT   SubjectID, Name FROM   Subjects order by Name", conn);
            SqlDataReader dr = comm.ExecuteReader();
            List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();

            while (dr.Read())
            {
                l.Add(new CascadingDropDownNameValue(
                  dr["Name"].ToString(),
                  dr["SubjectID"].ToString()));
            }
            
            return l.ToArray();
        }
        [WebMethod]
        public CascadingDropDownNameValue[] GetTeachersInSubj(string knownCategoryValues, string category)
        {
            int SubjectID;

            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            if (!kv.ContainsKey("Subj") || !Int32.TryParse(kv["Subj"], out SubjectID))
            {
                throw new ArgumentException("Couldn't find specialty choice.");
            };
            eRegisterData.DAL oDal = new eRegisterData.DAL();
            SqlConnection conn = oDal.getSubject();
            conn.Open();
            SqlCommand comm = new SqlCommand(
              @"Select ts.SubjectID, s.Name as [Subject] ,ts.TeacherID, a.FirstName + ' ' + a.LastName as Name 
                FROM Subjects s
                  Inner join TeacherSubject ts on s.SubjectID = ts.SubjectID 
                  Inner join Actors a on a.ActorID = ts.TeacherID
                WHERE ts.SubjectID=@SubjectID 
                ORDER BY Name", conn);
            comm.Parameters.AddWithValue("@SubjectID", SubjectID);
            SqlDataReader dr = comm.ExecuteReader();
            List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();
            while (dr.Read())
            {
                l.Add(new CascadingDropDownNameValue(dr["Name"].ToString(), dr["TeacherID"].ToString()));
            }
            conn.Close();
            return l.ToArray();
        }
       

    }
}
