using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace eRegisterData
{
    public class DAL
    {
         public static bool SendMessage(string username, string password, string emailRecipient)
        {   
             // метода НЕ изпраща е-mail, защото предоставената парола е грешна!!!
            try
            {
                string Body = string.Format("Целта на това съобщение е за да ви предостави потребителско име и парола за достъп до информационната система електронен дневник.\nПотребителско име: {0}\nПарола: {1}",username, password);
                MailMessage message = new MailMessage();
                SmtpClient SMTPServer = new SmtpClient();
                MailAddress messageFrom = new MailAddress("mimarinova89@gmail.com", "Администратор", System.Text.Encoding.UTF8);
                MailAddress messageTo = new MailAddress(emailRecipient, "", System.Text.Encoding.UTF8);
                SMTPServer.UseDefaultCredentials = false;
                SMTPServer.EnableSsl = true;
                NetworkCredential credential = new NetworkCredential("mimarinova89@gmail.com", "парола"); //трябва да се напишат верен e-mail, от който да се пращат съобщенията и вярната парола!!!
                SMTPServer.Host = "smtp.gmail.com";
                SMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SMTPServer.Port = 587;
                SMTPServer.Credentials = credential;
                message.From = messageFrom;
                message.Body = Body;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Subject = "Потребителско име и парола за достъп до информационна система";
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.To.Add(messageTo);
                SMTPServer.Send(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool EGNValidation(string egn)
        {
            if (string.IsNullOrEmpty(egn))
                return false;
            if (egn.Length != 10)
            {
                return false;
            }

            double num;
            if (!double.TryParse(egn, out num))
            {
                return false;
            }
            int[] weights = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            string date = string.Empty;
            DateTime dt;

            int year = Int16.Parse(egn.Substring(0, 2));
            int month = Int16.Parse(egn.Substring(2, 2));
            int day = Int16.Parse(egn.Substring(4, 2));

            if (month > 40)
            {
                date = (month - 40) + "-" + day + "-" + (year + 2000);
            }
            else if (month > 20)
            {
                date = (month - 20) + "-" + day + "-" + (year + 1800);
            }
            else
            {
                date = day + "-" + month + "-" + (year + 1900);
            }
            if (DateTime.TryParse(date, out dt) == false)
            {
                return false;
            }
            int checkSum = Int32.Parse(egn.Substring(9, 1));
            int egnSum = 0;
            int validCheckSum = 0;

            for (int i = 0; i < 9; i++)
            {
                egnSum += int.Parse(egn.Substring(i, 1)) * weights[i];
            }

            validCheckSum = egnSum % 11;

            if (validCheckSum == 10) { validCheckSum = 0; }

            if (checkSum == validCheckSum) { return true; }
            else { return false; }
        }
        private static string CreateRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
        public DataTable getNewsTitles()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT * 
                                        FROM News 
                                        WHERE news.DatePublication > DATEADD(MONTH,-1,GETDATE())
                                        ORDER BY DatePublication DESC";
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public DataTable getNewsByNewID(int newsIDParam)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from News where newsID='" + newsIDParam + "'";
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public DataTable getSchoole()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT s.SchooName, c.Name + ', ' + s.[Address] AS [Address],
	                                           s.Mission AS History, s.Strategy, s.Vision 
                                        FROM Schools s 
                                          INNER JOIN CityVillage c ON c.CityVillageID = s.CityVillageID
                                        WHERE s.SchoolID=5";
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public SqlConnection getSubject()
        {

            SqlConnection connection = new SqlConnection();

            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;


            return connection;
        }

        public DataTable getTeacherInfo(int TeacherID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter teacherid = new SqlParameter("@TeacherID", TeacherID);
                    teacherid.SqlDbType = SqlDbType.Int;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "spGetTeacherInfo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(teacherid);
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public DataTable insertNewSchool(string schoolName, string address, int cityVillageID, string mission, string strategy, string vision)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter schoolNamesql = new SqlParameter("@SchoolName", schoolName);
                    SqlParameter addresssql = new SqlParameter("@Address", address);
                    SqlParameter cityVillageIDsql = new SqlParameter("@CityVillageID", cityVillageID);
                    SqlParameter misionsql = new SqlParameter("@Mission", mission);
                    SqlParameter strategysql = new SqlParameter("@Strategy", strategy);
                    SqlParameter visionsql = new SqlParameter("@Vision", vision);
                    schoolNamesql.SqlDbType = SqlDbType.VarChar;
                    addresssql.SqlDbType = SqlDbType.VarChar;
                    cityVillageIDsql.SqlDbType = SqlDbType.Int;
                    misionsql.SqlDbType = SqlDbType.VarChar;
                    strategysql.SqlDbType = SqlDbType.VarChar;
                    visionsql.SqlDbType = SqlDbType.VarChar;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_School_Insert";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(schoolNamesql);
                    cmd.Parameters.Add(addresssql);
                    cmd.Parameters.Add(cityVillageIDsql);
                    cmd.Parameters.Add(misionsql);
                    cmd.Parameters.Add(strategysql);
                    cmd.Parameters.Add(visionsql);
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }

        public DataTable getSchooleInfo(int adminID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter parAdminID = new SqlParameter("@ActorID", adminID);
                    parAdminID.SqlDbType = SqlDbType.Int;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetSchooleInfo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(parAdminID);
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }

        public DataTable getSchooleInfo1(int SchoolID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter SchoolID1 = new SqlParameter("@SchoolID", SchoolID);
                    SchoolID1.SqlDbType = SqlDbType.Int;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetSchoolInfo1";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(SchoolID1);
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }


        public DataTable insertNewClasses(int Class)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter className = new SqlParameter("@Class", Class);


                    className.SqlDbType = SqlDbType.Int;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_Class_Insert";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(className);

                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public DataTable insertNewDivision(char Division)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter DivisionName = new SqlParameter("@Division", Division);


                    DivisionName.SqlDbType = SqlDbType.Char;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_DivisionInsert";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DivisionName);

                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public DataTable insertNewProfil(string Profil)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter PrifilName = new SqlParameter("@Profil", Profil);


                    PrifilName.SqlDbType = SqlDbType.VarChar;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_ProfilInsert";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(PrifilName);

                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public DataTable insertNewSubject(string Name)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter SubjectName = new SqlParameter("@Name", Name);


                    SubjectName.SqlDbType = SqlDbType.VarChar;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_SubjectInsert";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(SubjectName);

                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public bool UpdateSchool(int SchoolID, string schoolName, string address, int cityVillageID, string mission, string strategy, string vision)
        {
            
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter SchoolIDsql = new SqlParameter("@SchoolID", SchoolID);
                    SqlParameter schoolNamesql = new SqlParameter("@SchoolName", schoolName);
                    SqlParameter addresssql = new SqlParameter("@Address", address);
                    SqlParameter cityVillageIDsql = new SqlParameter("@CityVillageID", cityVillageID);
                    SqlParameter misionsql = new SqlParameter("@Mission", mission);
                    SqlParameter strategysql = new SqlParameter("@Strategy", strategy);
                    SqlParameter visionsql = new SqlParameter("@Vision", vision);
                    SchoolIDsql.SqlDbType = SqlDbType.Int;
                    schoolNamesql.SqlDbType = SqlDbType.VarChar;
                    addresssql.SqlDbType = SqlDbType.VarChar;
                    cityVillageIDsql.SqlDbType = SqlDbType.Int;
                    misionsql.SqlDbType = SqlDbType.VarChar;
                    strategysql.SqlDbType = SqlDbType.VarChar;
                    visionsql.SqlDbType = SqlDbType.VarChar;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_School_Update";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(SchoolIDsql);
                    cmd.Parameters.Add(schoolNamesql);
                    cmd.Parameters.Add(addresssql);
                    cmd.Parameters.Add(cityVillageIDsql);
                    cmd.Parameters.Add(misionsql);
                    cmd.Parameters.Add(strategysql);
                    cmd.Parameters.Add(visionsql);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e) { connection.Close(); }
            return true;
        }
        public bool UpdatePassword(int userID, string password)
        {

            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter paramUserID = new SqlParameter("@UserID", userID);
                    SqlParameter paramPassword = new SqlParameter("@Password", password);

                    paramUserID.SqlDbType = SqlDbType.Int;
                    paramPassword.SqlDbType = SqlDbType.VarChar;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_PasswordUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(paramUserID);
                    cmd.Parameters.Add(paramPassword);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e) { connection.Close(); }
            return true;
        }
        public DataTable getSchedule(int StudentID, string WeekDay, string Term)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter paramStudentID = new SqlParameter("@StudentID", StudentID);
                    paramStudentID.SqlDbType = SqlDbType.Int;
                    SqlParameter paramWeekDay = new SqlParameter("@WeekDay", WeekDay);
                    paramWeekDay.SqlDbType = SqlDbType.VarChar;
                    SqlParameter paramTerm = new SqlParameter("@Term", Term);
                    paramTerm.SqlDbType = SqlDbType.NChar;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetSchedule";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(paramStudentID);
                    cmd.Parameters.Add(paramWeekDay);
                    cmd.Parameters.Add(paramTerm);

                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public int getExcusedAbsences(int ActorID)
        {
            Int32 absenceID = 0;
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter paramActorID = new SqlParameter("@ActorID", ActorID);
                    paramActorID.SqlDbType = SqlDbType.Int;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_ExcusedAbsences";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(paramActorID);

                    absenceID = (Int32)cmd.ExecuteScalar();


                }
            }
            catch (SqlException e) { connection.Close(); }
            return (int)absenceID;
        }
        public String getInexcusablyAbsences(int StudentID)
        {
            String unexcusedAbsences = string.Empty;
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter paramActorID = new SqlParameter("@StudentID", StudentID);
                    paramActorID.SqlDbType = SqlDbType.Int;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetUnexcusedAbsences";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(paramActorID);
                    unexcusedAbsences = cmd.ExecuteScalar().ToString();


                }
            }
            catch (SqlException e) { connection.Close(); }
            return unexcusedAbsences;
        }

        public DataTable getInexcusablyInfo(int StudentID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter paramStudentID = new SqlParameter("@StudentID", StudentID);
                    paramStudentID.SqlDbType = SqlDbType.Int;


                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetInexcusablyInfo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(paramStudentID);


                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }


        public DataTable getTerm()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT * FROM Term";
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }

        public DataTable getSubjectInfo()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT * FROM Subjects order by Name";
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }

        public DataTable GetStudentScores(int StudentID, byte TermID, Int16 SubjectID, byte ScoreTypeID = 1)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter paramStudentID = new SqlParameter("@StudentID", StudentID);
                    paramStudentID.SqlDbType = SqlDbType.Int;
                    SqlParameter paramTermID = new SqlParameter("@TermID", TermID);
                    paramTermID.SqlDbType = SqlDbType.TinyInt;
                    SqlParameter paramSubjectID = new SqlParameter("@SubjectID", SubjectID);
                    if (SubjectID == 0)
                    {
                        paramSubjectID.Value = DBNull.Value;
                    }
                    paramSubjectID.SqlDbType = SqlDbType.SmallInt;
                    SqlParameter paramScoreTypeID = new SqlParameter("@ScoreTypeID", ScoreTypeID);
                    paramScoreTypeID.SqlDbType = SqlDbType.TinyInt;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetStudentScores";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(paramStudentID);
                    cmd.Parameters.Add(paramTermID);
                    cmd.Parameters.Add(paramSubjectID);
                    cmd.Parameters.Add(paramScoreTypeID);

                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public string GetStudentsAvgScore(int StudentID, byte TermID, Int16 SubjectID)
        {
            string avgScore = string.Empty;
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter paramStudentID = new SqlParameter("@StudentID", StudentID);
                    paramStudentID.SqlDbType = SqlDbType.Int;
                    SqlParameter paramTermID = new SqlParameter("@TermID", TermID);
                    paramTermID.SqlDbType = SqlDbType.TinyInt;
                    SqlParameter paramSubjectID = new SqlParameter("@SubjectID", SubjectID);
                    paramSubjectID.SqlDbType = SqlDbType.SmallInt;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetStudentsAverageScore";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(paramStudentID);
                    cmd.Parameters.Add(paramTermID);
                    cmd.Parameters.Add(paramSubjectID);


                    avgScore = cmd.ExecuteScalar().ToString();
                }
            }
            catch (SqlException e) { connection.Close(); }
            return avgScore;
        }
        public DataTable GetScoreInfo(int StudentID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;
            try
            {
                using (connection)
                {
                    SqlParameter paramStudentID = new SqlParameter("@StudentID", StudentID);
                    paramStudentID.SqlDbType = SqlDbType.Int;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetStudentsScore";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(paramStudentID);
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public string GetAVGScoreType(int StudentID, int TermID, Int16 ScoreTypeID)
        {
            string avgScoreType = string.Empty;
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter paramStudentID = new SqlParameter("@StudentID", StudentID);
                    paramStudentID.SqlDbType = SqlDbType.Int;
                    SqlParameter paramTermID = new SqlParameter("@TermID", TermID);
                    paramTermID.SqlDbType = SqlDbType.TinyInt;
                    SqlParameter paramScoreTypeID = new SqlParameter("@ScoreTypeID", ScoreTypeID);
                    paramScoreTypeID.SqlDbType = SqlDbType.SmallInt;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetAVGScoreType";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(paramStudentID);
                    cmd.Parameters.Add(paramTermID);
                    cmd.Parameters.Add(paramScoreTypeID);


                    avgScoreType = cmd.ExecuteScalar().ToString();
                }
            }
            catch (SqlException e) { connection.Close(); }
            return avgScoreType;
        }
        public DataTable GetTeacherList(int StudentID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter paramStudentID = new SqlParameter("@StudentID", StudentID);
                    paramStudentID.SqlDbType = SqlDbType.Int;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_TeacherList";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(paramStudentID);
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }

        public void CreateMessage(int MessageFromID, int MessageToID, string Path, string Body, int MessageTypeID, int StatusID,int ReplyMessageID = 0)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {

                    SqlParameter parMessageFromID = new SqlParameter("@MessageFromID", MessageFromID);
                    SqlParameter parReplyMessageID = new SqlParameter("@ReplyMessageID", ReplyMessageID);
                    if (ReplyMessageID == 0)
                    {
                        parReplyMessageID.Value = DBNull.Value;
                    }
                    SqlParameter parMessageToID = new SqlParameter("@MessageToID", MessageToID);
                    SqlParameter parPath = new SqlParameter("@Path", Path);
                    if (string.IsNullOrEmpty(Path))
                    {
                        parPath.Value = DBNull.Value;
                    }
                    SqlParameter parBody = new SqlParameter("@Body", Body);
                    SqlParameter parMessageTypeID = new SqlParameter("@MessageTypeID", MessageTypeID);
                    SqlParameter parStatusID = new SqlParameter("@StatusID", StatusID);

                    parMessageFromID.SqlDbType = SqlDbType.Int;
                    parReplyMessageID.SqlDbType = SqlDbType.Int;
                    parMessageToID.SqlDbType = SqlDbType.Int;
                    parPath.SqlDbType = SqlDbType.VarChar;
                    parBody.SqlDbType = SqlDbType.VarChar;
                    parMessageTypeID.SqlDbType = SqlDbType.Int;
                    parStatusID.SqlDbType = SqlDbType.Int;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_CreateMessage";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(parMessageFromID);
                    cmd.Parameters.Add(parReplyMessageID);
                    cmd.Parameters.Add(parMessageToID);
                    cmd.Parameters.Add(parPath);
                    cmd.Parameters.Add(parBody);
                    cmd.Parameters.Add(parMessageTypeID);
                    cmd.Parameters.Add(parStatusID);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException e) { connection.Close(); }
        }

        public DataTable getMessageType()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT * FROM MessageTypes";
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }

        public DataTable GetUsersMessages(int ActorID, int MessageTypeID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter paramActorID = new SqlParameter("@ActorID", ActorID);
                    paramActorID.SqlDbType = SqlDbType.Int;

                    SqlParameter paramMessageTypeID = new SqlParameter("@MessageTypeID", MessageTypeID);
                    if (MessageTypeID == 0)
                    {
                        paramMessageTypeID.Value = DBNull.Value;
                    }
                    paramMessageTypeID.SqlDbType = SqlDbType.Int;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetUsersMessages";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(paramActorID);
                    cmd.Parameters.Add(paramMessageTypeID);


                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }

        public DataTable GetAllSentMessages(int ActorID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;
            try
            {
                using (connection)
                {
                    SqlParameter paramActorID = new SqlParameter("@ActorID", ActorID);
                    paramActorID.SqlDbType = SqlDbType.Int;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetAllSentMessages";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(paramActorID);
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }

        public DataTable GetAllTemplates(int ActorID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;
            try
            {
                using (connection)
                {
                    SqlParameter paramActorID = new SqlParameter("@ActorID", ActorID);
                    paramActorID.SqlDbType = SqlDbType.Int;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetAllTemplates";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(paramActorID);
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }

        public DataTable GetActors(int UserTypeID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter paramUserTypeID = new SqlParameter("@UserTypeID", UserTypeID);
                    paramUserTypeID.SqlDbType = SqlDbType.Int;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetActors";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(paramUserTypeID);
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public DataTable GetAllClasses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetAllClasses";
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }

        public DataTable GetClassStudents(string ClassDevisionDetailsID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter paramClassDevisionDetailsID = new SqlParameter("@ClassDevisionDetailsID", ClassDevisionDetailsID);
                    paramClassDevisionDetailsID.SqlDbType = SqlDbType.Int;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetClassStudents";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(paramClassDevisionDetailsID);
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }

        public bool StudentsClass_Update(int StudentID, string FirstName, string MiddleName, string LastName, int Number, DateTime DateofChange, int ClassDivisionDetailsID)
        {
            //DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter parStudentID = new SqlParameter("@StudentID", StudentID);
                    SqlParameter parFName = new SqlParameter("@FirstName", FirstName);
                    SqlParameter parMName = new SqlParameter("@MiddleName", MiddleName);
                    SqlParameter parLNAme = new SqlParameter("@LastName", LastName);
                    SqlParameter parNumber = new SqlParameter("@Number", Number);
                    SqlParameter parDate = new SqlParameter("@DateofChange", DateofChange);
                    SqlParameter parDivDetailsID = new SqlParameter("@ClassDivisionDetailsID", ClassDivisionDetailsID);
                    parStudentID.SqlDbType = SqlDbType.Int;
                    parFName.SqlDbType = SqlDbType.VarChar;
                    parMName.SqlDbType = SqlDbType.VarChar;
                    parLNAme.SqlDbType = SqlDbType.VarChar;
                    parNumber.SqlDbType = SqlDbType.Int;
                    parDate.SqlDbType = SqlDbType.Date;
                    parDivDetailsID.SqlDbType = SqlDbType.Int;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_StudentsClass_Update";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(parStudentID);
                    cmd.Parameters.Add(parFName);
                    cmd.Parameters.Add(parMName);
                    cmd.Parameters.Add(parLNAme);
                    cmd.Parameters.Add(parNumber);
                    cmd.Parameters.Add(parDate);
                    cmd.Parameters.Add(parDivDetailsID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e) { connection.Close(); }
            return true;
        }

        public int AddTeacher(string UserName, string FirstName, string MiddleName,string LastName, bool Gender, string Address, string EGN, string Email, bool Status, string PhoneNumber, int SchoolID, int CityVillageID)
        {
            int teacherID = 0;
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            string Password = CreateRandomPassword(6);
            if (!EGNValidation(EGN))
            {
                return 0;
            }
            try
            {
                using (connection)
                {
                    SqlParameter paramUserName = new SqlParameter("@UserName", UserName);
                    paramUserName.SqlDbType = SqlDbType.VarChar;
                    SqlParameter paramPassword = new SqlParameter("@Password", Password);
                    paramPassword.SqlDbType = SqlDbType.VarChar;
                    SqlParameter paramFirstName = new SqlParameter("@FirstName", FirstName);
                    paramFirstName.SqlDbType = SqlDbType.VarChar;
                    SqlParameter paramMiddleName = new SqlParameter("@MiddleName", MiddleName);
                    paramMiddleName.SqlDbType = SqlDbType.VarChar;
                    SqlParameter paramLastName = new SqlParameter("@LastName", LastName);
                    paramLastName.SqlDbType = SqlDbType.VarChar;
                    SqlParameter paramGender = new SqlParameter("@Gender", Gender);
                    paramGender.SqlDbType = SqlDbType.Bit;
                    SqlParameter paramAddress = new SqlParameter("@Address", Address);
                    if (string.IsNullOrEmpty(Address))
                    {
                        paramAddress.Value = DBNull.Value;
                    }
                    paramAddress.SqlDbType = SqlDbType.VarChar;
                    SqlParameter paramEGN = new SqlParameter("@EGN", EGN);
                    paramEGN.SqlDbType = SqlDbType.NChar;
                    SqlParameter paramEmail = new SqlParameter("@Email", Email);
                    paramEmail.SqlDbType = SqlDbType.VarChar;
                    SqlParameter paramStatus = new SqlParameter("@Status", Status);
                    paramStatus.SqlDbType = SqlDbType.Bit;
                    SqlParameter paramPhoneNumber = new SqlParameter("@PhoneNumber", PhoneNumber);
                    paramPhoneNumber.SqlDbType = SqlDbType.VarChar;
                    SqlParameter paramSchoolID = new SqlParameter("@SchoolID", SchoolID);
                    paramSchoolID.SqlDbType = SqlDbType.Int;
                    SqlParameter paramCityVillageID = new SqlParameter("@CityVillageID", CityVillageID);
                    if (CityVillageID == 0)
                    {
                        paramCityVillageID.Value = DBNull.Value;
                    }
                    paramCityVillageID.SqlDbType = SqlDbType.Int;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_AddTeacher";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(paramUserName);
                    cmd.Parameters.Add(paramPassword);
                    cmd.Parameters.Add(paramFirstName);
                    cmd.Parameters.Add(paramMiddleName);
                    cmd.Parameters.Add(paramLastName);
                    cmd.Parameters.Add(paramGender);
                    cmd.Parameters.Add(paramAddress);
                    cmd.Parameters.Add(paramEGN);
                    cmd.Parameters.Add(paramEmail);
                    cmd.Parameters.Add(paramStatus);
                    cmd.Parameters.Add(paramPhoneNumber);
                    cmd.Parameters.Add(paramSchoolID);
                    cmd.Parameters.Add(paramCityVillageID);
                    teacherID = (Int32)cmd.ExecuteScalar();

                    if (teacherID == 0)
                    {
                        return 0;
                    }
                    cmd.Parameters.Clear();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = @"Select t2.UserName, t2.Password , t1.email 
                                            from Actors t1
                                              inner join Users t2 on t2.UserID = t1.UserID
                                            where ActorID = " + teacherID.ToString();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SendMessage(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
                    }
                    // Call Close when done reading.
                    reader.Close();
                }
            }
            catch (SqlException e) { connection.Close(); }
            return teacherID;
        }

        public DataTable getWeekDay()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT * FROM WeekDay";
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }

        public DataTable getSchedulesByClasses(int ClassDevisionDetailsID, string WeekDay, string Term)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter paramClassDevisionDetailsID = new SqlParameter("@ClassDevisionDetailsID", ClassDevisionDetailsID);
                    paramClassDevisionDetailsID.SqlDbType = SqlDbType.Int;
                    SqlParameter paramWeekDay = new SqlParameter("@WeekDay", WeekDay);
                    paramWeekDay.SqlDbType = SqlDbType.VarChar;
                    SqlParameter paramTerm = new SqlParameter("@Term", Term);
                    paramTerm.SqlDbType = SqlDbType.NChar;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_GetScheduleByClasses";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(paramClassDevisionDetailsID);
                    cmd.Parameters.Add(paramWeekDay);
                    cmd.Parameters.Add(paramTerm);

                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public void TeacherSubject_Insert(int TeacherID, int SubjectID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {

                    SqlParameter parTeacherID = new SqlParameter("@TeacherID", TeacherID);
                    SqlParameter parSubjectID = new SqlParameter("@SubjectID", SubjectID);


                    parTeacherID.SqlDbType = SqlDbType.Int;
                    parSubjectID.SqlDbType = SqlDbType.Int;
                   
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_TeacherSubject_Insert";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(parTeacherID);
                    cmd.Parameters.Add(parSubjectID);
                   
                    cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException e) { connection.Close(); }
        }
        public void TeacherClass_Insert(int TeacherID, int ClassDevisionDetailsID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {

                    SqlParameter parTeacherID = new SqlParameter("@TeacherID", TeacherID);
                    SqlParameter parClassDevisionDetailsID = new SqlParameter("@ClassDevisionDetailsID", ClassDevisionDetailsID);

                    parTeacherID.SqlDbType = SqlDbType.Int;
                    parClassDevisionDetailsID.SqlDbType = SqlDbType.Int;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_TeacherClass_Insert";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(parTeacherID);
                    cmd.Parameters.Add(parClassDevisionDetailsID);

                    cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException e) { connection.Close(); }
        }

        public bool Schedule_Update( int ScheduleID, int ClassDivisionDetailsID, int TermID, Int16 PeriodNum, Int16 SubjectID, Int16 WeekDayID)
        {
            //DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter parScheduleID = new SqlParameter("@ScheduleID", ScheduleID);
                    SqlParameter parClassDivisionDetailsID = new SqlParameter("@ClassDivisionDetailsID", ClassDivisionDetailsID);
                    SqlParameter parTermID = new SqlParameter("@TermID", TermID);
                    SqlParameter parPeriodNum = new SqlParameter("@PeriodNum", PeriodNum);
                    SqlParameter parSubjectID = new SqlParameter("@SubjectID", SubjectID);
                    SqlParameter parWeekDayID = new SqlParameter("@WeekDayID", WeekDayID);

                    parScheduleID.SqlDbType = SqlDbType.Int;
                    parClassDivisionDetailsID.SqlDbType = SqlDbType.Int;
                    parTermID.SqlDbType = SqlDbType.Int;
                    parPeriodNum.SqlDbType = SqlDbType.TinyInt;
                    parSubjectID.SqlDbType = SqlDbType.SmallInt;
                    parWeekDayID.SqlDbType = SqlDbType.TinyInt;
                    
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_Schedule_Update";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(parScheduleID);
                    cmd.Parameters.Add(parClassDivisionDetailsID);
                    cmd.Parameters.Add(parTermID);
                    cmd.Parameters.Add(parPeriodNum);
                    cmd.Parameters.Add(parSubjectID);
                    cmd.Parameters.Add(parWeekDayID);
                   
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e) { connection.Close(); }
            return true;
        }

        public DataTable EditTeacherInfo(string TeacherID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    SqlParameter paramTeacherID = new SqlParameter("@TeacherID", TeacherID);
                    paramTeacherID.SqlDbType = SqlDbType.Int;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_EditTeacherInfo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(paramTeacherID);
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }

        public bool EditTeacher_Update(int TeacherID, string FirstName, string MiddleName, string LastName, string Email, string PhoneNumber, int ClassDivisionID)
        {
            
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;
            try
            {
                using (connection)
                {
                    SqlParameter parTeacherID = new SqlParameter("@TeacherID", TeacherID);
                    SqlParameter parFirstName = new SqlParameter("@FirstName", FirstName);
                    SqlParameter parMiddleName = new SqlParameter("@MiddleName", MiddleName);
                    SqlParameter parLastName = new SqlParameter("@LastName", LastName);
                    SqlParameter parEmail = new SqlParameter("@Email", Email);
                    SqlParameter parPhoneNumber = new SqlParameter("@PhoneNumber", PhoneNumber);
                    SqlParameter parClassDivisionID = new SqlParameter("@ClassDivisionID", ClassDivisionID);

                    parTeacherID.SqlDbType = SqlDbType.Int;
                    parFirstName.SqlDbType = SqlDbType.VarChar;
                    parMiddleName.SqlDbType = SqlDbType.VarChar;
                    parLastName.SqlDbType = SqlDbType.VarChar;
                    parEmail.SqlDbType = SqlDbType.VarChar;
                    parPhoneNumber.SqlDbType = SqlDbType.VarChar;
                    parClassDivisionID.SqlDbType = SqlDbType.Int;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_EditTeacher_Update";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(parTeacherID);
                    cmd.Parameters.Add(parFirstName);
                    cmd.Parameters.Add(parMiddleName);
                    cmd.Parameters.Add(parLastName);
                    cmd.Parameters.Add(parEmail);
                    cmd.Parameters.Add(parPhoneNumber);
                    cmd.Parameters.Add(parClassDivisionID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e) { connection.Close(); }
            return true;
        }

        public int MessageReply(string MessageID)
        {
            int messageFromID = 0;
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;
            try
            {
                using (connection)
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT MessageFromID
                                        FROM Messages
                                        WHERE MessageID =" + MessageID;
                    messageFromID = (Int32)cmd.ExecuteScalar();
                    
                }
            }
            catch (SqlException e) { connection.Close(); }
            return messageFromID;
        }
        public DataTable MessageDraft(string MessageID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;
            try
            {
                using (connection)
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT MessageToID, Body
                                        FROM Messages
                                        WHERE MessageID =" + MessageID;
                    dt.Load(cmd.ExecuteReader());

                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public int MessageStatusID(string MessageID)
        {
            int messageStatusID = 0;
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;
            try
            {
                using (connection)
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT StatusID
                                        FROM Messages
                                        WHERE MessageID =" + MessageID;
                    messageStatusID = (Int32)cmd.ExecuteScalar();

                }
            }
            catch (SqlException e) { connection.Close(); }
            return messageStatusID;
        }

        public DataTable getSchools()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;

            try
            {
                using (connection)
                {
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT [SchoolID], [SchooName] FROM [Schools]";
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }

        public DataTable GetAbsenceInfo(string dateFrom, string dateTo, int minAbsence)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;
            try
            {
                using (connection)
                {
                    SqlParameter pardateFrom = new SqlParameter("@Datefrom", dateFrom);
                    SqlParameter pardateTo = new SqlParameter("@DateTo", dateTo);
                    SqlParameter parminAbsence = new SqlParameter("@AbsenceNumber", minAbsence);
                    pardateFrom.SqlDbType = SqlDbType.Date;
                    pardateTo.SqlDbType = SqlDbType.Date;
                    parminAbsence.SqlDbType = SqlDbType.Int;


                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_ShowAbsences";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(pardateFrom);
                    cmd.Parameters.Add(pardateTo);
                    cmd.Parameters.Add(parminAbsence);
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }

        public DataTable AvgClassesScore( int SchoolID, Int16 StudyYearID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;
            try
            {
                using (connection)
                {
                    SqlParameter parSchoolID = new SqlParameter("@SchoolID", SchoolID);
                    SqlParameter parStudyYearID = new SqlParameter("@StudyYearID", StudyYearID);

                    parSchoolID.SqlDbType = SqlDbType.Int;
                    parStudyYearID.SqlDbType = SqlDbType.TinyInt;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_AvgClassesScore";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(parSchoolID);
                    cmd.Parameters.Add(parStudyYearID);
                    
                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public DataTable AvgSchoolScore(int SchoolID, Int16 StudyYearID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;
            try
            {
                using (connection)
                {
                    SqlParameter parSchoolID = new SqlParameter("@SchoolID", SchoolID);
                    SqlParameter parStudyYearID = new SqlParameter("@StudyYearID", StudyYearID);

                    parSchoolID.SqlDbType = SqlDbType.Int;
                    parStudyYearID.SqlDbType = SqlDbType.TinyInt;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_AvgSchoolScore";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(parSchoolID);
                    cmd.Parameters.Add(parStudyYearID);

                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
        public DataTable AvgSubjectYearScore(int SchoolID, Int16 StudyYearID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            connection.ConnectionString = eRegisterData.Properties.Settings.Default.eRegisterConnectionString;
            try
            {
                using (connection)
                {
                    SqlParameter parSchoolID = new SqlParameter("@SchoolID", SchoolID);
                    SqlParameter parStudyYearID = new SqlParameter("@StudyYearID", StudyYearID);

                    parSchoolID.SqlDbType = SqlDbType.Int;
                    parStudyYearID.SqlDbType = SqlDbType.TinyInt;

                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "sp_AvgSubjectYearScore";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(parSchoolID);
                    cmd.Parameters.Add(parStudyYearID);

                    dt.Load(cmd.ExecuteReader());
                }
            }
            catch (SqlException e) { connection.Close(); }
            return dt;
        }
    }
}

