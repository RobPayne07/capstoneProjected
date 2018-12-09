using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace capstoneProjected
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menuRun = true;
            List<RoomStats> roomState = new List<RoomStats>();

            Console.WriteLine("We're going to dimension a house!");
            Console.WriteLine("Press any key to Continue");
            Console.ReadKey();

            while (menuRun)
            {
                menuRun = MenuRun(roomState);
            }

            //Console.WriteLine("HOUSE!");
            //Console.ReadKey();
        }

        static void WriteListToFile(List<RoomStats> roomState)
        {
            string filePath = @"data\RoomList.txt";

            DisplayHeader("Writing a List to A File.");

            Console.WriteLine("Press any key to write the current list to the file \"RoomList.txt\".");
            Console.ReadKey();

            string roomString;
            List<string> RoomList = new List<string>();

            foreach (RoomStats roomStat in roomState)
            {
                roomString =
                    roomStat.RoomName + "," +
                    roomStat.DimensionOne.ToString() + "," +
                    roomStat.DimensionTwo.ToString() + "," +
                    roomStat.SquareFootage.ToString();

                RoomList.Add(roomString);
            }

            try
            {
                File.WriteAllLines(filePath, RoomList);
                Console.WriteLine("List Written Successfully.");
            }
            catch (Exception) // throw any exception up to the calling method
            {
                Console.WriteLine("Didn't Work. Try Again.");
            }

           

            DisplayContinueScreeeeeeeeeeeeeen();
        }

        static List<RoomStats> ReadListFromFile()
        {
            DisplayHeader("Story Time");

            const char delineator = ','; // John Velis
            List<string> roomState = new List<string>();
            List<RoomStats> roomStates = new List<RoomStats>();
            RoomStats tempUserRoom = new RoomStats();
            string filePath = @"data\RoomList.txt";

            try
            {
                roomState = File.ReadAllLines(filePath).ToList();
            }
            catch (Exception) // throw any exception up to the calling method
            {
                Console.WriteLine("That didn't work. Try again.");
            }
            foreach (string roomStat in roomState)
            {
                string[] userRooms = roomStat.Split(delineator);

                tempUserRoom.DimensionOne = Convert.ToDouble(userRooms[1]);
                tempUserRoom.DimensionTwo = Convert.ToDouble(userRooms[2]);
                tempUserRoom.RoomName = userRooms[0];
                tempUserRoom.SquareFootage = Convert.ToDouble(userRooms[3]);

                roomStates.Add(tempUserRoom);
            }

            if (roomStates.Contains(tempUserRoom))
            {
                Console.WriteLine("List Read Successfully!");
            }

            DisplayContinueScreeeeeeeeeeeeeen();
            return roomStates;
        }

        static double AddRoom(List<RoomStats> roomState)
        {
            DisplayHeader("Adding a room\n");

            RoomStats userRoom1 = new RoomStats();
            double dimOne = 0;
            double dimTwo = 0;
            double tempSquare = 0;
            bool valDim = false;

            Console.WriteLine("Enter Name of Room: ");
            userRoom1.RoomName = Console.ReadLine().ToUpper();

            do
            {
                Console.WriteLine($"Enter {userRoom1.RoomName}'s first Dimension (FEET):");
                if (!double.TryParse(Console.ReadLine(), out dimOne))
                {
                    Console.WriteLine("Not a number or not a supported input. Try again.");
                    valDim = false;
                }
                else
                {
                    valDim = true;
                }
            } while (!valDim);
            userRoom1.DimensionOne = dimOne;
            valDim = false;
            do
            {
                Console.WriteLine($"Enter {userRoom1.RoomName}'s second Dimension (FEET):");
                if (!double.TryParse(Console.ReadLine(), out dimTwo))
                {
                    Console.WriteLine("Not a number or not a supported input. Try again.");
                    valDim = false;
                }
                else
                {
                    valDim = true;
                }
            } while (!valDim);
            userRoom1.DimensionTwo = dimTwo;

            userRoom1.SquareFootage = userRoom1.DimensionOne * userRoom1.DimensionTwo;

            Console.WriteLine($"Alright, so your first room is named {userRoom1.RoomName}, and it is a {userRoom1.DimensionOne}' x {userRoom1.DimensionTwo}' Room, adding to a total square footage of {userRoom1.SquareFootage} feet squared.");

            Console.WriteLine("Press any key to add room.");
            Console.ReadKey();
            roomState.Add(userRoom1);

            Console.WriteLine("Room Added!");

            tempSquare = userRoom1.SquareFootage;

            DisplayContinueScreeeeeeeeeeeeeen();

            return tempSquare;
        }

        static bool MenuRun(List<RoomStats> roomState)
        {
            double totalSquared = 0;
            double tempSquare = 0;
            bool menuRun = true;

            DisplayHeader("Menu? Menu.");

            do
            {
                Console.Clear();
                Console.WriteLine("Pick an Option:");
                Console.Write(
                    "\n A) Write a Room List to A File" +
                    "\n B) Read a Room List From a File" +
                    "\n C) Add a Room" +
                    "\n D) View the list of Rooms" +
                    "\n E) Exit \n\n");

                totalSquared = totalSquared + tempSquare;

                //Console.WriteLine($"Current Square Footage: {totalSquared}");
                Console.WriteLine($"Current Number of Rooms: {roomState.Count}");

                //Console.WriteLine($"Current Total Square footage: {roomState}");

                switch (Console.ReadLine().ToUpper())
                {
                    case "A":
                        WriteListToFile(roomState);
                        menuRun = true;
                        break;
                    case "B":
                        roomState = ReadListFromFile();
                        menuRun = true;
                        break;
                    case "C":
                        tempSquare = AddRoom(roomState);
                        menuRun = true;
                        break;
                    case "D":
                        DisplayListContents(roomState);
                        menuRun = true;
                        break;
                    case "E":
                        DisplayExitScreeeeeeeeeeeeen();
                        menuRun = false;
                        break;
                    default:
                        break;
                }
            } while (menuRun);

            return menuRun;
        }

        static void DisplayListContents(List<RoomStats> roomState)
        {
            DisplayHeader("\n\t\tList Of Rooms\n");

            Console.Write("\tRoom Name".PadRight(25) + "Dimension One".PadRight(25) + "Dimension Two".PadRight(25) + "Square Footage of Room\n");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");

            double totalSquared = 0;
            foreach (RoomStats roomStat in roomState)
            {
                Console.WriteLine($"\t{roomStat.RoomName}".PadRight(25) + $"{roomStat.DimensionOne}".PadRight(25) + $"{roomStat.DimensionTwo}".PadRight(25) + $"{roomStat.SquareFootage}\n");
                totalSquared += roomStat.SquareFootage; // John Velis
            }

            Console.WriteLine($"Current Square Footage: {totalSquared}");
            Console.WriteLine($"Current Number of Rooms: {roomState.Count}");

            Console.WriteLine();
            Console.WriteLine();
            DisplayContinueScreeeeeeeeeeeeeen();
        }

        #region Helpers?

        static void DisplayHeader(string header)
        {
            Console.Clear();
            Console.WriteLine("\t\t" + header);
            Console.WriteLine();
        }

        static void DisplayContinueScreeeeeeeeeeeeeen()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        static void DisplayExitScreeeeeeeeeeeeen()
        {
            DisplayHeader("");
            Console.WriteLine("This screen means you want to leave.");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        #endregion
    }
}
