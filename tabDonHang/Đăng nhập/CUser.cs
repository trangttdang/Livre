using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang
{
    class CUser
    {
        public string username;
        public string pass;
        public int quyentruycap;

        public CUser()
        {
            username = "";
            pass = "";
        }
        public CUser(string a, string b)
        {
            username = a;
            pass = b;
        }

    }
}
