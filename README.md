# libapicsharp

Diggernaut Official API Library for C#

This repo still in development.

#### install:

PM> Install-Package DiggernautAPI

#### usage:
```c#
var api = new API("f98c1dc37033a8b1755f839685062cf411112222");
  try
  {
      Console.WriteLine(api.GetDigger(98).last_session.GetData());
      //direct with session id
      Console.WriteLine(api.GetData(98));
  }
  catch(Exception e)
  {
      Console.WriteLine(e);
  }
      Console.ReadKey();
```
License MIT.
