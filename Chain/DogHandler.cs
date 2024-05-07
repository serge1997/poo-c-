namespace Poo.Chain;


using System;
using System.Collections.Generic;


class DogHandler : AbstractChain
{
    public DogHandler(object request)
    {
        this.Handle(request);
    }

    public override object Handle(object request)
    {
        if ( (request as string) != "MeatBall")
        {
            throw new ArgumentException(nameof(request), $"Food dont exist {request.ToString()}");
        }

        return base.Handle(request);
    }
}