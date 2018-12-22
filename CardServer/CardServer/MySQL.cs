using System;
using ADODB;
namespace CardServer
{
    class MySQL
    {
        public static Recordset DB_RS;
        public static Connection DB_CONN;

        public static void MySQLInit()
        {
            try
            {
                DB_RS = new Recordset();
                DB_CONN = new Connection();

                DB_CONN.ConnectionString = "Driver={MySQL ODBC 3.51 Driver};Server=31.31.196.94;Port=3306;Database=u0523300_cardgamer;User=u0523300_cardgam;Password=cardgamer123;Option=3;";
                DB_CONN.CursorLocation = CursorLocationEnum.adUseServer;
                DB_CONN.Open();
                Program.Log("Подключение к базе данных MySQL прошло успешно!");

                var db = DB_RS;
                {

                    //db.Open("SELECT * FROM accounts WHERE 0=1", DB_CONN, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                    //db.AddNew();
                    //db.Fields["Username"].Value = "EvilDron2";
                    //db.Fields["Password"].Value = "password";
                    //db.Fields["Email"].Value = "pop@hmail.com";
                  //  db.Update();
                    //db.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }

    }
}
