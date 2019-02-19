using System.Collections.Generic;
using Assets.Scripts.Model;
using Model;

namespace LeitnerSystem
{
    public class LeitnerState
    {
        List<LearnState<Vocabulary>> VocabularyLearnState { get; set; }
        List<LearnState<Saying>> SayingLearnState { get; set; }
        List<LearnState<AlphabetEntry>> AlphabetLearnState { get; set; }
    }
}