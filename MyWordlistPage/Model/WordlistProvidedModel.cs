namespace MyWordlistPage.Model
{
    public class WordlistProvidedModel
    {
        public string Level { get; set; }
        public string Type { get; set; }
        public string Word { get; set; }
        public string Meaning { get; set; }

        public override string ToString()
        {
            return Word;
        }
    }
}
