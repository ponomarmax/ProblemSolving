/*
 * Word Search
 * Link: https://leetcode.com/problems/word-search/
 */
var solution = new Solution();
var testCase1 = new char[][] { new char[] { 'A', 'B', 'C', 'E' } ,
                             new char[] { 'S', 'F', 'C', 'S' },
                             new char[] { 'A', 'D', 'E', 'E' } };
var word1 = "SEE";//"ABCCED";

var testCase2 = new char[][] { new char[] { 'b' } ,
                             new char[] { 'a' },
                             new char[] { 'b' } , new char[] { 'b' } ,new char[] { 'a' } };
var word2 = "baa";
Console.WriteLine(solution.Exist(testCase1, word1));
