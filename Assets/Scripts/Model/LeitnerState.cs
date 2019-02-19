using System.Collections.Generic;

namespace Assets.Scripts.Model
{
    public class LeitnerState
    {
        List<LearnState<Vocabulary>> VocabularyLearnState { get; set; }
        List<LearnState<Saying>> SayingLearnState { get; set; }
        List<LearnState<AlphabetEntry>> AlphabetLearnState { get; set; }
    }
}