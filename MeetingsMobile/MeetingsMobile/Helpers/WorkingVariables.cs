using MeetingsMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingsMobile.Helpers
{
    public static class WorkingVariables
    {
        public static AuthToken Token { get; set; }
        public static List<Role> Roles { get; internal set; }

        public static void SetRoles(string roles)
        {
            var rolesEnumList = new List<Role>();
            var rolesArray = roles.Split(',');
            if (rolesArray.Length > 0)
            {
                var rolesList = new List<string>(rolesArray);
                foreach (var r in rolesList)
                {
                    if (r == "1") rolesEnumList.Add(Role.Admin);
                    if (r == "2") rolesEnumList.Add(Role.GlobalAdmin);
                    if (r == "3") rolesEnumList.Add(Role.PlantAdmin);
                    if (r == "4") rolesEnumList.Add(Role.Ito);
                    if (r == "5") rolesEnumList.Add(Role.ServiceProvider);
                    if (r == "6") rolesEnumList.Add(Role.RiskPreventionist);
                }
            }

            Roles = rolesEnumList;
        }
    }

}
