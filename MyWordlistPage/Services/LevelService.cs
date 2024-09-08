
using MyWordlistPage.Model;
using System.Collections.ObjectModel;

namespace MyWordlistPage.Services
{
    public abstract class LevelService
    {
        public ObservableCollection<WordlistProvidedModel> pWords { get; set; }
        protected int currentIndex = 1;

        public WordlistProvidedModel GetCurrentWord()
        {
            if (pWords == null)
            {
                //LoadData();
                return null;
            }
            return pWords[currentIndex - 1];

        }

        public void NextWord()
        {
            if (pWords == null)
            {
                LoadData();
            }
            currentIndex = (currentIndex + 1) % (pWords.Count+1);
        }

        public int getCurrentIndex()
        {
            if (pWords == null)
            {
                return 0;
            }
            else if (currentIndex == 0)
            {
                currentIndex = 1;
            }
            return currentIndex;
        }

        public int getMax()
        {
            if (pWords == null)
            {
                return 0;
            }
            return pWords.Count;
        }

        public void PreWord()
        {
            if (pWords == null)
            {
                LoadData();
            }
            currentIndex = (currentIndex - 1) % pWords.Count;
        }

        public abstract void LoadData();

    }
}
