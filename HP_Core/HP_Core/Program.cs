using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace HP_Core
{
    //https://www.codeguru.com/csharp/.net/net_general/creating-a-most-recently-used-menu-list-in-.net.html
    class Program
    {
        private static Queue<string> menuList = new Queue<string>();

        static void Main(string[] args)
        {
            //menuList.Enqueue("Kevin");
            //menuList.Enqueue("Jerry");
            //menuList.Enqueue("Adam");
            //menuList.Enqueue("Julio");
            //// Most recetnly used Menu List.
            //menuList.Dequeue();
            foreach (var check in menuList)
            {
                Console.WriteLine(check);
            }

        }

        private void SaveRecentFile(string strPath)
        {
            // clear drop down or whatever.

            // Load Recent List();


            // if menu list eimpty..?
            // menu list Enqueue (path);


            // while menu list is equal or larger than 5.
            // then  dequeue call menulist.Dequeue();

            //foreach (string strItem in MRUlist)
            //{
            //    ToolStripMenuItem tsRecent = new
            //       ToolStripMenuItem(strItem, null);

            //    RecentToolStripMenuItem.DropDownItems.Add(tsRecent);
            //}

            StreamWriter strToWRite = new StreamWriter(System.Environment.CurrentDirectory + @"\Recent.txt");
            foreach (string item in menuList)
            {
                strToWRite.WriteLine(item);
            }
            strToWRite.Flush();
            strToWRite.Close();


        }
        private void LoadRecentList()
        {
            menuList.Clear();
            try
            {
                StreamReader srStream = new StreamReader
                   (Environment.CurrentDirectory + @"\Recent.txt");

                string strLine = "";

                while ((InlineAssignHelper(ref strLine,
                      srStream.ReadLine())) != null)

                    //MRUlist.Enqueue(strLine);

                    srStream.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error");
            }
        }
        private static T InlineAssignHelper<T>(ref T target, T value)
        {
            target = value;
            return value;
        }

    }
}
