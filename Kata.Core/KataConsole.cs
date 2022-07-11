namespace Kata.Core
{
    public class KataConsole
    {
        private readonly IFormProvider _formProvider;

        public KataConsole(IFormProvider formProvider)
        {
            _formProvider = formProvider;
        }

        public void Write(char letterOfTheAlphabet)
        {
            if (!char.IsLetter(letterOfTheAlphabet))
            {
                throw new ArgumentException($"{nameof(letterOfTheAlphabet)} is required");
            }

            string diamondFormContents = _formProvider.GenerateForm(letterOfTheAlphabet);

            Console.Write(diamondFormContents);
        }
    }
}
