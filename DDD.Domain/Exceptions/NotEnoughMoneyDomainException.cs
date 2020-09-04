namespace DDD.Domain.Exceptions
{
    public class NotEnoughMoneyDomainException:DomainException
    {
        public override string ErrorCode => "NOT_ENOUGH_MONEY";
    }
}
