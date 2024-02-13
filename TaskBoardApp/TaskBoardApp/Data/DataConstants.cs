namespace TaskBoardApp.Data
{
    public static class DataConstants
    {
        public static class Task
        {
            public const int TitleMaxLenght = 70; 
            public const int TitleMinLenght = 5;
            public const int DescriptionMinLenght = 10;
            public const int DescriptionMaxLenght = 100;
        }

        public static class Board 
        {
            public const int NameMaxLenght = 30;
            public const int NameMinLenght = 3;
            public const string DisplayNameBoard = "Board";
        }

        public static class ErrorMessages
        {
            public const string ErrorMessage = "This {0} field must be beetween {2} and {1} characters long";
            public const string BoardDoesntExist = "The board doesn't exist";
        }
    }
}
