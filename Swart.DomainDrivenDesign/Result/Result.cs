namespace Swart.DomainDrivenDesign
{
    public class Result<TReturn> : VoidResult, IResult<TReturn>
    {
        public TReturn Return { get; set; }
    }
}
