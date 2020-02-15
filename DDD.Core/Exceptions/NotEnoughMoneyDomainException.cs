namespace DDD.Core.Exceptions
{
    public class NotEnoughMoneyDomainException:DomainException
    {
        public override string ErrorCode => "NOT_ENOUGH_MONEY";
    }
}
