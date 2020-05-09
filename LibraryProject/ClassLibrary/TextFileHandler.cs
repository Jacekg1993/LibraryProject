using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


namespace ClassLibrary
{
    
    public static class TextFileHandler
    {
        static string booksFilePath = @"D:\C#\ProjectLibrary\LibraryProject\books.txt";
        static string moviesFilePath = @"D:\C#\ProjectLibrary\LibraryProject\movies.txt";

        static List<string> booksFileLines = File.ReadAllLines(booksFilePath).ToList();
        static List<string> moviesFileLines = File.ReadAllLines(moviesFilePath).ToList();
        
        public static Book CreateNewBook(string title, string section, int pages)
        {
            File.AppendAllText(booksFilePath, $"\n{title},{section},{pages}"); //Add new line to .txt file
            string lastLine = File.ReadLines(booksFilePath).Last(); //Reading last line from .txt file
            string[] argumentsFromFile = lastLine.Split(','); //Split this line into separated variables which will be used as an arguments
            return new Book(argumentsFromFile[0], argumentsFromFile[1], int.Parse(argumentsFromFile[2]));
        }

        //public static void 
    }
}
