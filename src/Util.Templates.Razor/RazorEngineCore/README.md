# RazorEngineCore
.NET5 Razor Template Engine. No legacy code.
* .NET 5.0
* .NET Standard 2.0
* .NET Framework 4.7.2
* Windows / Linux
* Publish as single file supported

[![NuGet](https://img.shields.io/nuget/dt/RazorEngineCore.svg?style=flat-square)](https://www.nuget.org/packages/RazorEngineCore)
[![NuGet](https://img.shields.io/nuget/v/RazorEngineCore.svg?style=flat-square)](https://www.nuget.org/packages/RazorEngineCore)
[![Gitter](https://img.shields.io/gitter/room/RazorEngineCore/community?style=flat-square)](https://gitter.im/RazorEngineCore/community?utm_source=badge&utm_medium=badge&utm_content=badge)



Every single star makes maintainer happy! ⭐

## NuGet
```
Install-Package RazorEngineCore
```

## Articles
* [CodeProject: Building String Razor Template Engine with Bare Hands](https://www.codeproject.com/Articles/5260233/Building-String-Razor-Template-Engine-with-Bare-Ha)

## Wiki
* [Strongly typed model](https://github.com/adoconnection/RazorEngineCore/wiki/Strongly-typed-model)
* [@Include and @Layout](https://github.com/adoconnection/RazorEngineCore/wiki/@Include-and-@Layout)
* [@Raw](https://github.com/adoconnection/RazorEngineCore/wiki/@Raw)
* [@Inject and referencing other assemblies](https://github.com/adoconnection/RazorEngineCore/wiki/@Inject-and-referencing-other-assemblies)
* [Switch from RazorEngine cshtml templates](https://github.com/adoconnection/RazorEngineCore/wiki/Switch-from-RazorEngine-cshtml-templates)
* [Azure Functions FileNotFoundException workaround](https://github.com/adoconnection/RazorEngineCore/wiki/Azure-Functions-FileNotFoundException-workaround)
* [@Html implementation example](https://github.com/adoconnection/RazorEngineCore/wiki/@Html-implementation-example)

## Extensions
* [wdcossey/RazorEngineCore.Extensions](https://github.com/wdcossey/RazorEngineCore.Extensions)

## Examples

#### Basic usage
```cs
IRazorEngine razorEngine = new RazorEngine();
IRazorEngineCompiledTemplate template = razorEngine.Compile("Hello @Model.Name");

string result = template.Run(new
{
    Name = "Alexander"
});

Console.WriteLine(result);
```

#### Strongly typed model
```cs
IRazorEngine razorEngine = new RazorEngine();
string templateText = "Hello @Model.Name";

// yeah, heavy definition
IRazorEngineCompiledTemplate<RazorEngineTemplateBase<TestModel>> template = razorEngine.Compile<RazorEngineTemplateBase<TestModel>>(templateText);

string result = template.Run(instance =>
{
    instance.Model = new TestModel()
    {
        Name = "Hello",
        Items = new[] {3, 1, 2}
    };
});

Console.WriteLine(result);
```

#### Save / Load compiled templates
Most expensive task is to compile template, you should not compile template every time you need to run it
```cs
IRazorEngine razorEngine = new RazorEngine();
IRazorEngineCompiledTemplate template = razorEngine.Compile("Hello @Model.Name");

// save to file
template.SaveToFile("myTemplate.dll");

//save to stream
MemoryStream memoryStream = new MemoryStream();
template.SaveToStream(memoryStream);
```

```cs
IRazorEngineCompiledTemplate template1 = RazorEngineCompiledTemplate.LoadFromFile("myTemplate.dll");
IRazorEngineCompiledTemplate template2 = RazorEngineCompiledTemplate.LoadFromStream(myStream);
```

```cs
IRazorEngineCompiledTemplate<MyBase> template1 = RazorEngineCompiledTemplate<MyBase>.LoadFromFile<MyBase>("myTemplate.dll");
IRazorEngineCompiledTemplate<MyBase> template2 = RazorEngineCompiledTemplate<MyBase>.LoadFromStream<MyBase>(myStream);
```

#### Caching
RazorEngineCore is not responsible for caching. Each team and project has their own caching frameworks and conventions therefore making it impossible to have builtin solution for all possible needs. 

If you dont have one, use following static ConcurrentDictionary example as a simplest thread safe solution.

```cs
private static ConcurrentDictionary<int, IRazorEngineCompiledTemplate> TemplateCache = new ConcurrentDictionary<int, IRazorEngineCompiledTemplate>();
```

```cs
private string RenderTemplate(string template, object model)
{
    int hashCode = template.GetHashCode();

    IRazorEngineCompiledTemplate compiledTemplate = TemplateCache.GetOrAdd(hashCode, i =>
    {
        RazorEngine razorEngine = new RazorEngine();
        return razorEngine.Compile(Content);
    });

    return compiledTemplate.Run(model);
}
```

#### Template functions
ASP.NET Core way of defining template functions:
```
<area>
    @{ RecursionTest(3); }
</area>

@{
  void RecursionTest(int level)
  {
	if (level <= 0)
	{
		return;
	}

	<div>LEVEL: @level</div>
	@{ RecursionTest(level - 1); }
  }
}
```
output:
```
<div>LEVEL: 3</div>
<div>LEVEL: 2</div>
<div>LEVEL: 1</div>
```

#### Helpers and custom members
```cs
string content = @"Hello @A, @B, @Decorator(123)";

IRazorEngine razorEngine = new RazorEngine();
IRazorEngineCompiledTemplate<CustomModel> template = razorEngine.Compile<CustomModel>(content);

string result = template.Run(instance =>
{
    instance.A = 10;
    instance.B = "Alex";
});

Console.WriteLine(result);
```
```cs
public class CustomModel : RazorEngineTemplateBase
{
    public int A { get; set; }
    public string B { get; set; }

    public string Decorator(object value)
    {
        return "-=" + value + "=-";
    }
}
```

#### Referencing assemblies
Keep your templates as simple as possible, if you need to inject "unusual" assemblies most likely you are doing it wrong.
Writing `@using System.IO` in template will not reference System.IO assembly, use builder to manually reference it.

```cs
IRazorEngine razorEngine = new RazorEngine();
IRazorEngineCompiledTemplate compiledTemplate = razorEngine.Compile(templateText, builder =>
{
    builder.AddAssemblyReferenceByName("System.Security"); // by name
    builder.AddAssemblyReference(typeof(System.IO.File)); // by type
    builder.AddAssemblyReference(Assembly.Load("source")); // by reference
});

string result = compiledTemplate.Run(new { name = "Hello" });
```


#### Credits
This package is inspired by [Simon Mourier SO post](https://stackoverflow.com/a/47756437/267736)


#### Changelog
* 2021.3.1
	* fixed NET5 publish as single file (thanks [@jddj007-hydra](https://github.com/jddj007-hydra))
	* AnonymousTypeWrapper array handling fix
	* System.Collections referenced by default
	* Microsoft.AspNetCore.Razor.Language 3.1.8 -> 5.0.3
	* Microsoft.CodeAnalysis.CSharp 3.7.0 -> 3.8.0
* 2020.10.1
	* Linux fix for #34
	* Microsoft.AspNetCore.Razor.Language 3.1.5 -> 3.1.8
	* Microsoft.CodeAnalysis.CSharp 3.6.0 -> 3.7.0
* 2020.9.1
	* .NET 4.7.2 support (thanks [@krmr](https://github.com/krmr))
* 2020.6.1
	* Reference assemblies by Metadata (thanks [@Merlin04](https://github.com/Merlin04))
	* Expose GeneratedCode in RazorEngineCompilationException
	* Microsoft.AspNetCore.Razor.Language 3.1.4 -> 3.1.5
* 2020.5.2
	* IRazorEngineTemplate interface 
	* RazorEngineTemplateBase methods go virtual
* 2020.5.1
	* Async methods (thanks [@wdcossey](https://github.com/wdcossey))
	* Microsoft.AspNetCore.Razor.Language 3.1.1 -> 3.1.4
	* Microsoft.CodeAnalysis.CSharp 3.4.0 -> 3.6.0
* 2020.3.3
	* Model with generic type arguments compiling fix
* 2020.3.2
	* External assembly referencing
	* Linq included by default
* 2020.3.1
	* In attribute rendering fix #4
* 2020.2.4
	* Null values in model correct handling
	* Null model fix
	* Netstandard2 insted of netcore3.1
* 2020.2.3
	* Html attribute rendering fix
	* Html attribute rendering tests
