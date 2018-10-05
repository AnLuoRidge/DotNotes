using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DotNotes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        static void LoadUsers()
        {
            try
            {
                string line;
                //Pass the file path and file name to the StreamReader constructor
                string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                StreamReader sr = new StreamReader(dir + @"\login.txt");

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    //                    Console.WriteLine(line);
                    // jimy1,asdasd,View,Jim,MacDonald,14-09-1970
                    var userInfo = line.Split(',');
                    var username = userInfo[0];
                    var pwd = userInfo[1];
                    var type = userInfo[2];
                    var firstName = userInfo[3];
                    var lastName = userInfo[4];
                    var dateStr = userInfo[5];

                    UserType userType = type == "Edit" ? UserType.Edit : UserType.View;

                    var user = new User(username, pwd, firstName, lastName, dateStr, userType);
                    Console.WriteLine(user.Username + user.DateOfBirth + user.Password + user.FirstName);
                    // type enum
                    // date convert
                    //Read the next line
                    line = sr.ReadLine();
                }


                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            // add a line to end of file

        }
    }
}
