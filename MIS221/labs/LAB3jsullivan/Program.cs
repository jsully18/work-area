// See https://aka.ms/new-console-template for more information


//Begin Main


string vibe = GetSpringBreakVibe();
while(vibe != "STOP"){

    string getDestinationRecommend = GetDestinationRecommendation(vibe);
    string getActivityRecommend = GetActivityRecommendation(getDestinationRecommend);
    DisplaySpringBreakDetails(vibe, getDestinationRecommend, getActivityRecommend);



    vibe = GetSpringBreakVibe(); //loop read
}

// method calling for user input
static string GetSpringBreakVibe(){
    System.Console.WriteLine("Enter your Spring Break Vibe of choice (Relaxing, Adventurous, Party, Luxurious, STOP to end)");
    string vibe = Console.ReadLine();
    return vibe;

}

// method calling place off of user input
static string GetDestinationRecommendation(string vibe){
    switch (vibe.ToLower()){
        case "relaxing":
            return "maldives beach resort";

        case "adventurous":
            return "rocky mountain national park";

        case "party":
            return "miami, fl";

        case "luxurious":
            return "monte carlo, monaco";

        default:
            return "Invalid Input";
    }

}

//method calling activity of off input
static string GetActivityRecommendation(string getDestinationRecommend){
    switch (getDestinationRecommend.ToLower()){
        case "maldives beach resort":
            return "Sunset Yoga on the Beach";
        
        case "rocky mountain national park":
            return "Hiking to Emerald Lake";
        
        case "miami, fl":
            return "Nightlife at South Beach";

        case "monte carlo, monaco":
            return "Yacht Cruise along the Riviera";

        default:
            return "Invalid Input";
    }
}

static void DisplaySpringBreakDetails(string vibe, string getDestinationRecommend, string getActivityRecommend){
    Console.WriteLine($"Your choice of {vibe} indicates that {getDestinationRecommend} with the activity of {getActivityRecommend} is the right fit.");
}