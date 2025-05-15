/* s225550997 Thembelihle Faltein 
 * s225576147 Simphiwe Nkosenye Hleza
 * s225139049 Gcobisa Sidumo
 * s225143178 Keanu Kapank
 * s225139472 Kamogelo Maifadi
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRT_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            int[] data = ReadFromFile("AssignementData.txt"); // Populating data array with elements in file

            char run = 'y';
            do
            {
                GetUserInput(data);
                Console.WriteLine("\n\nDo you want to continue running the program (y/n):");
                run = char.Parse(Console.ReadLine());
                Console.Clear();
            } while (run != 'n');

            Console.ReadLine();
        }

        private static void GetUserInput(int[] data)
        {
            Console.WriteLine("Good day, Mr Damian.Which number are you looking for today. ");
            int target = HandleException(); // Checks to see if the input value is valid
            
            Console.WriteLine("Which searching Algorithm would you like to use? ");
            Console.WriteLine("1)Linear Search\t\t2)Binary Search");
            

            //Do while loop will run and if the user does not enter one of the options (1 or 2). It will run again
            int searchOption;
            do
            {
                searchOption = HandleException();
            } while (!IsAcceptible(searchOption, 1, 2));

            

            //Using a switch statement. So different Searching algorithms will be executed depending on user input
            switch (searchOption)
            {
                case 1:
                    LinearSearch(data, target);
                    break;
                case 2:
                    Console.WriteLine("\nIf you want to use Binary Search we have to Sort our data first...");
                    Console.WriteLine("1)Bubble Sort\t\t2)Insertion Sort\t\t3)Quick Sort");

                    //Do while loop will run and if the user does not enter one of the options (1 , 2 or 3). It will run again
                    int sortOption = 0;
                    do
                    {
                        sortOption = HandleException();
                    } while (!IsAcceptible(sortOption, 1, 3)); // IsAcceptible Method to check if userInput is valid


                    Console.Write("We have found that there are some duplicates in the text file.Do you want to remove them?\n1)Yes\t2)No\n");
                    int option = HandleException();
                    int[] cleanArray = new int[100];
                    if (option == 1)
                    {
                        cleanArray = RemoveDuplicateArray(data, sortOption);

                        //Using a switch statement. So different Searching algorithms will be executed depending on user input
                        switch (sortOption)
                        {
                            case 1:
                                BubbleSort(cleanArray);
                                DisplayData(cleanArray);
                                break;
                            case 2:
                                
                                InsertionSort(cleanArray);
                                DisplayData(cleanArray);
                                break;
                            case 3:
                                
                                QuickSort(cleanArray, 0, cleanArray.Length - 1);
                                DisplayData(cleanArray);
                                break;
                        }
                        BinarySearch(cleanArray, target);
                    }
                    else
                    {

                        //Using a switch statement. So different Searching algorithms will be executed depending on user input
                        switch (sortOption)
                        {
                            case 1:
                         
                                BubbleSort(data);
                                DisplayData(data);
                                break;
                            case 2:
                                InsertionSort(data);
                                DisplayData(data);
                                break;
                            case 3:
                                QuickSort(data, 0, cleanArray.Length - 1);
                                DisplayData(data);
                                break;
                        }

                        BinarySearch(data, target);
                    }

                    break;
            }

        }

        static void LinearSearch(int[] arrayNumber, int numberToFind)
        {

            int indexFound = -1;
            bool found = false;

            //bool duplicateRemoval = false;
            //char removeValue = 'y';

            for (int i = 0; i < arrayNumber.Length; i++)
            {
                //checks if the number is in the array
                if (numberToFind == arrayNumber[i])
                {
                    indexFound = i;//sets indexfound to whatever index number the value was in
                    found = true;//checks if the value is true
                    Console.WriteLine($"{numberToFind} was found at index {indexFound}");//displaying the number we found and it's index
                    //Console.Write("\nDo you want to remove the duplicates?(y/n): ");
                    //removeValue = char.Parse(Console.ReadLine());
                }
                
                //if (removeValue == 'y')
                //{
                //    duplicateRemoval = true;
                //    if (duplicateRemoval == true)
                //    {
                //        DeleteDuplicates(arrayNumber);
                //    }
                ///
                
            }
            if (!found)
            {
                Console.WriteLine($"{numberToFind} was not found");
            }
        }

        static void BinarySearch(int[] lines, int number)
        {
            int first = 0, last = lines.Length - 1, middle = 0;
            bool found;
            int indexFound;
            first = 0;


            found = false;
            
            while (found == false && first <= last)
            {
                middle = (first + last) / 2;//checking where the middle index is in the array

                if (number == lines[middle]) //checks if the number to find is the one in the middle
                {
                    found = true;
                    
                }
                else 
                {
                    if (lines[middle] < number)//if the element to find is smaller than the middle element
                        first = middle + 1;//then change the position of the first pointer
                    else//if its bigger than the middle element 
                        last = middle - 1;//then change the position of the last pointer
                }
            }
            //code to display if the number is found or not
            if (found == true)
            {
                Console.WriteLine($"{number} was found at index {middle}");
            }else
            {
                Console.WriteLine($"{number} was not found");
            }
           

        }

        private static void BubbleSort(int[] data)
        {


            // After each itaration the largest number will 'bubble' up to the end of array
            for (int i = 0; i < data.Length; i++)
            {
                // Loop to check Adjacent value pairs
                for (int j = 1; j < data.Length; j++)
                {
                    //Check to see if element on left is less that it, if so Swap
                    if (data[j] < data[j - 1])
                    {
                        int temp = data[j];
                        data[j] = data[j - 1];
                        data[j - 1] = temp;
                    }
                }
            }

            
        }
        static void QuickSort(int[] array, int start, int end)
        {
            int i;
            if (start < end)
            {
                i = Partition(array, start, end);
                QuickSort(array, start, i - 1); ///Sorting the left-hand side of the pivot//
                QuickSort(array, i + 1, end);///Sorting the right-hand side of the pivot//
            }
        }

        static int Partition(int[] array, int start, int end)
        {
            int temp;
            int pivot = array[end];//Makes the pivot the last value of the array///
            int i = start - 1;///Set's "i" to the -1 index so that we can know the final resting place for the pivot/// 

            for (int x = start; x <= end - 1; x++)
            {
                if (array[x] <= pivot)///Checks if the selected array is less than the pivot// 
                {   
                    //This is where the swapping occurs//
                    i++;
                    temp = array[i];
                    array[i] = array[x];
                    array[x] = temp;
                }///end of IF///
            }///end of FOR LOOP///

            ///Increment "i" and swap the value at the index of "i" with the pivot///
            //////Swapping the values the values around to where it belongs///
            temp = array[i + 1];
            array[i + 1] = array[end];
            array[end] = temp;

            return i + 1;
        }

        private static void InsertionSort(int[] array)
        {

            for (int i = 0; i < array.Length - 1; i++)
            {
                int temp;
                //Checks to see all the element to the left of i
                for (int X = i + 1; X > 0; X--)

                    if (array[X - 1] > array[X]) // Swap if the element on left is greater than adjacent pair.
                    {
                        // Swapping takes place
                        temp = array[X - 1];
                        array[X - 1] = array[X];
                        array[X] = temp;
                    }
            }
        }
        private static int HandleException()
        {
            // Prevent user from entering text in input field
            bool isValid = false;
            int option = 0;
            do
            {
                try
                {
                    Console.Write("Enter your option here: ");
                    option = int.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (System.FormatException e)
                {
                    MessageBox.Show("Please enter a number and not text");
                }
            } while (!isValid);

            return option;
        }

        private static bool IsAcceptible(int option, int beginning, int end)
        {
            // Prevents user from entering an option that is not in our list
            if (option >= beginning && option <= end)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please enter only the option provided to you");
                return false;
            }
        }
        private static int[] ReadFromFile(string fileName)
        {
            // Check to see if our file exist
            if (File.Exists(Path.GetFullPath(fileName)))
            {
                StreamReader reader = new StreamReader(fileName);
                int[] data = new int[FileLength(fileName)]; // Getting the length of text file

                int i = 0;  
                //Reading from file while its not the end
                while (!reader.EndOfStream)
                {

                    data[i] = int.Parse(reader.ReadLine()); // Placing each line in the array
                    i++;
                }
                reader.Close();

                return data; 
            }else // If file does not exist
            {
                Console.WriteLine($"{fileName} does not exist");
                return null;
            }
        }

        private static int FileLength(string fileName)
        {
            // Gets the amount of element in file (size)
            int count = 0;
            StreamReader reader = new StreamReader(fileName);

            string line = "";
            while((line = reader.ReadLine()) != null)
            {
                count++;
            }

            return count;
        }

        private static void DisplayData(int[] data)
        {
            //Displaying all the elements in array to the user
            int count = 0;
            foreach (int i in data)
            {
                Console.WriteLine($"[index {count}] : {i}");
                count++;
            }
        }

        public static int DeleteDuplicates(int[] array, int sortingAlgo)
        {

            if (sortingAlgo == 1)
            {
                BubbleSort(array);
            }else if(sortingAlgo == 2)
            {
                InsertionSort(array);
            }else
            {
                QuickSort(array, 0, array.Length - 1);
            }

            
                   
            if (array.Length == 0)
            {
                return 0;
            }

            int endOfList = 0;

            for (int j = 1; j < array.Length; j++)
            {
                if (array[endOfList] != array[j])
                {
                    endOfList++;
                    array[endOfList] = array[j];
                }
            }

            return endOfList + 1;
        }

        public static int[] RemoveDuplicateArray(int[] array, int sortingOption)
        {
            int endofList = DeleteDuplicates(array, sortingOption);
            int[] newArray = new int[100];

            for (int i = 0; i < newArray.Length; i++)
            {
                Console.WriteLine(array[i]);
                newArray[i] = array[i];
            }

            return newArray;
        }
    }
}
