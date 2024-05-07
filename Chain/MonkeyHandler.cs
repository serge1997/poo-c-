namespace Poo.Chain;

class MonkeyHandler : AbstractChain
{

    public MonkeyHandler(object request)
    {
        this.Handle(request);
    }

    public override object Handle(object request)
    {
        if ((request as string) != "Banana")
        {
            throw new ArgumentException(nameof(request), $"Food dont exist {request.ToString()}");
        }

        return base.Handle(request);
    }
}
