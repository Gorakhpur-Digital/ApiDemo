namespace ApiDemo.Model.Message
{
    public interface IDbResponse
    {
        string Message { get; set; }
        string Status { get; set; }
    }

    public enum DbStatus
    {
        pending,
        fail,
        success
    }

    public class Response : IDbResponse
    {
        public virtual string Status { get; set; } = DbStatus.pending.ToString();
        public virtual string Message { get; set; } = "Db response message not found";
    }
}
