// Filename: Program.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopAccounting
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop
            {
                Members = new List<Member>(),
                Items = new List<Item>
                {
                    new Item { Flavor = "F1", Price = 1.00m },
                    new Item { Flavor = "F2", Price = 1.20m },
                    new Item { Flavor = "F3", Price = 1.50m }
                }
            };

            while (true)
            {
                Console.WriteLine("Enter command (add, view, quit):");
                string command = Console.ReadLine();

                if (command == "add")
                {
                    Console.WriteLine("Enter member name:");
                    string name = Console.ReadLine();

                    Member member = new Member { MemberId = Guid.NewGuid().ToString(), Name = name, Points = 0 };
                    shop.AddMember(member);

                    Console.WriteLine($"Added member {name} with ID {member.MemberId}");
                }
                else if (command == "view")
                {
                    Console.WriteLine("Enter member ID:");
                    string memberId = Console.ReadLine();

                    Member member = shop.Members.FirstOrDefault(m => m.MemberId == memberId);
                    if (member != null)
                    {
                        Console.WriteLine($"Member {member.Name} has {member.Points} points");
                    }
                    else
                    {
                        Console.WriteLine("Member not found");
                    }
                }
                else if (command == "quit")
                {
                    break;
                }
            }
        }
    }
}
