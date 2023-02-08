using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace SecurityQuestionApp
{
    class QandA
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }

    


    class Program
    {
        static void Main(string[] args)
        {
            bool storeExists = false;
            string userName = "nouserspecified";
            string folderPath = @"c:\myfolder";
            string userFile = userName + ".json";
            string inputPath = Path.Combine(folderPath, userFile);
            string userAnswer = "42";
            string storeAnswers = "no";
            string answerExisting = "no";
            bool answerCorrect = false;
            int numberOfQuestionsAnswered = 0;

            string outputPath = Path.Combine(folderPath, userFile);
            string json = "";
            List<QandA> questions = new List<QandA>();

            do
            {
                questions = new List<QandA>();
                
                userName = "nouserspecified";
                storeAnswers= "no";
                answerExisting = "no";
                numberOfQuestionsAnswered = 0;
                answerCorrect= false;
                
                //lets load the list with the questions

                //questions.Add(new QandA { ID = 1, Question = "What is your mother's maiden name?", Answer = "" });
                //questions.Add(new QandA { ID = 2, Question = "What was the name of your first pet?", Answer = "" });
                //questions.Add(new QandA { ID = 3, Question = "What is your favorite color?", Answer = "" });
                //questions.Add(new QandA { ID = 4, Question = "What is your favorite food?", Answer = "" });
                //questions.Add(new QandA { ID = 5, Question = "What is your favorite movie?", Answer = "" });
                //questions.Add(new QandA { ID = 6, Question = "What is your favorite book?", Answer = "" });
                //questions.Add(new QandA { ID = 7, Question = "What is your favorite song?", Answer = "" });
                //questions.Add(new QandA { ID = 8, Question = "What is your favorite hobby?", Answer = "" });
                //questions.Add(new QandA { ID = 9, Question = "What was your childhood nickname?", Answer = "" });
                //questions.Add(new QandA { ID = 10, Question = "What is the answer to life, the universe and everything?", Answer = "" });

                questions = resetList();

                Console.WriteLine("Hi!  What Is Your Name?");

                userName = Console.ReadLine();

                Console.WriteLine(" Hello, " + userName + "!");

                inputPath = Path.Combine(folderPath, userName + ".json");



                if (File.Exists(inputPath))

                {
                    storeExists = true;
                    //load the file from the local store
                    json = File.ReadAllText(inputPath);

                    questions = JsonConvert.DeserializeObject<List<QandA>>(json);

                    Console.WriteLine(userName + ", Do You Want To Answer The Existing Security Questions? yes/no");

                    answerExisting = Console.ReadLine();
                    if (string.IsNullOrEmpty(answerExisting))
                        answerExisting = "no";
                    
                    answerExisting = answerExisting.ToLower();

                }



                if (storeExists && answerExisting=="yes")
                {
                    //validate that the user is the user

                    foreach (QandA question in questions)
                    {
                        Console.WriteLine(question.Question);

                        userAnswer = Console.ReadLine();

                        if (userAnswer != "")
                        {

                            if (userAnswer == question.Answer && (userAnswer != null || userAnswer != "" || userAnswer != " "))
                            {
                                answerCorrect = true;
                                break;
                            }
                        }

                    }
                }
                else
                {
                    //populate list with user supplied answers

                    Console.WriteLine("Would You Like To Store Answers To Security Questions? yes/no");

                    storeAnswers = Console.ReadLine();

                    

                    if (!string.IsNullOrEmpty(storeAnswers))
                    {
                        if (storeAnswers.ToLower() == "yes")
                        {
                            if (storeExists)
                                questions = resetList();

                            do
                            {
                                foreach (QandA question in questions)
                                {
                                    if (numberOfQuestionsAnswered < 3)
                                    {
                                        if (string.IsNullOrEmpty(question.Answer))
                                        {
                                            Console.WriteLine(question.Question);
                                            question.Answer = Console.ReadLine();
                                            if (!string.IsNullOrEmpty(question.Answer))
                                            {
                                                numberOfQuestionsAnswered++;
                                            }
                                        }
                                    }
                                }

                            } while (numberOfQuestionsAnswered < 3);
                        }
                    }


                }


                if (answerCorrect && answerExisting=="yes")
                {
                    Console.WriteLine("Congratulations!  You Have Answered A Question Correctly");
                }
                else
                {
                    if (answerExisting=="yes")
                        Console.WriteLine("Apologies, But You Were Unable To Answer Any Of The Ten Questions.");
                }

                // foreach (QandA question in questions)
                // {
                //     Console.WriteLine(question.ID);
                //     Console.WriteLine(question.Question);
                //      Console.WriteLine(question.Answer);
                // }

                if (storeExists || storeAnswers=="yes" )
                {
                    Console.WriteLine("Press Any Key To Persist Existing Or Created Store");
                    Console.ReadKey();

                    json = JsonConvert.SerializeObject(questions, Formatting.Indented);

                    outputPath = Path.Combine(folderPath, userName + ".json");

                    File.WriteAllText(outputPath, json);

                    Console.WriteLine("the file " + outputPath + " has been created");

                }

                Console.WriteLine();

                Console.ReadKey();

                //reset the necessary data points

                
            }
            while (answerExisting.ToLower() =="yes"  || storeAnswers=="yes" || numberOfQuestionsAnswered>=3);

            

        }


        public static List<QandA> resetList()
        {
            List<QandA> templist = new List<QandA>();

            templist.Add(new QandA { ID = 1, Question = "What is your mother's maiden name?", Answer = "" });
            templist.Add(new QandA { ID = 2, Question = "What was the name of your first pet?", Answer = "" });
            templist.Add(new QandA { ID = 3, Question = "What is your favorite color?", Answer = "" });
            templist.Add(new QandA { ID = 4, Question = "What is your favorite food?", Answer = "" });
            templist.Add(new QandA { ID = 5, Question = "What is your favorite movie?", Answer = "" });
            templist.Add(new QandA { ID = 6, Question = "What is your favorite book?", Answer = "" });
            templist.Add(new QandA { ID = 7, Question = "What is your favorite song?", Answer = "" });
            templist.Add(new QandA { ID = 8, Question = "What is your favorite hobby?", Answer = "" });
            templist.Add(new QandA { ID = 9, Question = "What was your childhood nickname?", Answer = "" });
            templist.Add(new QandA { ID = 10, Question = "What is the answer to life, the universe and everything?", Answer = "" });

            return templist;

        }



    }
}
