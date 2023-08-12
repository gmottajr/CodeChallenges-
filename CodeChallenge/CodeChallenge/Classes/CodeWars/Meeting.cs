using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Classes.CodeWars
{
    public static class Meeting
    {
        public static string Guest(string value)
        {
            var guestList = value.Split(";").ToList();
            var sb = new StringBuilder();
            var nameList = new List<(string FamilyName, string FirstName)>(); ;
            foreach (var guest in guestList)
            {
                guest.Trim();
                var names = guest.Split(":").ToList();
                nameList.Add((FamilyName: names[1].ToUpper(), FirstName: names[0].ToUpper()));

                
            }

            foreach(var name in nameList.OrderBy(x => x.FamilyName).ThenBy(x => x.FirstName))
            {
                sb.Append($"({name.FamilyName}, {name.FirstName})");
            }
            return sb.ToString();
        }

        public static string MeetingGuestList(string s)
        {
            return string.Join("", s
                                .ToUpper().Split(';')
                                .Select(uu => uu.Split(':'))
                                .OrderBy(f => f[1]).ThenBy(g => g[0])
                                .Select(a => "(" + a[1] + ", " + a[0] + ")"));
        }

        public static class JohnMeeting
        {
            public static string Meeting(string s) => (
                string.Join("", s
                                .ToUpper().Split(';')
                                .Select(uu => uu.Split(':'))
                                .OrderBy(f => f[1]).ThenBy(g => g[0])
                                .Select(a => "(" + a[1] + ", " + a[0] + ")")));
        }
    }
}
