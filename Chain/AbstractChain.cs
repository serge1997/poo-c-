namespace Poo.Chain;

using System;
using System.Collections.Generic;

abstract class AbstractChain : IChaine
{

    private IChaine _nextHandle;

    public IChaine SetNext(IChaine nextHandle)
    {
        this._nextHandle = nextHandle;


        return nextHandle;
    }

    public virtual object Handle(object request)
    {
        if ( this._nextHandle != null )
        {
            return this._nextHandle.Handle(request);
        }
        return null;
    }
}
