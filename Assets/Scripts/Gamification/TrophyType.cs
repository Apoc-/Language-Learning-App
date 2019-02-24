using System;

namespace Gamification
{
    [Serializable]
    public enum TrophyType
    {
        None,
        Level2,
        Level10,
        Level20,
        
        VocabSeen,
        SayingSeen,
        AlphabetSeen,
        DialogueSeen,
        
        AnimalsSeen,
        TrafficSeen,
        FoodSeen,
        LocationSeen,
        
        BirthdaySeen,
        FestivalsSeen,
        WeatherSeen,
        BehaviourSeen,
        
        VocabLearned,
        SayingLearned,
        AlphabetLearned,
        
        AllSeen,
        AllLearned,
        
        SecondLogin
    }
}