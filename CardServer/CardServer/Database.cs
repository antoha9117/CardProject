using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;



namespace CardServer
{
    class Database
    {
        private static MD5 md5Hash = MD5.Create();

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static void AddAccount(string username, string password, string email)
        {
            var db = MySQL.DB_RS;
            {
                
                db.Open("SELECT * FROM accounts WHERE 0=1", MySQL.DB_CONN, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                db.AddNew();
                db.Fields["Username"].Value = username;
                db.Fields["Password"].Value = GetMd5Hash(md5Hash,password);
                db.Fields["Email"].Value = email;
                db.Update();
                db.Close();
            }
        } 
        public static bool AccountExist(long index, string username)
        {
            var db = MySQL.DB_RS;
            {

                db.Open("SELECT * FROM accounts WHERE Username='"+username+"'", MySQL.DB_CONN, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);

                if (db.EOF)
                {
                    ServerTCP.SendAlertTo(index, "User with this login doesn't exist!");
                    db.Close();
                    return false;
                }
                else
                {
                    db.Close();
                    return true;
                }
                
            }
        }
        public static bool PasswordOK(long index, string username, string password)
        {
            var db = MySQL.DB_RS;
            {

                db.Open("SELECT '"+username+"' FROM accounts WHERE Password='" + GetMd5Hash(md5Hash,password) + "'", MySQL.DB_CONN, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);

                if (db.EOF)
                {
                    ServerTCP.SendAlertTo(index, "Incorrect passord");

                    db.Close();
                    return false;
                }
                else
                {
                    db.Close();
                    return true;
                }

            }
        }

    }
}
