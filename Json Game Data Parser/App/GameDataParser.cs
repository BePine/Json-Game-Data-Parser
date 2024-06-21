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
            _userInteraction.ShowInput(usersInput);
            Console.ReadKey();

        }
    }
    public interface IUserInteraction
    {
        public IEnumerable<GameData> ReadInput();
        public void ShowInput(IEnumerable<GameData> gamesData);
    }

    public class UserInteraction : IUserInteraction
    {
        public IFileInteraction _fileInteraction { get; }
        public UserInteraction(IFileInteraction fileInteraction)
        {
            _fileInteraction = fileInteraction;
        }
        public IEnumerable<GameData> ReadInput()
        {
            string usersInput = Console.ReadLine();

            bool isValid = _fileInteraction.Validate(usersInput);
            if (isValid)
            {
                var gamesData = _fileInteraction.Read(usersInput);
                return gamesData;
            }
            return null;
        }
        public void ShowInput(IEnumerable<GameData> gamesData)
        {
            for (int i = 0; i < gamesData.Count(); i++)
            {
                var index = i + 1;
                Console.WriteLine($"{index}. {gamesData.ElementAt(i).Title}, " +
                    $" release: {gamesData.ElementAt(i).ReleaseYear}, rating: {gamesData.ElementAt(i).Rating}");
            }
        }
    }
    public interface IFileInteraction
    {
        public bool Validate(string input);
        public IEnumerable<GameData> Read(string usersInput);
    }

    public class FileInteraction : IFileInteraction
    {
        public bool Validate(string input)
        {
            if (input != null)
            {
                if (File.Exists(input))
                {
                    return true;
                }
            }
            return false;

        }
        public IEnumerable<GameData> Read(string usersInput)
        {
            IEnumerable<GameData> gamesData = new List<GameData>();

            var fileContents = File.ReadAllText(usersInput);
            gamesData = JsonSerializer.Deserialize<List<GameData>>(fileContents);
            return gamesData;

        }
    }
    public interface IGameData
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; } 
    }

    public class GameData : IGameData
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
    }

    
}
