using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tabDonHang
{
    class CmangUser
    {
        CUser[] mangUser;
        public int spt;

        public CmangUser()
        {
            mangUser = new CUser[1000];
            spt = 0;
        }

        public void nhapmangUser(CUser user)
        {
            mangUser[spt] = user;
            spt++;
        }
        public bool tim(CUser user)
        {
            for (int i = 0; i < spt; i++)
            {
                if (user.username == mangUser[i].username && user.pass == mangUser[i].pass)
                {
                    user.quyentruycap = mangUser[i].quyentruycap;
                    return true;
                }
            }
            return false;
        }
        public void docfile(string tenfile)
        {
            string s;
            string[] ttUser;
            FileStream file = new FileStream("Userdata.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            while ((s = sr.ReadLine()) != null)
            {
                CUser User = new CUser();
                ttUser = tach(s);
                User.username = ttUser[0];
                User.pass = ttUser[1];
                User.quyentruycap = int.Parse(ttUser[2]);
                nhapmangUser(User);
            }
            sr.Close();
            file.Close();
        }
        public static string[] tach(string tt)
        {
            string[] a = tt.Split('/');
            return a;
        }

        public string phanquyen(CUser a)
        {
            if (a.quyentruycap == 1)
                return "Hello Manager!";
            else if (a.quyentruycap == 2)
                return "Hello Salesperson!";
            return "";
        }
    }

}
