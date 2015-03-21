using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input your string : "); // request the string from the user.
            string str =  Console.ReadLine(); //read the string input from the user.
            int start_time, elapsed_time; //Inititate the timer variables.
            start_time = DateTime.Now.Millisecond; //start the timer for the rank function.
            long rank = findRank(str); //invoke the findRank() method.
            elapsed_time = DateTime.Now.Millisecond - start_time; //the end time - the start time.
            Console.WriteLine("The rank for"+str+" is :"+rank); //output the rank to the user.
            Console.WriteLine("This code took "+elapsed_time+"ms of 500ms to complete."); //output the elapsed time to the user.
            Console.ReadLine(); //used just to pause the console.
        }


        public static long findRank(String str) {
		str = str.ToUpper(); //ensure only capitalized.
		long count = 1; // initiate the counter variable.
		int occurence = 0; //initaiate the amount of time a character repeats with the value of 0.
		long rank = 1; // the permuted position of the given string.

        //A container for the characters we already visited. Dictionary <key, value >, the key is the character, and the value is the occurence.
		Dictionary <char, int > charCounts = new Dictionary<char, int>();

		// We are starting a backward iteration starting at the last character based on the length of the string minus one. 
        // If i is greater -1, we deduct from i, ensuring that we are going backwards.
		for (int i = str.Length - 1; i > -1; i--) {
			char currentCharacter = str[i]; // the current character we are assessing by .

			// occurence is the variable for duplicaation. If we find that we already looked at a charcter we add 1, else it is just one.
            //EXAMPLE if we have charCounts["A"] = 1, we then add 1 manking charCounts["A"] = 1, else charCounts["A"] = 1.
			occurence = charCounts.ContainsKey(currentCharacter) ? charCounts[currentCharacter] + 1 : 1;

            //Here we simply cannot use charCounts.Add(), since the Dictionary class does not allow duplicates
            //Therefore we can simply just manually update the existing key.
			charCounts[currentCharacter] = occurence; // from the previous occurence algorithm, this where we actually add the occurence value.

			// This is where the Lexicograpic permutation happens. we are looping through charCounts
            foreach(KeyValuePair<char, int> e in charCounts)
				if (e.Key < currentCharacter) { //if we find a key that is less than the current character
					rank += count * e.Value / occurence; // 
				}

            // This whole formula is if there are k distinct characters, the i^th character repeated n_i times, then the total number of permutations is given by
            //(n_1 + n_2 + ..+ n_k)! / n_1! n_2! ... n_k!
            // we than use the the multinomial coefficient to calculate the rank. 
			  count *= str.Length - i;
			  count /= occurence;
            
		}
		return rank; // we return the rank.
	}


    }
}
