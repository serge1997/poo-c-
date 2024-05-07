namespace Poo.Chain;


using System;
using System.Collections.Generic;


public interface IChaine
{
    IChaine SetNext(IChaine nextHandle);

    object Handle(object request);
}
