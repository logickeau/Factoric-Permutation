package perm;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Map;

public class Perm {

	public static void main(String[] args) {

		// prompt the user to enter their word
		System.out.print("Please enter the word: ");

		// open up standard input
		BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

		String str = null;

		// read the string from the command-line; need to use try/catch with
		// the readLine() method
		try {
			str = br.readLine();
		} catch (IOException ioe) {
			System.out.println("IO error trying to read your word!");
			System.exit(1);
		}
		System.out.println(findRank(str));
	}

	public static long findRank(String str) {
		str = str.toUpperCase(); //ensure only capitalized.
		long count = 1; //
		int occurence = 0;
		long rank = 1; // the permuted position of the given string.
		// permutated container map for characters we previously looked at to
		// find duplications.
		Map<Character, Integer> charCounts = new HashMap<Character, Integer>();

		// Here we iterate through all the given characters according to the
		// given string's length.
		for (int i = str.length() - 1; i > -1; i--) {
			char currentCharacter = str.charAt(i); // the current character
													// being assessed.

			// have we already looked at this character? if exist add 1 else
			// equals 1.
			occurence = charCounts.containsKey(currentCharacter) ? charCounts
					.get(currentCharacter) + 1 : 1;

			charCounts.put(currentCharacter, occurence); // place the current
															// character in our
															// container.

			// assess the current character against our container for
			// duplicates/
			for (Map.Entry<Character, Integer> e : charCounts.entrySet()) {
				// Permutates through all the given values count!/occurrence!
				// (n! / r!)
				if (e.getKey() < currentCharacter) {
					rank += count * e.getValue() / occurence;
				}
			}
			count *= str.length() - i;
			count /= occurence;
		}
		return rank;
	}

}
