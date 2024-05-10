using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ExcersiceLinq;
class Program
{
    public static void Main(string[] args)
    {
        TraineeData traineeData = new TraineeData();
        List<TraineeDetails> traineeDetailsList = traineeData.GetTraineeDetails();

        Console.WriteLine("----Select ----");
        Console.WriteLine(" 1 : Show list of Trainee Id");
        Console.WriteLine(" 2 : Show first 3 Trainee Id using Take");
        Console.WriteLine(" 3 : show last 2 Trainee Id using Skip");
        Console.WriteLine(" 4 : show count of Trainee");
        Console.WriteLine(" 5 : show Trainee Name who are all passed out 2019 or later");
        Console.WriteLine(" 6 : show Trainee Id and Trainee Name by alphabetic order of the trainee name");
        Console.WriteLine(" 7 : show Trainee Id, Trainee Name, Topic Name, Exercise Name and Mark who are all scores the more than or equal to 4 mark");
        Console.WriteLine(" 8 : show unique passed out year using distinct");
        Console.WriteLine(" 9 : show total marks of single user ");
        Console.WriteLine(" 10 : show first Trainee Id and Trainee Name");
        Console.WriteLine(" 11 : show last Trainee Id and Trainee Name");
        Console.WriteLine(" 12 : print total score of each trainee");
        Console.WriteLine(" 13 : show Maximum score");
        Console.WriteLine(" 14 : show Minimum score");
        Console.WriteLine(" 15 : show Average score");
        Console.WriteLine(" 16 : show true or false if any one has the more than 40");
        Console.WriteLine(" 17 : show true of false if all of them has the more than 20 ");
        Console.WriteLine(" 18 : show trainee Id, Trainee Name, Topic Name, Exercise Name and Mark by show the Trainee Name as descending & then show  Mark as descending.");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                {
                    ShowTraineeId(traineeDetailsList);
                    break;
                }
            case 2:
                {
                    ShowFirst3Trainee(traineeDetailsList);
                    break;
                }
            case 3:
                {
                    ShowLast2Trainee(traineeDetailsList);
                    break;
                }
            case 4:
                {
                    ShowTraineeCount(traineeDetailsList);
                    break;
                }
            case 5:
                {
                    ShowTraineePassedOutAfter2019(traineeDetailsList);
                    break;
                }
            case 6:
                {
                    ShowTraineeIdsAndNamesAlphabetically(traineeDetailsList);
                    break;
                }
            case 7:
                {
                    ShowHighScorer(traineeDetailsList);
                    break;
                }
            case 8:
                {
                    ShowUniquePassedOutYear(traineeDetailsList);
                    break;
                }
            case 9:
                {
                    ShowTotalMarksForSingleUser(traineeDetailsList);
                    break;
                }
            case 10:
                {
                    ShowFirstTraineeIdAndName(traineeDetailsList);
                    break;
                }
            case 11:
                {
                    ShowLastTraineeIdAndName(traineeDetailsList);
                    break;
                }
            case 12:
                {
                    ShowTotalScoreOfEachTrainee(traineeDetailsList);
                    break;
                }
            case 13:
                {
                    ShowMaximumScore(traineeDetailsList);
                    break;
                }
            case 14:
                {
                    ShowMinimumScore(traineeDetailsList);
                    break;
                }
            case 15:
                {
                    ShowAverageScore(traineeDetailsList);
                    break;
                }
            case 16:
                {
                    CheckIfAnyoneHasMoreThan40(traineeDetailsList);
                    break;
                }
            case 17:
                {
                    CheckIfAllHaveMoreThan20(traineeDetailsList);
                    break;
                }
            case 18:
                {
                    ShowDetailsDescendingOrder(traineeDetailsList);
                    break;
                }
            default:
                {
                    Console.WriteLine("Invalid choice!");
                    break;
                }
        }
    }
    // 1
    public static void ShowTraineeId(List<TraineeDetails> traineeDetails)
    {
        var traineeIDs = traineeDetails.Select(id => id.TraineeId);
        Console.WriteLine("Trainee IDs are ");
        foreach (var traineeId in traineeIDs)
        {
            Console.WriteLine(traineeId);
        }
    }
    // 2
    public static void ShowFirst3Trainee(List<TraineeDetails> traineeDetailsList)
    {
        var traineeIDs = traineeDetailsList.Select(id => id.TraineeId).Take(3);
        Console.WriteLine("First 3 Trainee ID's are ");
        foreach (var traineeId in traineeIDs)
        {
            Console.WriteLine(traineeId);
        }
    }
    // 3
    public static void ShowLast2Trainee(List<TraineeDetails> traineeDetailsList)
    {
        var traineeIds = traineeDetailsList.Select(td => td.TraineeId).Skip(traineeDetailsList.Count - 2);
        Console.WriteLine("Last 2 Trainee IDs:");
        foreach (var traineeId in traineeIds)
        {
            Console.WriteLine(traineeId);
        }
    }
    // 4
    public static void ShowTraineeCount(List<TraineeDetails> traineeDetailsList)
    {
        Console.WriteLine($"Total Trainees: {traineeDetailsList.Count}");
    }
    // 5
    public static void ShowTraineePassedOutAfter2019(List<TraineeDetails> traineeDetailsList)
    {
        var traineeNames = traineeDetailsList.Where(td => td.YearPassedOut >= 2019).Select(td => td.TraineeName);
        Console.WriteLine("Trainee Name Passed Out After 2019:");
        foreach (var traineeName in traineeNames)
        {
            Console.WriteLine(traineeName);
        }
    }
    // 6
    public static void ShowTraineeIdsAndNamesAlphabetically(List<TraineeDetails> traineeDetailsList)
    {
        var trainees = traineeDetailsList.OrderBy(td => td.TraineeName);//.Select(td => new { td.TraineeId, td.TraineeName });
        Console.WriteLine("Trainee IDs &  Names in Alphabetical Order:");
        foreach (var trainee in trainees)
        {
            Console.WriteLine($"Trainee ID: {trainee.TraineeId}, Trainee Name: {trainee.TraineeName}");
        }
    }
    // 7
    public static void ShowHighScorer(List<TraineeDetails> traineeDetailsList)
    {
        var highScorers = traineeDetailsList.SelectMany(td => td.ScoreDetails.Where(ts => ts.Mark >= 4),
                                                    (td, ts) => new { td.TraineeId, td.TraineeName, ts.TopicName, ts.ExerciseName, ts.Mark });
        Console.WriteLine("Trainee ID, Trainee Name, Topic Name, Exercise Name and Mark for Scores >= 4:");
        foreach (var scorer in highScorers)
        {
            Console.WriteLine($"Trainee ID: {scorer.TraineeId}, Trainee Name: {scorer.TraineeName}, Topic: {scorer.TopicName}, Exercise: {scorer.ExerciseName}, Mark: {scorer.Mark}");
        }
    }
    // 8 
    public  static void ShowUniquePassedOutYear(List<TraineeDetails> traineeDetailsList)
    {
        var uniqueYears = traineeDetailsList.Select(td => td.YearPassedOut).Distinct(); // get unique collection or remove duplicate
        Console.WriteLine("Unique Passed Out Years:");
        foreach (var year in uniqueYears)
        {
            Console.WriteLine(year);
        }
    }
    // 9
    public static void ShowTotalMarksForSingleUser(List<TraineeDetails> traineeDetailsList)
    {
        Console.WriteLine("Enter Trainee ID:");
        string traineeId = Console.ReadLine();
        var trainee = traineeDetailsList.FirstOrDefault(td => td.TraineeId == traineeId);
        if (trainee != null)
        {
            int totalMarks = trainee.ScoreDetails.Sum(ts => ts.Mark);
            Console.WriteLine($"Total Marks for Trainee {traineeId} : {totalMarks}");
        }
        else
        {
            Console.WriteLine("Invalid Trainee ID!");
        }
    }
    // 10
    public static void ShowFirstTraineeIdAndName(List<TraineeDetails> traineeDetailsList)
    {
        var firstTrainee = traineeDetailsList.First();
        Console.WriteLine($"First Trainee ID: {firstTrainee.TraineeId}, Name: {firstTrainee.TraineeName}");
    }
    // 11
    public static void ShowLastTraineeIdAndName(List<TraineeDetails> traineeDetails)
    {
        var lastTrainee = traineeDetails.Last();
        Console.WriteLine($"Last Trainee ID: {lastTrainee.TraineeId}, Name: {lastTrainee.TraineeName}");
    }
    // 12
    public static void ShowTotalScoreOfEachTrainee(List<TraineeDetails> traineeDetailsList)
    {
        Console.WriteLine("Total Score of Each Trainee:");
        foreach (var trainee in traineeDetailsList)
        {
            int totalScore = trainee.ScoreDetails.Sum(ts => ts.Mark);
            Console.WriteLine($"Trainee ID: {trainee.TraineeId}, Name: {trainee.TraineeName}, Total Score: {totalScore}");
        }
    }
    // 13
    public static void ShowMaximumScore(List<TraineeDetails> traineeDetailsList)
    {
        int maxTotalScore = traineeDetailsList.Max(td => td.ScoreDetails.Sum(ts => ts.Mark));
        Console.WriteLine($"Maximum  Score: {maxTotalScore}");
    }
    // 14
    public static void ShowMinimumScore(List<TraineeDetails> traineeDetailsList)
    {
        int minTotalScore = traineeDetailsList.Min(td => td.ScoreDetails.Sum(ts => ts.Mark));
        Console.WriteLine($"Minimum Score: {minTotalScore}");
    }
    // 15
    public static void ShowAverageScore(List<TraineeDetails> traineeDetailsList)
    {
        double averageTotalScore = traineeDetailsList.Average(td => td.ScoreDetails.Sum(ts => ts.Mark));
        Console.WriteLine($"Average Score: {averageTotalScore}");
    }
    // 16
    public static void CheckIfAnyoneHasMoreThan40(List<TraineeDetails> traineeDetailsList)
    {
        bool hasMoreThan40 = traineeDetailsList.Any(td => td.ScoreDetails.Sum(ts => ts.Mark) > 40);
        Console.WriteLine($"Person who attains more than 40 : {hasMoreThan40}");
    }
    // 17
    public static void CheckIfAllHaveMoreThan20(List<TraineeDetails> traineeDetailsList)
    {
        bool allHaveMoreThan20 = traineeDetailsList.All(td => td.ScoreDetails.Sum(ts => ts.Mark) > 20);
        Console.WriteLine($"All have more than 20 : {allHaveMoreThan20}");
    }
    // 18
    public static void ShowDetailsDescendingOrder(List<TraineeDetails> traineeDetailsList)
    {
        var details = traineeDetailsList.SelectMany(td => td.ScoreDetails,
                                                (td, ts) => new { td.TraineeId, td.TraineeName, ts.TopicName, ts.ExerciseName, ts.Mark })
                                    .OrderByDescending(td => td.TraineeName)
                                    .ThenByDescending(td => td.Mark);

        Console.WriteLine("Details sorted by Trainee Name (descending) and Mark (descending):");
        foreach (var detail in details)
        {
            Console.WriteLine($"Trainee ID: {detail.TraineeId}, Trainee Name: {detail.TraineeName}, Topic: {detail.TopicName}, Exercise: {detail.ExerciseName}, Mark: {detail.Mark}");
        }
    }
}







