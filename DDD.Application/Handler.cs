namespace DDD.Application
{
    public partial class Handler
    {
        //TODO write all dependencies here as ctor parameter once
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
