namespace Assets.Scripts.Model
{
    public class LearnState<T> where T : LearnItem
    {
        public T Item { get; set; }
        public int LeitnerBoxNr { get; set; }
    }
}