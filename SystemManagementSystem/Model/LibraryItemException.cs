
namespace SystemManagementSystem.LibraryCatalog
{
    [Serializable]
    internal class LibraryItemException : Exception
    {
        public LibraryItemException()
        {
        }

        public LibraryItemException(string? message) : base(message)
        {
        }

        public LibraryItemException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}