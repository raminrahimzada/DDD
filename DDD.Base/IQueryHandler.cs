namespace DDD.Base
{
    public interface IQueryHandler<in TQuery, TResponse>
      where TQuery:IQuery<TResponse>
    {
    }
   
}