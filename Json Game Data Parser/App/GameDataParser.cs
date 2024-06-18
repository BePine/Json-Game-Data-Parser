using System.Text.Json;
namespace Json_Game_Data_Parser.App
{

    public class GameDataParser
    {

        public IUserInteraction _userInteraction { get; }
        public GameDataParser(IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
        }
        public void run()
        {
            Console.WriteLine("enter the name of the file you want to read:");
            var usersInput = _userInteraction.ReadInput();
            _userInteraction.ShowInput();
            Console.ReadKey();

        }
    }
    public interface IUserInteraction
    {
        public string ReadInput();
        public void ShowInput();
    }

    public class UserInteraction : IUserInteraction
    {
        public IFileInteraction _fileInteraction { get; }
        public UserInteraction(IFileInteraction fileInteraction)
        {
            _fileInteraction = fileInteraction;
        }
        public string ReadInput()
        {
            var usersInput = Console.ReadLine();

            bool isValid = _fileInteraction.Validate(usersInput);
            if (isValid)
            {
                _fileInteraction.Read(usersInput);
            }
            else if(usersInput is null)
            {
                
            }
            return usersInput;
        }
        public void ShowInput()
        {

        }
    }
    public interface IFileInteraction
    {
        public bool Validate(string input);
        public void Read(string usersInput);
    }

    public class FileInteraction : IFileInteraction
    {
        public bool Validate(string input)
        {
            if (input is not null)
            {
                if (File.Exists(input))
                {
                    return true;
                }
            }
            return false;

        }
        public void Read(string usersInput)
        {
            
        }
    }

    
}
