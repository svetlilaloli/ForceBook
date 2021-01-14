using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class ForceBook
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> forceSideUsers = new Dictionary<string, List<string>>();
            string[] currentRow;
            string forceSide;
            string forceUser;
            bool exist;

            while (input != "Lumpawaroo")
            {
                if (input.IndexOf('|') > -1)
                {
                    currentRow = Array.ConvertAll(input.Split('|'), e => e.Trim());
                    forceSide = currentRow[0];
                    forceUser = currentRow[1];
                    exist = Exist(forceUser, forceSideUsers);

                    if (!exist)
                    {
                        forceSideUsers = AddUserToForce(forceSide, forceUser, forceSideUsers);
                    }
                }
                else if (input.IndexOf("->") > -1)
                {
                    currentRow = Array.ConvertAll(input.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries), e => e.Trim());
                    forceSide = currentRow[1];
                    forceUser = currentRow[0];
                    exist = Exist(forceUser, forceSideUsers);
                    if (exist)
                    {
                        forceSideUsers = ChangeForce(forceSide, forceUser, forceSideUsers);
                    }
                    else
                    {
                        forceSideUsers = AddUserToForce(forceSide, forceUser, forceSideUsers);
                    }
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
                input = Console.ReadLine();
            }

            PrintForces(forceSideUsers);
        }
        private static Dictionary<string, List<string>> ChangeForce(string forceSide, string forceUser, Dictionary<string, List<string>> forceSideUsers)
        {
            foreach (var force in forceSideUsers)
            {
                force.Value.Remove(forceUser);
            }

            forceSideUsers[forceSide].Add(forceUser);

            return forceSideUsers;
        }
        private static Dictionary<string, List<string>> AddUserToForce(string forceSide, string forceUser, Dictionary<string, List<string>> forceSideUsers)
        {
            if (!forceSideUsers.ContainsKey(forceSide))
            {
                forceSideUsers.Add(forceSide, new List<string>());
                forceSideUsers[forceSide].Add(forceUser);
            }
            else
            {
                forceSideUsers[forceSide].Add(forceUser);
            }

            return forceSideUsers;
        }
        private static void PrintForces(Dictionary<string, List<string>> forceSideUsers)
        {
            foreach (var force in forceSideUsers.OrderByDescending(f => f.Value.Count).ThenBy(f => f.Key).Where(f => f.Value.Count > 0))
            {
                Console.WriteLine($"Side: {force.Key}, Members: {force.Value.Count}");
                foreach (var user in force.Value.OrderBy(n => n))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
        private static bool Exist(string name, Dictionary<string, List<string>> forceSideUsers)
        {
            bool exist = false;

            foreach (var force in forceSideUsers)
            {
                if (force.Value.Find(u => u == name) != null)
                {
                    exist = true;
                }
            }

            return exist;
        }
    }
}