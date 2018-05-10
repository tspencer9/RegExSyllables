using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace RegExSyllables // uses the Flesch-Kincaid Reading Ease design
{
    public partial class RegexSyllables : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PhraseSubmitButton_Click(object sender, EventArgs e)
        {
            string phrase = phraseTextBox.Text;
            int sentenceCount = FindSentenceNumber(phrase),
                wordCount = FindWordNumber(phrase),
                syllableCount = FindSyllableNumber(phrase);

            double score = CalculateReadingScore(sentenceCount, wordCount, syllableCount);
            string readingLevel = FindReadingLevel(score);

            SentenceTextBox.Text = sentenceCount.ToString();
            WordTextbox.Text = wordCount.ToString();
            SyllableTextBox.Text = syllableCount.ToString();
            ScoreTextBox.Text = score.ToString();
            LevelTextBox.Text = readingLevel;
        }

        private int FindSentenceNumber(string sentence)
        {
            var mainMatches = Regex.Matches(sentence, @"\w[\.\?\!]"); // the end of a sentence
            var irregularMatches = Regex.Matches(sentence, @"[\.]\w+"); // if period found in email address for example
            return mainMatches.Count - irregularMatches.Count;
        }

        private int FindWordNumber(string sentence)
        {
            return Regex.Matches(sentence, @"\b\w+\b").Count; // takes into account contractions
        }

        private int FindSyllableNumber(string sentence) // get all the words and find the number of syllables per word
        {
            String[] words = sentence.Split(' ');
            Regex exceptionMatch = new Regex(@"(^y|([^cs]hes|[^csh]es|e|[^t]ed)\b)");
            int count = 0;

            foreach (String word in words)
            {
                word.ToLower();

                if (word.Length == 0) // if no text is entered and submit button is pressed
                    count += 0;
                else if (word.Length < 5) // words less than 5 characters have one syllable
                    count++;
                else
                {
                    string wordModified = exceptionMatch.Replace(word, "");
                    count += Regex.Matches(wordModified, @"[aeiouy]{1,2}").Count;
                }
            }

            return count;
        }

        private double CalculateReadingScore(int sentenceNumber, int wordNumber, int syllableNumber)
        {
            double averageWordsPerSentence = (double)wordNumber / (double)sentenceNumber;
            double averageSyllablesPerWord = (double)syllableNumber / (double)wordNumber;
            return 206.835 - 1.015 * averageWordsPerSentence - 84.6 * averageSyllablesPerWord;
        }

        private string FindReadingLevel(double score)
        {
            if (score > 90)
                return "5th grade";
            else if (score > 80)
                return "6th grade";
            else if (score > 70)
                return "7th grade";
            else if (score > 60)
                return "8th and 9th grade";
            else if (score > 50)
                return "10th - 12 grade";
            else if (score > 30)
                return "College";
            else if (score <= 30)
                return "College graduate";
            else
                return "Entry was not valid"; // if no text is entered
        }
    }
}