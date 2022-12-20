namespace ConsumeMessages.Model
{
    public interface IHandleMessages
    {
        public void Handle(string message, ISendMessages sender);
    }
}
