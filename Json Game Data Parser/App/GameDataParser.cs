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

    public class UserInteraction : IUserInteraction
    {
        public IValidationService _validationService { get; }
        public UserInteraction(IValidationService validationService)
        {
            _validationService = validationService;
        }
        public string ReadInput()
        {
            var usersInput = Console.ReadLine();

            _validationService.Validate(usersInput);

            return usersInput;
        }
        public void ShowInput()
        {

        }
    }
    public interface IValidationService
    {
        public void Validate(string input);
    }

    public class ValidationService : IValidationService
    {
        public void Validate(string input)
        {
            if (File.Exists(input))
            {
                
            }
            
            
        }
    }

    

    public interface IUserInteraction
    {
        public string ReadInput();
        public void ShowInput();
    }
}
