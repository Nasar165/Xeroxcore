namespace Components.Logger.Interface
{
    public interface IExceptionHelper
    {
        string GetFormatedErrorMessage(bool logAsJson);
        IError GetFormatedErrorObject();
    }
}