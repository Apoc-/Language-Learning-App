namespace LeitnerSystem
{
    public abstract class Question
    {
        public AudioQuestion AsAudioQuestion()
        {
            return (AudioQuestion) this;
        }

        public ImageQuestion AsImageQuestion()
        {
            return (ImageQuestion) this;
        }

        public TextQuestion AsTextQuestion()
        {
            return (TextQuestion) this;
        }
    }
}