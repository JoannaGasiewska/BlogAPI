namespace BlogAPI.BusinessLogic
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResult>
        where TCommand : ICommand
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}
